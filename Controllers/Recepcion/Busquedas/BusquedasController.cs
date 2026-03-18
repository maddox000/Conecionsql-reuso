using Microsoft.AspNetCore.Mvc;
using ConexionSql.Data;
using ConexionSql.Models.Recepciones.Busquedas;
using System;
using System.Linq;


namespace ConexionSql.Controllers.Recepcion.Busquedas
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
    }

}
