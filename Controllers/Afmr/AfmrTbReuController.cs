using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConexionSql.Data;
using System.Threading.Tasks;

namespace ConexionSql.Controllers.Afmr
{
    public class AfmrTbReuController : Controller
    {
        private readonly ConexionSqlContext _context;

        public AfmrTbReuController(ConexionSqlContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> AfmrTbReu(int id)
        {
            if (id == 0)
                return Content("Ingrese un ID de reuso.");

            var reu = await _context.TbReu
                .FirstOrDefaultAsync(x => x.TbReuId == id);

            if (reu == null)
                return Content("Registro no encontrado.");

            return View("~/Views/Afmr/AfmrTbReu.cshtml", reu);
        }
    }
}