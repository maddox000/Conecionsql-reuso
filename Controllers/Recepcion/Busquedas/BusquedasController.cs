using ConexionSql.Data;
using ConexionSql.Models.Recepciones;
using ConexionSql.Models.Recepciones.Busquedas;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using ConexionSql.Models.reuepciones;


namespace ConexionSql.Controllers.reuepcion.Busquedas
{
    public class BusquedasController : Controller
    {
        private readonly ConexionSqlContext _context;

        // ✅ Constructor solo para inyectar dependencias
        public BusquedasController(ConexionSqlContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IActionResult BusquedasFecha(DateTime? fechaInicio, DateTime? fechaFin)
        {
            var fechaFinBusqueda = fechaFin ?? DateTime.Today;
            var fechaInicioBusqueda = fechaInicio ?? DateTime.Today.AddDays(-10);

            var lista = (from rd in _context.TbRecDet
                         join r in _context.TbRec on rd.TbRecId equals r.TbRecId
                         where r.TbRecFec >= fechaInicioBusqueda && r.TbRecFec <= fechaFinBusqueda
                         orderby r.TbRecFec descending
                         select new BusquedaRecepcionesDto
                         {
                             CodigoEtiqueta = rd.TbRecDetId,
                             Recepcion = r.TbRecId,
                             Fecha = r.TbRecFec ?? DateTime.MinValue,
                             Sector = r.TbRecSecDesDen,
                             Denominacion = rd.TbRecDetMatDen ?? "NO REGISTRA",
                             Cantidad = rd.TbRecDetCant
                         }).ToList();

            return View("~/Views/Recepcion/Busquedas/BusquedaMaterialesFecha.cshtml", lista);
        }

        public IActionResult ConsultaRecepcion(int id)
        {
            var cabecera = _context.TbRec
                .FirstOrDefault(x => x.TbRecId == id);

            if (cabecera == null)
            {
                return NotFound();
            }

            var detalles = _context.TbRecDet
                .Where(x => x.TbRecId == id)
                .Select(x => new TbRecDetDto
                {
                    TB_REC_DET_ID = x.TbRecDetId,
                    TB_REC_DET_MAT_PR = x.TbRecDetMatPr,
                    TbRecDetMatDen = x.TbRecDetMatDen,
                    TB_REC_DET_REU_ID = x.TbRecDetReuId,
                    TB_REC_DET_CANT = x.TbRecDetCant,
                    TB_REC_DET_LAV_STOCK = x.TbRecDetLavStock ?? 0,
                    TB_REC_DET_EMP_STOCK = x.TbRecDetEmpStock ?? 0,
                    TB_REC_DET_PRO_STOCK = x.TbRecDetProStock ?? 0,
                    TB_REC_DET_ENT_STOCK = x.TbRecDetEntStock ?? 0,
                    TB_REC_DET_TXT_3 = x.TbRecDetTxt3
                })
                .ToList();

            ViewBag.Cabecera = cabecera;
            ViewBag.Detalles = detalles;

            return View("~/Views/Recepcion/Busquedas/ConsultaRecepcion.cshtml");
        }
    }

}
