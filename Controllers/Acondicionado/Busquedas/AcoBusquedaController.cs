using ConexionSql.Data;
using ConexionSql.Models.Acondicionado;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConexionSql.Controllers.Acondicionado.Busquedas
{
    public class AcoBusquedaController : Controller
    {
        private readonly ConexionSqlContext _context;

        public AcoBusquedaController(ConexionSqlContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> ConsultaAcondicionado(int tbProAcoId)
        {
            if (tbProAcoId <= 0)
                return NotFound("❌ ID de acondicionado inválido.");

            var cabecera = await _context.TbProAco
                .FirstOrDefaultAsync(x => x.TbProAcoId == tbProAcoId);

            if (cabecera == null)
                return NotFound("❌ No se encontró la cabecera del acondicionado.");

            var detalles = await _context.TbProAcoDet
                .Where(d => d.TbProAcoDetAcoId == tbProAcoId)
                .OrderByDescending(d => d.TbProAcoDetId)
                .Select(d => new TbProAcoDetDto
                {
                    TbProAcoDetId = d.TbProAcoDetId,
                    TbProAcoDetAcoId = d.TbProAcoDetAcoId,

                    TbProAcoDetRecDetId = d.TbProAcoDetRecDetId,
                    TbProAcoDetMatDen = d.TbProAcoDetMatDen,
                    TbProAcoDetSecDesDen = d.TbProAcoDetSecDesDen,
                    TbProAcoDetReuId = d.TbProAcoDetReuId,
                    TbProAcoDetMatEtiDen = d.TbProAcoDetMatEtiDen,

                    TbProAcoDetRecDetCant = d.TbProAcoDetRecDetCant,
                    TbProAcoDetEmpTot = d.TbProAcoDetEmpTot,
                    TbProAcoDetEmpStock = d.TbProAcoDetEmpStock,

                    TbProAcoDetCant = d.TbProAcoDetCant
                })
                .ToListAsync();

            var dto = new TbProAcoDetFormDto
            {
                Cabecera = cabecera,
                Detalle = new TbProAcoDetDto
                {
                    TbProAcoDetAcoId = tbProAcoId
                },
                Detalles = detalles
            };

            return View("~/Views/Acondicionado/Busquedas/ConsultaAcondicionado.cshtml", dto);
        }
    }
}