using ConexionSql.Data;
using ConexionSql.InfoBasica.Dtos;
using ConexionSql.InfoBasica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConexionSql.InfoBasica.Controllers
{
    public class IBProveedorController : Controller
    {
        private readonly ConexionSqlContext _db;

        public IBProveedorController(ConexionSqlContext db) => _db = db;

        public IActionResult IBProveedor()
        {
            var lista = _db.Set<IBProveedor>().FromSqlRaw("EXEC SP_IBProveedor_Listar").ToList();

            // Ruta corregida según la ubicación real del archivo
            return View("~/Views/InfoBasica/IBProveedor.cshtml", lista);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Guardar(IBProveedorDto dto)
        {
            _db.Database.ExecuteSqlRaw(
                "EXEC SP_IBProveedor_Guardar @p0, @p1, @p2",
                dto.Id,
                dto.Denominacion,
                dto.Oculto
            );

            return RedirectToAction("IBProveedor");
        }

        //[HttpPost]
        //public IActionResult Guardar(IBProveedorDto dto)
        //{
        //    _db.Database.ExecuteSqlRaw("EXEC SP_IBProveedor_Guardar @p0, @p1",
        //        dto.Denominacion, dto.Oculto);

        //    return RedirectToAction("IBProveedor");
        //}

        // Para cargar los datos en el modal cuando apretás "Editar"
        [HttpGet]
        public IActionResult Obtener(int id)
        {
            var proveedor = _db.Set<IBProveedor>().FromSqlRaw("EXEC SP_IBProveedor_Listar").AsEnumerable()
                            .FirstOrDefault(x => x.IB_ORT_ID == id);
            return Json(proveedor);
        }

        // El control eliminar que usamos siempre
        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            _db.Database.ExecuteSqlRaw("EXEC SP_IBProveedor_Eliminar @p0", id);
            return RedirectToAction("IBProveedor");
        }
    }
}