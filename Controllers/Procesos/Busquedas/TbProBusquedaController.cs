using ConexionSql.Data;
using ConexionSql.Models.Procesos;
using ConexionSql.Models.Procesos.Controles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using ConexionSql.Models.Procesos.Controles;

namespace ConexionSql.Controllers.Procesos.Busquedas
{
    public class TbProBusquedaController : Controller
    {
        private readonly ConexionSqlContext _context;

        public TbProBusquedaController(ConexionSqlContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> VerProceso(int tbProId)
        {
            if (tbProId <= 0)
                return NotFound("❌ ID de proceso inválido.");

            var cabecera = await _context.TbPro
                .FirstOrDefaultAsync(p => p.TbProId == tbProId);

            if (cabecera == null)
                return NotFound("❌ No se encontró la cabecera del proceso.");

            var detalles = await _context.TbProDet
                .Where(d => d.TbProId == tbProId)
                .OrderByDescending(d => d.TbProDetId)
                .Select(d => new TbProDetDto
                {
                    TB_PRO_DET_ID = d.TbProDetId,
                    TB_PRO_ID = d.TbProId,
                    TB_PRO_DET_REC_DET_ID = d.TbProDetRecDetId ?? 0,
                    TB_PRO_DET_REC_DET_MAT_DEN = d.TbProDetRecDetMatDen,
                    TB_PRO_DET_CANT = d.TbProDetCant,
                    TB_PRO_DET_PC_USR = d.TbProDetPcUsr,
                    TB_PRO_FEC = d.TbProFec
                })
                .ToListAsync();

            var dto = new TbProDetFormDto
            {
                Cabecera = cabecera,
                Detalle = new TbProDetDto
                {
                    TB_PRO_ID = tbProId
                },
                Detalles = detalles
            };

            return View("~/Views/Procesos/Busquedas/ConsultaProceso.cshtml", dto);
        }
        
        //trae resultados para el control
        [HttpGet]
        public IActionResult ObtenerResultados()
        {
            var lista = _context.TbProPteRes
                .Where(x => x.TbProPteResOcu == false)
                .Select(x => new TbProPteResDto
                {
                    TB_PRO_PTE_RES_ID = x.TbProPteResId,
                    TB_PRO_PTE_RES_DEN = x.TbProPteResDen,
                    TB_PRO_PTE_RES_OCU = x.TbProPteResOcu
                })
                .ToList();

            return Json(new { success = true, data = lista });
        }

        [HttpPost]
        public IActionResult ActualizarResultadoControl([FromBody] TbProDetPteResultadoDto dto)
        {
            try
            {
                if (dto == null || dto.TB_PRO_DET_PTE_ID <= 0 || dto.TB_PRO_PTE_RES_ID <= 0)
                {
                    return Json(new { success = false, mensaje = "Datos inválidos." });
                }

                string estadoDen = "EN PROCESO";

                // 👉 NUEVO: detectar resultados 3 o 6
                bool dispararReproceso = dto.TB_PRO_PTE_RES_ID == 3 || dto.TB_PRO_PTE_RES_ID == 6;

                using (var conn = _context.Database.GetDbConnection())
                {
                    conn.Open();

                    int tbProId = 0;

                    // 👉 1. Actualizar el control seleccionado
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"
            UPDATE TB_PRO_DET_PTE
            SET TB_PRO_PTE_RES_ID = @resId,
                TB_PRO_PTE_RES_DEN = @resDen
            WHERE TB_PRO_DET_PTE_ID = @id
        ";

                        var p1 = cmd.CreateParameter();
                        p1.ParameterName = "@resId";
                        p1.Value = dto.TB_PRO_PTE_RES_ID;
                        cmd.Parameters.Add(p1);

                        var p2 = cmd.CreateParameter();
                        p2.ParameterName = "@resDen";
                        p2.Value = dto.TB_PRO_PTE_RES_DEN ?? "";
                        cmd.Parameters.Add(p2);

                        var p3 = cmd.CreateParameter();
                        p3.ParameterName = "@id";
                        p3.Value = dto.TB_PRO_DET_PTE_ID;
                        cmd.Parameters.Add(p3);

                        cmd.ExecuteNonQuery();
                    }

                    // 👉 2. Obtener TB_PRO_ID del control actualizado
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"
            SELECT TB_PRO_ID
            FROM TB_PRO_DET_PTE
            WHERE TB_PRO_DET_PTE_ID = @id
        ";

                        var p = cmd.CreateParameter();
                        p.ParameterName = "@id";
                        p.Value = dto.TB_PRO_DET_PTE_ID;
                        cmd.Parameters.Add(p);

                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            tbProId = Convert.ToInt32(result);
                        }
                    }

                    // 👉 3. Contar cuantos controles tiene el proceso
                    int totalControles = 0;

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"
            SELECT COUNT(*)
            FROM TB_PRO_DET_PTE
            WHERE TB_PRO_ID = @tbProId
        ";

                        var p = cmd.CreateParameter();
                        p.ParameterName = "@tbProId";
                        p.Value = tbProId;
                        cmd.Parameters.Add(p);

                        totalControles = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // 👉 4. Si no hay controles, no tocar cabecera
                    if (totalControles == 0)
                    {
                        return Json(new
                        {
                            success = true,
                            mensaje = "Resultado actualizado correctamente.",
                            estadoDen = "EN PROCESO",
                            dispararReproceso = dispararReproceso,
                            mensajeReproceso = dispararReproceso ? "⚠️ Resultado 3 o 6 detectado. Acá después abrimos el modal de reproceso." : ""
                        });
                    }

                    // 👉 5. Verificar si existe algun control sin resultado o fuera de 2,5,7
                    int controlesPendientesOFueraDeFinalizado = 0;

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"
                SELECT COUNT(*)
                FROM TB_PRO_DET_PTE
                WHERE TB_PRO_ID = @tbProId
                  AND (
                        TB_PRO_PTE_RES_ID IS NULL
                        OR TB_PRO_PTE_RES_ID NOT IN (2,5,7)
                      )
                ";

                        var p = cmd.CreateParameter();
                        p.ParameterName = "@tbProId";
                        p.Value = tbProId;
                        cmd.Parameters.Add(p);

                        controlesPendientesOFueraDeFinalizado = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // 👉 6. Si hay al menos uno sin resultado o fuera de 2,5,7, no tocar cabecera
                    if (controlesPendientesOFueraDeFinalizado > 0)
                    {
                        return Json(new
                        {
                            success = true,
                            mensaje = "Resultado actualizado correctamente.",
                            estadoDen = "EN PROCESO",
                            dispararReproceso = dispararReproceso,
                            mensajeReproceso = dispararReproceso ? "⚠️ Resultado 3 o 6 detectado. Acá después abrimos el modal de reproceso." : ""
                        });
                    }

                    // 👉 7. Solo si todos estan en 2,5,7, finalizar cabecera
                    int estadoId = 2;
                    estadoDen = "FINALIZADO";

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"
            UPDATE TB_PRO
            SET IB_PRO_EST_ID = @estadoId,
                IB_PRO_EST_DEN = @estadoDen
            WHERE TB_PRO_ID = @tbProId
        ";

                        var p1 = cmd.CreateParameter();
                        p1.ParameterName = "@estadoId";
                        p1.Value = estadoId;
                        cmd.Parameters.Add(p1);

                        var p2 = cmd.CreateParameter();
                        p2.ParameterName = "@estadoDen";
                        p2.Value = estadoDen;
                        cmd.Parameters.Add(p2);

                        var p3 = cmd.CreateParameter();
                        p3.ParameterName = "@tbProId";
                        p3.Value = tbProId;
                        cmd.Parameters.Add(p3);

                        cmd.ExecuteNonQuery();
                    }
                }

                return Json(new
                {
                    success = true,
                    mensaje = "Resultado actualizado correctamente.",
                    estadoDen = estadoDen,
                    dispararReproceso = dispararReproceso,
                    mensajeReproceso = dispararReproceso ? "⚠️ Resultado 3 o 6 detectado. Acá después abrimos el modal de reproceso." : ""
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    mensaje = ex.Message
                });
            }
        }
    }
}