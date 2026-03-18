using Microsoft.AspNetCore.Mvc;
using ConexionSql.Data;
using ConexionSql.Models.Recepciones;
using ConexionSql.Models.IbPer;
using ConexionSql.Models.Materiales;
using ConexionSql.Models.Estados;
using System;
using System.Linq;
using System.Collections.Generic;

namespace ConexionSql.Controllers.Recepcion
{
    public class RecepcionController : Controller
    {
        private readonly ConexionSqlContext _context;

        public RecepcionController(ConexionSqlContext context)
        {
            _context = context;
        }

        // 📄 Vista principal de recepción (la que estás usando ahora: /Recepcion/TbRecIndex)
        public IActionResult TbRecIndex()
        {
            // 🔽 Trae recepciones por si las usás después en la vista
            var listaRecepciones = _context.TbRec.ToList();

            // 🔽 Lista de personal
            var personal = _context.IbPers
                .OrderBy(p => p.IbPerApe)
                .ThenBy(p => p.IbPerNom)
                .Select(p => new IbPerDto
                {
                    IbPerId = p.IbPerId,
                    IbPerNom = p.IbPerNom,
                    IbPerApe = p.IbPerApe
                })
                .ToList();

            // 🔽 Lista de sectores
            var sectores = _context.IbSectores
                .OrderBy(s => s.IbSecDen)
                .ToList();

            ViewBag.ListaPersonal = personal;
            ViewBag.ListaSectores = sectores;
            ViewBag.ListaRecepciones = listaRecepciones;

            // 👤 Traer usuario validado desde sesión
            var usuarioIdSesion = HttpContext.Session.GetString("UsuarioId");

            if (!string.IsNullOrEmpty(usuarioIdSesion))
            {
                var usuario = _context.IbPers
                    .FirstOrDefault(p => p.IbPerId == int.Parse(usuarioIdSesion));

                if (usuario != null)
                {
                    ViewBag.UsuarioId = usuario.IbPerId;
                    ViewBag.UsuarioLogueado = $"{usuario.IbPerApe}, {usuario.IbPerNom}";
                }
            }

            // ⚠️ Esta vista espera un TbRec, no una lista
            return View(new TbRec());
        }

        // ➕ GET: Nueva recepción
        [HttpGet]
        public IActionResult CrearRecepcion()
        {
            // 🔽 Cargar combos de personal
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

            // 🔽 Cargar combos de sectores
            var sectores = _context.IbSectores
                .OrderBy(s => s.IbSecDen)
                .ToList();

            ViewBag.ListaPersonal = personal;
            ViewBag.ListaSectores = sectores;

            // 👤 Traer usuario validado desde sesión
            var usuarioIdSesion = HttpContext.Session.GetString("UsuarioId");

            if (!string.IsNullOrEmpty(usuarioIdSesion))
            {
                var usuario = _context.IbPers
                    .FirstOrDefault(p => p.IbPerId == int.Parse(usuarioIdSesion));

                if (usuario != null)
                {
                    ViewBag.UsuarioId = usuario.IbPerId;
                    ViewBag.UsuarioLogueado = $"{usuario.IbPerApe}, {usuario.IbPerNom}";
                }
            }

            return View(new TbRec());
        }

        // 💾 POST: Guardar nueva recepción
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearRecepcion(TbRec nuevaRecepcion)
        {
            if (ModelState.IsValid)
            {
                // 👤 Traer usuario desde sesión
                var usuarioIdSesion = HttpContext.Session.GetString("UsuarioId");

                // 👉 Si existe en sesión, lo asignamos a la cabecera
                if (!string.IsNullOrEmpty(usuarioIdSesion))
                {
                    nuevaRecepcion.TbRecPerId = int.Parse(usuarioIdSesion);
                }

                // 🔄 Buscar datos completos del personal desde DB
                var personal = !string.IsNullOrEmpty(usuarioIdSesion)
                    ? _context.IbPers.FirstOrDefault(p => p.IbPerId == int.Parse(usuarioIdSesion))
                    : null;

                // 🔄 Buscar sectores seleccionados
                var sectorOrigen = _context.IbSectores
                    .FirstOrDefault(s => s.IbSecId == nuevaRecepcion.TbRecSecOriId);

                var sectorDestino = _context.IbSectores
                    .FirstOrDefault(s => s.IbSecId == nuevaRecepcion.TbRecSecDesId);

                // 🕒 Datos automáticos
                nuevaRecepcion.TbRecFec = DateTime.Today;
                nuevaRecepcion.TbRecPcLog = Environment.MachineName;
                nuevaRecepcion.TbRecPcUsr = User.Identity?.Name ?? "Usuario";

                // 👤 Completar datos del usuario logueado en TB_REC
                if (personal != null)
                {
                    nuevaRecepcion.TbRecPerNom = $"{personal.IbPerApe}, {personal.IbPerNom}";
                    nuevaRecepcion.TbRecPerCarId = personal.IbPerCarId;
                    nuevaRecepcion.TbRecPerCarDen = personal.IbPerCarDen;

                    // 🔁 También lo devolvemos a la vista
                    ViewBag.UsuarioId = personal.IbPerId;
                    ViewBag.UsuarioLogueado = $"{personal.IbPerApe}, {personal.IbPerNom}";
                }

                // 🏭 Completar nombres de sectores
                if (sectorOrigen != null)
                    nuevaRecepcion.TbRecSecOriDen = sectorOrigen.IbSecDen;

                if (sectorDestino != null)
                    nuevaRecepcion.TbRecSecDesDen = sectorDestino.IbSecDen;

                // 💾 Guardar cabecera en TB_REC
                _context.TbRec.Add(nuevaRecepcion);
                _context.SaveChanges();

                TempData["MensajeExito"] = "Recepción guardada correctamente.";

                // 🔽 Cargar materiales para el subformulario
                var materiales = _context.IbMat
                    .Select(m => new IbMatDto
                    {
                        IbMatId = m.IB_MAT_ID,
                        IbMatDen = m.IB_MAT_DEN
                    })
                    .ToList();

                // 🔽 Cargar estados
                var estados = _context.IbEst
                    .OrderBy(e => e.IbEstDen)
                    .Select(e => new IbEstDto
                    {
                        IbEstId = e.IbEstId,
                        IbEstDen = e.IbEstDen
                    })
                    .ToList();

                // 🧾 Preparar subformulario de detalle
                ViewBag.SubFormularioDetalle = new TbRecDetFormDto
                {
                    Detalle = new TbRecDetDto
                    {
                        TB_REC_ID = nuevaRecepcion.TbRecId
                    },
                    Materiales = materiales,
                    Estados = estados
                };

                ViewBag.Detalles = new List<TbRecDetDto>();
            }

            // 🔁 Recargar listas para redibujar la vista
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

            ViewBag.ListaSectores = _context.IbSectores
                .OrderBy(s => s.IbSecDen)
                .ToList();

            // 👤 Si todavía no se cargó el nombre, volver a traerlo
            if (ViewBag.UsuarioLogueado == null)
            {
                var usuarioIdSesion = HttpContext.Session.GetString("UsuarioId");

                if (!string.IsNullOrEmpty(usuarioIdSesion))
                {
                    var usuario = _context.IbPers
                        .FirstOrDefault(p => p.IbPerId == int.Parse(usuarioIdSesion));

                    if (usuario != null)
                    {
                        ViewBag.UsuarioId = usuario.IbPerId;
                        ViewBag.UsuarioLogueado = $"{usuario.IbPerApe}, {usuario.IbPerNom}";
                    }
                }
            }

            return View(nuevaRecepcion);
        }
    }
}