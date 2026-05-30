using Microsoft.AspNetCore.Mvc;
using ConexionSql.Services.SP_Busquedas.Interfaces;
using ConexionSql.Models.SP_Busquedas;
using System;
using System.Collections.Generic;

namespace ConexionSql.Controllers.SP_Busqueda
{
    public class BusAcoController : Controller
    {
        private readonly IBusAcoService _acoService;

        public BusAcoController(IBusAcoService acoService)
        {
            _acoService = acoService;
        }

        [HttpGet]
        public IActionResult IndexAcondicionado()
        {
            // Rango por defecto para la vista inicial
            ViewBag.FEC_INI = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
            ViewBag.FEC_FIN = DateTime.Now.ToString("yyyy-MM-dd");

            // CAMBIO: Apuntamos al nombre exacto del archivo IndexAco.cshtml
            return View("~/Views/AcoBusqueda/IndexAco.cshtml", new List<BusAcoDto>());
        }

        [HttpPost]
        public IActionResult Buscar(DateTime? BUS_FEC_INI, DateTime? BUS_FEC_FIN,
                                    string BUS_CET, string BUS_ACO_ID, string BUS_DEN,
                                    string BUS_REU_ID, string BUS_SEC)
        {
            // VALIDACIÓN: Rango de fechas (Saneamiento de nulos)
            DateTime fechaDesde = (BUS_FEC_INI == null || BUS_FEC_INI == DateTime.MinValue)
                                  ? DateTime.Now.AddDays(-30)
                                  : BUS_FEC_INI.Value;

            DateTime fechaHasta = (BUS_FEC_FIN == null || BUS_FEC_FIN == DateTime.MinValue)
                                  ? DateTime.Now
                                  : BUS_FEC_FIN.Value;

            // Saneamiento de Strings para el SP (para que el SP reciba "" y lo convierta a NULL si es necesario)
            string cet = BUS_CET ?? "";
            string acoId = BUS_ACO_ID ?? "";
            string den = BUS_DEN ?? "";
            string reuId = BUS_REU_ID ?? "";
            string sec = BUS_SEC ?? "";

            // Llamada al servicio
            var resultados = _acoService.GetAcondicionados(
                fechaDesde,
                fechaHasta,
                cet,
                acoId,
                den,
                reuId,
                sec
            );

            // Retornamos la Partial View ubicada en la carpeta AcoBusqueda
            return PartialView("~/Views/AcoBusqueda/_ResultadosBusAco.cshtml", resultados);
        }
    }
}