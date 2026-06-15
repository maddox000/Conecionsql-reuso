using ConexionSql.Data;
using ConexionSql.Models.Lavado;
using ConexionSql.Models.Reuso;
using ConexionSql.Utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ConexionSql.Controllers.Lavado
{
    public class TbProLavDetController : Controller
    {
        private readonly ConexionSqlContext _context;

        public TbProLavDetController(ConexionSqlContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> SubFormulario(int id)
        {
            Console.WriteLine($"📥 SubFormulario LAVADO INVOCADO con tbProLavId = {id}");

            var cabecera = await _context.TbProLav.FirstOrDefaultAsync(p => p.TbProLavId == id);
            if (cabecera == null)
                return NotFound("❌ No se encontró la cabecera del lavado.");

            var dto = new TbProLavDetFormDto
            {
                Cabecera = cabecera,
                Detalle = new TbProLavDetDto
                {
                    TB_PRO_LAV_ID = id
                },
                Detalles = await _context.TbProLavDet
                    .Where(d => d.TB_PRO_LAV_DET_PRO_LAV_ID == id)
                    .OrderByDescending(d => d.TB_PRO_LAV_DET_ID)
                    .Select(d => new TbProLavDetDto
                    {
                        TB_PRO_LAV_DET_ID = d.TB_PRO_LAV_DET_ID,
                        TB_PRO_LAV_ID = d.TB_PRO_LAV_DET_PRO_LAV_ID,
                        TB_PRO_LAV_DET_REC_DET_ID = d.TB_PRO_LAV_DET_REC_DET_ID ?? 0,
                        TB_PRO_LAV_DET_REC_DET_MAT_DEN = d.TB_PRO_LAV_DET_IB_MAT_DEN,
                        TB_PRO_LAV_DET_CANT = d.TB_PRO_LAV_DET_CANT,
                        TB_PRO_LAV_DET_CANT_ELIM = d.TB_PRO_LAV_DET_CANT_ELIM,
                        TB_PRO_LAV_DET_DAT = d.TB_PRO_LAV_DET_DAT,
                        TB_PRO_LAV_DET_PC_USR = d.TB_PRO_LAV_DET_PC_USR,
                        TB_PRO_LAV_FEC = d.TB_PRO_LAV_DET_PRO_LAV_FEC
                    })
                    .ToListAsync()
            };

            return View("~/Views/Lavado/_SubFormulario.cshtml", dto);
        }

        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] TbProLavDetDto dto)
        {
            Console.WriteLine("🔄 TbProLavDet.Insertar fue invocado");

            if (dto == null || dto.TB_PRO_LAV_ID <= 0)
                return Json(new { success = false, mensaje = "❌ Datos incompletos." });

            if (dto.TB_PRO_LAV_DET_REC_DET_ID == 0)
                return Json(new { success = false, mensaje = "❌ Debe ingresar una etiqueta válida." });

            var recDet = await _context.TbRecDet
                .FirstOrDefaultAsync(r => r.TbRecDetId == dto.TB_PRO_LAV_DET_REC_DET_ID);


            if (recDet == null)
                return Json(new { success = false, mensaje = "❌ Etiqueta no encontrada." });

            int stock = recDet.TbRecDetLavStock ?? 0;
            int cantidad = dto.TB_PRO_LAV_DET_CANT ?? 0;

            if (cantidad <= 0 || cantidad > stock)
            {
                return Json(new { success = false, mensaje = $"❌ Stock insuficiente. Disponible: {stock}" });
            }

            


            // ✅ Descontar y acumular stock
            recDet.TbRecDetLavStock = stock - cantidad;
            recDet.TbRecDetLavTot = (recDet.TbRecDetLavTot ?? 0) + cantidad;
            recDet.TbRecDetEmpStock = (recDet.TbRecDetEmpStock ?? 0) + cantidad;
            recDet.TbRecDetEstIngId = 23;
            recDet.TbRecDetEstIngDen = "CE PROCESO LAVADO";

            var mat = await _context.IbMat
                .FirstOrDefaultAsync(x => x.IB_MAT_ID == recDet.TbRecDetMatId);

            var nuevo = new TbProLavDet
            {
                TB_PRO_LAV_DET_PRO_LAV_ID = dto.TB_PRO_LAV_ID ?? 0,
                TB_PRO_LAV_DET_REC_DET_ID = dto.TB_PRO_LAV_DET_REC_DET_ID,

                // MATERIAL → desde TB_REC_DET
                TB_PRO_LAV_DET_IB_MAT_ID = recDet.TbRecDetMatId,
                TB_PRO_LAV_DET_IB_MAT_PR = recDet.TbRecDetMatPr,
                TB_PRO_LAV_DET_IB_MAT_DEN = recDet.TbRecDetMatDen,

                // DESDE IB_MAT
                TB_PRO_LAV_DET_IB_MAT_MAR_ID = mat?.IB_MAT_MAR_ID,
                TB_PRO_LAV_DET_IB_MAT_MAR_DEN = mat?.IB_MAT_MAR_DEN,
                TB_PRO_LAV_DET_IB_MAT_MAR_CAT = mat?.IB_MAT_MAR_CAT,
                TB_PRO_LAV_DET_IB_MAT_PRI_OPC = mat?.IB_MAT_PRI_OPC ?? false,
                TB_PRO_LAV_DET_IB_MAT_CON_REG = mat?.IB_MAT_CON_UNID,
                TB_PRO_LAV_DET_IB_MAT_CON_ACT = mat?.IB_MAT_CON_ACT,

                // SECTOR
                TB_PRO_LAV_DET_SEC_DES_ID = recDet.TbRecSecDesId,
                TB_PRO_LAV_DET_SEC_DES_DEN = recDet.TbRecSecDesDen,

                // ORT
                TB_PRO_LAV_DET_ORT_ID = recDet.TbRecOrtId,
                TB_PRO_LAV_DET_ORT_DEN = recDet.TbRecOrtDen,
                TB_PRO_LAV_DET_ORT_PAC = recDet.TbRecDetPac,
                TB_PRO_LAV_DET_ORT_REM = recDet.TbRecDetRem,

                // OTROS
                TB_PRO_LAV_DET_PRO_ID = recDet.TbRecDetProId,
                TB_PRO_LAV_DET_REU_ID = recDet.TbRecDetReuId,

                // CANTIDADES / VOLUMEN / STOCK
                TB_PRO_LAV_DET_REC_DET_CANT = recDet.TbRecDetCant,
                TB_PRO_LAV_DET_REC_CANT = dto.TB_PRO_LAV_DET_CANT,
                TB_PRO_LAV_DET_VOL_MAT = recDet.IbMatVol,
                TB_PRO_LAV_DET_VOL_PRO = (recDet.IbMatVol ?? 0) * (dto.TB_PRO_LAV_DET_CANT ?? 0),
                TB_PRO_LAV_DET_STOCK = recDet.TbRecDetLavStock,
                TB_PRO_LAV_DET_TOT = recDet.TbRecDetLavTot,

                // CANTIDAD
                TB_PRO_LAV_DET_CANT = dto.TB_PRO_LAV_DET_CANT,

                // REPROCESO / ABORTADOS
                TB_PRO_LAV_DET_REPRO = false,
                TB_PRO_LAV_DET_NUM_1 = dto.TB_PRO_LAV_DET_CANT,
                TB_PRO_LAV_DET_NUM_2 = 0,
                TB_PRO_LAV_DET_NUM_3 = 0,

                // SISTEMA
                TB_PRO_LAV_DET_PC_LOG = Environment.MachineName,
                TB_PRO_LAV_DET_PC_USR = Environment.UserName,

                // FECHA Y HORA
                TB_PRO_LAV_DET_PRO_LAV_FEC = DateTime.Now,
                TB_PRO_LAV_DET_PRO_LAV_HOR = DateTime.Now,

                // ESTADO
                TB_PRO_LAV_DET_EST_ID = 2,
                TB_PRO_LAV_DET_EST_DEN = "PROCESADO"
            };

            _context.TbProLavDet.Add(nuevo);
            await _context.SaveChangesAsync();

            // =========================================================
            // VALIDAR Y PREPARAR ESTADO TB_REU PARA LAVADO
            // =========================================================
            TbReu? reusoActualizar = null;

            if (!string.IsNullOrWhiteSpace(recDet.TbRecDetReuId) && recDet.TbRecDetReuId != "1")
            {
                reusoActualizar = await _context.TbReu
                    .FirstOrDefaultAsync(x => x.TbReuIdForm == recDet.TbRecDetReuId);

                if (reusoActualizar == null)
                {
                    return Json(new
                    {
                        success = false,
                        mensaje = "❌ No se encontró el código de reuso asociado a la etiqueta."
                    });
                }

                int sectorReusoId = reusoActualizar.TbReuSecId ?? 0;
                int estadoActualReusoId = reusoActualizar.TbReuEstIngId ?? 0;

                // HMD
                if (sectorReusoId == 905)
                {
                    if (estadoActualReusoId != 12)
                    {
                        return Json(new
                        {
                            success = false,
                            mensaje = $"El código de reuso se encuentra en etapa {reusoActualizar.TbReuEstIngDen}. No corresponde a Lavado."
                        });
                    }

                    reusoActualizar.TbReuEstIngId = 23;
                    reusoActualizar.TbReuEstIngDen = "CE PROCESO LAVADO";
                    reusoActualizar.TbReuEstIngFec = DateTime.Now;
                }

                // CCV / Farmacia
                else if (sectorReusoId == 929 || sectorReusoId == 936)
                {
                    if (estadoActualReusoId != 17)
                    {
                        return Json(new
                        {
                            success = false,
                            mensaje = $"El código de reuso se encuentra en etapa {reusoActualizar.TbReuEstIngDen}. No corresponde a Lavado."
                        });
                    }

                    reusoActualizar.TbReuEstIngId = 18;
                    reusoActualizar.TbReuEstIngDen = "CE - Proceso de lavado";
                    reusoActualizar.TbReuEstIngFec = DateTime.Now;
                }
            }

            //termina estado de reuso

            var cabecera = await _context.TbProLav
            .FirstOrDefaultAsync(x => x.TbProLavId == dto.TB_PRO_LAV_ID);

            if (cabecera != null)
            {
                cabecera.TbProLavUpro = (cabecera.TbProLavUpro ?? 0) + (dto.TB_PRO_LAV_DET_CANT ?? 0);
                await _context.SaveChangesAsync();
            }

            var detalles = await _context.TbProLavDet
                .Where(d => d.TB_PRO_LAV_DET_PRO_LAV_ID == dto.TB_PRO_LAV_ID)
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

                    TB_PRO_LAV_DET_EST_ID = d.TB_PRO_LAV_DET_EST_ID,
                    TB_PRO_LAV_DET_EST_DEN = d.TB_PRO_LAV_DET_EST_DEN,

                    TB_PRO_LAV_DET_CANT = d.TB_PRO_LAV_DET_CANT,
                    TB_PRO_LAV_DET_CANT_ELIM = d.TB_PRO_LAV_DET_CANT_ELIM,
                    TB_PRO_LAV_DET_DAT = d.TB_PRO_LAV_DET_DAT
                })
                .ToListAsync();

            string html = await this.RenderViewToStringAsync(
                "~/Views/Lavado/_DetalleTabla.cshtml",
                detalles,
                true
            );

            return Json(new
            {
                success = true,
                html,
                mensaje = "✅ Detalle agregado correctamente.",
                tbProLavId = dto.TB_PRO_LAV_ID,
                total = cabecera?.TbProLavUpro ?? 0
            });
        }

        //eliminar del detalle

        [HttpPost]
        public async Task<IActionResult> EliminarDetalle([FromBody] int idDetalle)
        {
            try
            {
                var detalle = await _context.TbProLavDet
                    .FirstOrDefaultAsync(x => x.TB_PRO_LAV_DET_ID == idDetalle);

                if (detalle == null)
                    return Json(new { success = false, mensaje = "❌ No se encontró el detalle." });

                if (detalle.TB_PRO_LAV_DET_DAT == "ELIMINADO" || (detalle.TB_PRO_LAV_DET_CANT_ELIM ?? 0) > 0)
                    return Json(new { success = false, mensaje = "❌ El detalle ya fue eliminado." });

                var recDet = await _context.TbRecDet
                    .FirstOrDefaultAsync(x => x.TbRecDetId == detalle.TB_PRO_LAV_DET_REC_DET_ID);

                if (recDet == null)
                    return Json(new { success = false, mensaje = "❌ No se encontró el detalle de recepción." });

                int cantidad = detalle.TB_PRO_LAV_DET_CANT ?? 0;

                if (cantidad <= 0)
                    return Json(new { success = false, mensaje = "❌ Cantidad inválida." });

                int empStockActual = recDet.TbRecDetEmpStock ?? 0;

                if (empStockActual < cantidad)
                    return Json(new { success = false, mensaje = "❌ No se puede revertir: stock de acondicionado insuficiente." });

                // Inversa exacta del Insertar Lavado
                recDet.TbRecDetLavStock = (recDet.TbRecDetLavStock ?? 0) + cantidad;
                recDet.TbRecDetLavTot = (recDet.TbRecDetLavTot ?? 0) - cantidad;
                recDet.TbRecDetEmpStock = empStockActual - cantidad;

                var cabecera = await _context.TbProLav
                    .FirstOrDefaultAsync(x => x.TbProLavId == detalle.TB_PRO_LAV_DET_PRO_LAV_ID);

                if (cabecera != null)
                {
                    cabecera.TbProLavUpro = (cabecera.TbProLavUpro ?? 0) - cantidad;
                }

                // Baja lógica
                detalle.TB_PRO_LAV_DET_CANT_ELIM = cantidad;
                detalle.TB_PRO_LAV_DET_DAT = "ELIMINADO";

                await _context.SaveChangesAsync();

                return Json(new
                {
                    success = true,
                    mensaje = "✅ Detalle eliminado correctamente.",
                    total = cabecera?.TbProLavUpro ?? 0
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    mensaje = "❌ Error al eliminar detalle: " + ex.Message
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerMaterial(int tbRecDetId)
        {
            try
            {
                var recDet = await _context.TbRecDet
                    .FirstOrDefaultAsync(r => r.TbRecDetId == tbRecDetId);

                if (recDet == null)
                    return Json(new { success = false, mensaje = "Etiqueta no encontrada." });

                int sinProcesar = recDet.TbRecDetLavStock ?? 0;

                if (sinProcesar <= 0)
                {
                    return Json(new
                    {
                        success = false,
                        mensaje = "❌ No hay stock disponible para Lavado.",
                        autoInsertar = false,
                        cantidadAuto = 0
                    });
                }

                return Json(new
                {
                    success = true,
                    materialId = recDet.TbRecDetMatId,
                    nombre = recDet.TbRecDetMatDen,
                    sector = recDet.TbRecSecDesDen,
                    codigoReuso = recDet.TbRecDetReuId,
                    recibidos = recDet.TbRecDetRecStock ?? 0,
                    enProceso = recDet.TbRecDetLavTot ?? 0,
                    sinProcesar = sinProcesar,

                    autoInsertar = sinProcesar == 1,
                    cantidadAuto = 1
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error en ObtenerMaterial Lavado: " + ex.Message);
                return Json(new { success = false, mensaje = "❌ Error interno al obtener material." });
            }
        }

        //para el boton cerrar

        [HttpPost]
        public async Task<IActionResult> CerrarProceso(int tbProLavId)
        {
            try
            {
                var cabecera = await _context.TbProLav
                    .FirstOrDefaultAsync(x => x.TbProLavId == tbProLavId);

                if (cabecera == null)
                {
                    return Json(new
                    {
                        success = false,
                        mensaje = "❌ No se encontró el proceso."
                    });
                }

                cabecera.TbProLavHorFin = new DateTime(
                    1899,
                    12,
                    30,
                    DateTime.Now.Hour,
                    DateTime.Now.Minute,
                    DateTime.Now.Second
                );

                await _context.SaveChangesAsync();

                return Json(new
                {
                    success = true
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
