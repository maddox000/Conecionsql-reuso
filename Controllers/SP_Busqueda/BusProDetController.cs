using Microsoft.AspNetCore.Mvc;
using ConexionSql.Services.SP_Busquedas.Interfaces;
using ConexionSql.Models.SP_Busquedas;
using System;
using System.Collections.Generic;

namespace ConexionSql.Controllers.SP_Busqueda
{
    public class BusProDetController : Controller
    {
        private readonly IBusProDetService _proDetService;

        public BusProDetController(IBusProDetService proDetService)
        {
            _proDetService = proDetService;
        }

        [HttpGet]
        public IActionResult IndexProDet()
        {
            // Rango predeterminado para la UI
            ViewBag.FEC_INI = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
            ViewBag.FEC_FIN = DateTime.Now.ToString("yyyy-MM-dd");

            // CORRECCIÓN: Nombre de archivo y carpeta exactos
            return View("~/Views/ProBusqueda/IndexBusProDet.cshtml", new List<BusProDetDto>());
        }

        [HttpPost]
        public IActionResult Buscar(
            DateTime? BUS_FEC_INI,
            DateTime? BUS_FEC_FIN,
            string BUS_SEC_DES,
            string BUS_ORT_DEN,
            string BUS_DEN,
            string BUS_PR,
            string BUS_REU_ID,
            string BUS_PAC,
            string BUS_PRO,
            string BUS_REM,
            DateTime? BUS_FEN)
        {
            // Saneamiento de fechas para evitar nulos en el Service
            DateTime fechaDesde = BUS_FEC_INI ?? DateTime.Now.AddDays(-30);
            DateTime fechaHasta = BUS_FEC_FIN ?? DateTime.Now;

            // Llamada al servicio con todos los filtros
            var resultados = _proDetService.GetProcesosDetalle(
                fechaDesde,
                fechaHasta,
                BUS_SEC_DES ?? "",
                BUS_ORT_DEN ?? "",
                BUS_DEN ?? "",
                BUS_PR ?? "",
                BUS_REU_ID ?? "",
                BUS_PAC ?? "",
                BUS_PRO ?? "",
                BUS_REM ?? "",
                BUS_FEN
            );

            // Retornamos la Partial View de resultados
            return PartialView("~/Views/ProBusqueda/_ResultadosBusProDet.cshtml", resultados);
        }
    }
}
