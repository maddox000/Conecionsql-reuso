using ConexionSql.Data;
using ConexionSql.Models.Lavado;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConexionSql.Models.Lavado.Controles;

namespace ConexionSql.Controllers.Lavado.Busquedas
{
    public class TbProLavBusquedaController : Controller
    {
        private readonly ConexionSqlContext _context;

        public TbProLavBusquedaController(ConexionSqlContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> ConsultaLavado(int tbProLavId)
        {
            if (tbProLavId <= 0)
                return NotFound("❌ ID de lavado inválido.");

            var cabecera = await _context.TbProLav
                .FirstOrDefaultAsync(x => x.TbProLavId == tbProLavId);

            if (cabecera == null)
                return NotFound("❌ No se encontró la cabecera del lavado.");

            var detalles = await _context.TbProLavDet
                .Where(d => d.TB_PRO_LAV_DET_PRO_LAV_ID == tbProLavId)
                .OrderByDescending(d => d.TB_PRO_LAV_DET_ID)
                .Select(d => new TbProLavDetDto
                {
                    TB_PRO_LAV_DET_ID = d.TB_PRO_LAV_DET_ID,

                    TB_PRO_LAV_ID = d.TB_PRO_LAV_DET_PRO_LAV_ID ?? 0,

                    TB_PRO_LAV_DET_REC_DET_ID = d.TB_PRO_LAV_DET_REC_DET_ID ?? 0,

                    TB_PRO_LAV_DET_REC_DET_MAT_DEN = d.TB_PRO_LAV_DET_IB_MAT_DEN,

                    TB_REC_SEC_DES_DEN = d.TB_PRO_LAV_DET_SEC_DES_DEN,

                    TB_PRO_LAV_DET_REC_DET_REU_ID = d.TB_PRO_LAV_DET_REU_ID,

                    TB_PRO_LAV_DET_REC_DET_CANT = d.TB_PRO_LAV_DET_REC_DET_CANT,

                    TB_PRO_LAV_DET_REC_DET_PRO_TOT = d.TB_PRO_LAV_DET_TOT,

                    TB_PRO_LAV_DET_REC_DET_PRO_STOCK = d.TB_PRO_LAV_DET_STOCK,

                    TB_PRO_LAV_DET_CANT = d.TB_PRO_LAV_DET_CANT,

                    TB_PRO_LAV_FEC = d.TB_PRO_LAV_DET_PRO_LAV_FEC
                })
                .ToListAsync();

            var dto = new TbProLavDetFormDto
            {
                Cabecera = cabecera,

                Detalle = new TbProLavDetDto
                {
                    TB_PRO_LAV_ID = tbProLavId
                },

                Detalles = detalles
            };

            return View("~/Views/Lavado/Busquedas/ConsultaLavado.cshtml", dto);
        }

        [HttpGet]
        public IActionResult ObtenerResultados()
        {
            var lista = _context.TbProPteRes
                .Where(x => x.TbProPteResOcu == false)
                .Select(x => new
                {
                    TB_PRO_PTE_RES_ID = x.TbProPteResId,
                    TB_PRO_PTE_RES_DEN = x.TbProPteResDen,
                    TB_PRO_PTE_RES_OCU = x.TbProPteResOcu
                })
                .ToList();

            return Json(new { success = true, data = lista });
        }

        [HttpPost]
        public IActionResult ActualizarResultadoControl([FromBody] TbProLavDetPteResultadoDto dto)
        {
            try
            {
                if (dto == null || dto.TB_PRO_LAV_DET_PTE_ID <= 0 || dto.TB_PRO_PTE_RES_ID <= 0)
                    return Json(new { success = false, mensaje = "Datos inválidos." });

                string estadoDen = "EN PROCESO";

                bool dispararReproceso =
                    dto.TB_PRO_PTE_RES_ID == 3 || dto.TB_PRO_PTE_RES_ID == 6;

                using (var conn = _context.Database.GetDbConnection())
                {
                    conn.Open();

                    int tbProLavId = 0;

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"
                    UPDATE TB_PRO_LAV_DET_PTE
                    SET TB_PRO_LAV_PTE_RES_ID = @resId,
                        TB_PRO_LAV_PTE_RES_DEN = @resDen
                    WHERE TB_PRO_LAV_DET_PTE_ID = @id
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
                        p3.Value = dto.TB_PRO_LAV_DET_PTE_ID;
                        cmd.Parameters.Add(p3);

                        cmd.ExecuteNonQuery();
                    }

                    using (var cmd = conn.CreateCommand())
                            {
                                cmd.CommandText = @"
                            SELECT TB_PRO_LAV_ID
                            FROM TB_PRO_LAV_DET_PTE
                            WHERE TB_PRO_LAV_DET_PTE_ID = @id
                        ";

                        var p = cmd.CreateParameter();
                        p.ParameterName = "@id";
                        p.Value = dto.TB_PRO_LAV_DET_PTE_ID;
                        cmd.Parameters.Add(p);

                        var result = cmd.ExecuteScalar();

                        if (result != null)
                            tbProLavId = Convert.ToInt32(result);
                    }

                    int pendientes = 0;

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"
                    SELECT COUNT(*)
                    FROM TB_PRO_LAV_DET_PTE
                    WHERE TB_PRO_LAV_ID = @tbProLavId
                      AND (
                            TB_PRO_LAV_PTE_RES_ID IS NULL
                            OR TB_PRO_LAV_PTE_RES_ID NOT IN (2,5,7)
                          )
                ";

                        var p = cmd.CreateParameter();
                        p.ParameterName = "@tbProLavId";
                        p.Value = tbProLavId;
                        cmd.Parameters.Add(p);

                        pendientes = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    if (pendientes == 0)
                    {
                        estadoDen = "FINALIZADO";

                        using (var cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = @"
                        UPDATE TB_PRO_LAV
                        SET TB_PRO_LAV_EST_ID = 2,
                            TB_PRO_LAV_EST_DEN = @estadoDen
                        WHERE TB_PRO_LAV_ID = @tbProLavId
                    ";

                            var p1 = cmd.CreateParameter();
                            p1.ParameterName = "@estadoDen";
                            p1.Value = estadoDen;
                            cmd.Parameters.Add(p1);

                            var p2 = cmd.CreateParameter();
                            p2.ParameterName = "@tbProLavId";
                            p2.Value = tbProLavId;
                            cmd.Parameters.Add(p2);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                return Json(new
                {
                    success = true,
                    mensaje = "Resultado actualizado correctamente.",
                    estadoDen = estadoDen,
                    dispararReproceso = dispararReproceso,
                    mensajeReproceso = dispararReproceso
                        ? "⚠️ Resultado detectado. El lavado requiere reproceso."
                        : ""
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

        [HttpPost]
        public async Task<IActionResult> ActualizarChecksLiberacion([FromBody] TbProLavLiberacionChecksDto dto)
        {
            if (dto == null || dto.TbProLavId <= 0)
            {
                return Json(new
                {
                    success = false,
                    mensaje = "Lavado inválido."
                });
            }

            var lavado = await _context.TbProLav
                .FirstOrDefaultAsync(x => x.TbProLavId == dto.TbProLavId);

            if (lavado == null)
            {
                return Json(new
                {
                    success = false,
                    mensaje = "No se encontró el lavado."
                });
            }

            lavado.TbProLavLpaCk1 = dto.TbProLavLpaCk1;
            lavado.TbProLavLpaCk2 = dto.TbProLavLpaCk2;
            lavado.TbProLavLpaCk3 = dto.TbProLavLpaCk3;

            if (dto.LiberarLavado)
            {
                lavado.TbProLavEstId = 2;
                lavado.TbProLavEstDen = "FINALIZADO";
            }

            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true,
                mensaje = "Liberación guardada correctamente.",
                estadoDen = lavado.TbProLavEstDen
            });
        }
    }
}