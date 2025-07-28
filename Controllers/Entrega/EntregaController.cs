using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConexionSql.Data;
using ConexionSql.Models.Entrega;
using ConexionSql.Models.IbPer;
using ConexionSql.Models.Sectores;
using ConexionSql.Models.Materiales;
using ConexionSql.Models.Estados;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

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

            // 🔽 Lista de personal (DTO)
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

            return View(model);
        }

        // 🔹 POST: Guarda la cabecera de entrega (vía JSON)
        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] TbEntFormDto dto)
        {
            try
            {
                // 🔍 Buscar datos reales desde base
                var personal = await _context.IbPers.FirstOrDefaultAsync(p => p.IbPerId == dto.TB_ENT_PER_ID);
                var sector = await _context.IbSectores.FirstOrDefaultAsync(s => s.IbSecId == dto.TB_ENT_SEC_ID);

                var nueva = new TbEnt
                {
                    TbEntFec = DateTime.Today,
                    TbEntHorFin = null,
                    TbEntPerId = dto.TB_ENT_PER_ID,
                    TbEntPerNom = personal != null ? $"{personal.IbPerApe}, {personal.IbPerNom}" : dto.TB_ENT_PER_NOM,
                    TbEntSecId = dto.TB_ENT_SEC_ID,
                    TbEntSecDen = sector?.IbSecDen ?? dto.TB_ENT_SEC_DEN,
                    TbEntCantTot = 0,
                    TbEntPcLog = Environment.MachineName,
                    TbEntPcUsr = User.Identity?.Name ?? "Usuario"
                };

                _context.TbEnt.Add(nueva);
                await _context.SaveChangesAsync();

                // 🔽 Lista de materiales
                var materiales = await _context.IbMat
                    .Select(m => new IbMatDto
                    {
                        IbMatId = m.IB_MAT_ID,
                        IbMatDen = m.IB_MAT_DEN
                    })
                    .ToListAsync();

                // 🔽 Lista de estados
                var estados = await _context.IbEst
                    .OrderBy(e => e.IbEstDen)
                    .Select(e => new IbEstDto
                    {
                        IbEstId = e.IbEstId,
                        IbEstDen = e.IbEstDen
                    })
                    .ToListAsync();

                // ✅ Preparar DTO para subformulario
                ViewBag.SubFormularioDetalle = new TbEntDetFormDto
                {
                    Detalle = new TbEntDetDto
                    {
                        TB_ENT_ID = nueva.TbEntId
                    }
                    // Si después necesitás pasar `Materiales` o `Estados`, agregalos al DTO
                };

                ViewBag.Detalles = new List<TbEntDetDto>();

                return Json(new { success = true, tbEntId = nueva.TbEntId });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = "ERROR: " + ex.Message });
            }
        }
    }
}
