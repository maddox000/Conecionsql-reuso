using ConexionSql.Data;
using ConexionSql.Models.InfoBasica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public IActionResult PruebaModalPersonal()
        {
            return View("~/Views/InfoBasica/PruebaModalPersonal.cshtml");
        }
    }
    }