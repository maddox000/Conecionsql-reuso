using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ConexionSql.Models.SP_Busquedas.SP_BusRecDetDisp;
using ConexionSql.Services.SP_Busquedas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using ConexionSql.Models.SP_Busquedas.SP_BusRecDetDisp;
using ConexionSql.Services.SP_Busquedas.Interfaces;
// SI USAS EXCEL:
using ClosedXML.Excel;
// SI USAS PDF:
//using Rotativa.AspNetCore;

namespace ConexionSql.Controllers.SP_Busqueda
{
    public class Bus_RecDetDispController : Controller
    {
        private readonly IBusRecDetDispService _busService;

        public Bus_RecDetDispController(IBusRecDetDispService busService)
        {
            _busService = busService;
        }

        public IActionResult Index(int? mti_id, string titulo)
        {
            ViewBag.FiltroMtiId = mti_id;
            ViewBag.TituloBusqueda = string.IsNullOrEmpty(titulo) ? "Búsqueda - Disponibles por Etapa" : titulo;

            if (mti_id == 8)
            {
                // Si es producción, las variables de fecha van vacías (NULL)
                ViewBag.FecIni = null;
                ViewBag.FecFin = null;
            }
            else
            {
                // Si es stock normal, arranca con la fecha de hoy
                ViewBag.FecIni = DateTime.Today.ToString("yyyy-MM-dd");
                ViewBag.FecFin = DateTime.Today.ToString("yyyy-MM-dd");
            }

            return View("~/Views/SP_Busquedas/Bus_RecDetDisp.cshtml");
        }

        [HttpPost]
        public async Task<JsonResult> Buscar([FromBody] BusRecDetDispRequest request)
        {
            var resultados = await _busService.ObtenerListadoAsync(request);
            return Json(resultados);
        }

        // Dejamos los métodos creados pero vacíos para evitar el 404
        [HttpGet]
        public async Task<IActionResult> ExportarExcel([FromQuery] BusRecDetDispRequest request)
        {
            var resultados = await _busService.ObtenerListadoAsync(request);
            using (var workbook = new ClosedXML.Excel.XLWorkbook())
            {
                var sheet = workbook.Worksheets.Add("Disponibles");
                sheet.Cell(1, 1).InsertTable(resultados);
                using (var ms = new System.IO.MemoryStream())
                {
                    workbook.SaveAs(ms);
                    return File(ms.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Reporte.xlsx");
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> ExportarPDF([FromQuery] BusRecDetDispRequest request)
        {
            var resultados = await _busService.ObtenerListadoAsync(request);
            return Ok("Controlador funcionando");
        }
    }
}