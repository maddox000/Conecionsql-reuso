using ConexionSql.Data;
using ConexionSql.Models.Materiales;
using ConexionSql.Models.Recepciones;
using ConexionSql.Models.Reuso;
using ConexionSql.Utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ConexionSql.Controllers
{
    public class TbRecDetController : Controller
    {
        private readonly ConexionSqlContext _context;

        public TbRecDetController(ConexionSqlContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] TbRecDetDto detalle)
        {
            Console.WriteLine("🔄 Insertar() fue invocado.");
            Console.WriteLine($"📥 Recibido DTO: RecId={detalle.TB_REC_ID}, MatId={detalle.IB_MAT_ID}, Cant={detalle.TB_REC_DET_CANT}");

            if (!ModelState.IsValid)
            {
                Console.WriteLine("❌ ModelState inválido.");
                return Json(new { success = false, mensaje = "Datos inválidos." });
            }

            try
            {
                // =========================================================
                // PASO 1: BUSCAR CABECERA
                // =========================================================
                var tbRec = await _context.TbRec
                    .FirstOrDefaultAsync(r => r.TbRecId == detalle.TB_REC_ID);

                if (tbRec == null)
                {
                    return Json(new { success = false, mensaje = "Cabecera no encontrada." });
                }

                // =========================================================
                // PASO 2: BUSCAR MATERIAL
                // =========================================================
                var material = await _context.IbMat
                    .FirstOrDefaultAsync(m => m.IB_MAT_ID == detalle.IB_MAT_ID);

                if (material == null)
                {
                    return Json(new { success = false, mensaje = "Material no encontrado." });
                }

                string nombreMaterial = material.IB_MAT_DEN ?? "SIN MATERIAL";

                // =========================================================
                // PASO 3: BUSCAR ESTADO
                // =========================================================
                string nombreEstado = await _context.IbEst
                    .Where(e => e.IbEstId == detalle.IB_EST_ID)
                    .Select(e => e.IbEstDen)
                    .FirstOrDefaultAsync() ?? "SIN ESTADO";

                // =========================================================
                // PASO 4: DEFINIR UDE SEGÚN ESTADO ELEGIDO
                // =========================================================
                int udeLav = 0;
                int udeDec = 0;
                int udeTra = 0;
                int udeEmp = 0;
                int udePro = 0;
                int udeEnt = 0;

                switch (detalle.IB_EST_ID)
                {
                    case 1:
                        udeLav = detalle.TB_REC_DET_CANT;
                        break;

                    case 3:
                        udeEmp = detalle.TB_REC_DET_CANT;
                        break;

                    case 4:
                        udePro = detalle.TB_REC_DET_CANT;
                        break;

                    case 5:
                        udeEnt = detalle.TB_REC_DET_CANT;
                        break;

                    case 6:
                        udeDec = detalle.TB_REC_DET_CANT;
                        break;

                    case 7:
                        udeTra = detalle.TB_REC_DET_CANT;
                        break;
                }

                // =========================================================
                // PASO 5: ARMAR DETALLE
                // =========================================================
                var entidad = new TbRecDet
                {
                    // -----------------------------------------------------
                    // RELACIÓN CON CABECERA
                    // -----------------------------------------------------
                    TbRecId = detalle.TB_REC_ID,

                    // -----------------------------------------------------
                    // DATOS DE CABECERA
                    // -----------------------------------------------------
                    TbRecFec = tbRec.TbRecFec,
                    TbRecHor = tbRec.TbRecHorIni,
                    TbRecPerId = tbRec.TbRecPerId,
                    TbRecPerNom = tbRec.TbRecPerNom,
                    TbRecPerApe = tbRec.TbRecPerApe,
                    TbRecPerCarId = tbRec.TbRecPerCarId,
                    TbRecPerCarDen = tbRec.TbRecPerCarDen,
                    TbRecSecOriId = tbRec.TbRecSecOriId,
                    TbRecSecOriDen = tbRec.TbRecSecOriDen,
                    TbRecSecDesId = tbRec.TbRecSecDesId,
                    TbRecSecDesDen = tbRec.TbRecSecDesDen,
                    TbRecOrtId = tbRec.TbRecOrtId,
                    TbRecOrtDen = tbRec.TbRecOrtDen,
                    TbRecSecPer = tbRec.TbRecSecPer,

                    // -----------------------------------------------------
                    // DATOS DEL MATERIAL
                    // -----------------------------------------------------
                    TbRecDetMatId = material.IB_MAT_ID,
                    TbRecDetMatDen = material.IB_MAT_DEN,
                    TbRecDetMatPr = material.IB_MAT_PR,
                    TbRecDetMatMtiId = material.IB_MAT_MTI_ID,
                    TbRecDetMatMtiDen = material.IB_MAT_MTI_DEN,

                    // -----------------------------------------------------
                    // DATOS DEL ESTADO
                    // -----------------------------------------------------
                    TbRecDetEstId = detalle.IB_EST_ID,
                    TbRecDetEstDen = nombreEstado,
                    TbRecDetEstIngId = 22,
                    TbRecDetEstIngDen = "CE Recepcionado",

                    // -----------------------------------------------------
                    // CANTIDAD
                    // -----------------------------------------------------
                    TbRecDetCant = detalle.TB_REC_DET_CANT,

                    // -----------------------------------------------------
                    // DEFAULTS IGUALADOS A ACCESS
                    // -----------------------------------------------------
                    TbRecDetVopOpc = false,
                    TbRecDetRepId = detalle.TB_REC_DET_REP_ID ?? 1,
                    TbRecDetReuOpc = false,
                    TbRecDetReuId = "1",
                    TbRecDetReuDen = "NO REGISTRADO",
                    TbRecDetOrtId = 0,
                    TbRecDetOrtDen = "NO REGISTRA",
                    TbRecDetReuCant = 0,

                    // -----------------------------------------------------
                    // CAMPOS QUE EN ACCESS VENÍAN CARGADOS
                    // -----------------------------------------------------
                    TbRecDetProId = 1,
                    TbRecDetProNom = "NO REGISTRA",
                    TbRecDetProApe = "NO REGISTRA",
                    TbRecDetPac = "NO REGISTRA",
                    TbRecDetRem = "0",
                    TbRecDetObs = null,
                    TbRecDetMde = false,

                    // -----------------------------------------------------
                    // STOCKS DE RECEPCIÓN
                    // -----------------------------------------------------
                    TbRecDetRecCant = 0,
                    TbRecDetRecStock = detalle.TB_REC_DET_CANT,
                    TbRecDetRecTot = 0,
                    TbRecDetRecUde = 1,
                    TbRecDetStock = 0,
                    TbRecDetTot = 0,

                    // -----------------------------------------------------
                    // LAVADO
                    // -----------------------------------------------------
                    TbRecDetLavCant = 0,
                    TbRecDetLavTot = 0,
                    TbRecDetLavUde = udeLav,

                    // -----------------------------------------------------
                    // DECONTAMINADO
                    // -----------------------------------------------------
                    TbRecDetDecCant = 0,
                    TbRecDetDecTot = 0,
                    TbRecDetDecUde = udeDec,

                    // -----------------------------------------------------
                    // TRASLADO
                    // -----------------------------------------------------
                    TbRecDetTraCant = 0,
                    TbRecDetTraUde = udeTra,

                    // -----------------------------------------------------
                    // EMPAQUE / ACONDICIONADO
                    // -----------------------------------------------------
                    TbRecDetEmpCant = 0,
                    TbRecDetEmpTot = 0,
                    TbRecDetEmpUde = udeEmp,

                    // -----------------------------------------------------
                    // PROCESO
                    // -----------------------------------------------------
                    TbRecDetProAbo = 0,
                    TbRecDetProCant = 0,
                    TbRecDetProTot = 0,
                    TbRecDetProUde = udePro,

                    // -----------------------------------------------------
                    // ENTREGA
                    // -----------------------------------------------------
                    TbRecDetEntTot = 0,
                    TbRecDetEntUde = udeEnt,

                    // -----------------------------------------------------
                    // SECTOR
                    // -----------------------------------------------------
                    TbRecDetSecCant = 0,
                    TbRecDetSecStock = 0,
                    TbRecDetSecTot = 0,

                    // -----------------------------------------------------
                    // DEVOLUCIÓN
                    // -----------------------------------------------------
                    TbRecDetDevCant = 0,

                    // -----------------------------------------------------
                    // OTROS
                    // -----------------------------------------------------
                    IbMatVol = 1,
                    TbRecDetNum1 = 0,
                    TbRecDetNum2 = detalle.TB_REC_DET_NUM_2,
                    TbRecDetNum3 = detalle.TB_REC_DET_NUM_3,
                    TbRecDetTxt3 = detalle.TB_REC_DET_TXT_3,
                    TbRecDetDti1 = detalle.TB_REC_DET_DTI_1,

                    // -----------------------------------------------------
                    // STOCKS EXISTENTES
                    // -----------------------------------------------------
                    TbRecDetEmpStock = detalle.TB_REC_DET_EMP_STOCK,
                    TbRecDetProStock = detalle.TB_REC_DET_PRO_STOCK,
                    TbRecDetLavStock = detalle.TB_REC_DET_LAV_STOCK,
                    TbRecDetEntStock = detalle.TB_REC_DET_ENT_STOCK,
                    TbRecDetDecStock = detalle.TB_REC_DET_DEC_STOCK,
                    TbRecDetEntCant = detalle.TB_REC_DET_ENT_CANT,

                    // -----------------------------------------------------
                    // DATOS DE SISTEMA
                    // -----------------------------------------------------
                    TbRecDetPcLog = Environment.MachineName,
                    TbRecDetPcUsr = Environment.UserName
                };

                // =========================================================
                // PASO 6: GUARDAR
                // =========================================================
                _context.TbRecDet.Add(entidad);
                await _context.SaveChangesAsync();

                // =========================================================
                // PASO 7: GENERAR ETIQUETA
                // =========================================================
                string zpl = Etiquetas.RecepcionDetalle(
                    material: nombreMaterial,
                    cantidad: detalle.TB_REC_DET_CANT,
                    fecha: tbRec.TbRecFec ?? DateTime.Now,
                    hora: tbRec.TbRecHorIni?.TimeOfDay ?? DateTime.Now.TimeOfDay,
                    nroRecepcion: tbRec.TbRecId,
                    idDetalle: entidad.TbRecDetId
                );

                ImpresionZebra.EnviarAImpresora("ZDesigner GK420t", zpl);

                // =========================================================
                // PASO 8: RECARGAR LISTA
                // =========================================================
                var lista = await _context.TbRecDet
                    .Where(d => d.TbRecId == detalle.TB_REC_ID)
                    .Select(d => new TbRecDetDto
                    {
                        TB_REC_DET_ID = d.TbRecDetId,
                        TB_REC_ID = d.TbRecId,
                        IB_MAT_ID = d.TbRecDetMatId,
                        TbRecDetMatDen = d.TbRecDetMatDen,
                        IB_EST_ID = d.TbRecDetEstId,
                        IB_EST_DEN = d.TbRecDetEstDen,
                        TB_REC_DET_CANT = d.TbRecDetCant,
                        TB_REC_DET_NUM_2 = d.TbRecDetNum2,
                        TB_REC_DET_NUM_3 = d.TbRecDetNum3,
                        TB_REC_DET_TXT_3 = d.TbRecDetTxt3,
                        TB_REC_DET_DTI_1 = d.TbRecDetDti1
                    })
                    .ToListAsync();

                // =========================================================
                // PASO 9: RENDERIZAR TABLA
                // =========================================================
                string html = await this.RenderViewToStringAsync(
                    "~/Views/Recepcion/_DetalleTabla.cshtml",
                    lista,
                    true
                );

                return Json(new
                {
                    success = true,
                    mensaje = "✅ Detalle agregado correctamente.",
                    html
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.Message}");
                return Json(new { success = false, mensaje = "Error interno." });
            }
        }

        private string? ValidarIngresoRecepcion(TbRecDetDto detalle)
        {
            /*abre A_PAN_OPCverifica circuito cerrado
             * hec profesionales
             * me.tb_rec_pro.enabled = false
             * hace algo si no es jde
            
            
                    if (etiUniOpc)
                    {
                        // código único = TRUE
                        
                    }
                    else
                    {
                        // código único = FALSE
                        if (limiteEtiquetas =0)
                        {
                            // botAutClick
                        }
                        else
                        {
                            limiteEtiquetas > 0
                            "Ud quiere impirmir.....? = si
                            // botAutClick
                        }
                    }
                return "Debe seleccionar un material.";*/

            if (detalle.TB_REC_DET_CANT <= 0)
                return "Cantidad inválida.";

            if (detalle.IB_EST_ID <= 0)
                return "Debe seleccionar un estado.";

            // 🔥 TUS IF VAN ACÁ
            // ejemplo:
            if (detalle.IB_EST_ID == 4 && detalle.TB_REC_DET_CANT > 1000)
                return "Cantidad demasiado alta para esterilizado.";

            return null; 
        }

        private async Task<IbMat?> AfmrIbMat(int matId)
        {
            return await _context.IbMat
                .FirstOrDefaultAsync(x => x.IB_MAT_ID == matId);
        }

        private async Task<IbMatEti?> AfmrIbMatEti(int etiId)
        {
            return await _context.IbMatEti
                .FirstOrDefaultAsync(x => x.IB_MAT_ETI_ID == etiId);
        }

        private async Task<TbReu?> AfmrTbReu(int id)
        {
            return await _context.TbReu
                .FirstOrDefaultAsync(x => x.TbReuId == id);
        }

        private async Task<TbRecDet?> AfmrTbRecDet(int id)
        {
            return await _context.TbRecDet
                .FirstOrDefaultAsync(x => x.TbRecDetId == id);
        }

        //private async Task<APanOpc?> AfmrAPanOpc()
        //{
        //    return await _context.APanOpc
        //        .FirstOrDefaultAsync();
        //}



        private string? BotAutClick(TbRecDetDto detalle)
        {

            /*abre A_PAN_OPC verifica circuito cerrado
             * circuito JDE
             * si es reu verifica q cantidad sea 1
             * if (detalle.IB_MAT_ID <= 0)
                return "Debe seleccionar un material.";
            debe verificar si es 1 id le dice q no seleciono material y vualve al campo den
            elseif(detalle.IB_MAT_ID > 1)
            abre afmrIbmat, buscando x id
            abre afmr ib_matEti where eti_id lo saca de afmrIbmat

             */
            // 1. validar material
            if (detalle.IB_MAT_ID <= 0)
            {
                var material = AfmrIbMat(detalle.IB_MAT_ID.Value).Result;
                return "Debe seleccionar un material.";
            }
            else
            {
                // 2. traer material (AFMR_IB_MAT)
                var material = AfmrIbMat(detalle.IB_MAT_ID.Value).Result;

                if (material == null)
                    return "Material no encontrado.";

                // 3. si es reutilizable → cantidad debe ser 1
                if (material.IB_MAT_REU_OPC == true && detalle.TB_REC_DET_CANT > 1)
                {
                    return "Para materiales de reuso la cantidad debe ser 1.";
                }

                // 4. traer envoltorio desde material
                if (material.IB_MAT_ETI_ID != null)
                {
                    var etiqueta = AfmrIbMatEti(material.IB_MAT_ETI_ID.Value).Result;

                    // acá después metés lógica de etiqueta
                }
            }

            // más lógica tuya acá...

            return null;
        }
    }
}