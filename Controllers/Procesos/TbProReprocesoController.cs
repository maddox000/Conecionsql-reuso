using ConexionSql.Data;
using ConexionSql.Models.Procesos;
using ConexionSql.Models.Recepciones;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConexionSql.Controllers.Procesos
{
    public class TbProReprocesoController : Controller
    {
        private readonly ConexionSqlContext _context;

        public TbProReprocesoController(ConexionSqlContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> EjecutarReproceso([FromBody] int tbProId)
        {
            if (tbProId <= 0)
            {
                return Json(new
                {
                    success = false,
                    mensaje = "TB_PRO_ID inválido."
                });
            }

            bool soloVerDetalles = false;

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var detallesProceso = await _context.TbProDet
                    .Where(x => x.TbProId == tbProId && (x.TbProDetCantAbo ?? 0) > 0)
                    .ToListAsync();

                if (soloVerDetalles)
                {
                    await transaction.RollbackAsync();

                    return Json(new
                    {
                        success = true,
                        cantidad = detallesProceso.Count,
                        data = detallesProceso
                    });
                }

                if (detallesProceso.Count == 0)
                {
                    await transaction.RollbackAsync();

                    return Json(new
                    {
                        success = false,
                        mensaje = "No se encontraron detalles abortados para reprocesar."
                    });
                }

                foreach (var detalle in detallesProceso)
                {
                    var cantidadAbortada = detalle.TbProDetCantAbo ?? 0;

                    if (cantidadAbortada <= 0)
                        continue;

                    var recDetId = detalle.TbProDetRecDetId ?? 0;

                    if (recDetId <= 0)
                    {
                        await transaction.RollbackAsync();

                        return Json(new
                        {
                            success = false,
                            mensaje = $"El detalle de proceso {detalle.TbProDetId} no tiene TB_PRO_DET_REC_DET_ID válido."
                        });
                    }

                    var detalleRecepcion = await _context.TbRecDet
                        .FirstOrDefaultAsync(x => x.TbRecDetId == recDetId);

                    if (detalleRecepcion == null)
                    {
                        await transaction.RollbackAsync();

                        return Json(new
                        {
                            success = false,
                            mensaje = $"No se encontró TB_REC_DET para el código de etiqueta {recDetId}."
                        });
                    }

                    detalleRecepcion.TbRecDetProStock = (detalleRecepcion.TbRecDetProStock ?? 0) + cantidadAbortada;
                    detalle.TbProDetNum3 = (detalle.TbProDetNum3 ?? 0) + cantidadAbortada;
                    detalle.TbProDetCantAbo = 0;
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return Json(new
                {
                    success = true,
                    mensaje = "Reproceso total ejecutado correctamente."
                });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();

                return Json(new
                {
                    success = false,
                    mensaje = ex.Message
                });
            }
        }
    }
}