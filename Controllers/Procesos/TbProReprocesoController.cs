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

                    detalleRecepcion.TbRecDetProStock =
                        (detalleRecepcion.TbRecDetProStock ?? 0) + cantidadAbortada;

                    detalleRecepcion.TbRecDetEntStock =
                        (detalleRecepcion.TbRecDetEntStock ?? 0) - cantidadAbortada;

                    detalle.TbProDetNum3 =
                        (detalle.TbProDetNum3 ?? 0) + cantidadAbortada;

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

        // comienza reproceso parcial

        [HttpGet]
        public async Task<IActionResult> ObtenerNoConformidades()
        {
            var lista = await _context.TbProNco
                .Where(x => !x.TbProNcoOcu)
                .OrderBy(x => x.TbProNcoDen)
                .Select(x => new TbProNcoDto
                {
                    TB_PRO_NCO_ID = x.TbProNcoId,
                    TB_PRO_NCO_DEN = x.TbProNcoDen,
                    TB_PRO_NCO_OCU = x.TbProNcoOcu,
                    TB_PRO_NCO_EST_ID = x.TbProNcoEstId
                })
                .ToListAsync();

            return Json(lista);
        }

        private void ReprocesoParcialStock(
        TbRecDet detalleRecepcion,
        int motivoId,
        int cantidad)
        {
            detalleRecepcion.TbRecDetEntStock =
                (detalleRecepcion.TbRecDetEntStock ?? 0) - cantidad;

            switch (motivoId)
            {
                // ACONDICIONADO
                case 3:
                case 5:
                case 7:
                case 9:
                case 13:

                    detalleRecepcion.TbRecDetEmpStock =
                        (detalleRecepcion.TbRecDetEmpStock ?? 0) + cantidad;

                    break;

                // LAVADO
                case 4:
                case 8:
                case 10:

                    detalleRecepcion.TbRecDetLavStock =
                        (detalleRecepcion.TbRecDetLavStock ?? 0) + cantidad;

                    break;

                // ESTERILIZADO
                case 6:
                case 11:
                case 12:
                case 14:

                    detalleRecepcion.TbRecDetProStock =
                        (detalleRecepcion.TbRecDetProStock ?? 0) + cantidad;

                    break;

                default:
                    throw new Exception("Motivo de reproceso parcial no configurado.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> EjecutarReprocesoParcial([FromBody] ReprocesoParcialDto dto)
        {
            if (dto == null)
            {
                return Json(new
                {
                    success = false,
                    mensaje = "Datos inválidos para reproceso parcial."
                });
            }

            if (dto.TbProId <= 0)
            {
                return Json(new
                {
                    success = false,
                    mensaje = "Proceso inválido."
                });
            }

            if (dto.MotivoId <= 0)
            {
                return Json(new
                {
                    success = false,
                    mensaje = "Debe seleccionar un motivo de reproceso."
                });
            }

            if (dto.Detalles == null || dto.Detalles.Count == 0)
            {
                return Json(new
                {
                    success = false,
                    mensaje = "No se seleccionaron materiales."
                });
            }

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var proceso = await _context.TbPro
                    .FirstOrDefaultAsync(x => x.TbProId == dto.TbProId);

                if (proceso == null)
                {
                    await transaction.RollbackAsync();

                    return Json(new
                    {
                        success = false,
                        mensaje = "Proceso no encontrado."
                    });
                }

                var detallesProceso = await _context.TbProDet
                    .Where(x => x.TbProId == dto.TbProId)
                    .ToListAsync();

                var idsSeleccionados = dto.Detalles
                    .Select(x => x.TbProDetId)
                    .ToList();

                var detalles = detallesProceso
                    .Where(x => idsSeleccionados.Contains(x.TbProDetId))
                    .ToList();

                if (detalles.Count == 0)
                {
                    await transaction.RollbackAsync();

                    return Json(new
                    {
                        success = false,
                        mensaje = "No se encontraron detalles seleccionados."
                    });
                }

                foreach (var detalle in detalles)
                {
                    var detalleDto = dto.Detalles
                        .FirstOrDefault(x => x.TbProDetId == detalle.TbProDetId);

                    if (detalleDto == null)
                        continue;

                    var cantidad = detalleDto.Cantidad;

                    if (cantidad <= 0)
                        continue;

                    if (detalle.TbProDetCant.HasValue && cantidad > detalle.TbProDetCant.Value)
                    {
                        await transaction.RollbackAsync();

                        return Json(new
                        {
                            success = false,
                            mensaje = $"La cantidad a reprocesar no puede superar la cantidad del detalle {detalle.TbProDetId}."
                        });
                    }

                    var recDetId = detalle.TbProDetRecDetId ?? 0;

                    var detalleRecepcion = await _context.TbRecDet
                        .FirstOrDefaultAsync(x => x.TbRecDetId == recDetId);

                    if (detalleRecepcion == null)
                    {
                        await transaction.RollbackAsync();

                        return Json(new
                        {
                            success = false,
                            mensaje = $"No se encontró TB_REC_DET para el detalle {detalle.TbProDetId}."
                        });
                    }

                    ReprocesoParcialStock(
                        detalleRecepcion,
                        dto.MotivoId,
                        cantidad
                    );
                }

                proceso.IbProEstId = 4;
                proceso.IbProEstDen = "REPROCESO PARCIAL";

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