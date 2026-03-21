using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConexionSql.Data;
using ConexionSql.Models.Recepciones;
using System.Threading.Tasks;

namespace ConexionSql.Controllers.Afmr
{
    public class AfmrTbRecDetController : Controller
    {
        private readonly ConexionSqlContext _context;

        public AfmrTbRecDetController(ConexionSqlContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> AfmrTbRecDet(int id)
        {
            if (id == 0)
                return Content("Ingrese un ID de detalle.");

            var det = await _context.TbRecDet
                .FirstOrDefaultAsync(x => x.TbRecDetId == id);

            if (det == null)
                return Content("Detalle no encontrado.");

            return View("~/Views/Afmr/AfmrTbRecDet.cshtml", det);
        }
    }
}
