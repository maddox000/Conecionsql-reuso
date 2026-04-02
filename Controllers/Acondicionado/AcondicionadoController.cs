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
            // 🔐 Obtener usuario logueado
            var usuarioId = HttpContext.Session.GetString("UsuarioId");

            if (string.IsNullOrEmpty(usuarioId))
            {
                return RedirectToAction("Index", "Home");
            }

            // 🔎 Buscar datos del usuario
            var personal = _context.IbPers
                .FirstOrDefault(x => x.IbPerId.ToString() == usuarioId);

            ViewBag.UsuarioLogueado = personal != null
                ? $"{personal.IbPerApe}, {personal.IbPerNom}"
                : "";

            return View("~/Views/Acondicionado/CrearAcondicionado.cshtml");
        }

        /// <summary>
        /// Recibe y guarda la nueva cabecera de Acondicionado (POST).
        /// Luego redirige al subformulario para cargar los detalles.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CrearAcondicionado(TbProAco model)
        {
            try
            {
                var usuarioId = HttpContext.Session.GetString("UsuarioId");

                if (string.IsNullOrEmpty(usuarioId))
                {
                    return RedirectToAction("Index", "Home");
                }

                var personal = _context.IbPers
                    .FirstOrDefault(x => x.IbPerId.ToString() == usuarioId);

                var entidad = new TbProAco
                {
                    TbProAcoFec = DateTime.Now.Date,
                    TbProAcoHorIni = model.TbProAcoHorIni,
                    TbProAcoHorFin = model.TbProAcoHorFin,
                    TbProAcoUpro = model.TbProAcoUpro,

                    // 👤 Usuario logueado
                    TbProAcoPerId = personal?.IbPerId,
                    TbProAcoPerNom = $"{personal?.IbPerApe}, {personal?.IbPerNom}",
                    TbProAcoPerCarId = personal?.IbPerCarId,
                    TbProAcoPerCarDen = personal?.IbPerCarDen,

                    TbProAcoPcLog = Environment.MachineName,
                    TbProAcoPcUsr = Environment.UserName,

                    TbProAcoNum1 = 0,
                    TbProAcoNum2 = 0,
                    TbProAcoNum3 = 0,
                    TbProAcoTxt1 = "TXT",
                    TbProAcoTxt2 = "TXT",
                    TbProAcoTxt3 = "TXT",
                    // MEM
                    TbProAcoMem1 = "MEM",
                    TbProAcoMem2 = "MEM",
                    TbProAcoMem3 = "MEM",

                    // CLIENTE
                    TbProAcoCliId = 0,
                    TbProAcoCliDen = "NO REGISTRADO",
                };

                _context.TbProAco.Add(entidad);
                await _context.SaveChangesAsync();

                TempData["MensajeExito"] = "✅ Acondicionado creado correctamente";

                return RedirectToAction("SubFormAcoDet", "TbProAcoDet", new { id = entidad.TbProAcoId });
            }
            catch (Exception ex)
            {
                TempData["MensajeExito"] = "❌ Error: " + ex.Message;
                return RedirectToAction("CrearAcondicionado");
            }
        }
    }
}
