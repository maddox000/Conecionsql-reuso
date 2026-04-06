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
                var sector = await _context.IbSectores
                    .FirstOrDefaultAsync(s => s.IbSecId == dto.TB_ENT_SEC_ID);

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

                if (usuario == null)
                {
                    return Json(new
                    {
                        success = false,
                        mensaje = "❌ Usuario no encontrado."
                    });
                }

                var nueva = new TbEnt
                {
                    // 📅 FECHA / HORA
                    TbEntFec = DateTime.Today,
                    TbEntHorIni = DateTime.Now,
                    TbEntHorFin = null,

                    // 👤 PERSONAL
                    TbEntPerId = usuario.IbPerId,
                    TbEntPerNom = usuario.IbPerNom,
                    TbEntPerApe = usuario.IbPerApe,
                    TbEntPerCarId = usuario.IbPerCarId,
                    TbEntPerCarDen = usuario.IbPerCarDen,

                    // 🏢 SECTOR DESTINO
                    TbEntSecId = dto.TB_ENT_SEC_ID,
                    TbEntSecDen = sector?.IbSecDen ?? dto.TB_ENT_SEC_DEN,

                    // 🔥 CAMPOS COMPLETOS
                    TbEntSecPer = string.IsNullOrWhiteSpace(dto.TB_ENT_SEC_PER)
         ? "NO REGISTRADO"
         : dto.TB_ENT_SEC_PER,

                    TbEntObs = string.IsNullOrWhiteSpace(dto.TB_ENT_OBS)
         ? ""
         : dto.TB_ENT_OBS,

                    // 📦 TOTAL
                    TbEntCantTot = 0,

                    // 🔧 NUMÉRICOS
                    TbEntNum1 = 0,
                    TbEntNum2 = 0,
                    TbEntNum3 = 0,
                    TbEntNum4 = 0,
                    TbEntNum5 = 0,

                    // 🔧 TEXTOS
                    TbEntTxt1 = null,
                    TbEntTxt2 = null,
                    TbEntTxt3 = null,
                    TbEntTxt4 = null,
                    TbEntTxt5 = null,

                    // 🔧 FECHAS AUX
                    TbEntDti1 = null,
                    TbEntDti2 = null,
                    TbEntDti3 = null,
                    TbEntDti4 = null,
                    TbEntDti5 = null,

                    // 🔧 MEMOS
                    TbEntMem1 = null,
                    TbEntMem2 = null,
                    TbEntMem3 = null,

                    // 🔧 CHECKS
                    TbEntCk1 = false,
                    TbEntCk2 = false,
                    TbEntCk3 = false,
                    TbEntCk4 = false,
                    TbEntCk5 = false,

                    // 🔧 BITS
                    TbEntBit1 = false,
                    TbEntBit2 = false,
                    TbEntBit3 = false,

                    // 🔧 CHECKLIST
                    TbEntCkl1 = false,
                    TbEntCkl2 = false,
                    TbEntCkl3 = false,
                    TbEntCkl4 = false,
                    TbEntCkl5 = false,
                    TbEntCkl6 = false,

                    // 🔧 OTROS
                    TbEntPac = "NO REGISTRADO",
                    TbEntCliId = 0,
                    TbEntCliDen = "NO REGISTRADO",
                    TbEntSecOriId = 1,
                    TbEntSecOriDen = "NO REGISTRADO",
                    TbEntTranspOpcId = 0,
                    TbEntTranspOpcDen = "NO REGISTRADO",

                    // ✏️ EDICIÓN
                    TbEntPerIdEdit = null,
                    TbEntPerNomEdit = null,
                    TbEntPerApeEdit = null,
                    TbEntFecEdit = null,
                    TbEntHorEdit = null,

                    // 🖥️ SISTEMA
                    TbEntPcLog = Environment.MachineName,
                    TbEntPcUsr = User.Identity?.Name ?? "Usuario"
                };

                _context.TbEnt.Add(nueva);
                await _context.SaveChangesAsync();

                // 🔁 Igualar ID_FORM al ID generado
                nueva.TbEntIdForm = nueva.TbEntId;
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