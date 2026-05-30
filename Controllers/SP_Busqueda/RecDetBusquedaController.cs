using ConexionSql.Models.SP_Busquedas;
using ConexionSql.Services.SP_Busquedas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ConexionSql.Controllers.SP_Busqueda
{
    public class RecDetBusquedaController : Controller
    {
        private readonly IRecDetService _recDetService;

        public RecDetBusquedaController(IRecDetService recDetService)
        {
            _recDetService = recDetService;
        }

        public IActionResult Index()
        {
            ViewBag.FEC_INI = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
            ViewBag.FEC_FIN = DateTime.Now.ToString("yyyy-MM-dd");
            return View(new List<RecDetBusquedaDto>());
        }

        [HttpPost]
        public IActionResult Buscar(int? BUS_CET, string BUS_FEC_INI, string BUS_FEC_FIN, string BUS_DEN, string BUS_SEC_ORI, string BUS_SEC_DES, string BUS_EST, string BUS_MAT_PR, string BUS_ORT_DEN, string BUS_PAC, string BUS_PRO, string BUS_REM, string BUS_REU_ID, string BUS_FEN, bool? BUS_ACAJ_OPC, bool? BUS_TRA_OPC)
        {
            DateTime? fecIni = string.IsNullOrWhiteSpace(BUS_FEC_INI) ? null : DateTime.Parse(BUS_FEC_INI);
            DateTime? fecFin = string.IsNullOrWhiteSpace(BUS_FEC_FIN) ? null : DateTime.Parse(BUS_FEC_FIN);
            DateTime? fecProc = string.IsNullOrWhiteSpace(BUS_FEN) ? null : DateTime.Parse(BUS_FEN);

            var resultados = _recDetService.BuscarRecDet(fecIni, fecFin, BUS_DEN, BUS_SEC_ORI, BUS_SEC_DES, BUS_EST, BUS_MAT_PR, BUS_ORT_DEN, BUS_PAC, BUS_PRO, BUS_REM, BUS_REU_ID, fecProc, BUS_ACAJ_OPC, BUS_TRA_OPC, BUS_CET);
            return PartialView("_ResultadosRecDet", resultados);
        }

        [HttpGet]
        public JsonResult GetSugerencias(string term, string campo, string tabla)
        {
            var sugerencias = _recDetService.ObtenerSugerencias(term, campo, tabla);
            return Json(sugerencias);
        }
    }
}