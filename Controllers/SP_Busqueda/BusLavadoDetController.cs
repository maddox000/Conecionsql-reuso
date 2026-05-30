using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConexionSql.Models.SP_Busquedas;
using ConexionSql.Services.SP_Busquedas.Interfaces;

namespace ConexionSql.Controllers.SP_Busqueda
{
    public class BusLavadoDetController : Controller
    {
        private readonly IBusLavadoDetService _busLavadoDetService;

        public BusLavadoDetController(IBusLavadoDetService busLavadoDetService)
        {
            _busLavadoDetService = busLavadoDetService;
        }

        // GET: /BusLavadoDet/IndexLavDet
        public IActionResult IndexLavDet()
        {
            ViewBag.FecIni = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
            ViewBag.FecFin = DateTime.Now.ToString("yyyy-MM-dd");

            // ESPECIFICAMOS LA RUTA COMPLETA DE LA VISTA
            return View("~/Views/LavDetBusqueda/IndexLavDet.cshtml", new List<BusLavadoDetDto>());
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Buscar(
            DateTime FEC_INI,
            DateTime FEC_FIN,
            string BUS_PTI,
            string BUS_EST,
            string BUS_CET,
            string BUS_DEN,
            string BUS_SEC,
            string BUS_REU_ID,
            string BUS_TPROT)
        {
            try
            {
                var resultados = await _busLavadoDetService.GetLavadoDetalleAsync(
                    FEC_INI, FEC_FIN, BUS_PTI, BUS_EST, BUS_CET, BUS_DEN, BUS_SEC, BUS_REU_ID, BUS_TPROT
                );

                // ESPECIFICAMOS LA RUTA COMPLETA DE LA PARTIAL
                return PartialView("~/Views/LavDetBusqueda/_ResultadosBusLavDet.cshtml", resultados);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public JsonResult GetSugerencias(string term, string campo, string tabla)
        {
            return Json(new List<string>());
        }
    }
}