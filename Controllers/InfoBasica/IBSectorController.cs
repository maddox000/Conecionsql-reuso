using ConexionSql.Data;
using ConexionSql.Models.InfoBasica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConexionSql.Controllers.InfoBasica
{
    public class IBSectorController : Controller
    {
        private readonly ConexionSqlContext _db;

        public IBSectorController(ConexionSqlContext db) => _db = db;

        // Carga la pantalla principal con la grilla
        public IActionResult IBSector()
        {
            var lista = _db.Set<IBSector>().FromSqlRaw("EXEC SP_IBSector_Listado").ToList();
            return View("~/Views/InfoBasica/IBSector.cshtml", lista);
        }

        // Obtiene un sector específico para el modal Editar
        [HttpGet]
        public IActionResult Obtener(int id)
        {
            var sector = _db.Set<IBSector>().FromSqlRaw("EXEC SP_IBSector_Listado").AsEnumerable()
                            .FirstOrDefault(x => x.SectorId == id);
            return Json(sector);
        }

        // Guarda el formulario completo del modal (Botón Guardar)
        [HttpPost]
        public IActionResult Guardar(IBSector model)
        {
            _db.Database.ExecuteSqlRaw("EXEC SP_IBSector_Guardar @p0, @p1, @p2, @p3, @p4",
                model.SectorId, model.SectorDenominacion, model.SectorDestino, model.ActivarTraslados, model.Oculto);

            return RedirectToAction("IBSector");
        }

        // Elimina un registro
        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            _db.Database.ExecuteSqlRaw("EXEC SP_IBSector_Eliminar @p0", id);
            return RedirectToAction("IBSector");
        }

        // Devuelve solo los nombres de los sectores para el autocompletado (AJAX)
        [HttpGet]
        public IActionResult ObtenerListaSectores()
        {
            var sectores = _db.Set<IBSector>()
                              .FromSqlRaw("EXEC SP_IBSector_Listado")
                              .AsEnumerable() // <-- Agregamos esta línea clave
                              .Select(s => s.SectorDenominacion)
                              .ToList();

            return Json(sectores);
        }

        // Guarda un sector rápido desde el evento AfterUpdate (AJAX)
        [HttpPost]
        public IActionResult GuardarAjax(string denominacion)
        {
            _db.Database.ExecuteSqlRaw("EXEC SP_IBSector_Guardar @p0, @p1, @p2, @p3, @p4",
                0, denominacion, "", false, false);

            return Json(new { success = true });
        }
    }
}