using ConexionSql.Services.InfoBasica.Interfaces;
using ConexionSql.Models.InfoBasica;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConexionSql.Controllers.InfoBasica
{
    [Route("IbEquipos/[action]")]
    public class IbEquiposController : Controller
    {
        private readonly IIbEquiposService _equiposService;

        public IbEquiposController(IIbEquiposService equiposService)
        {
            _equiposService = equiposService;
        }

        // GET: /IbEquipos/Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var lista = await _equiposService.ObtenerTodosAsync();
            // Asegúrate de que este archivo exista en Views/InfoBasica/Index.cshtml
            return View("~/Views/InfoBasica/Index.cshtml", lista);
        }

        // GET: /IbEquipos/Nuevo
        [HttpGet]
        public async Task<IActionResult> Nuevo()
        {
            ViewBag.TiposEquipo = await _equiposService.ObtenerTiposEquipoAsync();
            ViewBag.Marcas = await _equiposService.ObtenerMarcasAsync();
            ViewBag.TiposCiclo = await _equiposService.ObtenerTiposCicloAsync();

            return View("~/Views/InfoBasica/IB_EquiposForm.cshtml", new IbEquDto());
        }

        // GET: /IbEquipos/Editar/5
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var equipo = await _equiposService.ObtenerEquipoPorIdAsync(id);
            if (equipo == null) return RedirectToAction(nameof(Index));

            ViewBag.TiposEquipo = await _equiposService.ObtenerTiposEquipoAsync();
            ViewBag.Marcas = await _equiposService.ObtenerMarcasAsync();
            ViewBag.TiposCiclo = await _equiposService.ObtenerTiposCicloAsync();

            return View("~/Views/InfoBasica/IB_EquiposForm.cshtml", equipo);
        }

        // POST: /IbEquipos/Guardar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Guardar(IbEquDto equipo)
        {
            if (ModelState.IsValid)
            {
                bool ok = await _equiposService.GuardarEquipoAsync(equipo);
                if (ok) return RedirectToAction(nameof(Index));
            }

            // Si falla, recargamos los combos y volvemos al formulario
            ViewBag.TiposEquipo = await _equiposService.ObtenerTiposEquipoAsync();
            ViewBag.Marcas = await _equiposService.ObtenerMarcasAsync();
            ViewBag.TiposCiclo = await _equiposService.ObtenerTiposCicloAsync();

            return View("~/Views/InfoBasica/IB_EquiposForm.cshtml", equipo);
        }
    }
}