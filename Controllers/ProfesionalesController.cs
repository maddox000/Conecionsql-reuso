using ConexionSql.Data;
using ConexionSql.Models.Profesionales;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConexionSql.Controllers.Profesionales
{
    public class ProfesionalesController : Controller
    {
        private readonly ConexionSqlContext _context;

        public ProfesionalesController(ConexionSqlContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ListaProfesionales()
        {
            var lista = await _context.IbPro
                .OrderBy(x => x.IbProId)
                .Select(x => new IbProDto
                {
                    IbProId = x.IbProId,
                    IbProNom = x.IbProNom,
                    IbProApe = x.IbProApe,
                    IbProTel = x.IbProTel,
                    IbProTmo = x.IbProTmo,
                    IbProEm = x.IbProEm,
                    IbProOcu = x.IbProOcu
                })
                .ToListAsync();

            return View("~/Views/Profesionales/ListaProfesionales.cshtml", lista);
        }
    }
}