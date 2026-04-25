using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConexionSql.Data;
using ConexionSql.Models;
using ConexionSql.Models.IbPer;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConexionSql.Controllers.Personal
{
    public class IbPerController : Controller
    {
        private readonly ConexionSqlContext _context;

        public IbPerController(ConexionSqlContext context)
        {
            _context = context;
        }

        // GET: IbPer
        public async Task<IActionResult> Index()
        {
            var ibPers = await _context.IbPers
                .Select(p => new IbPerDto
                {
                    IbPerId = p.IbPerId,
                    IbPerNom = p.IbPerNom,
                    IbPerApe = p.IbPerApe
                })
                .ToListAsync();

            return View("~/Views/IbPer/ListaPersonal.cshtml", ibPers);
        }

        // GET: IbPer/IbPerEdit
        public async Task<IActionResult> IbPerEdit()
        {
            var personas = await _context.IbPers
                .Select(p => new IbPerDto
                {
                    IbPerId = p.IbPerId,
                    IbPerNom = p.IbPerNom,
                    IbPerApe = p.IbPerApe
                })
                .ToListAsync();

            var viewModel = new IbPerEditDto { Personas = personas };
            return View(viewModel);
        }

        // POST: IbPer/IbPerEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IbPerEdit(IbPerEditDto viewModel)
        {
            if (ModelState.IsValid)
            {
                foreach (var personaDto in viewModel.Personas)
                {
                    var persona = await _context.IbPers.FindAsync(personaDto.IbPerId);
                    if (persona != null)
                    {
                        persona.IbPerNom = personaDto.IbPerNom;
                        persona.IbPerApe = personaDto.IbPerApe;
                    }
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        // GET: IbPer/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var persona = await _context.IbPers.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }

            var personaDto = new IbPerDto
            {
                IbPerId = persona.IbPerId,
                IbPerNom = persona.IbPerNom,
                IbPerApe = persona.IbPerApe
            };

            return View(personaDto);
        }

        // POST: IbPer/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(IbPerDto model)
        {
            if (ModelState.IsValid)
            {
                var persona = await _context.IbPers.FindAsync(model.IbPerId);
                if (persona == null)
                {
                    return NotFound();
                }

                persona.IbPerNom = model.IbPerNom;
                persona.IbPerApe = model.IbPerApe;

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: IbPer/InsertIbPer
        [HttpGet]
        public IActionResult InsertIbPer()
        {
            ViewBag.Unidades = _context.IbPerUni
                .Select(u => new SelectListItem
                {
                    Value = u.IbPerUniId.ToString(),
                    Text = u.IbUniDen
                }).ToList();

            ViewBag.Cargos = _context.IbPerCar
                .Select(c => new SelectListItem
                {
                    Value = c.IbPerCarId.ToString(),
                    Text = c.IbPerCarDen
                }).ToList();

            ViewBag.Secciones = _context.IbSectores
                .Select(s => new SelectListItem
                {
                    Value = s.IbSecId.ToString(),
                    Text = s.IbSecDen
                }).ToList();


            return View("InsertIbPer");
        }

        // POST: IbPer/InsertIbPer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertIbPer(IbPerDto nuevoPersonal)
        {
            if (ModelState.IsValid)
            {
                var unidad = await _context.IbPerUni.FirstOrDefaultAsync(u => u.IbPerUniId == nuevoPersonal.IbPerUniId);
                var cargo = await _context.IbPerCar.FirstOrDefaultAsync(c => c.IbPerCarId == nuevoPersonal.IbPerCarId);
                var seccion = await _context.IbSectores.FirstOrDefaultAsync(s => s.IbSecId == nuevoPersonal.IbSecId);

                var entidad = new IbPer
                {
                    IbPerLeg = nuevoPersonal.IbPerLeg,
                    IbPerNom = nuevoPersonal.IbPerNom,
                    IbPerApe = nuevoPersonal.IbPerApe,
                    IbPerPas = nuevoPersonal.IbPerPas,
                    IbPsw = nuevoPersonal.IbPsw,

                    IbPerUniId = nuevoPersonal.IbPerUniId,
                    IbPerUniDen = unidad?.IbUniDen,

                    IbPerCarId = nuevoPersonal.IbPerCarId,
                    IbPerCarDen = cargo?.IbPerCarDen,

                    IbSecId = nuevoPersonal.IbSecId,
                    IbSecDen = seccion?.IbSecDen,

                    IbPerOcu = true // ✅ requerido
                };

                _context.IbPers.Add(entidad);
                await _context.SaveChangesAsync();

                // ✅ Mostrar mensaje de éxito
                TempData["MensajeExito"] = "El personal fue registrado correctamente.";

                return RedirectToAction(nameof(Index));
            }

            // Si hay error de validación, recargar combos
            ViewBag.Unidades = _context.IbPerUni
                .Select(u => new SelectListItem
                {
                    Value = u.IbPerUniId.ToString(),
                    Text = u.IbUniDen
                }).ToList();

            ViewBag.Cargos = _context.IbPerCar
                .Select(c => new SelectListItem
                {
                    Value = c.IbPerCarId.ToString(),
                    Text = c.IbPerCarDen
                }).ToList();

            ViewBag.Secciones = _context.IbSectores
                .Select(s => new SelectListItem
                {
                    Value = s.IbSecId.ToString(),
                    Text = s.IbSecDen
                }).ToList();

            return View("InsertIbPer", nuevoPersonal);
        }




    }
}




