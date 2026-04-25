using ConexionSql.Data;
using ConexionSql.Models.Materiales;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConexionSql.Controllers.Materiales
{
    public class MaterialesController : Controller
    {
        private readonly ConexionSqlContext _context;

        public MaterialesController(ConexionSqlContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ListaMateriales()
        {
            var lista = await _context.IbMat
                .OrderBy(x => x.IB_MAT_ID)
                .Select(x => new IbMatDto
                {
                    // Código sistema
                    IbMatId = x.IB_MAT_ID,

                    // Código producto
                    IbMatPr = x.IB_MAT_PR,

                    // Denominación
                    IbMatDen = x.IB_MAT_DEN,

                    // Tipo de material
                    IbMatMtiDen = x.IB_MAT_MTI_DEN,

                    // Ubicación física
                    IbMatEstIngDen = x.IB_MAT_EST_ING_DEN,

                    // Contenido
                    IbMatConUnid = x.IB_MAT_CON_UNID,

                    // Controlado
                    IbMatConAct = x.IB_MAT_CON_ACT,

                    // Inhabilitado
                    IbMatOcu = x.IB_MAT_OCU
                })
                .ToListAsync();

            return View("~/Views/Materiales/ListaMateriales.cshtml", lista);
        }
    }
}