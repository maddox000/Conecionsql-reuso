using ConexionSql.Data;
using ConexionSql.Models.InfoBasica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using ConexionSql.Models.IbPer;

namespace ConexionSql.Controllers.InfoBasica
{
    public class IBPersonalController : Controller
    {
        private readonly ConexionSqlContext _db;

        public IBPersonalController(ConexionSqlContext db) => _db = db;

        public IActionResult IBPersonalListado()
        {
            // Acá agregamos "Dto" en el Set<>
            var lista = _db.Set<IBPersonalDto>().FromSqlRaw("EXEC SP_IBPersonal_Listado").ToList();
            return View("~/Views/InfoBasica/IBPersonalListado.cshtml", lista);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Guardar(IBPersonalGuardarDto dto)
        {
            var cargo = await _db.IbPerCar
                .FirstOrDefaultAsync(c => c.IbPerCarId == dto.CargoId);

            var seccion = await _db.IbSectores
                .FirstOrDefaultAsync(s => s.IbSecId == dto.SectorId);

            var unidad = await _db.IbPerUni
                .FirstOrDefaultAsync(u => u.IbPerUniId == dto.NivelUsuarioId);

            IbPer entidad;

            if (dto.Id > 0)
            {
                entidad = await _db.IbPers
                    .FirstOrDefaultAsync(p => p.IbPerId == dto.Id);

                if (entidad == null)
                    return RedirectToAction(nameof(IBPersonalListado));
            }
            else
            {
                entidad = new IbPer();
                _db.IbPers.Add(entidad);
            }

            entidad.IbPerNom = dto.Nombre;
            entidad.IbPerApe = dto.Apellido;

            entidad.IbPerPas = dto.Password;
            entidad.IbPsw = dto.Password;

            entidad.IbPerUniId = dto.NivelUsuarioId;
            entidad.IbPerUniDen = unidad?.IbUniDen;

            entidad.IbPerCarId = dto.CargoId;
            entidad.IbPerCarDen = cargo?.IbPerCarDen;

            entidad.IbSecId = dto.SectorId;
            entidad.IbSecDen = seccion?.IbSecDen;

            entidad.IbPerOcu = dto.Inhabilitado;

            entidad.IbPerPcLog = Environment.MachineName;
            entidad.IbPerPcUsr = Environment.UserName;

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(IBPersonalListado));
        }

        //metodos para traer las listas

        [HttpGet]
        public IActionResult BuscarCargos(string texto)
        {
            var lista = _db.IbPerCar
                .Where(c => string.IsNullOrEmpty(texto)
                         || c.IbPerCarDen.Contains(texto))
                .Select(c => new
                {
                    id = c.IbPerCarId,
                    den = c.IbPerCarDen
                })
                .Take(20)
                .ToList();

            return Json(lista);
        }

        [HttpGet]
        public IActionResult BuscarNivelesUsuario(string texto)
        {
            var lista = _db.IbPerUni
                .Where(u => string.IsNullOrEmpty(texto)
                         || u.IbUniDen.Contains(texto))
                .Select(u => new
                {
                    id = u.IbPerUniId,
                    den = u.IbUniDen
                })
                .Take(20)
                .ToList();

            return Json(lista);
        }

        [HttpGet]
        public IActionResult BuscarSectores(string texto)
        {
            var lista = _db.IbSectores
                .Where(s => string.IsNullOrEmpty(texto)
                         || s.IbSecDen.Contains(texto))
                .Select(s => new
                {
                    id = s.IbSecId,
                    den = s.IbSecDen
                })
                .Take(20)
                .ToList();

            return Json(lista);
        }

        // editar personal

        [HttpGet]
        public async Task<IActionResult> ObtenerPersonal(int id)
        {
            var persona = await _db.IbPers
                .Where(p => p.IbPerId == id)
                .Select(p => new
                {
                    id = p.IbPerId,
                    apellido = p.IbPerApe ?? "",
                    nombre = p.IbPerNom ?? "",

                    cargoId = p.IbPerCarId ?? 0,
                    cargo = p.IbPerCarDen ?? "",

                    nivelUsuarioId = p.IbPerUniId ?? 0,
                    nivelUsuario = p.IbPerUniDen ?? "",

                    sectorId = p.IbSecId ?? 0,
                    sector = p.IbSecDen ?? "",

                    inhabilitado = p.IbPerOcu,
                    password = p.IbPsw,
                    passwordRepite = p.IbPsw
                })
                .FirstOrDefaultAsync();

            if (persona == null)
            {
                return Json(new { success = false, mensaje = "No se encontró el personal." });
            }

            return Json(new { success = true, data = persona });
        }
    }
}