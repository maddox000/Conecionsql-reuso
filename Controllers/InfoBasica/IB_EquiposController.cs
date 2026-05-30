using ConexionSql.Data;
using ConexionSql.Models.InfoBasica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClosedXML.Excel; // Asegúrate de tener esta librería instalada
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