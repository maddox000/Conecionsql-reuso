using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
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

            if (!string.IsNullOrEmpty(usuarioIdSesion) && int.TryParse(usuarioIdSesion, out int usuarioId))
            {
                var usuario = _context.IbPers
                    .FirstOrDefault(p => p.IbPerId == usuarioId);

                if (usuario != null)
                {
                    ViewBag.UsuarioId = usuario.IbPerId;
                    ViewBag.UsuarioLogueado = $"{usuario.IbPerApe}, {usuario.IbPerNom}";
                }
            }

            // ⚠️ Esta vista espera un TbRec, no una lista
            return View("~/Views/Recepcion/TbRecIndex.cshtml", new TbRec());
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

            if (!string.IsNullOrEmpty(usuarioIdSesion) && int.TryParse(usuarioIdSesion, out int usuarioId))
            {
                var usuario = _context.IbPers
                    .FirstOrDefault(p => p.IbPerId == usuarioId);

                if (usuario != null)
                {
                    ViewBag.UsuarioId = usuario.IbPerId;
                    ViewBag.UsuarioLogueado = $"{usuario.IbPerApe}, {usuario.IbPerNom}";
                }
            }

            return View("~/Views/Recepcion/CrearRecepcion.cshtml", new TbRec());
        }

        // 💾 POST: Guardar nueva recepción
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearRecepcion(TbRec nuevaRecepcion)
        {
            if (ModelState.IsValid)
            {
                // 👤 ==============================
                // USUARIO DESDE SESIÓN
                // ==============================
                var usuarioIdSesion = HttpContext.Session.GetString("UsuarioId");

                if (!string.IsNullOrEmpty(usuarioIdSesion) && int.TryParse(usuarioIdSesion, out int usuarioId))
                {
                    nuevaRecepcion.TbRecPerId = usuarioId;
                }

                // 🔄 Traer datos completos del personal
                var personal = (!string.IsNullOrEmpty(usuarioIdSesion) && int.TryParse(usuarioIdSesion, out int usuarioIdPersonal))
                    ? _context.IbPers.FirstOrDefault(p => p.IbPerId == usuarioIdPersonal)
                    : null;

                // 🔄 Traer sectores
                var sectorOrigen = _context.IbSectores
                    .FirstOrDefault(s => s.IbSecId == nuevaRecepcion.TbRecSecOriId);

                var sectorDestino = _context.IbSectores
                    .FirstOrDefault(s => s.IbSecId == nuevaRecepcion.TbRecSecDesId);

                // 🕒 ==============================
                // FECHA Y HORA
                // ==============================
                var ahora = DateTime.Now;

                // Fecha real
                nuevaRecepcion.TbRecFec = DateTime.Today;

                // Hora tipo Access (base 1899)
                nuevaRecepcion.TbRecHorIni = new DateTime(1899, 12, 30, ahora.Hour, ahora.Minute, ahora.Second);

                // Horario fin se completa después
                nuevaRecepcion.TbRecHorFin = null;

                // 💻 Datos de máquina
                nuevaRecepcion.TbRecPcLog = Environment.MachineName;
                nuevaRecepcion.TbRecPcUsr = User.Identity?.Name ?? "Usuario";

                // 👤 ==============================
                // DATOS DEL PERSONAL
                // ==============================
                if (personal != null)
                {
                    nuevaRecepcion.TbRecPerNom = $"{personal.IbPerApe}, {personal.IbPerNom}";
                    nuevaRecepcion.TbRecPerCarId = personal.IbPerCarId;
                    nuevaRecepcion.TbRecPerCarDen = personal.IbPerCarDen;

                    ViewBag.UsuarioId = personal.IbPerId;
                    ViewBag.UsuarioLogueado = $"{personal.IbPerApe}, {personal.IbPerNom}";
                }

                // 🏭 ==============================
                // SECTORES
                // ==============================
                if (sectorOrigen != null)
                    nuevaRecepcion.TbRecSecOriDen = sectorOrigen.IbSecDen;

                if (sectorDestino != null)
                    nuevaRecepcion.TbRecSecDesDen = sectorDestino.IbSecDen;

                // 🔴 ==============================
                // CAMPOS FIJOS / DEFAULT SISTEMA
                // ==============================

                nuevaRecepcion.TbRecOrtId = 1;
                nuevaRecepcion.TbRecOrtDen = "NO REGISTRA";

                nuevaRecepcion.TbRecSecPer = "NO REGISTRADO";

                if (string.IsNullOrEmpty(nuevaRecepcion.TbRecObs))
                    nuevaRecepcion.TbRecObs = "";

                nuevaRecepcion.TbRecCantTot = 0;

                nuevaRecepcion.TbRecNum1 = 1;
                nuevaRecepcion.TbRecNum2 = 2;
                nuevaRecepcion.TbRecNum3 = 3;

                nuevaRecepcion.TbRecTxt1 = "NO REGISTRADO";
                nuevaRecepcion.TbRecTxt2 = "TXT";
                nuevaRecepcion.TbRecTxt3 = "TXT";

                nuevaRecepcion.TbRecMem1 = "MEM";
                nuevaRecepcion.TbRecMem2 = "MEM";
                nuevaRecepcion.TbRecMem3 = "MEM";

                nuevaRecepcion.TbRecCliId = 0;
                nuevaRecepcion.TbRecCliDen = "NO REGISTRADO";

                // 💾 ==============================
                // GUARDAR CABECERA
                // ==============================
                _context.TbRec.Add(nuevaRecepcion);
                _context.SaveChanges();

                TempData["MensajeExito"] = "Recepción guardada correctamente.";

                // 📦 ==============================
                // CARGAR SUBFORMULARIO DETALLE
                // ==============================
                var materiales = _context.IbMat
                    .Select(m => new IbMatDto
                    {
                        IbMatId = m.IB_MAT_ID,
                        IbMatDen = m.IB_MAT_DEN,
                        IbMatMarDen = m.IB_MAT_MAR_DEN,
                        IbMatProDen = m.IB_MAT_PRO_DEN,
                        IbMatMtiDen = m.IB_MAT_MTI_DEN
                    })
                    .ToList();

                var revisiones = _context.IbMatRevisiones
                    .Where(r => !r.IbMatRevOcu)
                    .OrderBy(r => r.IbMatRevDen)
                    .Select(r => new IbMatRevDto
                    {
                        IbMatRevId = r.IbMatRevId,
                        IbMatRevDen = r.IbMatRevDen
                    })
                    .ToList();

                var estados = _context.IbEst
                    .OrderBy(e => e.IbEstDen)
                    .Select(e => new IbEstDto
                    {
                        IbEstId = e.IbEstId,
                        IbEstDen = e.IbEstDen
                    })
                    .ToList();

                ViewBag.SubFormularioDetalle = new TbRecDetFormDto
                {
                    Detalle = new TbRecDetDto
                    {
                        TB_REC_ID = nuevaRecepcion.TbRecId
                    },
                    Materiales = materiales,
                    Revisiones = revisiones,
                    Estados = estados
                };

                ViewBag.Detalles = new List<TbRecDetDto>();
            }

            // 🔁 ==============================
            // RECARGA DE LISTAS
            // ==============================
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

            // 👤 ==============================
            // RECUPERAR USUARIO SI NO VIENE
            // ==============================
            if (ViewBag.UsuarioLogueado == null)
            {
                var usuarioIdSesion = HttpContext.Session.GetString("UsuarioId");

                if (!string.IsNullOrEmpty(usuarioIdSesion) && int.TryParse(usuarioIdSesion, out int usuarioId))
                {
                    var usuario = _context.IbPers
                        .FirstOrDefault(p => p.IbPerId == usuarioId);

                    if (usuario != null)
                    {
                        ViewBag.UsuarioId = usuario.IbPerId;
                        ViewBag.UsuarioLogueado = $"{usuario.IbPerApe}, {usuario.IbPerNom}";
                    }
                }
            }

            return View("~/Views/Recepcion/CrearRecepcion.cshtml", nuevaRecepcion);
        }
    }
}