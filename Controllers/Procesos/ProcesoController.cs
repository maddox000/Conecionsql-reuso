using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConexionSql.Data;
using ConexionSql.Models.Procesos;
using ConexionSql.Models.Equipos;
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

            // 🔸 Equipos dinámicos
            model.Equipos = new List<SelectListItem>();

            // 🔸 Tipos de Ciclo dinámicos
            model.TiposCiclo = new List<SelectListItem>();

            return View("~/Views/Procesos/CrearProcesos.cshtml", model);
        }

        // 🔸 Tipos de Ciclo por tipo de proceso
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
            if (dto == null)
            {
                return Json(new
                {
                    success = false,
                    mensaje = "❌ dto vino null."
                });
            }
            Console.WriteLine($"TipoProcesoId: {dto.TipoProcesoId}");
            Console.WriteLine($"TipoCicloId: {dto.TipoCicloId}");
            Console.WriteLine($"TipoCicloDen: {dto.TipoCicloDen}");

            try
            {
                var esExterno = dto.TipoProcesoId == 5;
                var equipoIdReal = esExterno ? 1 : dto.EquipoId;

                var equipo = await _context.IbEqu
                    .FirstOrDefaultAsync(e => e.IbEquId == equipoIdReal);

                if (equipo == null)
                {
                    return Json(new
                    {
                        success = false,
                        mensaje = "❌ Equipo no encontrado."
                    });
                }

                var personal = await _context.IbPers
                    .FirstOrDefaultAsync(p => p.IbPerId == dto.UsuarioId);

                if (personal == null)
                {
                    return Json(new
                    {
                        success = false,
                        mensaje = "❌ Usuario logueado no encontrado."
                    });
                }

                var nuevo = new TbPro
                {
                    // Tipo proceso
                    TbProPtiId = dto.TipoProcesoId,
                    TbProPtiDen = dto.TipoProcesoDen,

                    // Equipo
                    TbProEquId = equipoIdReal,
                    TbProEquDen = equipo.IbEquTeqDen,
                    TbProEquNum = equipo.IbEquNum,
                    TbProEquMarId = equipo.IbEquMarId,
                    TbProEquMarDen = equipo.IbEquMarDen,
                    TbProEquMod = equipo.IbEquMod,
                    TbProEquSer = equipo.IbEquSer,
                    TbProIbEquTeqId = equipo.IbEquTeqId,
                    TbProIbEquTeqDen = equipo.IbEquTeqDen,
                    TbProUpro = 0,

                    IbEquCap = equipo.IbEquCap,
                    IbEquCapu = equipo.IbEquCapu,
                    IbEquCapr = 0,
                    IbEquPco = equipo.IbEquPco,
                    IbEquPve = equipo.IbEquPve,

                    TbProCant = 0,

                    // Proveedor
                    TbProProvId = esExterno ? dto.ProveedorId : 1,
                    TbProProvDen = esExterno ? dto.ProveedorDen : "NO REGISTRA",

                    // Tipo ciclo
                    TbProTciId = dto.TipoCicloId,
                    TbProTciDen = dto.TipoCicloDen,

                    // Personal logueado
                    TbProPerId = personal.IbPerId,
                    TbProPerNom = $"{personal.IbPerApe} {personal.IbPerNom}".Trim(),
                    TbProPerApe = "",
                    TbProPerCarId = personal.IbPerCarId,
                    TbProPerCarDen = personal.IbPerCarDen,

                    // Fecha / hora
                    TbProFec = DateTime.Today,
                    TbProHorIni = DateTime.Now,
                    TbProHorFin = null,

                    // Estado
                    IbProEstId = 1,
                    IbProEstDen = "EN PROCESO",

                    // Auditoría
                    TbProPcLog = Environment.MachineName,
                    TbProPcUsr = personal.IbPerNom,

                    TbProCext = 0,
                    // Auxiliares
                    TbProTxt2 = dto.TipoProcesoDen,
                    TbProNum1 = 0,
                    TbProNum2 = 1,
                    TbProNum3 = 0,

                    TbPro1 = 0,
                    TbPro2 = 0,
                    TbPro3 = 0,
                    TbPro4 = 0,
                    TbPro5 = 0,
                    TbPro6 = 0,
                    TbPro7 = 0,
                    TbPro8 = 0,
                    TbPro9 = 0,
                    TbPro10 = 0,
                    TbPro11 = 0,
                    TbPro12 = 0,
                    TbPro13 = 0,
                    TbPro14 = 0,
                    TbPro15 = 0,
                    TbPro16 = 0,
                    TbPro17 = 0,
                    TbPro18 = 0,
                    TbPro19 = 0,
                    TbPro20 = 0,
                    TbPro21 = 0,
                    TbPro22 = 0,
                    TbPro23 = 0,
                    TbPro24 = 0,
                    TbPro25 = 0,
                    TbPro26 = 0,
                    TbPro27 = 0,
                    TbPro28 = 0,
                };

                _context.TbPro.Add(nuevo);
                await _context.SaveChangesAsync();

                var tbProIdGenerado = nuevo.TbProId;

                nuevo.TbProIdForm = tbProIdGenerado;
                await _context.SaveChangesAsync();

                var redirectUrl = Url.Action(
                    "SubFormulario",
                    "TbProDet",
                    new { tbProId = tbProIdGenerado }
                );

                Console.WriteLine($"✅ TB_PRO guardado con ID = {tbProIdGenerado}");
                Console.WriteLine($"✅ redirectUrl = {redirectUrl}");

                return Json(new
                {
                    success = true,
                    tbProId = tbProIdGenerado,
                    redirectUrl = redirectUrl
                });
            }
            catch (Exception ex)
            {
                var errorReal = ex.InnerException?.Message ?? ex.Message;

                Console.WriteLine("❌ Error en Insertar:");
                Console.WriteLine(ex.ToString());

                return Json(new
                {
                    success = false,
                    mensaje = "❌ ERROR REAL: " + errorReal
                });
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
                    nombre = e.IbEquTeqDen
                })
                .OrderBy(e => e.nombre)
                .ToListAsync();

            return Json(equipos);
        }

        // 🔹 GET: Obtener proveedores (IB_EST_PRO)
        [HttpGet]
        public async Task<IActionResult> ObtenerProveedores()
        {
            var proveedores = await _context.IbEstPro
                .Where(p => !p.IbEstProvOcu)
                .Select(p => new
                {
                    id = p.IbEstProvId,
                    nombre = p.IbEstProvDen
                })
                .OrderBy(p => p.nombre)
                .ToListAsync();

            return Json(proveedores);
        }
    }
}