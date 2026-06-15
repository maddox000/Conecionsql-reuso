using Microsoft.AspNetCore.Mvc;
using ConexionSql.Services.SP_Busquedas.Interfaces;
using ConexionSql.Models.SP_Busquedas;
using System;
using System.Collections.Generic;

namespace ConexionSql.Controllers.SP_Busqueda
{
    public class BusRecController : Controller
    {
        private readonly IBusRecService _recService;

        public BusRecController(IBusRecService recService)
        {
            _recService = recService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // Fecha Inicio: 1800 días atrás | Fecha Fin: Hoy
            ViewBag.FEC_INI = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
            ViewBag.FEC_FIN = DateTime.Now.ToString("yyyy-MM-dd");

            // CORRECCIÓN: Apuntamos a la carpeta RecBusqueda
            return View("~/Views/RecBusqueda/Index.cshtml", new List<BusRecDto>());
        }

        [HttpPost]
        public IActionResult Buscar(DateTime? FEC_INI, DateTime? FEC_FIN,
                                    string BUS_SEC_ORI, string BUS_SEC_DES, string BUS_ORT_DEN,
                                    string BUS_DEN, string BUS_PR, string BUS_REU_ID,
                                    string BUS_PAC, string BUS_PRO, string BUS_REM, DateTime? BUS_FEN)
        {
            DateTime fechaDesde = (FEC_INI == null || FEC_INI == DateTime.MinValue)
                                  ? DateTime.Now.AddDays(-30)
                                  : FEC_INI.Value;

            DateTime fechaHasta = (FEC_FIN == null || FEC_FIN == DateTime.MinValue)
                                  ? DateTime.Now
                                  : FEC_FIN.Value;

            string secOri = BUS_SEC_ORI ?? "";
            string secDes = BUS_SEC_DES ?? "";
            string ortDen = BUS_ORT_DEN ?? "";
            string den = BUS_DEN ?? "";
            string pr = BUS_PR ?? "";
            string reuId = BUS_REU_ID ?? "";
            string pac = BUS_PAC ?? "";
            string pro = BUS_PRO ?? "";
            string rem = BUS_REM ?? "";

            var resultados = _recService.GetRecs(
                fechaDesde,
                fechaHasta,
                secOri,
                secDes,
                ortDen,
                den,
                pr,
                reuId,
                pac,
                pro,
                rem,
                BUS_FEN
            );

            // CORRECCIÓN: Apuntamos a la carpeta RecBusqueda
            return PartialView("~/Views/RecBusqueda/_ResultadosBusRec.cshtml", resultados);
        }

        [HttpGet]
        public JsonResult GetSugerencias(string term, string campo, string tabla)
        {
            return Json(new List<string>());
        }
    }
}