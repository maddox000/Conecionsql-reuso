using ConexionSql.Data;
using ConexionSql.Models.Entrega;
using ConexionSql.Models.Estados;
using ConexionSql.Models.IbPer;
using ConexionSql.Models.Materiales;
using ConexionSql.Models.Sectores;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConexionSql.Controllers
{
    public class EntregaController : Controller
    {
        private readonly ConexionSqlContext _context;

        public EntregaController(ConexionSqlContext context)
        {
            _context = context;
        }

        // 🔹 GET: Muestra el formulario para crear una nueva entrega
        [HttpGet]
        public async Task<IActionResult> CrearEntrega()
        {
            var model = new TbEntFormDto
            {
                TB_ENT_FEC = DateTime.Today,
                TB_ENT_HOR_INI = DateTime.Now.ToString("HH:mm"),
                TB_ENT_HOR_FIN = DateTime.Now.ToString("HH:mm"),
                TB_ENT_CANT_TOT = 0
            };

            // 🔽 Lista de personal
            var personal = await _context.IbPers
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
                .ToListAsync();

            // 🔽 Lista de sectores
            var sectores = await _context.IbSectores
                .OrderBy(s => s.IbSecDen)
                .ToListAsync();

            ViewBag.ListaPersonal = personal;
            ViewBag.ListaSectores = sectores;

            // 👤 Traer usuario validado desde sesión
            var usuarioIdSesion = HttpContext.Session.GetString("UsuarioId");

            if (!string.IsNullOrEmpty(usuarioIdSesion))
            {
                var usuario = await _context.IbPers
                    .FirstOrDefaultAsync(p => p.IbPerId == int.Parse(usuarioIdSesion));

                if (usuario != null)
                {
                    ViewBag.UsuarioId = usuario.IbPerId;
                    ViewBag.UsuarioLogueado = $"{usuario.IbPerApe}, {usuario.IbPerNom}";
                }
            }

            return View(model);
        }

        // 🔹 POST: Guarda la cabecera de entrega
        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] TbEntFormDto dto)
        {
            try
            {
                // 🔍 Buscar datos reales
                var personal = await _context.IbPers
                    .FirstOrDefaultAsync(p => p.IbPerId == dto.TB_ENT_PER_ID);

                var sector = await _context.IbSectores
                    .FirstOrDefaultAsync(s => s.IbSecId == dto.TB_ENT_SEC_ID);

                // 🔥 CAMBIO: usar UsuarioId como en Recepción
                var usuarioIdSesion = HttpContext.Session.GetString("UsuarioId");

                if (string.IsNullOrEmpty(usuarioIdSesion))
                {
                    return Json(new
                    {
                        success = false,
                        mensaje = "❌ No hay usuario en sesión."
                    });
                }

                var usuario = await _context.IbPers
                    .FirstOrDefaultAsync(p => p.IbPerId == int.Parse(usuarioIdSesion));

                var nueva = new TbEnt
                {
                    TbEntFec = DateTime.Today,
                    TbEntHorFin = null,

                    // 👤 USUARIO (igual que Recepción)
                    TbEntPerId = int.Parse(usuarioIdSesion),
                    TbEntPerNom = usuario != null
                        ? $"{usuario.IbPerApe}, {usuario.IbPerNom}"
                        : dto.TB_ENT_PER_NOM,

                    // 🏢 Sector
                    TbEntSecId = dto.TB_ENT_SEC_ID,
                    TbEntSecDen = sector?.IbSecDen ?? dto.TB_ENT_SEC_DEN,

                    TbEntCantTot = 0,
                    TbEntPcLog = Environment.MachineName,

                    // 👤 Usuario sistema (NO tocar)
                    TbEntPcUsr = User.Identity?.Name ?? "Usuario"
                };

                _context.TbEnt.Add(nueva);
                await _context.SaveChangesAsync();

                return Json(new
                {
                    success = true,
                    tbEntId = nueva.TbEntId
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    mensaje = "ERROR: " + ex.Message
                });
            }
        }
    }
}