using ClosedXML.Excel; // Asegúrate de tener esta librería instalada
using ConexionSql.Data;
using ConexionSql.Models.InfoBasica;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace ConexionSql.Controllers.InfoBasica
{
    public class IB_EquiposController : Controller
    {
        private readonly ConexionSqlContext _context;

        public IB_EquiposController(ConexionSqlContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> IB_Equipos()
        {
            var equipos = await _context.IbEqu
                .OrderBy(x => x.IbEquId)
                .Select(x => new IbEquDto
                {
                    IbEquId = x.IbEquId,
                    IbEquTeqDen = x.IbEquTeqDen,
                    IbEquMarDen = x.IbEquMarDen,
                    IbEquMod = x.IbEquMod,
                    IbEquSer = x.IbEquSer,
                    IbEquOcu = x.IbEquOcu
                })
                .ToListAsync();

            return View("~/Views/InfoBasica/IB_EquiposList.cshtml", equipos);
        }

        //amb de equipos

        private async Task CargarCombosEquipo()
        {
            ViewBag.TiposEquipo = await _context.IbEquTeq
                .OrderBy(x => x.IbEquTeqDen)
                .Select(x => new IbEquTeqDto
                {
                    IbEquTeqId = x.IbEquTeqId,
                    IbEquTeqDen = x.IbEquTeqDen,
                    IbEquPtiId = x.IbEquPtiId ?? 0,
                    IbEquPtiDen = x.IbEquPtiDen
                })
                .ToListAsync();

            ViewBag.Marcas = await _context.IbEquMar
                .OrderBy(x => x.IbEquMarDen)
                .Select(x => new IbEquMarDto
                {
                    IbEquMarId = x.IbEquMarId,
                    IbEquMarDen = x.IbEquMarDen
                })
                .ToListAsync();
        }

        [HttpGet]
        public async Task<IActionResult> Nuevo()
        {
            await CargarCombosEquipo();

            var dto = new IbEquDto();

            return View("~/Views/InfoBasica/IB_EquiposForm.cshtml", dto);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            await CargarCombosEquipo();

            var equipo = await _context.IbEqu
                .Where(x => x.IbEquId == id)
                .Select(x => new IbEquDto
                {
                    IbEquId = x.IbEquId,
                    IbEquTeqId = x.IbEquTeqId ?? 0,
                    IbEquTeqDen = x.IbEquTeqDen,
                    IbEquPtiId = x.IbEquPtiId ?? 0,
                    IbEquPtiDen = x.IbEquPtiDen,
                    IbEquMarId = x.IbEquMarId ?? 0,
                    IbEquMarDen = x.IbEquMarDen,
                    IbEquMod = x.IbEquMod,
                    IbEquSer = x.IbEquSer,
                    IbEquNum = x.IbEquNum.ToString(),
                    IbEquOcu = x.IbEquOcu,

                    IbEquAlt = x.IbEquAlt.ToString(),
                    IbEquAnc = x.IbEquAnc.ToString(),
                    IbEquPro = x.IbEquPro.ToString(),
                    IbEquCap = x.IbEquCap.ToString(),
                    IbEquPorc = x.IbEquPorc.ToString(),
                    IbEquCapu = x.IbEquCapu.ToString(),
                    IbEquLmat = x.IbEquLmat.ToString(),

                    IbEquPco = x.IbEquPco ?? 0,
                    IbEquPcoCoef = x.IbEquPcoCoef ?? 0,
                    IbEquPve = x.IbEquPve ?? 0
                })
                .FirstOrDefaultAsync();

            if (equipo == null)
            {
                return RedirectToAction(nameof(IB_Equipos));
            }

            return View("~/Views/InfoBasica/IB_EquiposForm.cshtml", equipo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GuardarEquipo(IbEquDto dto)
        {
            ConexionSql.Models.Equipos.IbEqu entidad;

            if (dto.IbEquId > 0)
            {
                entidad = await _context.IbEqu
                    .FirstOrDefaultAsync(x => x.IbEquId == dto.IbEquId);

                if (entidad == null)
                    return RedirectToAction(nameof(IB_Equipos));
            }
            else
            {
                entidad = new ConexionSql.Models.Equipos.IbEqu();
                _context.IbEqu.Add(entidad);
            }

            entidad.IbEquTeqId = dto.IbEquTeqId;
            var tipoEquipo = await _context.IbEquTeq
            .FirstOrDefaultAsync(x => x.IbEquTeqId == dto.IbEquTeqId);

            entidad.IbEquTeqDen = tipoEquipo?.IbEquTeqDen;
            entidad.IbEquPtiId = tipoEquipo?.IbEquPtiId;
            entidad.IbEquPtiDen = tipoEquipo?.IbEquPtiDen;
            var marca = await _context.IbEquMar
            .FirstOrDefaultAsync(x => x.IbEquMarId == dto.IbEquMarId);

            int? altura = int.TryParse(dto.IbEquAlt, out var alt) ? alt : null;
            int? ancho = int.TryParse(dto.IbEquAnc, out var anc) ? anc : null;
            int? profundidad = int.TryParse(dto.IbEquPro, out var pro) ? pro : null;
            int? porcentaje = int.TryParse(dto.IbEquPorc, out var porc) ? porc : null;

            entidad.IbEquMarId = dto.IbEquMarId;
            entidad.IbEquMarDen = marca?.IbEquMarDen;

            entidad.IbEquMod = dto.IbEquMod?.ToUpper();
            entidad.IbEquSer = dto.IbEquSer?.ToUpper();
            entidad.IbEquNum = int.TryParse(dto.IbEquNum, out var num) ? num : null;

            entidad.IbEquAlt = altura;
            entidad.IbEquAnc = ancho;
            entidad.IbEquPro = profundidad;
            entidad.IbEquPorc = porcentaje;

            entidad.IbEquCap = (altura ?? 0) * (ancho ?? 0) * (profundidad ?? 0);
            entidad.IbEquCapu = entidad.IbEquCap * (porcentaje ?? 0) / 100;

            entidad.IbEquLmat = int.TryParse(dto.IbEquLmat, out var lmat) ? lmat : null;

            entidad.IbEquPco = Convert.ToInt32(dto.IbEquPco);
            entidad.IbEquPcoCoef = Convert.ToInt32(dto.IbEquPcoCoef);
            entidad.IbEquPve = Convert.ToInt32(dto.IbEquPve);

            entidad.IbEquOcu = dto.IbEquOcu;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(IB_Equipos));
        }

        //termina abm equipos

        [HttpGet]
        public async Task<IActionResult> ExportarExcel()
        {
            var equipos = await _context.IbEqu
                .OrderBy(x => x.IbEquId)
                .Select(x => new {
                    Codigo = x.IbEquId,
                    Tipo = x.IbEquTeqDen,
                    Marca = x.IbEquMarDen,
                    Modelo = x.IbEquMod,
                    Serie = x.IbEquSer
                }).ToListAsync();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Equipos");

                // Encabezados
                worksheet.Cell(1, 1).Value = "Codigo";
                worksheet.Cell(1, 2).Value = "Tipo";
                worksheet.Cell(1, 3).Value = "Marca";
                worksheet.Cell(1, 4).Value = "Modelo";
                worksheet.Cell(1, 5).Value = "Serie";

                // Estilo de encabezados
                worksheet.Range("A1:E1").Style.Font.Bold = true;
                worksheet.Range("A1:E1").Style.Fill.BackgroundColor = XLColor.LightGray;

                // Cargar datos
                for (int i = 0; i < equipos.Count; i++)
                {
                    worksheet.Cell(i + 2, 1).Value = equipos[i].Codigo;
                    worksheet.Cell(i + 2, 2).Value = equipos[i].Tipo;
                    worksheet.Cell(i + 2, 3).Value = equipos[i].Marca;
                    worksheet.Cell(i + 2, 4).Value = equipos[i].Modelo;
                    worksheet.Cell(i + 2, 5).Value = equipos[i].Serie;
                }

                worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ListadoEquipos.xlsx");
                }
            }
        }

        [HttpGet]
        public IActionResult ExportarPdf()
        {
            return Content("Ruta encontrada. Aquí implementarás la generación del PDF.");
        }
    }
}