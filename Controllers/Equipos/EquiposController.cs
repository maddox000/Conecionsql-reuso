using ConexionSql.Data;
using ConexionSql.Models.Equipos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConexionSql.Controllers
{
    public class EquiposController : Controller
    {
        private readonly ConexionSqlContext _context;

        public EquiposController(ConexionSqlContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return RedirectToAction("ListaEquipos");
        }

        public IActionResult ViewEquipo()
        {
            var dto = new IbEquDto();
            return View("~/Views/Equipos/ViewEquipo.cshtml", dto);
        }

        public async Task<IActionResult> ListaEquipos()
        {
            var equipos = await _context.IbEqu
                .OrderBy(x => x.IbEquId)
                .Select(x => new IbEquDto
                {
                    IbEquId = x.IbEquId,
                    IbEquTeqDen = x.IbEquTeqDen,
                    IbEquMarDen = x.IbEquMarDen,
                    IbEquMod = x.IbEquMod,
                    IbEquSer = x.IbEquSer,
                    IbEquOcu = x.IbEquOcu
                })
                .ToListAsync();

            return View("~/Views/Equipos/ListaEquipos.cshtml", equipos);
        }
    }
}