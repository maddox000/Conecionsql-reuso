using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConexionSql.Data;
using ConexionSql.Models.Recepciones;
using ConexionSql.Utilidades;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ConexionSql.Controllers
{
    public class TbRecDetController : Controller
    {
        private readonly ConexionSqlContext _context;

        public TbRecDetController(ConexionSqlContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Inserta un nuevo detalle de recepción (TB_REC_DET) y genera la etiqueta ZPL.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] TbRecDetDto detalle)
        {
            Console.WriteLine("🔄 Insertar() fue invocado.");
            Console.WriteLine($"📥 Recibido DTO: RecId={detalle.TB_REC_ID}, MatId={detalle.IB_MAT_ID}, Cant={detalle.TB_REC_DET_CANT}");

            if (!ModelState.IsValid)
            {
                Console.WriteLine("❌ ModelState inválido.");
                return Json(new { success = false, mensaje = "Datos inválidos." });
            }

            try
            {
                // Paso 1: Verificar que la cabecera TB_REC exista
                var tbRec = await _context.TbRec.FirstOrDefaultAsync(r => r.TbRecId == detalle.TB_REC_ID);
                if (tbRec == null)
                {
                    Console.WriteLine("❌ No se encontró la cabecera TB_REC.");
                    return Json(new { success = false, mensaje = "Cabecera de recepción no encontrada." });
                }

                // Paso 2: Obtener nombre del material desde IB_MAT
                string? nombreMaterial = await _context.IbMat
                    .Where(m => m.IB_MAT_ID == detalle.IB_MAT_ID)
                    .Select(m => m.IB_MAT_DEN)
                    .FirstOrDefaultAsync() ?? "SIN MATERIAL";

                // Paso 2.1: Obtener nombre del estado desde IB_EST
                string? nombreEstado = await _context.IbEst
                    .Where(e => e.IbEstId == detalle.IB_EST_ID)
                    .Select(e => e.IbEstDen)
                    .FirstOrDefaultAsync() ?? "SIN ESTADO";

                // Paso 3: Crear e insertar el detalle
                var entidad = new TbRecDet
                {
                    TbRecId = detalle.TB_REC_ID,
                    TbRecDetMatId = detalle.IB_MAT_ID,
                    TbRecDetMatDen = nombreMaterial,
                    TbRecDetCant = detalle.TB_REC_DET_CANT,

                    // 🔹 Stock según el estado recibido (los otros llegan en 0)
                    TbRecDetEmpStock = detalle.TB_REC_DET_EMP_STOCK,
                    TbRecDetProStock = detalle.TB_REC_DET_PRO_STOCK,
                    TbRecDetLavStock = detalle.TB_REC_DET_LAV_STOCK,
                    TbRecDetEntStock = detalle.TB_REC_DET_ENT_STOCK,
                    TbRecDetDecStock = detalle.TB_REC_DET_DEC_STOCK,
                    TbRecDetEntCant = detalle.TB_REC_DET_ENT_CANT,

                    // 🔹 Estado (ID + Den)
                    TbRecDetEstId = detalle.IB_EST_ID,
                    TbRecDetEstDen = nombreEstado,

                    TbRecDetPcLog = Environment.MachineName,
                    TbRecDetPcUsr = Environment.UserName,
                    TbRecFec = DateTime.Now,
                    TbRecSecOriId = tbRec.TbRecSecOriId,
                    TbRecSecOriDen = tbRec.TbRecSecOriDen,
                    TbRecSecDesId = tbRec.TbRecSecDesId,
                    TbRecSecDesDen = tbRec.TbRecSecDesDen
                };

                _context.TbRecDet.Add(entidad);
                await _context.SaveChangesAsync();

                // Paso 4: Generar etiqueta ZPL
                string zpl = Etiquetas.RecepcionDetalle(
                    material: nombreMaterial,
                    cantidad: detalle.TB_REC_DET_CANT,
                    fecha: tbRec.TbRecFec ?? DateTime.Now,
                    hora: tbRec.TbRecHorIni?.TimeOfDay ?? DateTime.Now.TimeOfDay,
                    nroRecepcion: tbRec.TbRecId,
                    idDetalle: entidad.TbRecDetId
                );

                ImpresionZebra.EnviarAImpresora("ZDesigner GK420t", zpl);

                // Paso 5: Obtener lista actualizada
                var lista = await _context.TbRecDet
                    .Where(d => d.TbRecId == detalle.TB_REC_ID)
                    .Select(d => new TbRecDetDto
                    {
                        TB_REC_DET_ID = d.TbRecDetId,
                        TB_REC_ID = d.TbRecId,
                        IB_MAT_ID = d.TbRecDetMatId,
                        TbRecDetMatDen = d.TbRecDetMatDen,
                        IB_EST_ID = d.TbRecDetEstId,
                        IB_EST_DEN = d.TbRecDetEstDen,
                        TB_REC_DET_CANT = d.TbRecDetCant
                    })
                    .ToListAsync();

                // Paso 6: Renderizar vista parcial
                string html = await this.RenderViewToStringAsync("~/Views/Recepcion/_DetalleTabla.cshtml", lista, true);

                return Json(new { success = true, mensaje = "✅ Detalle agregado correctamente.", html });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al insertar detalle: {ex.Message}");
                return Json(new { success = false, mensaje = "Error interno al insertar." });
            }
        }



    }
}
