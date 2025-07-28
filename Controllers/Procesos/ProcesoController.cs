using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConexionSql.Data;
using ConexionSql.Models.Procesos;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ConexionSql.Controllers
{
    public class ProcesoController : Controller
    {
        private readonly ConexionSqlContext _context;

        public ProcesoController(ConexionSqlContext context)
        {
            _context = context;
        }

        // 🔹 GET: Mostrar formulario para crear nuevo proceso
        [HttpGet]
        public async Task<IActionResult> CrearProceso()
        {
            var model = new TbProFormDto
            {
                TipoProcesoId = 0,
                EquipoId = 0,
                TipoCicloId = 0
            };

            // 🔸 Tipos de Proceso
            model.TiposProceso = await _context.IbEquPti
                .Where(p => !p.IbEquPtiOcu && !new[] { 6, 7 }.Contains(p.IbEquPtiId))
                .Select(p => new SelectListItem
                {
                    Value = p.IbEquPtiId.ToString(),
                    Text = p.IbEquPtiDen
                })
                .OrderBy(p => p.Text)
                .ToListAsync();



            // 🔸 Equipos: se cargan dinámicamente según el tipo seleccionado
            model.Equipos = new List<SelectListItem>();
            // 🔸 Tipos de Ciclo: se cargan dinámicamente según el tipo seleccionado
            model.TiposCiclo = new List<SelectListItem>();
            return View("~/Views/Procesos/CrearProcesos.cshtml", model);
        }

        // 🔸 Tipos de Ciclo
        [HttpGet]
        public async Task<IActionResult> ObtenerTiposCicloPorProceso(int ptiId)
        {
            Console.WriteLine($"🎯 ObtenerTiposCicloPorProceso ejecutado con ptiId = {ptiId}");
            var ciclos = await _context.IbProTci
                .Where(tc => !tc.TbProPtiOcu && tc.TbProPtiId == ptiId)
                .Select(tc => new
                {
                    id = tc.TbProTciId,
                    nombre = tc.TbProTciDen
                })
                .OrderBy(tc => tc.nombre)
                .ToListAsync();

            return Json(ciclos);
        }


        // 🔹 POST: Insertar nueva cabecera de proceso
        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] TbProFormDto dto)
        {
            try
            {
                var nuevo = new TbPro
                {
                    TbProPtiId = dto.TipoProcesoId,
                    TbProPtiDen = dto.TipoProcesoDen,
                    TbProEquId = dto.EquipoId,
                    TbProEquDen = dto.EquipoDen,
                    TbProTciId = dto.TipoCicloId,
                    TbProTciDen = dto.TipoCicloDen,
                    TbProFec = DateTime.Today,
                    TbProHorIni = DateTime.Now,
                    TbProHorFin = null,
                    TbProPcLog = Environment.MachineName,
                    TbProPcUsr = User.Identity?.Name ?? "Usuario"
                };

                _context.TbPro.Add(nuevo);
                await _context.SaveChangesAsync();

                // ✅ Respuesta esperada por el frontend (igual que Entrega)
                return Json(new { success = true, tbProId = nuevo.TbProId });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = "❌ ERROR: " + ex.Message });
            }
        }


        // 🔹 GET: Obtener lista de equipos según tipo de proceso
        [HttpGet]
        public async Task<IActionResult> ObtenerEquiposPorTipo(int ptiId)
        {
            var equipos = await _context.IbEqu
                .Where(e => e.IbEquPtiId == ptiId && e.IbEquTeqDen != null)
                .Select(e => new
                {
                    id = e.IbEquId,
                    nombre = e.IbEquTeqDen // ✅ Denominación correcta
                })
                .OrderBy(e => e.nombre)
                .ToListAsync();

            return Json(equipos);
        }
    }
}
