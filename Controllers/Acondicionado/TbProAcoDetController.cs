using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConexionSql.Data;
using ConexionSql.Models.Procesos;
using ConexionSql.Models.Recepciones;
using ConexionSql.Models.Acondicionado;
using System;
using System.Linq;
using System.Threading.Tasks;
using ConexionSql.Utilidades;

namespace ConexionSql.Controllers
{
    public class TbProAcoDetController : Controller
    {
        private readonly ConexionSqlContext _context;

        public TbProAcoDetController(ConexionSqlContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Insertar(int tbRecDetId, int cantidad, int tbProAcoId)
        {
            Console.WriteLine("🟢 TbProAcoDetController.Insertar invocado.");

            if (cantidad <= 0)
                return Json(new { success = false, mensaje = "Debe ingresar una cantidad válida." });

            try
            {
                var cabecera = await _context.TbProAco.FindAsync(tbProAcoId);
                if (cabecera == null)
                    return Json(new { success = false, mensaje = "❌ Cabecera no encontrada." });

                var recDet = await _context.TbRecDet
                    .FirstOrDefaultAsync(r => r.TbRecDetId == tbRecDetId);

                if (recDet == null)
                    return Json(new { success = false, mensaje = "❌ No se encontró el detalle de recepción." });

                int stockDisponible = recDet.TbRecDetEmpStock ?? 0;
                if (stockDisponible == 0)
                    return Json(new { success = false, mensaje = "❌ No hay stock disponible." });

                if (cantidad > stockDisponible)
                    return Json(new { success = false, mensaje = $"❌ Stock insuficiente. Disponible: {stockDisponible}" });

                // Actualizar stock en TB_REC_DET
                recDet.TbRecDetEmpStock -= cantidad;
                recDet.TbRecDetEmpTot = (recDet.TbRecDetEmpTot ?? 0) + cantidad;
                recDet.TbRecDetProStock = (recDet.TbRecDetProStock ?? 0) + cantidad;

                // Estado ingreso en TB_REC_DET
                recDet.TbRecDetEstIngId = 24;
                recDet.TbRecDetEstIngDen = "CE PROCESO ACONDICIONADO";

                // Crear nuevo detalle de acondicionado
                var nuevoDet = new TbProAcoDet
                {
                    TbProAcoDetAcoId = tbProAcoId,
                    TbProAcoDetRecDetId = recDet.TbRecDetId,
                    TbProAcoDetMatId = recDet.TbRecDetMatId,
                    TbProAcoDetMatDen = recDet.TbRecDetMatDen,
                    TbProAcoDetCant = cantidad,

                    // Extras seguros
                    TbProAcoDetReuId = recDet.TbRecDetReuId,
                    TbProAcoDetMatEtiId = recDet.TbRecDetMatEtiId,
                    TbProAcoDetMatEtiDen = recDet.TbRecDetMatEtiDen,
                    TbProAcoDetRecDetCant = recDet.TbRecDetCant,

                    // Estos los dejamos fijos para no romper
                    TbProAcoDetSecDesId = 0,
                    TbProAcoDetMatVol = 0,

                    // Stock
                    TbProAcoDetEmpStock = stockDisponible,
                    TbProAcoDetEmpCant = cantidad,
                    TbProAcoDetEmpTot = cantidad,
                    TbProAcoDetProStock = cantidad,

                    TbProAcoDetPcLog = Environment.MachineName,
                    TbProAcoDetPcUsr = Environment.UserName,
                    TbProAcoDetHor = DateTime.Now
                };

                _context.TbProAcoDet.Add(nuevoDet);

                // Sumar cantidad a la cabecera
                cabecera.TbProAcoUpro = (cabecera.TbProAcoUpro ?? 0) + cantidad;

                await _context.SaveChangesAsync();

                var detallesActualizados = await _context.TbProAcoDet
                    .Where(d => d.TbProAcoDetAcoId == tbProAcoId)
                    .Select(d => new TbProAcoDetDto
                    {
                        TbProAcoDetId = d.TbProAcoDetId,
                        TbProAcoDetMatId = d.TbProAcoDetMatId,
                        TbProAcoDetMatDen = d.TbProAcoDetMatDen,
                        TbProAcoDetCant = d.TbProAcoDetCant,
                        TbProAcoDetPcUsr = d.TbProAcoDetPcUsr,
                        TbProAcoDetPcLog = d.TbProAcoDetPcLog,
                        TbProAcoDetHor = d.TbProAcoDetHor
                    })
                    .ToListAsync();

                string html = await this.RenderViewToStringAsync(
                    "~/Views/Acondicionado/_DetalleTablaAco.cshtml",
                    detallesActualizados,
                    true
                );

                return Json(new
                {
                    success = true,
                    mensaje = "✅ Detalle de Acondicionado agregado correctamente.",
                    html = html
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error en Insertar: " + ex.Message);
                return Json(new { success = false, mensaje = "❌ Error interno al insertar." });
            }
        }

        [HttpGet]
        public async Task<IActionResult> SubFormAcoDet(int id)
        {
            var cabecera = await _context.TbProAco.FindAsync(id);
            if (cabecera == null)
                return NotFound("Cabecera no encontrada");

            var detalles = await _context.TbProAcoDet
                .Where(d => d.TbProAcoDetAcoId == id)
                .Select(d => new TbProAcoDetDto
                {
                    TbProAcoDetId = d.TbProAcoDetId,
                    TbProAcoDetMatId = d.TbProAcoDetMatId,
                    TbProAcoDetMatDen = d.TbProAcoDetMatDen,
                    TbProAcoDetCant = d.TbProAcoDetCant,
                    TbProAcoDetPcUsr = d.TbProAcoDetPcUsr,
                    TbProAcoDetPcLog = d.TbProAcoDetPcLog,
                    TbProAcoDetHor = d.TbProAcoDetHor
                })
                .ToListAsync();

            var dto = new TbProAcoDetFormDto
            {
                Cabecera = cabecera,
                Detalles = detalles
            };

            return View("~/Views/Acondicionado/_SubFormAcoDet.cshtml", dto);
        }


        [HttpGet]
        public async Task<IActionResult> ObtenerMaterial(int tbRecDetId)
        {
            var detalle = await _context.TbRecDet
                .Where(r => r.TbRecDetId == tbRecDetId)
                .Select(r => new { nombre = r.TbRecDetMatDen })
                .FirstOrDefaultAsync();

            if (detalle == null)
                return Json(new { success = false, mensaje = "Etiqueta no encontrada." });

            return Json(new { success = true, nombre = detalle.nombre });
        }
    }
}
