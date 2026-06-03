using ConexionSql.Data;
using ConexionSql.Models.Acondicionado;
using ConexionSql.Models.Procesos;
using ConexionSql.Models.Recepciones;
using ConexionSql.Utilidades;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ConexionSql.Controllers
{
    public class TbProAcoDetController : Controller
    {
        private readonly ConexionSqlContext _context;

        public TbProAcoDetController(ConexionSqlContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Insertar(int tbRecDetId, int cantidad, int tbProAcoId)
        {
            Console.WriteLine("🟢 TbProAcoDetController.Insertar invocado.");

            if (cantidad <= 0)
                return Json(new { success = false, mensaje = "Debe ingresar una cantidad válida." });

            try
            {
                var cabecera = await _context.TbProAco.FindAsync(tbProAcoId);
                if (cabecera == null)
                    return Json(new { success = false, mensaje = "❌ Cabecera no encontrada." });

                var recDet = await _context.TbRecDet
                    .FirstOrDefaultAsync(r => r.TbRecDetId == tbRecDetId);

                if (recDet == null)
                    return Json(new { success = false, mensaje = "❌ No se encontró el detalle de recepción." });

                int stockDisponible = recDet.TbRecDetEmpStock ?? 0;
                if (stockDisponible == 0)
                    return Json(new { success = false, mensaje = "❌ No hay stock disponible." });

                if (cantidad > stockDisponible)
                    return Json(new { success = false, mensaje = $"❌ Stock insuficiente. Disponible: {stockDisponible}" });

                // Actualizar stock en TB_REC_DET
                recDet.TbRecDetEmpStock -= cantidad;
                recDet.TbRecDetEmpTot = (recDet.TbRecDetEmpTot ?? 0) + cantidad;
                recDet.TbRecDetProStock = (recDet.TbRecDetProStock ?? 0) + cantidad;

                // Estado ingreso en TB_REC_DET
                recDet.TbRecDetEstIngId = 24;
                recDet.TbRecDetEstIngDen = "CE PROCESO ACONDICIONADO";

                // Crear nuevo detalle de acondicionado
                var nuevoDet = new TbProAcoDet
                {
                    TbProAcoDetAcoId = tbProAcoId,

                    // Origen TB_REC_DET
                    TbProAcoDetRecDetId = recDet.TbRecDetId,
                    TbProAcoDetRecDetCant = recDet.TbRecDetCant,

                    // Material
                    TbProAcoDetMatId = recDet.TbRecDetMatId,
                    TbProAcoDetMatDen = recDet.TbRecDetMatDen,
                    TbProAcoDetMatVol = recDet.IbMatVol,

                    // Mantenimiento / tipo material
                    TbProAcoDetMatMtiId = recDet.TbRecDetMatMtiId,
                    TbProAcoDetMatMtiDen = recDet.TbRecDetMatMtiDen,

                    // Etiqueta / envoltorio
                    TbProAcoDetMatEtiId = recDet.TbRecDetMatEtiId,
                    TbProAcoDetMatEtiDen = recDet.TbRecDetMatEtiDen,

                    // Reuso
                    TbProAcoDetReuId = recDet.TbRecDetReuId,

                    // Sector destino
                    TbProAcoDetSecDesId = recDet.TbRecSecDesId,
                    TbProAcoDetSecDesDen = recDet.TbRecSecDesDen,

                    // Sector origen
                    TbProAcoDetSecOriId = recDet.TbRecSecOriId,
                    TbProAcoDetSecOriDen = recDet.TbRecSecOriDen,

                    // Cantidades
                    TbProAcoDetCant = cantidad,
                    TbProAcoDetEmpStock = recDet.TbRecDetEmpStock,
                    TbProAcoDetEmpCant = cantidad,
                    TbProAcoDetEmpTot = cantidad,
                    TbProAcoDetProStock = cantidad,

                    // NUM
                    TbProAcoDetNum1 = 0,
                    TbProAcoDetNum2 = 0,
                    TbProAcoDetNum3 = 0,

                    // TXT
                    TbProAcoDetTxt1 = "TXT",
                    TbProAcoDetTxt2 = "TXT",
                    TbProAcoDetTxt3 = "TXT",

                    // MEM
                    TbProAcoDetMem1 = "MEM",
                    TbProAcoDetMem2 = "MEM",
                    TbProAcoDetMem3 = "MEM",

                    // Otros
                    TbProAcoDetCantMult = 1,
                    TbProAcoDetCantElim = 0,
                    TbProAcoDetDat = "NO REGISTRADO",

                    // Auditoría
                    TbProAcoDetPcLog = Environment.MachineName,
                    TbProAcoDetPcUsr = Environment.UserName,
                    TbProAcoDetHor = DateTime.Now,

                    TbProAcoDetSel = false,
                    TbProAcoDetSelCant = 0,
                    TbProAcoDetIvisOpc = false,
                    TbProAcoDetAcajOpc = false,
                    TbProAcoDetAcajRevId = 0,
                    TbProAcoDetAcajCant = 0,
                    TbProAcoDetPerId = 0,
                    TbProAcoDetPtiId = 0,
                };

                _context.TbProAcoDet.Add(nuevoDet);

                // Sumar cantidad a la cabecera
                cabecera.TbProAcoUpro = (cabecera.TbProAcoUpro ?? 0) + cantidad;

                await _context.SaveChangesAsync();
                await ImprimirEtiquetaAcondicionado(recDet, nuevoDet, cantidad);

                var cfgImpresion = await _context.APanOpc
                    .FirstOrDefaultAsync(x => x.IdDenominacion == "A_PAN_IMP_ETI_EN" && x.Valor == true);

                if (cfgImpresion?.ValorTxt == "ACONDICIONADO")
                {
                    // impresión de acondicionado va acá
                }

                var detallesActualizados = await _context.TbProAcoDet
                    .Where(d => d.TbProAcoDetAcoId == tbProAcoId)
                    .Select(d => new TbProAcoDetDto
                    {
                        TbProAcoDetId = d.TbProAcoDetId,
                        TbProAcoDetRecDetId = d.TbProAcoDetRecDetId,
                        TbProAcoDetRecDetCant = d.TbProAcoDetRecDetCant,
                        TbProAcoDetMatId = d.TbProAcoDetMatId,
                        TbProAcoDetMatDen = d.TbProAcoDetMatDen,
                        TbProAcoDetSecDesDen = d.TbProAcoDetSecDesDen,
                        TbProAcoDetReuId = d.TbProAcoDetReuId,
                        TbProAcoDetMatEtiDen = d.TbProAcoDetMatEtiDen,
                        TbProAcoDetEmpTot = d.TbProAcoDetEmpTot,
                        TbProAcoDetEmpStock = d.TbProAcoDetEmpStock,
                        TbProAcoDetCant = d.TbProAcoDetCant,
                        TbProAcoDetPcUsr = d.TbProAcoDetPcUsr,
                        TbProAcoDetPcLog = d.TbProAcoDetPcLog,
                        TbProAcoDetHor = d.TbProAcoDetHor
                    })
                    .ToListAsync();

                string html = await this.RenderViewToStringAsync(
                    "~/Views/Acondicionado/_DetalleTablaAco.cshtml",
                    detallesActualizados,
                    true
                );

                return Json(new
                {
                    success = true,
                    mensaje = "✅ Detalle de Acondicionado agregado correctamente.",
                    html = html
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error en Insertar: " + ex.Message);
                return Json(new { success = false, mensaje = "❌ Error interno al insertar." });
            }
        }

        [HttpGet]
        public async Task<IActionResult> SubFormAcoDet(int id)
        {
            var cabecera = await _context.TbProAco.FindAsync(id);
            if (cabecera == null)
                return NotFound("Cabecera no encontrada");

            var detalles = await _context.TbProAcoDet
                .Where(d => d.TbProAcoDetAcoId == id)
                .Select(d => new TbProAcoDetDto
                {
                    TbProAcoDetId = d.TbProAcoDetId,
                    TbProAcoDetMatId = d.TbProAcoDetMatId,
                    TbProAcoDetMatDen = d.TbProAcoDetMatDen,
                    TbProAcoDetCant = d.TbProAcoDetCant,
                    TbProAcoDetPcUsr = d.TbProAcoDetPcUsr,
                    TbProAcoDetPcLog = d.TbProAcoDetPcLog,
                    TbProAcoDetHor = d.TbProAcoDetHor
                })
                .ToListAsync();

            var dto = new TbProAcoDetFormDto
            {
                Cabecera = cabecera,
                Detalles = detalles
            };

            return View("~/Views/Acondicionado/_SubFormAcoDet.cshtml", dto);
        }


        [HttpGet]
        public async Task<IActionResult> ObtenerMaterial(int tbRecDetId)
        {
            try
            {
                var recDet = await _context.TbRecDet
                    .FirstOrDefaultAsync(r => r.TbRecDetId == tbRecDetId);

                if (recDet == null)
                    return Json(new { success = false, mensaje = "Etiqueta no encontrada." });

                int sinProcesar = recDet.TbRecDetEmpStock ?? 0;

                return Json(new
                {
                    success = true,
                    nombre = recDet.TbRecDetMatDen,
                    sector = recDet.TbRecSecDesDen,
                    codigoReuso = recDet.TbRecDetReuId,
                    tipoEnvoltorio = recDet.TbRecDetMatEtiDen,
                    recibidos = recDet.TbRecDetRecStock ?? 0,
                    enProceso = recDet.TbRecDetEmpTot ?? 0,
                    sinProcesar = sinProcesar,

                    // NUEVO: si queda 1, el JS puede insertar directo con cantidad = 1
                    autoInsertar = sinProcesar == 1,
                    cantidadAuto = 1
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error en ObtenerMaterial: " + ex.Message);
                return Json(new { success = false, mensaje = "❌ Error interno al obtener material." });
            }
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerPendientes()
        {
            try
            {
                var fechaDesde = DateTime.Now.AddDays(-10);

                var pendientes = await _context.TbRecDet
                    .Where(r =>
                        (r.TbRecDetEmpStock ?? 0) > 0 &&
                        r.TbRecFec >= fechaDesde
                    )
                    .Select(r => new
                    {
                        id = r.TbRecDetId,
                        material = r.TbRecDetMatDen,
                        sector = r.TbRecSecDesDen,
                        codigoReuso = r.TbRecDetReuId,

                        recibidos = r.TbRecDetCant,
                        registrados = r.TbRecDetEmpTot ?? 0,
                        pendientes = r.TbRecDetEmpStock ?? 0
                    })
                    .OrderByDescending(r => r.id)
                    .ToListAsync();

                return Json(new { success = true, data = pendientes });
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error en ObtenerPendientes: " + ex.Message);
                return Json(new { success = false, mensaje = "Error al obtener pendientes." });
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertarMasivo([FromBody] TbProAcoMasivoDto dto)
        {
            if (dto == null || dto.TbProAcoId <= 0 || dto.Etiquetas == null || !dto.Etiquetas.Any())
            {
                return Json(new
                {
                    success = false,
                    mensaje = "No hay materiales seleccionados."
                });
            }

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                int registrados = 0;

                var cabecera = await _context.TbProAco.FindAsync(dto.TbProAcoId);
                if (cabecera == null)
                    throw new Exception("❌ Cabecera no encontrada.");

                foreach (var recDetId in dto.Etiquetas)
                {
                    var recDet = await _context.TbRecDet
                        .FirstOrDefaultAsync(r => r.TbRecDetId == recDetId);

                    if (recDet == null)
                        throw new Exception($"❌ No se encontró el detalle de recepción {recDetId}.");

                    int stockDisponible = recDet.TbRecDetEmpStock ?? 0;

                    if (stockDisponible == 0)
                        throw new Exception($"❌ No hay stock disponible en {recDetId}.");

                    int cantidad = stockDisponible;

                    if (cantidad > stockDisponible)
                        throw new Exception($"❌ Stock insuficiente en {recDetId}.");

                    // 🔵 ACTUALIZAR TB_REC_DET
                    recDet.TbRecDetEmpStock -= cantidad;
                    recDet.TbRecDetEmpTot = (recDet.TbRecDetEmpTot ?? 0) + cantidad;
                    recDet.TbRecDetProStock = (recDet.TbRecDetProStock ?? 0) + cantidad;

                    recDet.TbRecDetEstIngId = 24;
                    recDet.TbRecDetEstIngDen = "CE PROCESO ACONDICIONADO";

                    // 🔵 CREAR DETALLE COMPLETO (MISMO QUE INSERTAR)
                    var nuevoDet = new TbProAcoDet
                    {
                        TbProAcoDetAcoId = dto.TbProAcoId,

                        TbProAcoDetRecDetId = recDet.TbRecDetId,
                        TbProAcoDetRecDetCant = recDet.TbRecDetCant,

                        TbProAcoDetMatId = recDet.TbRecDetMatId,
                        TbProAcoDetMatDen = recDet.TbRecDetMatDen,
                        TbProAcoDetMatVol = recDet.IbMatVol,

                        TbProAcoDetMatMtiId = recDet.TbRecDetMatMtiId,
                        TbProAcoDetMatMtiDen = recDet.TbRecDetMatMtiDen,

                        TbProAcoDetMatEtiId = recDet.TbRecDetMatEtiId,
                        TbProAcoDetMatEtiDen = recDet.TbRecDetMatEtiDen,

                        TbProAcoDetReuId = recDet.TbRecDetReuId,

                        TbProAcoDetSecDesId = recDet.TbRecSecDesId,
                        TbProAcoDetSecDesDen = recDet.TbRecSecDesDen,

                        TbProAcoDetSecOriId = recDet.TbRecSecOriId,
                        TbProAcoDetSecOriDen = recDet.TbRecSecOriDen,

                        TbProAcoDetCant = cantidad,
                        TbProAcoDetEmpStock = recDet.TbRecDetEmpStock,
                        TbProAcoDetEmpCant = cantidad,
                        TbProAcoDetEmpTot = cantidad,
                        TbProAcoDetProStock = cantidad,

                        TbProAcoDetNum1 = 0,
                        TbProAcoDetNum2 = 0,
                        TbProAcoDetNum3 = 0,

                        TbProAcoDetTxt1 = "TXT",
                        TbProAcoDetTxt2 = "TXT",
                        TbProAcoDetTxt3 = "TXT",

                        TbProAcoDetMem1 = "MEM",
                        TbProAcoDetMem2 = "MEM",
                        TbProAcoDetMem3 = "MEM",

                        TbProAcoDetCantMult = 1,
                        TbProAcoDetCantElim = 0,
                        TbProAcoDetDat = "NO REGISTRADO",

                        TbProAcoDetPcLog = Environment.MachineName,
                        TbProAcoDetPcUsr = Environment.UserName,
                        TbProAcoDetHor = DateTime.Now,

                        TbProAcoDetSel = false,
                        TbProAcoDetSelCant = 0,
                        TbProAcoDetIvisOpc = false,
                        TbProAcoDetAcajOpc = false,
                        TbProAcoDetAcajRevId = 0,
                        TbProAcoDetAcajCant = 0,
                        TbProAcoDetAcajFalt = "NO REGISTRADO",
                        TbProAcoDetPerId = 0,
                        TbProAcoDetPtiId = 0,

                        
                        TbProAcoDetIvisOpcNom = "NO REGISTRADO",
                        TbProAcoDetAcajOpcNom = "NO REGISTRADO",
                        TbProAcoDetAcajRevDen = "NO REGISTRADO",

                        // PERSONAL / PROCESO
                        TbProAcoDetPerDen = "NO REGISTRADO",
                        TbProAcoDetPtiDen = "NO REGISTRADO",

                        // EQUIPO / LOTE
                        TbProAcoDetEquNum = "NO REGISTRADO",
                        TbProAcoDetLot = "NO REGISTRADO",
                    };

                    _context.TbProAcoDet.Add(nuevoDet);

                    // 🔵 CABECERA
                    cabecera.TbProAcoUpro = (cabecera.TbProAcoUpro ?? 0) + cantidad;
                    await _context.SaveChangesAsync();
                    await ImprimirEtiquetaAcondicionado(recDet, nuevoDet, cantidad);

                    registrados++;
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                

                return Json(new
                {
                    success = true,
                    mensaje = $"Se registraron {registrados} materiales correctamente."
                });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();

                return Json(new
                {
                    success = false,
                    mensaje = ex.Message
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerDetallesAco(int tbProAcoId)
        {
            var detalles = await _context.TbProAcoDet
                .Where(d => d.TbProAcoDetAcoId == tbProAcoId)
                .Select(d => new TbProAcoDetDto
                {
                    TbProAcoDetId = d.TbProAcoDetId,
                    TbProAcoDetRecDetId = d.TbProAcoDetRecDetId,
                    TbProAcoDetRecDetCant = d.TbProAcoDetRecDetCant,
                    TbProAcoDetMatId = d.TbProAcoDetMatId,
                    TbProAcoDetMatDen = d.TbProAcoDetMatDen,
                    TbProAcoDetSecDesDen = d.TbProAcoDetSecDesDen,
                    TbProAcoDetReuId = d.TbProAcoDetReuId,
                    TbProAcoDetMatEtiDen = d.TbProAcoDetMatEtiDen,
                    TbProAcoDetEmpTot = d.TbProAcoDetEmpTot,
                    TbProAcoDetEmpStock = d.TbProAcoDetEmpStock,
                    TbProAcoDetCant = d.TbProAcoDetCant,
                    TbProAcoDetPcUsr = d.TbProAcoDetPcUsr,
                    TbProAcoDetPcLog = d.TbProAcoDetPcLog,
                    TbProAcoDetHor = d.TbProAcoDetHor
                })
                .ToListAsync();

            string html = await this.RenderViewToStringAsync(
                "~/Views/Acondicionado/_DetalleTablaAco.cshtml",
                detalles,
                true
            );

            return Json(new
            {
                success = true,
                html
            });
        }

        //metodo impresion en aco
        private async Task ImprimirEtiquetaAcondicionado(TbRecDet recDet, TbProAcoDet nuevoDet, int cantidad)
        {
            var cfgImpresion = await _context.APanOpc
                .FirstOrDefaultAsync(x => x.IdDenominacion == "A_PAN_IMP_ETI_EN" && x.Valor == true);

            if (cfgImpresion?.ValorTxt != "ACONDICIONADO")
                return;

            bool esCompleto = recDet.TbRecDetRepId == 2;
            bool esIncompleto = recDet.TbRecDetRepId == 3;

            string? zplCompleto = null;
            string? zplIncompleto = null;
            string? zplPrioridad = null;
            string? zplReprocesado = null;

            if (esCompleto)
            {
                zplCompleto = Etiquetas.RecepcionDetalleCompleto(
                    sector: recDet.TbRecSecOriDen,
                    material: recDet.TbRecDetMatDen,
                    fechaRecepcion: recDet.TbRecFec ?? DateTime.Now,
                    nroRecepcion: recDet.TbRecId,
                    idDetalle: nuevoDet.TbProAcoDetId,
                    cantidad: recDet.TbRecDetNum2 ?? 0
                );
            }

            if (esIncompleto)
            {
                zplIncompleto = Etiquetas.RecepcionDetalleIncompleto(
                    sector: recDet.TbRecSecOriDen,
                    material: recDet.TbRecDetMatDen,
                    fechaRecepcion: recDet.TbRecFec ?? DateTime.Now,
                    nroRecepcion: recDet.TbRecId,
                    idDetalle: nuevoDet.TbProAcoDetId,
                    cantidad: recDet.TbRecDetNum2 ?? 0,
                    detalleFaltante: recDet.TbRecDetMem1 ?? ""
                );
            }

            if (recDet.TbRecDetRepId == 5)
            {
                zplPrioridad = Etiquetas.RecepcionDetallePrioridadProceso(
                    recDet.TbRecSecDesDen,
                    recDet.TbRecDetMatDen,
                    recDet.TbRecFec ?? DateTime.Now,
                    recDet.TbRecId,
                    nuevoDet.TbProAcoDetId
                );
            }

            if (recDet.TbRecDetRepId == 10)
            {
                zplReprocesado = Etiquetas.RecepcionDetalleReprocesadoSinUso(
                    recDet.TbRecSecDesDen,
                    recDet.TbRecDetMatDen,
                    recDet.TbRecFec ?? DateTime.Now,
                    recDet.TbRecId,
                    nuevoDet.TbProAcoDetId
                );
            }

            string zpl = Etiquetas.RecepcionDetalle(
                sector: recDet.TbRecSecOriDen,
                material: recDet.TbRecDetMatDen,
                fechaRecepcion: recDet.TbRecFec ?? DateTime.Now,
                vencimiento: recDet.TbRecDetVen ?? DateTime.Now.AddMonths(6),
                nroRecepcion: recDet.TbRecId,
                idDetalle: nuevoDet.TbProAcoDetId,
                codigoReuso: recDet.TbRecDetReuId,
                tipoMaterial: recDet.TbRecDetMatMtiDen
            );

            for (int i = 0; i < cantidad; i++)
            {
                ImpresionZebra.EnviarAImpresora("ZDesigner GK420t", zpl);

                if (esCompleto && zplCompleto != null)
                    ImpresionZebra.EnviarAImpresora("ZDesigner GK420t", zplCompleto);

                if (esIncompleto && zplIncompleto != null)
                    ImpresionZebra.EnviarAImpresora("ZDesigner GK420t", zplIncompleto);

                if (recDet.TbRecDetRepId == 5 && zplPrioridad != null)
                    ImpresionZebra.EnviarAImpresora("ZDesigner GK420t", zplPrioridad);

                if (recDet.TbRecDetRepId == 10 && zplReprocesado != null)
                    ImpresionZebra.EnviarAImpresora("ZDesigner GK420t", zplReprocesado);
            }
        }


        [HttpGet]
        public async Task<IActionResult> ValidarLavadoPendiente(int id)
        {
            var pendientes = await _context.Set<TbProLavPendienteDto>()
                .FromSqlRaw($@"
        EXEC SP_BUSCAR_LAVADO_PENDIENTE_POR_ETIQUETA
        @TB_REC_DET_ID = {id}")
                .ToListAsync();

            if (pendientes.Any())
            {
                return Json(new
                {
                    success = false,
                    requiereFinalizarLavado = true,
                    tbProLavId = pendientes.First().TbProLavId,
                    mensaje = "Aún existen lavados sin finalizar para este elemento. ¿Desea finalizar los lavados incompletos?"
                });
            }

            return Json(new
            {
                success = true,
                requiereFinalizarLavado = false
            });
        }


        [HttpPost]
        public async Task<IActionResult> CerrarProceso(int tbProAcoId)
        {
            try
            {
                var cabecera = await _context.TbProAco
                    .FirstOrDefaultAsync(x => x.TbProAcoId == tbProAcoId);

                if (cabecera == null)
                {
                    return Json(new
                    {
                        success = false,
                        mensaje = "❌ No se encontró el proceso."
                    });
                }

                cabecera.TbProAcoHorFin = new DateTime(
                    1899,
                    12,
                    30,
                    DateTime.Now.Hour,
                    DateTime.Now.Minute,
                    DateTime.Now.Second
                );

                await _context.SaveChangesAsync();

                return Json(new
                {
                    success = true
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    mensaje = ex.Message
                });
            }
        }
    }
}
