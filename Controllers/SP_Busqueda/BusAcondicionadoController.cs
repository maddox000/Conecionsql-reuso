using Microsoft.AspNetCore.Mvc;
using ConexionSql.Services.SP_Busquedas.Interfaces;

namespace ConexionSql.Controllers.SP_Busqueda
{
    public class BusAcondicionadoController : Controller
    {
        private readonly IBusAcondicionadoService _service;

        public BusAcondicionadoController(IBusAcondicionadoService service)
        {
            _service = service;
        }

        public IActionResult IndexAcondicionado()
        {
            ViewBag.FecFin = DateTime.Now.ToString("yyyy-MM-dd");
            ViewBag.FecIni = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
            return View("~/Views/AcoBusqueda/IndexAcondicionado.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Filtrar(DateTime? fecIni, DateTime? fecFin,
            string? cet, string? acoId, string? den, string? reuId, string? sec)
        {
            var resultados = await _service.GetAcondicionadosAsync(fecIni, fecFin, cet, acoId, den, reuId, sec);
            return PartialView("_ResultadosAcondicionado", resultados);
        }
    }
}