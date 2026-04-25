using ConexionSql.Data;
using ConexionSql.Models.Sectores;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConexionSql.Controllers.Sectores
{
    public class SectoresController : Controller
    {
        private readonly ConexionSqlContext _context;

        public SectoresController(ConexionSqlContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ListaSectores()
        {
            var lista = await _context.IbSectores
                .OrderBy(x => x.IbSecId)
                .Select(x => new IbSecDto
                {
                    IbSecId = x.IbSecId,
                    IbSecDen = x.IbSecDen,
                    IbSecDesDen = x.IbSecDesDen,
                    IbSecOcu = x.IbSecOcu
                })
                .ToListAsync();

            return View("~/Views/Sectores/ListaSectores.cshtml", lista);
        }
    }
}
