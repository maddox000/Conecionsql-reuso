using Microsoft.AspNetCore.Mvc;
using ConexionSql.Interfaces;
using ConexionSql.Models.SP_Busquedas;
using System;
using System.Collections.Generic;

namespace ConexionSql.Controllers.SP_Busqueda
{
    public class BusLavadoController : Controller
    {
        private readonly IBusLavadoService _lavadoService;

        public BusLavadoController(IBusLavadoService lavadoService)
        {
            _lavadoService = lavadoService;
        }

        [HttpGet]
        public IActionResult IndexLav()
        {
            // Fecha Inicio: 30 días atrás | Fecha Fin: Hoy
            ViewBag.FEC_INI = DateTime.Now.AddDays(-1800).ToString("yyyy-MM-dd");
            ViewBag.FEC_FIN = DateTime.Now.ToString("yyyy-MM-dd");

            return View("~/Views/LavBusqueda/IndexLav.cshtml", new List<BusLavadoDto>());
        }

        [HttpPost]
        public IActionResult Buscar(DateTime? BUS_FEC_INI, DateTime? BUS_FEC_FIN, string BUS_PTI,
                                    string BUS_EST, string BUS_LOT, string BUS_EQU_TEQ, string BUS_EQU_NUM)
        {
            // VALIDACIÓN CRUCIAL: Si la fecha llega nula o es 01/01/0001, asignamos el rango de 30 días.
            // Esto es lo que frena el error de "SqlDateTime overflow" en el Service.
            DateTime fechaDesde = (BUS_FEC_INI == null || BUS_FEC_INI == DateTime.MinValue)
                                  ? DateTime.Now.AddDays(-30)
                                  : BUS_FEC_INI.Value;

            DateTime fechaHasta = (BUS_FEC_FIN == null || BUS_FEC_FIN == DateTime.MinValue)
                                  ? DateTime.Now
                                  : BUS_FEC_FIN.Value;

            // Limpieza de strings para que el SP reciba "" en lugar de NULL
            string pti = BUS_PTI ?? "";
            string est = BUS_EST ?? "";
            string lot = BUS_LOT ?? "";
            string teq = BUS_EQU_TEQ ?? "";
            string num = BUS_EQU_NUM ?? "";

            // Llamada al servicio con los parámetros ya saneados
            var resultados = _lavadoService.GetLavados(
                fechaDesde,
                fechaHasta,
                pti,
                est,
                lot,
                teq,
                num
            );

            // Retornamos la Partial View
            return PartialView("~/Views/LavBusqueda/_ResultadosBusLavado.cshtml", resultados);
        }

        [HttpGet]
        public JsonResult GetSugerencias(string term, string campo, string tabla)
        {
            // Podés implementar la lógica de sugerencias aquí más adelante
            return Json(new List<string>());
        }
    }
}