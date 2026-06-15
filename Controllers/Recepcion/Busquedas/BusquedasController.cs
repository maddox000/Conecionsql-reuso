using ConexionSql.Data;
using ConexionSql.Models.Recepciones;
using ConexionSql.Models.Recepciones.Busquedas;
using ConexionSql.Models.reuepciones;
using ConexionSql.Utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;


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

        //reimpresion de etiquetas

        [HttpPost]
        public async Task<IActionResult> ReimprimirEtiqueta(int tbRecDetId)
        {
            var entidad = await _context.TbRecDet
                .FirstOrDefaultAsync(x => x.TbRecDetId == tbRecDetId);

            if (entidad == null)
                return Json(new { success = false, mensaje = "Detalle no encontrado." });

            var tbRec = await _context.TbRec
                .FirstOrDefaultAsync(x => x.TbRecId == entidad.TbRecId);

            if (tbRec == null)
                return Json(new { success = false, mensaje = "Recepción no encontrada." });

            var material = await _context.IbMat
            .FirstOrDefaultAsync(x => x.IB_MAT_ID == entidad.TbRecDetMatId);

            if (material == null)
                return Json(new { success = false, mensaje = "Material no encontrado." });

            string nombreMaterial = material.IB_MAT_DEN ?? "SIN MATERIAL";

            string ortDen = entidad.TbRecDetOrtDen ?? "NO REGISTRADO";

            bool esOrtopediaOProfesional =
            entidad.TbRecDetOrtId > 0 ||
            !string.IsNullOrWhiteSpace(entidad.TbRecDetProNom) ||
            !string.IsNullOrWhiteSpace(entidad.TbRecDetPac);

            // ACA VAMOS A PEGAR EL BLOQUE DE IMPRESION
            bool esCompleto = entidad.TbRecDetRepId == 2;
            bool esIncompleto = entidad.TbRecDetRepId == 3;

            string zplCompleto = null;
            string zplIncompleto = null;
            string zplPrioridad = null;
            string zplReprocesado = null;

            if (esCompleto)
            {
                zplCompleto = Etiquetas.RecepcionDetalleCompleto(
                    sector: tbRec.TbRecSecOriDen,
                    material: nombreMaterial,
                    fechaRecepcion: tbRec.TbRecFec ?? DateTime.Now,
                    nroRecepcion: tbRec.TbRecId,
                    idDetalle: entidad.TbRecDetId,
                    cantidad: entidad.TbRecDetNum2 ?? 0
                );
            }

            if (esIncompleto)
            {
                zplIncompleto = Etiquetas.RecepcionDetalleIncompleto(
                    sector: tbRec.TbRecSecOriDen,
                    material: nombreMaterial,
                    fechaRecepcion: tbRec.TbRecFec ?? DateTime.Now,
                    nroRecepcion: tbRec.TbRecId,
                    idDetalle: entidad.TbRecDetId,
                    cantidad: entidad.TbRecDetNum2 ?? 0,
                    detalleFaltante: entidad.TbRecDetMem1 ?? ""
                );
            }

            if (entidad.TbRecDetRepId == 5)
            {
                zplPrioridad = Etiquetas.RecepcionDetallePrioridadProceso(
                    tbRec.TbRecSecDesDen,
                    material.IB_MAT_DEN,
                    tbRec.TbRecFec ?? DateTime.Now,
                    tbRec.TbRecId,
                    entidad.TbRecDetId
                );
            }

            if (entidad.TbRecDetRepId == 10)
            {
                zplReprocesado = Etiquetas.RecepcionDetalleReprocesadoSinUso(
                    tbRec.TbRecSecDesDen,
                    material.IB_MAT_DEN,
                    tbRec.TbRecFec ?? DateTime.Now,
                    tbRec.TbRecId,
                    entidad.TbRecDetId
                );
            }

            string zpl = "";

            if (esOrtopediaOProfesional)
            {
                if (ortDen == "NO REGISTRADO")
                {
                    zpl = Etiquetas.RecepcionDetalleProfesional(
                        sector: tbRec.TbRecSecDesDen,
                        material: nombreMaterial,
                        fechaRecepcion: tbRec.TbRecFec ?? DateTime.Now,
                        vencimiento: DateTime.Now.AddMonths(12),
                        nroRecepcion: tbRec.TbRecId,
                        idDetalle: entidad.TbRecDetId,
                        profesional: entidad.TbRecDetProNom ?? "NO REGISTRA",
                        fechaProc: entidad.TbRecDetFen,
                        horaProc: entidad.TbRecDetHen,
                        cantidad: entidad.TbRecDetCant
                    );
                }
                else
                {
                    zpl = Etiquetas.RecepcionDetalleOrtopedia(
                        sector: tbRec.TbRecSecOriDen,
                        material: nombreMaterial,
                        fechaRecepcion: tbRec.TbRecFec ?? DateTime.Now,
                        nroRecepcion: tbRec.TbRecId,
                        idDetalle: entidad.TbRecDetId,
                        profesional: entidad.TbRecDetProNom ?? "NO REGISTRA",
                        paciente: entidad.TbRecDetPac ?? "NO REGISTRA",
                        remito: entidad.TbRecDetRem ?? "0",
                        ortopedia: entidad.TbRecDetOrtDen ?? "NO REGISTRA",
                        fechaProc: entidad.TbRecDetFen,
                        horaProc: entidad.TbRecDetHen
                    );
                }
            }

            if (entidad.TbRecDetReuOpc == true)
            {
                zpl = Etiquetas.RecepcionDetalleReuso(
                    sector: tbRec.TbRecSecDesDen,
                    material: nombreMaterial,
                    fechaRecepcion: tbRec.TbRecFec ?? DateTime.Now,
                    vencimiento: DateTime.Now.AddMonths(6),
                    nroRecepcion: tbRec.TbRecId,
                    idDetalle: entidad.TbRecDetId,
                    codigoReuso: entidad.TbRecDetReuId,
                    tipoMaterial: entidad.TbRecDetMatMtiDen,
                    reusoCant: entidad.TbRecDetReuCant ?? 0
                );
            }
            else
            {
                zpl = Etiquetas.RecepcionDetalle(
                    sector: tbRec.TbRecSecDesDen,
                    material: nombreMaterial,
                    fechaRecepcion: tbRec.TbRecFec ?? DateTime.Now,
                    vencimiento: DateTime.Now.AddMonths(6),
                    nroRecepcion: tbRec.TbRecId,
                    idDetalle: entidad.TbRecDetId,
                    codigoReuso: entidad.TbRecDetReuId,
                    tipoMaterial: entidad.TbRecDetMatMtiDen
                );
            }

            var cfgImpresion = await _context.APanOpc
            .FirstOrDefaultAsync(x =>
                x.IdDenominacion == "A_PAN_IMP_ETI_EN"
                && x.Valor == true);

            if (cfgImpresion?.ValorId == 1)
            {
                for (int i = 0; i < entidad.TbRecDetCant; i++)
                {
                    // etiqueta principal
                    ImpresionZebra.EnviarAImpresora("ZDesigner GK420t", zpl);

                    // completo
                    if (esCompleto && zplCompleto != null)
                    {
                        ImpresionZebra.EnviarAImpresora("ZDesigner GK420t", zplCompleto);
                    }

                    // incompleto
                    if (esIncompleto && zplIncompleto != null)
                    {
                        ImpresionZebra.EnviarAImpresora("ZDesigner GK420t", zplIncompleto);
                    }

                    // prioridad
                    if (entidad.TbRecDetRepId == 5 && zplPrioridad != null)
                    {
                        ImpresionZebra.EnviarAImpresora("ZDesigner GK420t", zplPrioridad);
                    }

                    // reprocesado sin uso
                    if (entidad.TbRecDetRepId == 10 && zplReprocesado != null)
                    {
                        ImpresionZebra.EnviarAImpresora("ZDesigner GK420t", zplReprocesado);
                    }
                }
            }

            return Json(new
            {
                success = true,
                mensaje = "Etiqueta reimpresa correctamente."
            });
        }
    }

}
