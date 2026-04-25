using ConexionSql.Data;
using ConexionSql.Models.Proveedores;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConexionSql.Controllers.Proveedores
{
    public class ProveedoresController : Controller
    {
        private readonly ConexionSqlContext _context;

        public ProveedoresController(ConexionSqlContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ListaProveedores()
        {
            var lista = await _context.IbOrt
                .OrderBy(x => x.IbOrtId)
                .Select(x => new IbOrtDto
                {
                    IbOrtId = x.IbOrtId,
                    IbOrtDen = x.IbOrtDen,
                    IbOrtOcu = x.IbOrtOcu
                })
                .ToListAsync();

            return View("~/Views/Proveedores/ListaProveedores.cshtml", lista);
        }
    }
}