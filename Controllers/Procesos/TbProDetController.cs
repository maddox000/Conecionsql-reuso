using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConexionSql.Data;
using ConexionSql.Models.Procesos;
using System;
using System.Linq;
using System.Threading.Tasks;
using ConexionSql.Utilidades;

namespace ConexionSql.Controllers.Procesos
{
    public class TbProDetController : Controller
    {
        private readonly ConexionSqlContext _context;

        public TbProDetController(ConexionSqlContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> SubFormulario(int id)
        {
            Console.WriteLine($"📥 SubFormulario INVOCADO con tbProId = {id}");

            var cabecera = await _context.TbPro
                .FirstOrDefaultAsync(p => p.TbProId == id);

            if (cabecera == null)
                return NotFound("❌ No se encontró la cabecera del proceso.");

            var dto = new TbProDetFormDto
            {
                Cabecera = cabecera,
                Detalle = new TbProDetDto
                {
                    TB_PRO_ID = id
                },
                Detalles = await _context.TbProDet
                    .Where(d => d.TbProId == id)
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
                    .ToListAsync()
            };

            return View("~/Views/Procesos/_SubFormProDet.cshtml", dto);
        }

        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] TbProDetDto dto)
        {
            Console.WriteLine("🔄 TbProDet.Insertar fue invocado");

            if (dto == null || dto.TB_PRO_ID <= 0)
                return Json(new { success = false, mensaje = "❌ Datos incompletos." });

            if (dto.TB_PRO_DET_REC_DET_ID == 0)
                return Json(new { success = false, mensaje = "❌ Debe ingresar una etiqueta válida." });

            var cabecera = await _context.TbPro
                .FirstOrDefaultAsync(p => p.TbProId == dto.TB_PRO_ID);

            if (cabecera == null)
                return Json(new { success = false, mensaje = "❌ No se encontró la cabecera del proceso." });

            var recDet = await _context.TbRecDet
                .FirstOrDefaultAsync(r => r.TbRecDetId == dto.TB_PRO_DET_REC_DET_ID);

            if (recDet == null)
                return Json(new { success = false, mensaje = "❌ Etiqueta no encontrada." });

            int stock = recDet.TbRecDetProStock ?? 0;
            int cantidad = dto.TB_PRO_DET_CANT ?? 0;

            if (cantidad <= 0)
                return Json(new { success = false, mensaje = "❌ Debe ingresar una cantidad mayor a 0." });

            if (cantidad > stock)
                return Json(new { success = false, mensaje = $"❌ Stock insuficiente. Disponible: {stock}" });

            // ✅ Actualizar stock en TB_REC_DET
            recDet.TbRecDetProStock = stock - cantidad;
            recDet.TbRecDetProTot = (recDet.TbRecDetProTot ?? 0) + cantidad;
            recDet.TbRecDetEntCant = (recDet.TbRecDetEntCant ?? 0) + cantidad;

            // ✅ Insertar detalle en TB_PRO_DET
            var nuevo = new TbProDet
            {
                TbProId = dto.TB_PRO_ID,
                TbProDetRecDetId = dto.TB_PRO_DET_REC_DET_ID,
                TbProDetRecDetMatId = recDet.TbRecDetMatId ?? 0,
                TbProDetRecDetMatDen = recDet.TbRecDetMatDen,
                TbProDetCant = cantidad,
                TbProDetPcLog = Environment.MachineName,
                TbProDetPcUsr = Environment.UserName,
                TbProFec = dto.TB_PRO_FEC ?? DateTime.Now
            };

            _context.TbProDet.Add(nuevo);
            await _context.SaveChangesAsync();

            var detalles = await _context.TbProDet
                .Where(d => d.TbProId == dto.TB_PRO_ID)
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

            string html = await this.RenderViewToStringAsync(
                "~/Views/Procesos/_DetalleTabla.cshtml",
                detalles,
                true
            );

            return Json(new
            {
                success = true,
                html,
                mensaje = "✅ Detalle agregado correctamente.",
                tbProId = dto.TB_PRO_ID
            });
        }

        [HttpGet]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var recDet = await _context.TbRecDet
                .FirstOrDefaultAsync(r => r.TbRecDetId == id);

            if (recDet == null)
                return Json(new { success = false, mensaje = "❌ Etiqueta no encontrada." });

            return Json(new
            {
                success = true,
                materialId = recDet.TbRecDetMatId,
                materialDen = recDet.TbRecDetMatDen,
                stockDisponible = recDet.TbRecDetProStock ?? 0
            });
        }
    }
}