using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConexionSql.Data;
using ConexionSql.Models.Lavado;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ConexionSql.Controllers
{
    public class LavadoController : Controller
    {
        private readonly ConexionSqlContext _context;

        public LavadoController(ConexionSqlContext context)
        {
            _context = context;
        }

        // 🔹 GET: Mostrar formulario para crear nuevo lavado
        [HttpGet]
        public async Task<IActionResult> CrearLavado()
        {
            var model = new TbProLavFormDto
            {
                TipoLavadoId = 0,
                EquipoId = 0,
                TipoCicloId = 0
            };

            // ✅ Tipos de Lavado visibles
            model.TiposLavado = await _context.IbLavLti
                .Where(t => !t.IbLavLtiOcu)
                .Select(t => new SelectListItem
                {
                    Value = t.IbLavLtiId.ToString(),
                    Text = t.IbLavLtiDen
                })
                .OrderBy(t => t.Text)
                .ToListAsync();

            // 🔸 Equipos y Tipos de Ciclo vacíos inicialmente
            model.Equipos = new List<SelectListItem>();
            model.TiposCiclo = new List<SelectListItem>();

            // 👤 Usuario logueado
            var usuarioIdSesion = HttpContext.Session.GetString("UsuarioId");

            if (!string.IsNullOrEmpty(usuarioIdSesion))
            {
                var usuario = await _context.IbPers
                    .FirstOrDefaultAsync(p => p.IbPerId == int.Parse(usuarioIdSesion));

                if (usuario != null)
                {
                    ViewBag.UsuarioId = usuario.IbPerId;
                    ViewBag.UsuarioLogueado = $"{usuario.IbPerApe}, {usuario.IbPerNom}";
                    ViewBag.UserCargo = usuario.IbPerCarDen;
                }
            }

            return View("~/Views/Lavado/CrearLavado.cshtml", model);
        }

        // 🔹 GET: Obtener lista de equipos
        [HttpGet]
        public async Task<IActionResult> ObtenerEquiposPorTipo()
        {
            var equipos = await _context.IbEqu
                .Where(e => e.IbEquTeqId == 6)
                .Select(e => new
                {
                    id = e.IbEquId,
                    nombre = e.IbEquMarDen + " - " + e.IbEquMod
                })
                .OrderBy(e => e.nombre)
                .ToListAsync();

            return Json(equipos);
        }

        // 🔹 GET: Obtener tipos de ciclo
        [HttpGet]
        public async Task<IActionResult> ObtenerTiposCiclo()
        {
            var ciclos = await _context.IbLavTci
                .Where(tc => !tc.IbLavTciOcu)
                .Select(tc => new
                {
                    id = tc.IbLavTciId,
                    nombre = tc.IbLavTciDen
                })
                .OrderBy(tc => tc.nombre)
                .ToListAsync();

            return Json(ciclos);
        }

        // 🔹 POST: Insertar nuevo lavado
        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] TbProLavFormDto dto)
        {
            try
            {
                if (dto.TipoLavadoId == 0)
                    return Json(new { success = false, mensaje = "Debe seleccionar el tipo de lavado." });

                // 👤 Usuario desde sesión
                var usuarioIdSesion = HttpContext.Session.GetString("UsuarioId");

                if (string.IsNullOrEmpty(usuarioIdSesion))
                    return Json(new { success = false, mensaje = "No se encontró el usuario logueado." });

                var personal = await _context.IbPers
                    .FirstOrDefaultAsync(p => p.IbPerId == int.Parse(usuarioIdSesion));

                if (personal == null)
                    return Json(new { success = false, mensaje = "No se encontró el personal logueado." });

                var equipo = await _context.IbEqu
                    .FirstOrDefaultAsync(e => e.IbEquId == dto.EquipoId);

                // 📄 Instancia del modelo
                var entidad = new TbProLav
                {
                    TbProLavFec = dto.Fecha ?? DateTime.Now.Date,
                    TbProLavHorIni = new DateTime(1899, 12, 30, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),
                    TbProLavHorFin = null,

                    // 🔢 Número de ciclo y observaciones
                    TbProLavNum = dto.NumeroCiclo ?? 0,
                    TbProLavObs = string.IsNullOrWhiteSpace(dto.Observaciones)
                        ? "NO REGISTRA"
                        : dto.Observaciones,

                    // 🧼 Tipo de lavado / ciclo / equipo
                    TbProLavPtiId = dto.TipoLavadoId,
                    TbProLavPtiDen = dto.TipoLavadoDen,

                    TbProLavEquId = dto.EquipoId,
                    TbProLavEquDen = dto.EquipoDen,
                    TbProLavEquNum = equipo?.IbEquNum?.ToString(),
                    TbProIbEquTeqId = equipo?.IbEquTeqId,
                    TbProIbEquTeqDen = equipo?.IbEquTeqDen,
                    TbProLavEquMarId = equipo?.IbEquMarId,
                    TbProLavEquMarDen = equipo?.IbEquMarDen,
                    TbProLavEquSer = equipo?.IbEquSer,
                    TbProLavEquMod = equipo?.IbEquMod,

                    // ⚙️ Datos de capacidad del equipo
                    TbProLavEquCap = equipo?.IbEquCap,
                    TbProLavEquCapu = equipo?.IbEquCapu,
                    TbProLavEquCapr = 0,
                    TbProLavEquPco = equipo?.IbEquPco,
                    TbProLavEquPve = equipo?.IbEquPve,
                    

                    TbProLavTciId = dto.TipoCicloId,
                    TbProLavTciDen = dto.TipoCicloDen,

                    // 📌 Estado inicial
                    TbProLavUpro = 0,
                    TbProLavEstId = 1,
                    TbProLavEstDen = "EN PROCESO",
                    TbProLavEstFec = null,

                    // 🧴 Detergente / dilución / contacto hardcodeado por ahora
                    TbProLavDetgMarId = 1,
                    TbProLavDetgMarDen = "NO REGISTRADO",
                    TbProLavDetgLot = "NO REGISTRADO",
                    TbProLavDetgVen = "NO REGISTRADO",
                    TbProLavDetgDilId = 1,
                    TbProLavDetgDilDen = "NO REGISTRADO",
                    TbProLavDetgCtoId = 1,
                    TbProLavDetgCtoDen = "NO REGISTRADO",

                    // 📍 Ubicación / contenedor hardcodeado por ahora
                    TbProLavUbieId = 1,
                    TbProLavUbieDen = "NO REGISTRADO",
                    TbProLavContId = 1,
                    TbProLavContDen = "NO REGISTRADO",

                    // ✅ Opciones / controles iniciales
                    TbProLavUbieOpc = false,
                    TbProLavConlOpc = false,

                    TbProLavLpaPerId = 1,
                    TbProLavLpaPerNom = "NO REGISTRADO",
                    TbProLavLpaFec = null,
                    TbProLavLpaCk1 = false,
                    TbProLavLpaCk2 = false,
                    TbProLavLpaCk3 = false,
                    TbProLavLpaCk4 = false,
                    TbProLavLpaCk5 = false,

                    TbProLavLmat = 0,

                    // 👤 Cliente hardcodeado por ahora
                    TbProLavCliId = 0,
                    TbProLavCliDen = "NO REGISTRADO",

                    // 🌡️ Valores numéricos iniciales
                    TbProDecLavTemp = 0,
                    TbProDecAguVol = 0,
                    TbProDecDetVol = 0,

                    // 👤 Personal
                    TbProLavPerId = personal.IbPerId,
                    TbProLavPerApe = null,
                    TbProLavPerNom = $"{personal.IbPerApe}, {personal.IbPerNom}",
                    TbProLavPerCarId = personal.IbPerCarId,
                    TbProLavPerCarDen = personal.IbPerCarDen,

                    // 🖥️ Log
                    TbProLavPcLog = Environment.MachineName,
                    TbProLavPcUsr = Environment.UserName
                };

                if (dto.TipoLavadoId == 4)
                {
                    entidad.TbProLavEquId = 1;
                    entidad.TbProLavEquDen = "NO REGISTRADO";

                    entidad.TbProLavTciId = 1;
                    entidad.TbProLavTciDen = "NO REGISTRADO";

                    entidad.TbProLavEquNum = null;
                    entidad.TbProIbEquTeqId = null;
                    entidad.TbProIbEquTeqDen = null;
                    entidad.TbProLavEquMarId = null;
                    entidad.TbProLavEquMarDen = null;
                    entidad.TbProLavEquSer = null;
                    entidad.TbProLavEquMod = null;

                    entidad.TbProLavEquCap = null;
                    entidad.TbProLavEquCapu = null;
                    entidad.TbProLavEquCapr = null;
                    entidad.TbProLavEquPco = null;
                    entidad.TbProLavEquPve = null;
                    entidad.TbProLavEquVol = null;

                    entidad.TbProLavPest1 = 0;
                    entidad.TbProLavPest2 = 0;
                    entidad.TbProLavPest3 = 0;
                    entidad.TbProLavPest4 = 0;
                    entidad.TbProLavPestTot = 0;
                }

                _context.TbProLav.Add(entidad);
                await _context.SaveChangesAsync();

                return Json(new { success = true, tbProLavId = entidad.TbProLavId });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = "❌ Error al guardar el lavado: " + ex.Message });
            }
        }
    }
}