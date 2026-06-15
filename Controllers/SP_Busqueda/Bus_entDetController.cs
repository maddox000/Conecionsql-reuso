using ConexionSql.Models.SP_Busquedas;
using ConexionSql.Services.SP_Busquedas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ConexionSql.Controllers.SP_Busqueda
{
    public class Bus_EntDetController : Controller
    {
        private readonly IBus_EntDetService _busEntDetService;

        public Bus_EntDetController(IBus_EntDetService busEntDetService)
        {
            _busEntDetService = busEntDetService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.FecIni = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
            ViewBag.FecFin = DateTime.Now.ToString("yyyy-MM-dd");

            return View("~/Views/SP_Busquedas/Bus_EntDet.cshtml", new List<Bus_EntDetDto>());
        }

        [HttpPost]
        public IActionResult Buscar(
            int? BUS_CET,
            DateTime? FEC_INI,
            DateTime? FEC_FIN,
            string BUS_DEN,
            string BUS_SEC,
            string BUS_REU,
            string BUS_PAC,
            string BUS_PRO,
            string BUS_PROV,
            string BUS_REM)
        {
            var filtros = new Bus_EntDetDto
            {
                FEC_INI = FEC_INI ?? DateTime.Today.AddDays(-30),
                FEC_FIN = FEC_FIN ?? DateTime.Today,
                BUS_DEN = BUS_DEN,
                BUS_SEC = BUS_SEC,
                BUS_REU = BUS_REU,
                BUS_CET = BUS_CET,
                BUS_PAC = BUS_PAC,
                BUS_PRO = BUS_PRO,
                BUS_PROV = BUS_PROV,
                BUS_REM = BUS_REM
            };

            var resultados = _busEntDetService.BuscarEntregas(
                filtros.BUS_CET, filtros.FEC_INI, filtros.FEC_FIN,
                filtros.BUS_DEN, filtros.BUS_SEC, filtros.BUS_REU,
                filtros.BUS_PAC, filtros.BUS_PRO, filtros.BUS_PROV, filtros.BUS_REM);

            return PartialView("~/Views/SP_Busquedas/_ResultadosBusEntDet.cshtml", resultados);
        }

        [HttpGet]
        public JsonResult GetSugerencias(string term, string campo, string tabla)
        {
            // Pequeña validación de seguridad para evitar consultas nulas
            if (string.IsNullOrWhiteSpace(term) || string.IsNullOrWhiteSpace(campo) || string.IsNullOrWhiteSpace(tabla))
            {
                return Json(new List<string>());
            }

            // Le pasamos la pelota a tu capa de servicio
            var sugerencias = _busEntDetService.GetSugerencias(term, campo, tabla);

            return Json(sugerencias);
        }

        [HttpGet]
        public IActionResult ExportarExcel(
            int? BUS_CET,
            DateTime? FEC_INI,
            DateTime? FEC_FIN,
            string BUS_DEN,
            string BUS_SEC,
            string BUS_REU,
            string BUS_PAC,
            string BUS_PRO,
            string BUS_PROV,
            string BUS_REM)
        {
            var filtros = new Bus_EntDetDto
            {
                FEC_INI = FEC_INI ?? DateTime.Today.AddDays(-30),
                FEC_FIN = FEC_FIN ?? DateTime.Today,
                BUS_DEN = BUS_DEN,
                BUS_SEC = BUS_SEC,
                BUS_REU = BUS_REU,
                BUS_CET = BUS_CET,
                BUS_PAC = BUS_PAC,
                BUS_PRO = BUS_PRO,
                BUS_PROV = BUS_PROV,
                BUS_REM = BUS_REM
            };

            var resultados = _busEntDetService.BuscarEntregas(
                filtros.BUS_CET, filtros.FEC_INI, filtros.FEC_FIN,
                filtros.BUS_DEN, filtros.BUS_SEC, filtros.BUS_REU,
                filtros.BUS_PAC, filtros.BUS_PRO, filtros.BUS_PROV, filtros.BUS_REM);

            byte[] fileBytes = new byte[0]; // TODO: Lógica Excel
            string nombreSugerido = $"Entregas_Materiales_{filtros.FEC_INI:yyyyMMdd}.xlsx";

            return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", nombreSugerido);
        }

        [HttpGet]
        public IActionResult ConsultaEntrega(int tbEntId)
        {
            return RedirectToAction("TbEntIndex", "Entrega", new { id = tbEntId });
        }
    }
}