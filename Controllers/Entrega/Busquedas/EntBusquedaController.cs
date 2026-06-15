using ConexionSql.Data;
using ConexionSql.Models.Entrega;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConexionSql.Controllers.Entrega.Busquedas
{
    public class EntBusquedaController : Controller
    {
        private readonly ConexionSqlContext _context;

        public EntBusquedaController(ConexionSqlContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> ConsultaEntrega(int tbEntId)
        {
            if (tbEntId <= 0)
                return NotFound("❌ ID de entrega inválido.");

            var cabecera = await _context.TbEnt
                .FirstOrDefaultAsync(x => x.TbEntId == tbEntId);

            if (cabecera == null)
                return NotFound("❌ No se encontró la cabecera de la entrega.");

            var detalles = await _context.TbEntDet
                .Where(d => d.TbEntId == tbEntId)
                .OrderByDescending(d => d.TbEntDetId)
                .Select(d => new TbEntDetDto
                {
                    TbEntDetId = d.TbEntDetId,
                    TB_ENT_DET_ID = d.TbEntDetId,

                    TbEntId = d.TbEntId,
                    TB_ENT_ID = d.TbEntId,

                    TbEntDetRecDetId = d.TbEntDetRecDetId,
                    TB_ENT_DET_REC_DET_ID = d.TbEntDetRecDetId,

                    TbEntDetRecDetMatDen = d.TbEntDetRecDetMatDen,

                    TbEntDetRecDetReuId = d.TbEntDetRecDetReuId,
                    CodigoReuso = d.TbEntDetRecDetReuId,

                    TbEntDetRecDetCant = d.TbEntDetRecDetCant,
                    Recibidos = d.TbEntDetRecDetCant,

                    TbEntDetRecDetEntStock = d.TbEntDetRecDetEntStock,
                    Pendientes = d.TbEntDetRecDetEntStock,

                    TbEntDetRecDetEntTot = d.TbEntDetRecDetEntTot,
                    Entregados = d.TbEntDetRecDetEntTot,

                    TbEntDetCant = d.TbEntDetCant,
                    TB_ENT_DET_CANT = d.TbEntDetCant
                })
                .ToListAsync();

            var dto = new TbEntDetFormDto
            {
                Cabecera = cabecera,
                Detalle = new TbEntDetDto
                {
                    TbEntId = tbEntId,
                    TB_ENT_ID = tbEntId
                },
                Detalles = detalles
            };

            return View("~/Views/Entrega/Busquedas/ConsultaEntrega.cshtml", dto);
        }
    }
}