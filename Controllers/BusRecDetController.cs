using Microsoft.AspNetCore.Mvc;
using ConexionSql.Interfaces;
using ConexionSql.Models.SP_Busquedas;
using System;
using System.Collections.Generic;
using ConexionSql.Services.SP_Busquedas.Interfaces;

namespace ConexionSql.Controllers
{
    public class BusRecDetController : Controller
    {
        private readonly IBusRecDetService _busRecDetService;

        public BusRecDetController(IBusRecDetService busRecDetService)
        {
            _busRecDetService = busRecDetService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // Fecha Inicio: 1800 días atrás | Fecha Fin: Hoy (según tu modelo)
            ViewBag.FEC_INI = DateTime.Now.AddDays(-1800).ToString("yyyy-MM-dd");
            ViewBag.FEC_FIN = DateTime.Now.ToString("yyyy-MM-dd");

            return View("~/Views/RecDetBusqueda/Index.cshtml", new List<BusRecDetDto>());
        }

        [HttpPost]
        public IActionResult Buscar(int? BUS_CET, DateTime? BUS_FEC_INI, DateTime? BUS_FEC_FIN,
                                    string BUS_DEN, string BUS_SEC_ORI, string BUS_SEC_DES,
                                    string BUS_EST, string BUS_MAT_PR, string BUS_ORT_DEN,
                                    string BUS_PAC, string BUS_PRO, string BUS_REM,
                                    string BUS_REU_ID, DateTime? BUS_FEN, bool? BUS_ACAJ_OPC)
        {
            // VALIDACIÓN: Si la fecha llega nula o es MinValue, asignamos rango (según tu lógica).
            DateTime fechaDesde = (BUS_FEC_INI == null || BUS_FEC_INI == DateTime.MinValue)
                                  ? DateTime.Now.AddDays(-30)
                                  : BUS_FEC_INI.Value;

            DateTime fechaHasta = (BUS_FEC_FIN == null || BUS_FEC_FIN == DateTime.MinValue)
                                  ? DateTime.Now
                                  : BUS_FEC_FIN.Value;

            // Limpieza de strings para que el SP reciba "" en lugar de NULL
            string den = BUS_DEN ?? "";
            string secOri = BUS_SEC_ORI ?? "";
            string secDes = BUS_SEC_DES ?? "";
            string est = BUS_EST ?? "";
            string matPr = BUS_MAT_PR ?? "";
            string ortDen = BUS_ORT_DEN ?? "";
            string pac = BUS_PAC ?? "";
            string pro = BUS_PRO ?? "";
            string rem = BUS_REM ?? "";
            string reuId = BUS_REU_ID ?? "";

            // Llamada al servicio con todos los parámetros del SP_Buscar_RecDet
            var resultados = _busRecDetService.GetRecDet(
                BUS_CET,
                fechaDesde,
                fechaHasta,
                den,
                secOri,
                secDes,
                est,
                matPr,
                ortDen,
                pac,
                pro,
                rem,
                reuId,
                BUS_FEN,
                BUS_ACAJ_OPC
            );

            // Retornamos la Partial View
            return PartialView("~/Views/BusRecDet/_ResultadosBusRecDet.cshtml", resultados);
        }

        [HttpGet]
        public JsonResult GetSugerencias(string term, string campo, string tabla)
        {
            return Json(new List<string>());
        }
    }
}