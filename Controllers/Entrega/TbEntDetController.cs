using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConexionSql.Data;
using ConexionSql.Models.Entrega;
using System;
using System.Linq;
using System.Threading.Tasks;
using ConexionSql.Utilidades;

namespace ConexionSql.Controllers.Entrega
{
    public class TbEntDetController : Controller
    {
        private readonly ConexionSqlContext _context;

        public TbEntDetController(ConexionSqlContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> SubFormulario(int id)
        {
            var cabecera = await _context.TbEnt.FindAsync(id);
            if (cabecera == null)
                return NotFound();

            var dto = new TbEntDetFormDto
            {
                Cabecera = cabecera,
                Detalle = new TbEntDetDto
                {
                    TB_ENT_ID = id
                }
            };

            var detalles = await _context.TbEntDet
                .Where(d => d.TbEntId == id)
                .OrderByDescending(d => d.TbEntDetId)
                .Select(d => new TbEntDetDto
                {
                    TB_ENT_DET_ID = d.TbEntDetId,
                    TB_ENT_ID = d.TbEntId,
                    TB_ENT_DET_CANT = d.TbEntDetCant,
                    TbEntDetRecDetMatDen = d.TbEntDetRecDetMatDen
                })
                .ToListAsync();

            dto.Detalles = detalles;

            return View("~/Views/Entrega/_SubFormEntDet.cshtml", dto);
        }

        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] TbEntDetDto dto)
        {
            if (!ModelState.IsValid)
                return Json(new { success = false, mensaje = "Datos inválidos." });

            try
            {
                var cabecera = await _context.TbEnt.FindAsync(dto.TB_ENT_ID);
                if (cabecera == null)
                    return Json(new { success = false, mensaje = "No se encontró la entrega." });

                var recDet = await _context.TbRecDet.FindAsync(dto.TB_ENT_DET_REC_DET_ID);
                if (recDet == null)
                    return Json(new { success = false, mensaje = "No se encontró la etiqueta escaneada." });

                if (recDet.TbRecSecDesId != cabecera.TbEntSecId)
                    return Json(new { success = false, mensaje = "El sector de destino no coincide con el de la etiqueta." });

                int stockDisponible = recDet.TbRecDetEntCant ?? 0;
                if (stockDisponible == 0)
                    return Json(new { success = false, mensaje = "❌ No hay stock disponible." });

                if ((dto.TB_ENT_DET_CANT ?? 0) > stockDisponible)
                    return Json(new { success = false, mensaje = $"❌ Stock insuficiente. Disponible: {stockDisponible}" });

                // ✅ Descontar de stock y acumular
                recDet.TbRecDetEntCant -= dto.TB_ENT_DET_CANT ?? 0;
                recDet.TbRecDetEntStock = (recDet.TbRecDetEntStock ?? 0) + (dto.TB_ENT_DET_CANT ?? 0);

                var nuevo = new TbEntDet
                {
                    TbEntId = dto.TB_ENT_ID ?? 0,
                    TbEntDetRecDetId = dto.TB_ENT_DET_REC_DET_ID ?? 0,
                    TbEntDetRecDetMatId = recDet.TbRecDetMatId,
                    TbEntDetRecDetMatDen = recDet.TbRecDetMatDen,
                    TbEntDetCant = dto.TB_ENT_DET_CANT,
                    TbEntDetPcUsr = Environment.UserName,
                    TbEntDetPcLog = Environment.MachineName
                };

                _context.TbEntDet.Add(nuevo);
                await _context.SaveChangesAsync();

                var detalles = await _context.TbEntDet
                    .Where(d => d.TbEntId == dto.TB_ENT_ID)
                    .OrderByDescending(d => d.TbEntDetId)
                    .Select(d => new TbEntDetDto
                    {
                        TB_ENT_DET_ID = d.TbEntDetId,
                        TB_ENT_ID = d.TbEntId,
                        TB_ENT_DET_CANT = d.TbEntDetCant,
                        TbEntDetRecDetMatDen = d.TbEntDetRecDetMatDen
                    })
                    .ToListAsync();

                // ✅ Esta es la única línea cambiada para corregir la generación del HTML
                string html = await this.RenderViewToStringAsync(
                    "~/Views/Entrega/_DetalleTabla.cshtml",
                    detalles,
                    true
                );

                return Json(new { success = true, html, mensaje = "✅ Detalle agregado correctamente." });
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error en Insertar: " + ex.Message);
                return Json(new { success = false, mensaje = "❌ Error inesperado al guardar el detalle." });
            }
        }

        [HttpGet]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var recDet = await _context.TbRecDet.FindAsync(id);
            if (recDet == null)
                return Json(new { success = false, mensaje = "No se encontró la etiqueta." });

            return Json(new
            {
                success = true,
                materialId = recDet.TbRecDetMatId,
                materialDen = recDet.TbRecDetMatDen,
                stockDisponible = recDet.TbRecDetEntCant ?? 0
            });
        }
    }
}
