using ConexionSql.Data;
using ConexionSql.Models.Procesos;
using ConexionSql.Models.Procesos.Controles;
using ConexionSql.Utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<IActionResult> SubFormulario(int tbProId)
        {
            Console.WriteLine($"📥 SubFormulario INVOCADO con tbProId = {tbProId}");

            var cabecera = await _context.TbPro
                .FirstOrDefaultAsync(p => p.TbProId == tbProId);

            if (cabecera == null)
                return NotFound("❌ No se encontró la cabecera del proceso.");

            var dto = new TbProDetFormDto
            {
                Cabecera = cabecera,
                Detalle = new TbProDetDto
                {
                    TB_PRO_ID = tbProId
                },
                Detalles = await _context.TbProDet
                    .Where(d => d.TbProId == tbProId)
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

            recDet.TbRecDetProStock = stock - cantidad;
            recDet.TbRecDetProTot = (recDet.TbRecDetProTot ?? 0) + cantidad;
            recDet.TbRecDetEntCant = (recDet.TbRecDetEntCant ?? 0) + cantidad;

            var material = await _context.IbMat
            .FirstOrDefaultAsync(m => m.IB_MAT_ID == recDet.TbRecDetMatId);
            var equipo = await _context.IbEqu
            .FirstOrDefaultAsync(e => e.IbEquId == cabecera.TbProEquId);

            if (equipo == null)
                return Json(new { success = false, mensaje = "❌ No se encontró el equipo del proceso." });

            var nuevo = new TbProDet
            {
                TbProId = dto.TB_PRO_ID,

                // 🔥 REC_DET
                TbProDetRecDetId = recDet.TbRecDetId,

                // 🔥 REC
                TbProDetRecId = recDet.TbRecId,

                // 🔥 MATERIAL
                TbProDetRecDetMatId = recDet.TbRecDetMatId ?? 0,
                TbProDetRecDetMatDen = recDet.TbRecDetMatDen,

                // 🔥 TIPO MATERIAL (IB_MAT)
                TbProDetRecDetMatTipId = material?.IB_MAT_MTI_ID,
                TbProDetRecDetMatTipDen = material?.IB_MAT_MTI_DEN,

                // 🔥 DATOS DE REC_DET
                TbProDetRecDetCant = recDet.TbRecDetCant,
                TbProDetRecDetProStock = recDet.TbRecDetProStock,
                TbProDetRecDetProTot = recDet.TbRecDetProTot,
                TbProDetRecDetReuId = recDet.TbRecDetReuId,

                // 🔥 INGRESO
                TbProDetCant = cantidad,
                TbProDetCantAbo = cantidad,

                // 🔥 SECTORES (DESDE TB_REC_DET)
                TbRecSecDesId = recDet.TbRecSecDesId,
                TbRecSecDesDen = recDet.TbRecSecDesDen,
                TbRecSecOriId = recDet.TbRecSecOriId,
                TbRecSecOriDen = recDet.TbRecSecOriDen,

                // 🔥 ORIGEN / LOTE
                TbRecOrtId = recDet.TbRecOrtId,
                TbRecOrtDen = recDet.TbRecOrtDen,
                TbCodTexLot = recDet.TbRecDetLot,

                // 🔥 VOLUMEN
                IbMatVol = recDet.IbMatVol,

                // 🔥 CABECERA TB_PRO
                TbProPtiId = cabecera.TbProPtiId,
                TbProPtiDen = cabecera.TbProPtiDen,
                TbProEquId = cabecera.TbProEquId,
                TbProIbEquTeqId = cabecera.TbProIbEquTeqId,
                TbProIbEquTeqDen = cabecera.TbProIbEquTeqDen,
                TbProEquNum = cabecera.TbProEquNum,
                TbProEquDen = cabecera.TbProEquDen,
                TbProEquMarId = cabecera.TbProEquMarId,
                TbProEquMarDen = cabecera.TbProEquMarDen,
                TbProEquMod = cabecera.TbProEquMod,
                TbProEquSer = cabecera.TbProEquSer,
                TbProTciId = cabecera.TbProTciId,
                TbProTciDen = cabecera.TbProTciDen,

                // 🔥 CAPACIDAD / PARÁMETROS DE EQUIPO DESDE CABECERA
                IbEquCap = cabecera.IbEquCap,
                IbEquCapu = cabecera.IbEquCapu,
                IbEquCapr = cabecera.IbEquCapr,
                IbEquPco = cabecera.IbEquPco,
                IbEquPve = cabecera.IbEquPve,

                // 🔥 NUM / TXT / ESTADO
                TbProDetNum1 = recDet.TbRecDetCant,   // cantidad de recepción
                TbProDetNum2 = 1,
                TbProDetNum3 = 0,
                TbProDetTxt1 = "-",
                TbProDetTxt2 = "NO REGISTRADO",
                TbProDetRepro = false,
                TbProDetEstId = 2,
                TbProDetEstDen = "PROCESADO",
                TbProDetEstFec = DateTime.Now,
                TbProDetCantMult = 1,
                TbProDetCantElim = 0,

                // 🔥 SISTEMA
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

        [HttpGet]
        public IActionResult ObtenerTiposControl()
        {
            var lista = _context.TbProPte
                .Where(x => !x.IbPtePtiOcu)
                .Select(x => new TbProPteDto
                {
                    IB_PTE_ID = x.IbPteId,
                    IB_PTE_DEN = x.IbPteDen
                })
                .ToList();

            return Ok(lista);
        }

        [HttpGet]
        public IActionResult ObtenerUbicacionesControl()
        {
            var lista = _context.TbProPteUbi
                .Where(x => !x.IbPtesUbiOcu)
                .Select(x => new
                {
                    IB_PTES_UBI_ID = x.IbPtesUbiId,
                    IB_PTES_UBI_DEN = x.IbPtesUbiDen
                })
                .ToList();

            return Ok(lista);
        }
    }
}