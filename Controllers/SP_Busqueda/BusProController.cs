using Microsoft.AspNetCore.Mvc;
using ConexionSql.Services.SP_Busquedas.Interfaces;
using ConexionSql.Models.SP_Busquedas;
using System;
using System.Collections.Generic;

namespace ConexionSql.Controllers.SP_Busqueda
{
    public class BusProController : Controller
    {
        private readonly IBusProService _proService;

        public BusProController(IBusProService proService)
        {
            _proService = proService;
        }

        [HttpGet]
        public IActionResult IndexProcesos()
        {
            // Rango predeterminado de 30 días
            ViewBag.FEC_INI = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
            ViewBag.FEC_FIN = DateTime.Now.ToString("yyyy-MM-dd");

            // CAMBIO: Apuntamos al nuevo nombre IndexBusPro.cshtml
            //return View("~/Views/ProBusqueda/IndexBusPro.cshtml", new List<BusProDto>());
            return View("/Views/ProBusqueda/IndexBusPro.cshtml", new List<BusProDto>());
        }

        [HttpPost]
        public IActionResult Buscar(DateTime? FEC_INI, DateTime? FEC_FIN, string BUS_PTI_DEN, string BUS_EST_DEN)
        {
            // Saneamiento de strings
            string ptiDen = BUS_PTI_DEN ?? "";
            string estDen = BUS_EST_DEN ?? "";

            var resultados = _proService.GetProcesos(FEC_INI, FEC_FIN, ptiDen, estDen);

            // Retornamos la parcial (esta no cambió de nombre)
            return PartialView("~/Views/ProBusqueda/_ResultadosBusPro.cshtml", resultados);
        }
    }
}