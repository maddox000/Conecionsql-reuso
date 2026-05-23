using ConexionSql.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConexionSql.Models.Lavado;

namespace ConexionSql.Controllers.Lavado
{
    public class TbProLavReprocesoController : Controller
    {
        private readonly ConexionSqlContext _context;

        private const int EstadoDetalleReprocesadoId = 3;
        private const string EstadoDetalleReprocesadoDen = "REPROCESADO";

        public TbProLavReprocesoController(
            ConexionSqlContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> EjecutarReproceso(
            [FromBody] TbProLavLiberacionChecksDto dto)
        {
            if (dto == null || dto.TbProLavId <= 0)
            {
                return Json(new
                {
                    success = false,
                    mensaje = "TB_PRO_LAV_ID inválido."
                });
            }

            using var transaction =
                await _context.Database.BeginTransactionAsync();

            try
            {
                var detallesLavado =
                    await _context.TbProLavDet
                    .Where(x =>
                    x.TB_PRO_LAV_DET_PRO_LAV_ID == dto.TbProLavId
                    &&
                    (x.TB_PRO_LAV_DET_NUM_1 ?? 0) > 0)
                    .ToListAsync();

                if (detallesLavado.Count == 0)
                {
                    await transaction.RollbackAsync();

                    return Json(new
                    {
                        success = false,
                        mensaje = "No se encontraron detalles abortados para reprocesar."
                    });
                }

                foreach (var detalle in detallesLavado)
                {
                    var cantidadAbortada =
                        detalle.TB_PRO_LAV_DET_NUM_1 ?? 0;

                    if (cantidadAbortada <= 0)
                        continue;

                    var recDetId =
                        detalle.TB_PRO_LAV_DET_REC_DET_ID ?? 0;

                    var detalleRecepcion =
                        await _context.TbRecDet
                        .FirstOrDefaultAsync(
                            x => x.TbRecDetId == recDetId);

                    if (detalleRecepcion == null)
                        continue;

                    detalleRecepcion.TbRecDetLavStock =
                        (detalleRecepcion.TbRecDetLavStock ?? 0)
                        + cantidadAbortada;

                    detalleRecepcion.TbRecDetEmpStock =
                        (detalleRecepcion.TbRecDetEmpStock ?? 0)
                        - cantidadAbortada;

                    detalle.TB_PRO_LAV_DET_NUM_3 =
                        (detalle.TB_PRO_LAV_DET_NUM_3 ?? 0)
                        + cantidadAbortada;

                    detalle.TB_PRO_LAV_DET_NUM_1 = 0;

                    detalle.TB_PRO_LAV_DET_REPRO = true;
                    detalle.TB_PRO_LAV_DET_EST_ID = EstadoDetalleReprocesadoId;
                    detalle.TB_PRO_LAV_DET_EST_DEN = EstadoDetalleReprocesadoDen;
                    detalle.TB_PRO_LAV_DET_EST_FEC = DateTime.Now;

                    //if (dto.ResultadoFinalLavado == "ABORTAR_LAVADO")
                    //{
                    //    detalle.TB_PRO_LAV_DET_EST_ID = 3;
                    //    detalle.TB_PRO_LAV_DET_EST_DEN = "ABORTADO";
                    //}

                    //if (dto.ResultadoFinalLavado == "FALLA_EQUIPO")
                    //{
                    //    detalle.TB_PRO_LAV_DET_EST_ID = 5;
                    //    detalle.TB_PRO_LAV_DET_EST_DEN = "FALLA DE PROCESO";
                    //}
                }



                //completa estado de cabecera

                var lavado = await _context.TbProLav
                .FirstOrDefaultAsync(x => x.TbProLavId == dto.TbProLavId);

                if (lavado != null)
                {
                    if (dto.ResultadoFinalLavado == "ABORTAR_LAVADO")
                    {
                        lavado.TbProLavEstId = 3;
                        lavado.TbProLavEstDen = "ABORTADO";
                        lavado.TbProLavTxt2 = "PROCESO ABORTADO";
                    }

                    if (dto.ResultadoFinalLavado == "FALLA_EQUIPO")
                    {
                        lavado.TbProLavEstId = 5;
                        lavado.TbProLavEstDen = "FALLA DE PROCESO";
                        lavado.TbProLavTxt2 = "FALLA DE PROCESO";
                    }
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

        [HttpGet]
        public async Task<IActionResult> ObtenerNoConformidades()
        {
            var motivos = await _context.TbProLavNco
                .Where(x => x.TB_PRO_LAV_NCO_OCU == false)
                .OrderBy(x => x.TB_PRO_LAV_NCO_DEN)
                .Select(x => new
                {
                    id = x.TB_PRO_LAV_NCO_ID,
                    den = x.TB_PRO_LAV_NCO_DEN
                })
                .ToListAsync();

            return Json(new
            {
                success = true,
                data = motivos
            });
        }

        [HttpPost]
        public async Task<IActionResult> EjecutarReprocesoParcial(
        [FromBody] ReprocesoParcialLavadoDto dto)
        {
            if (dto == null || dto.TbProLavId <= 0)
                return Json(new { success = false, mensaje = "Lavado inválido." });

            if (dto.MotivoId <= 0)
                return Json(new { success = false, mensaje = "Debe seleccionar un motivo de reproceso." });

            if (dto.Detalles == null || dto.Detalles.Count == 0)
                return Json(new { success = false, mensaje = "No se seleccionaron materiales." });

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                foreach (var item in dto.Detalles)
                {
                    if (item.TbProLavDetId <= 0 || item.Cantidad <= 0)
                        continue;

                    var detalle = await _context.TbProLavDet
                        .FirstOrDefaultAsync(x =>
                            x.TB_PRO_LAV_DET_ID == item.TbProLavDetId &&
                            x.TB_PRO_LAV_DET_PRO_LAV_ID == dto.TbProLavId);

                    if (detalle == null)
                        continue;

                    if (detalle.TB_PRO_LAV_DET_CANT.HasValue &&
                        item.Cantidad > detalle.TB_PRO_LAV_DET_CANT.Value)
                    {
                        await transaction.RollbackAsync();

                        return Json(new
                        {
                            success = false,
                            mensaje = $"La cantidad a reprocesar no puede superar la cantidad del detalle {detalle.TB_PRO_LAV_DET_ID}."
                        });
                    }

                    var recDetId = detalle.TB_PRO_LAV_DET_REC_DET_ID ?? 0;

                    var detalleRecepcion = await _context.TbRecDet
                        .FirstOrDefaultAsync(x => x.TbRecDetId == recDetId);

                    if (detalleRecepcion == null)
                    {
                        await transaction.RollbackAsync();

                        return Json(new
                        {
                            success = false,
                            mensaje = $"No se encontró TB_REC_DET para el detalle {detalle.TB_PRO_LAV_DET_ID}."
                        });
                    }

                    detalleRecepcion.TbRecDetLavStock =
                        (detalleRecepcion.TbRecDetLavStock ?? 0) + item.Cantidad;

                    detalleRecepcion.TbRecDetEmpStock =
                        (detalleRecepcion.TbRecDetEmpStock ?? 0) - item.Cantidad;

                    detalle.TB_PRO_LAV_DET_NUM_3 =
                        (detalle.TB_PRO_LAV_DET_NUM_3 ?? 0) + item.Cantidad;
                    detalle.TB_PRO_LAV_DET_NUM_1 =
                        Math.Max(
                            0,
                            (detalle.TB_PRO_LAV_DET_NUM_1 ?? 0)
                            - item.Cantidad
                        );
                    detalle.TB_PRO_LAV_DET_REPRO = true;
                    detalle.TB_PRO_LAV_DET_EST_ID = EstadoDetalleReprocesadoId;
                    detalle.TB_PRO_LAV_DET_EST_DEN = EstadoDetalleReprocesadoDen;
                    detalle.TB_PRO_LAV_DET_EST_FEC = DateTime.Now;
                }



                await _context.SaveChangesAsync();
                await transaction.CommitAsync();



                return Json(new
                {
                    success = true,
                    mensaje = "Reproceso parcial ejecutado correctamente."
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