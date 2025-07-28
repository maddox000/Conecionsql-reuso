using Microsoft.AspNetCore.Mvc;
using ConexionSql.Data;
using ConexionSql.Models.Recepciones;
using ConexionSql.Models.IbPer;
using ConexionSql.Models.Materiales;
using ConexionSql.Models.Estados; // 👈 necesario para IbEstDto
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

        // 📄 Vista que lista todas las recepciones
        public IActionResult TbRecIndex()
        {
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

            return View();
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

            return View();
        }

        // 💾 POST: Guardar nueva recepción
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearRecepcion(TbRec nuevaRecepcion)
        {
            if (ModelState.IsValid)
            {
                // 🔄 Trae datos relacionados
                var personal = _context.IbPers.FirstOrDefault(p => p.IbPerId == nuevaRecepcion.TbRecPerId);
                var sectorOrigen = _context.IbSectores.FirstOrDefault(s => s.IbSecId == nuevaRecepcion.TbRecSecOriId);
                var sectorDestino = _context.IbSectores.FirstOrDefault(s => s.IbSecId == nuevaRecepcion.TbRecSecDesId);

                // 🕒 Fecha y datos automáticos
                nuevaRecepcion.TbRecFec = DateTime.Today;
                nuevaRecepcion.TbRecPcLog = Environment.MachineName;
                nuevaRecepcion.TbRecPcUsr = User.Identity?.Name ?? "Usuario";

                // 👤 Datos del personal
                if (personal != null)
                {
                    nuevaRecepcion.TbRecPerNom = $"{personal.IbPerApe}, {personal.IbPerNom}";
                    nuevaRecepcion.TbRecPerCarId = personal.IbPerCarId;
                    nuevaRecepcion.TbRecPerCarDen = personal.IbPerCarDen;
                }

                // 🏭 Nombres de sectores
                if (sectorOrigen != null)
                    nuevaRecepcion.TbRecSecOriDen = sectorOrigen.IbSecDen;

                if (sectorDestino != null)
                    nuevaRecepcion.TbRecSecDesDen = sectorDestino.IbSecDen;

                // 💾 Guarda cabecera de recepción
                _context.TbRec.Add(nuevaRecepcion);
                _context.SaveChanges();

                TempData["MensajeExito"] = "Recepción guardada correctamente.";

                // 🔽 Cargar materiales
                var materiales = _context.IbMat
                    .Select(m => new IbMatDto
                    {
                        IbMatId = m.IB_MAT_ID,
                        IbMatDen = m.IB_MAT_DEN
                    }).ToList();

                // 🔽 Cargar estados (nuevo combo después de material)
                var estados = _context.IbEst
                    .OrderBy(e => e.IbEstDen)
                .Select(e => new IbEstDto
                {
                    IbEstId = e.IbEstId,
                    IbEstDen = e.IbEstDen
                })
                .ToList(); // 👈 necesario para convertir a List<IbEstDto>


                // 🧾 Preparar ViewModel para subformulario
                ViewBag.SubFormularioDetalle = new TbRecDetFormDto
                {
                    Detalle = new TbRecDetDto
                    {
                        TB_REC_ID = nuevaRecepcion.TbRecId
                    },
                    Materiales = materiales,
                    Estados = estados // ✅ ahora se pasan los estados
                };

                ViewBag.Detalles = new List<TbRecDetDto>();
            }

            // 🔁 Re-carga combos para redibujar vista principal
            ViewBag.ListaPersonal = _context.IbPers
                .OrderBy(p => p.IbPerApe).ThenBy(p => p.IbPerNom)
                .Select(p => new IbPerDto
                {
                    IbPerId = p.IbPerId,
                    IbPerNom = p.IbPerNom,
                    IbPerApe = p.IbPerApe,
                    IbPerCarId = p.IbPerCarId,
                    IbPerCarDen = p.IbPerCarDen
                }).ToList();

            ViewBag.ListaSectores = _context.IbSectores
                .OrderBy(s => s.IbSecDen)
                .ToList();

            return View(nuevaRecepcion);
        }
    }
}
