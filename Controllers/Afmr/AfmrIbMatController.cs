using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConexionSql.Data;
using ConexionSql.Models.Materiales;
using ConexionSql.Utilidades.Afmr;
using System.Threading.Tasks;

namespace ConexionSql.Controllers.Afmr
{
    public class AfmrIbMatController : Controller
    {
        private readonly ConexionSqlContext _context;

        public AfmrIbMatController(ConexionSqlContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> AfmrIbMat(int id)
        {
            if (id == 0)
                return Content("Ingrese un ID de material.");

            var material = await _context.IbMat
                .FirstOrDefaultAsync(m => m.IB_MAT_ID == id);

            if (material == null)
                return Content("Material no encontrado.");

            AfmrIbMatHelper.Ejecutar(material);

            return View("~/Views/Afmr/AfmrIbMat.cshtml", material);
        }
    }
}
