using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConexionSql.Services.SP_Busquedas.Interfaces;
using ConexionSql.Models.SP_Busquedas;

namespace ConexionSql.Controllers
{
    public class RecBusquedaController : Controller
    {
        private readonly IBusLavadoDetService _recService;

        // Constructor con inyección de dependencia
        public RecBusquedaController(IBusLavadoDetService recService)
        {
            _recService = recService;
        }

        // GET: /RecBusqueda
        // Este método es el que abre la página inicial y evita el error 404
        [HttpGet]
        public IActionResult Index()
        {
            // Parámetros iniciales para la vista
            ViewBag.FEC_INI = DateTime.Now.ToString("yyyy-MM-dd");
            ViewBag.FEC_FIN = DateTime.Now.ToString("yyyy-MM-dd");

            // Retornamos la vista principal (Index.cshtml)
            return View(
                    "~/Views/RecBusqueda/Index.cshtml",
                    new List<RecBusquedaDto>()
                );
                    }

        // POST: /RecBusqueda/Buscar
        [HttpPost]
        public async Task<IActionResult> Buscar(string FEC_INI, string FEC_FIN, string BUS_SEC_ORI,
                                            string BUS_SEC_DES, string BUS_ORT_DEN, string BUS_DEN,
                                            string BUS_PR, string BUS_REU_ID, string BUS_PAC,
                                            string BUS_PRO, string BUS_REM, string BUS_FEN)
        {
            try
            {
                // LOGICA DE FECHAS: Si el JS no manda fechas, usamos el día de hoy
                DateTime fecIni = string.IsNullOrWhiteSpace(FEC_INI) ? DateTime.Today : DateTime.Parse(FEC_INI);
                DateTime fecFin = string.IsNullOrWhiteSpace(FEC_FIN) ? DateTime.Today : DateTime.Parse(FEC_FIN);

                // La fecha de procedimiento (BUS_FEN) se procesa pero solo se usa si es necesario.
                // Tal como pediste, priorizamos la búsqueda por rango de fechas (fecIni y fecFin).
                DateTime? fecProc = string.IsNullOrWhiteSpace(BUS_FEN) ? (DateTime?)null : DateTime.Parse(BUS_FEN);

                // Llamada asíncrona al servicio
                var resultados = await _recService.GetLavadoDetalleAsync(
                    fecIni,
                    fecFin,
                    pti: "", // Opcional según tu SP
                    est: BUS_SEC_DES ?? "", // Mapeo según necesidad del SP
                    cet: BUS_REM ?? "",
                    den: BUS_DEN ?? "",
                    sec: BUS_SEC_ORI ?? "",
                    reu: BUS_REU_ID ?? ""
                );

                // Retornamos la vista parcial con los datos mapeados
                return PartialView("_ResultadosRec", resultados);
            }
            catch (Exception ex)
            {
                // En caso de error, devolvemos el mensaje para debug
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}