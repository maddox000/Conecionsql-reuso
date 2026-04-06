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

                int cantidad = dto.TB_ENT_DET_CANT ?? 0;
                if (cantidad <= 0)
                    return Json(new { success = false, mensaje = "❌ La cantidad debe ser mayor a 0." });

                int stockDisponible = recDet.TbRecDetEntStock ?? 0;
                if (stockDisponible == 0)
                    return Json(new { success = false, mensaje = "❌ No hay stock disponible." });

                if (cantidad > stockDisponible)
                    return Json(new { success = false, mensaje = $"❌ Stock insuficiente. Disponible: {stockDisponible}" });

                // ✅ Descontar stock
                recDet.TbRecDetEntStock = (recDet.TbRecDetEntStock ?? 0) - cantidad;

                // ✅ Acumular total en cabecera TB_ENT
                cabecera.TbEntCantTot = (cabecera.TbEntCantTot ?? 0) + cantidad;

                var nuevo = new TbEntDet
                {
                    // 🔗 RELACIÓN
                    TbEntId = dto.TB_ENT_ID ?? 0,
                    TbEntDetRecDetId = dto.TB_ENT_DET_REC_DET_ID ?? 0,

                    // 🔥 REC
                    TbEntDetRecId = 1,

                    // 🔥 MATERIAL
                    TbEntDetRecDetMatId = recDet.TbRecDetMatId,
                    TbEntDetRecDetMatDen = recDet.TbRecDetMatDen,

                    // 🔥 TIPO MATERIAL
                    TbEntDetRecDetMatTipId = recDet.TbRecDetMatMtiId,
                    TbEntDetRecDetMatTipDen = recDet.TbRecDetMatMtiDen,

                    // 🔥 DATOS ORIGINALES DE RECEPCIÓN
                    TbEntDetRecDetCant = recDet.TbRecDetCant,
                    TbEntDetRecDetReuId = recDet.TbRecDetReuId,

                    // 🔥 PROFESIONAL
                    TbRecDetProId = recDet.TbRecDetProId,
                    TbRecDetProNom = recDet.TbRecDetProNom,
                    TbRecDetProApe = recDet.TbRecDetProApe,

                    // 🔥 PACIENTE / REMITO
                    TbEntDetRecDetPac = recDet.TbRecDetPac,
                    TbRecDetRem = recDet.TbRecDetRem,

                    // 🔥 STOCK / ENTREGA
                    TbEntDetRecDetEntStock = recDet.TbRecDetEntStock,
                    TbEntDetRecDetEntCant = recDet.TbRecDetEntCant,
                    TbEntDetRecDetEntTot = cantidad,

                    // 📦 CANTIDAD ENTREGADA AHORA
                    TbEntDetCant = cantidad,

                    // 🏢 SECTOR
                    TbEntSecId = cabecera.TbEntSecId,
                    TbEntSecDen = cabecera.TbEntSecDen,

                    // 📅 FECHA
                    TbEntFec = cabecera.TbEntFec,

                    // 🔢 AUXILIARES
                    TbEntDetNum1 = 1,
                    TbEntDetNum2 = 2,
                    TbEntDetNum3 = 3,

                    // 📝 TEXTOS
                    TbEntDetTxt1 = "UNO",
                    TbEntDetTxt2 = "DOS",
                    TbEntDetTxt3 = "TRES",

                    // 📆 FECHAS AUX
                    TbEntDetDti1 = cabecera.TbEntFec,
                    TbEntDetDti2 = cabecera.TbEntFec,
                    TbEntDetDti3 = cabecera.TbEntFec,

                    // 📄 MEMOS
                    TbEntDetMem1 = null,
                    TbEntDetMem2 = null,
                    TbEntDetMem3 = null,

                    // ☑ CHECKLIST
                    TbEntDetCkl1 = false,
                    TbEntDetCkl2 = false,
                    TbEntDetCkl3 = false,
                    TbEntDetCkl4 = false,
                    TbEntDetCkl5 = false,
                    TbEntDetCkl6 = false,

                    // 🔘 BITS
                    TbEntDetBit1 = false,
                    TbEntDetBit2 = false,
                    TbEntDetBit3 = false,

                    // 🔧 OTROS
                    TbEntDetCantMult = 0,
                    TbEntDetCantElim = 0,
                    TbEntDetDat = null,
                    TbEntDetMatEtiId = recDet.TbRecDetMatEtiId,
                    TbEntDetMatEtiDen = recDet.TbRecDetMatEtiDen,
                    TbEntDetProPtiId = recDet.TbRecDetProPtiId,
                    TbEntDetProPtiDen = recDet.TbRecDetProPtiDen,
                    TbEntDetTranspOpcId = 0,
                    TbEntDetTranspOpcDen = "NO REGISTRADO",

                    // 🖥️ SISTEMA
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

                string html = await this.RenderViewToStringAsync(
                    "~/Views/Entrega/_DetalleTabla.cshtml",
                    detalles,
                    true
                );

                return Json(new
                {
                    success = true,
                    html,
                    total = cabecera.TbEntCantTot ?? 0,
                    mensaje = "✅ Detalle agregado correctamente."
                });
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
                stockDisponible = recDet.TbRecDetEntStock ?? 0
            });
        }
    }
}
