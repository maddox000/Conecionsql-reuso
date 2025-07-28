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

            // 🔸 Equipos y Tipos de Ciclo: vacíos inicialmente (carga dinámica)
            model.Equipos = new List<SelectListItem>();
            model.TiposCiclo = new List<SelectListItem>();

            return View("~/Views/Lavado/CrearLavado.cshtml", model);
        }

        // 🔹 GET: Obtener lista de equipos (solo equipos con TEQ_ID = 6)
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

        // 🔹 GET: Obtener tipos de ciclo (visibles desde IB_LAV_TCI)
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
                // Validación mínima
                if (dto.TipoLavadoId == 0)
                    return Json(new { success = false, mensaje = "Debe seleccionar el tipo de lavado." });

                // 📄 Instancia del modelo
                var entidad = new TbProLav
                {
                    TbProLavFec = dto.Fecha ?? DateTime.Now.Date,
                    TbProLavHorIni = dto.HoraIni.HasValue ? DateTime.Today.Add(dto.HoraIni.Value) : null,
                    TbProLavHorFin = dto.HoraFin.HasValue ? DateTime.Today.Add(dto.HoraFin.Value) : null,
                    TbProLavPtiId = dto.TipoLavadoId,
                    TbProLavPtiDen = dto.TipoLavadoDen,
                    TbProLavEquId = dto.EquipoId,
                    TbProLavEquDen = dto.EquipoDen,
                    TbProLavTciId = dto.TipoCicloId,
                    TbProLavTciDen = dto.TipoCicloDen,
                    TbProLavPcLog = Environment.MachineName,
                    TbProLavPcUsr = Environment.UserName
                };

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
