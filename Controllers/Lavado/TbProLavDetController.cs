using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConexionSql.Data;
using ConexionSql.Models.Lavado;
using ConexionSql.Utilidades;
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

                // SISTEMA
                TB_PRO_LAV_DET_PC_LOG = Environment.MachineName,
                TB_PRO_LAV_DET_PC_USR = Environment.UserName,

                // FECHA Y HORA
                TB_PRO_LAV_DET_PRO_LAV_FEC = DateTime.Now,
                TB_PRO_LAV_DET_PRO_LAV_HOR = DateTime.Now,

                // ESTADO
                TB_PRO_LAV_DET_EST_ID = 1,
                TB_PRO_LAV_DET_EST_DEN = "EN PROCESO"
            };

            _context.TbProLavDet.Add(nuevo);
            await _context.SaveChangesAsync();

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
                    TB_PRO_LAV_DET_CANT = d.TB_PRO_LAV_DET_CANT,
                    TB_PRO_LAV_DET_REC_DET_MAT_DEN = d.TB_PRO_LAV_DET_IB_MAT_DEN
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

        [HttpGet]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var recDet = await _context.TbRecDet.FindAsync(id);
            if (recDet == null)
                return Json(new { success = false, mensaje = "Etiqueta no encontrada." });

            return Json(new
            {
                success = true,
                materialId = recDet.TbRecDetMatId,
                materialDen = recDet.TbRecDetMatDen,
                stockDisponible = recDet.TbRecDetLavStock ?? 0
            });
        }
    }
}
