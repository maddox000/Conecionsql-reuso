using ConexionSql.Data;
using ConexionSql.Models.Instrumental;
using ConexionSql.Models.Materiales;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConexionSql.Controllers.Instrumental
{
    public class InstrumentalController : Controller
    {
        private readonly ConexionSqlContext _context;

        public InstrumentalController(ConexionSqlContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var lista = await _context.IbMatCons
                .Select(x => new IbMatConDto
                {
                    // Codigo sistema
                    IbMatIntId = x.IbMatIntId,

                    // Codigo producto
                    IbMatIntPr = x.IbMatIntPr,

                    // Denominacion
                    IbMatIntDen = x.IbMatIntDen,

                    // Marca
                    IbMatIntMarDen = x.IbMatIntMarDen,

                    // Catalogo
                    IbMatIntMarCat = x.IbMatIntMarCat,

                    // Inhabilitado
                    IbMatIntOcu = x.IbMatIntOcu,

                    // Imagenes
                    IbMatIntImg1 = x.IbMatIntImg1,
                    IbMatIntImg2 = x.IbMatIntImg2,
                    IbMatIntImg3 = x.IbMatIntImg3,
                    IbMatIntImg4 = x.IbMatIntImg4,
                    IbMatIntImg5 = x.IbMatIntImg5
                })
                .OrderBy(x => x.IbMatIntId)
                .ToListAsync();

            return View("~/Views/Instrumental/ListaInstrumental.cshtml", lista);
        }
    }
}
