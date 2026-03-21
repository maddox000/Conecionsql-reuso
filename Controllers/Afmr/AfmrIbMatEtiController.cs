using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConexionSql.Data;
using ConexionSql.Models.Materiales;
using System.Threading.Tasks;

namespace ConexionSql.Controllers.Afmr
{
    public class AfmrIbMatEtiController : Controller
    {
        private readonly ConexionSqlContext _context;

        public AfmrIbMatEtiController(ConexionSqlContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> AfmrIbMatEti(int id)
        {
            if (id == 0)
                return Content("Ingrese un ID de etiqueta.");

            var etiqueta = await _context.IbMatEti
                .FirstOrDefaultAsync(e => e.IB_MAT_ETI_ID == id);

            if (etiqueta == null)
                return Content("Etiqueta no encontrada.");

            return View("~/Views/Afmr/AfmrIbMatEti.cshtml", etiqueta);
        }
    }
}