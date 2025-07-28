using Microsoft.AspNetCore.Mvc;
using ConexionSql.Data;
using ConexionSql.Models.Acondicionado;
using ConexionSql.Models.IbPer;
using System;
using System.Linq;

namespace ConexionSql.Controllers.Acondicionado
{
    public class AcondicionadoController : Controller
    {
        private readonly ConexionSqlContext _context;

        public AcondicionadoController(ConexionSqlContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Vista principal del módulo Acondicionado.
        /// Lista las cabeceras de acondicionados ya guardadas.
        /// </summary>
        public IActionResult Index()
        {
            var lista = _context.TbProAco.ToList();

            var personal = _context.IbPers
                .OrderBy(p => p.IbPerApe)
                .ThenBy(p => p.IbPerNom)
                .Select(p => new IbPerDto
                {
                    IbPerId = p.IbPerId,
                    IbPerNom = p.IbPerNom,
                    IbPerApe = p.IbPerApe,
                    IbPerCarId = p.IbPerCarId,
                    IbPerCarDen = p.IbPerCarDen
                })
                .ToList();

            ViewBag.ListaPersonal = personal;

            return View(lista);
        }

        /// <summary>
        /// Formulario para crear una nueva cabecera de Acondicionado (GET).
        /// </summary>
        [HttpGet]
        public IActionResult CrearAcondicionado()
        {
            var personal = _context.IbPers
                .OrderBy(p => p.IbPerApe)
                .ThenBy(p => p.IbPerNom)
                .Select(p => new IbPerDto
                {
                    IbPerId = p.IbPerId,
                    IbPerNom = p.IbPerNom,
                    IbPerApe = p.IbPerApe,
                    IbPerCarId = p.IbPerCarId,
                    IbPerCarDen = p.IbPerCarDen
                })
                .ToList();

            ViewBag.ListaPersonal = personal;

            return View();
        }

        /// <summary>
        /// Recibe y guarda la nueva cabecera de Acondicionado (POST).
        /// Luego redirige al subformulario para cargar los detalles.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearAcondicionado(TbProAco nuevaCabecera)
        {
            if (ModelState.IsValid)
            {
                var personal = _context.IbPers.FirstOrDefault(p => p.IbPerId == nuevaCabecera.TbProAcoPerId);

                // Datos de sistema
                nuevaCabecera.TbProAcoFec = DateTime.Today;
                nuevaCabecera.TbProAcoHorIni = DateTime.Now;
                nuevaCabecera.TbProAcoPcLog = Environment.MachineName;
                nuevaCabecera.TbProAcoPcUsr = User.Identity?.Name ?? "Usuario";

                // Copiar nombre y cargo del personal si existe
                if (personal != null)
                {
                    nuevaCabecera.TbProAcoPerNom = $"{personal.IbPerApe}, {personal.IbPerNom}";
                    nuevaCabecera.TbProAcoPerCarId = personal.IbPerCarId;
                    nuevaCabecera.TbProAcoPerCarDen = personal.IbPerCarDen;
                }

                // Guardar cabecera
                _context.TbProAco.Add(nuevaCabecera);
                _context.SaveChanges();

                TempData["MensajeExito"] = "✅ Acondicionado guardado correctamente.";

                // ✅ Redirigir al subformulario con el ID generado
                return RedirectToAction("SubFormAcoDet", "TbProAcoDet", new { id = nuevaCabecera.TbProAcoId });
            }

            // Si falla, volver a cargar la lista de personal
            ViewBag.ListaPersonal = _context.IbPers
                .OrderBy(p => p.IbPerApe)
                .ThenBy(p => p.IbPerNom)
                .Select(p => new IbPerDto
                {
                    IbPerId = p.IbPerId,
                    IbPerNom = p.IbPerNom,
                    IbPerApe = p.IbPerApe,
                    IbPerCarId = p.IbPerCarId,
                    IbPerCarDen = p.IbPerCarDen
                })
                .ToList();

            return View(nuevaCabecera);
        }
    }
}
