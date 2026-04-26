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

        public async Task<IActionResult> ViewEquipo(int id)
        {
            var equipo = await _context.IbEqu
                .Where(x => x.IbEquId == id)
                .Select(x => new IbEquDto
                {
                    IbEquId = x.IbEquId,
                    IbEquTeqDen = x.IbEquTeqDen,
                    IbEquPtiDen = x.IbEquPtiDen,
                    IbEquMarDen = x.IbEquMarDen,
                    IbEquMod = x.IbEquMod,
                    IbEquSer = x.IbEquSer,
                    IbEquNum = x.IbEquNum,

                    IbEquAlt = x.IbEquAlt,
                    IbEquAnc = x.IbEquAnc,
                    IbEquPro = x.IbEquPro,
                    IbEquCag = x.IbEquCag,
                    IbEquPte = x.IbEquPte,
                    IbEquCap = x.IbEquCap,
                    IbEquPorc = x.IbEquPorc,
                    IbEquCapu = x.IbEquCapu,

                    IbEquCai = x.IbEquCai,
                    IbEquCel = x.IbEquCel,
                    IbEquCes = x.IbEquCes,
                    IbEquPco = x.IbEquPco,

                    IbEquCagCant = x.IbEquCagCant,
                    IbEquCaiCant = x.IbEquCaiCant,
                    IbEquCelCant = x.IbEquCelCant,

                    IbEquPve = x.IbEquPve,

                    IbEquOcu = x.IbEquOcu
                })
                .FirstOrDefaultAsync();

            if (equipo == null)
                return NotFound();

            return View("~/Views/Equipos/ViewEquipo.cshtml", equipo);
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