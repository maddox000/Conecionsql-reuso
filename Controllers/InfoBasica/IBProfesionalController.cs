using ConexionSql.Data;
using ConexionSql.InfoBasica.Dtos;
using ConexionSql.Models.Profesionales;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConexionSql.InfoBasica.Controllers
{
    public class IBProfesionalController : Controller
    {
        private readonly ConexionSqlContext _db;

        public IBProfesionalController(ConexionSqlContext db) => _db = db;

        public IActionResult IBProfesional()
        {
            var lista = _db.Set<IbPro>()
                .FromSqlRaw("EXEC SP_IBProfesional_Listar")
                .ToList();

            return View("~/Views/InfoBasica/IBProfesional.cshtml", lista);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Guardar(IBProfesionalDto dto)
        {
            _db.Database.ExecuteSqlRaw(
                "EXEC SP_IBProfesional_Guardar @p0, @p1, @p2, @p3",
                dto.Id,
                dto.Nombre,
                dto.Apellido,
                dto.Oculto
            );

            return RedirectToAction("IBProfesional");
        }

        [HttpGet]
        public IActionResult Obtener(int id)
        {
            var profesional = _db.Set<IbPro>()
                .FromSqlRaw("EXEC SP_IBProfesional_Listar")
                .AsEnumerable()
                .FirstOrDefault(x => x.IbProId == id);

            if (profesional == null)
                return NotFound();

            return Json(new
            {
                iB_PRO_ID = profesional.IbProId,
                iB_PRO_NOM = profesional.IbProNom,
                iB_PRO_APE = profesional.IbProApe,
                iB_PRO_OCU = profesional.IbProOcu
            });
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            _db.Database.ExecuteSqlRaw("EXEC SP_IBProfesional_Eliminar @p0", id);
            return RedirectToAction("IBProfesional");
        }
    }
}