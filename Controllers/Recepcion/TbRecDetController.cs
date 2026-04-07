using ConexionSql.Data;
using ConexionSql.Models.Afmr;
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

        private async Task<object> ProcesarControlReuso(int matId)
        {
            var material = await AfmrIbMat(matId);

            if (material == null)
            {
                return new
                {
                    ok = false,
                    mensaje = "No se encontró el material."
                };
            }

            if (material.IB_MAT_REU_OPC)
            {
                return new
                {
                    ok = true,
                    requiereControlReuso = true,
                    mensaje1 = "El elemento que desea registrar está configurado para control de reuso",
                    mensaje2 = "Ingrese el código de reuso asignado al producto médico"
                };
            }

            return new
            {
                ok = true,
                requiereControlReuso = false
            };
        }

        [HttpPost]
        public async Task<IActionResult> ControlarReuso([FromBody] TbRecDetDto detalle)
        {
            try
            {
                var resultado = await ProcesarControlReuso(detalle.IB_MAT_ID ?? 0);
                return Json(resultado);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    ok = false,
                    mensaje = "Error: " + ex.Message
                });
            }
        }

        [HttpPost]
        public IActionResult EvaluarRevision([FromBody] TbRecDetDto detalle)
        {
            try
            {
                int revisionId = detalle.TB_REC_DET_REP_ID ?? 0;

                // 🔹 1 → NO REGISTRA
                if (revisionId == 1)
                {
                    return Json(new { ok = true, usarFlujoActual = true });
                }

                // 🔹 2 → COMPLETO
                if (revisionId == 2)
                {
                    return Json(new
                    {
                        ok = true,
                        abrirModalRevision = true,
                        requiereFaltantes = false
                    });
                }

                // 🔹 3 → INCOMPLETO
                if (revisionId == 3)
                {
                    return Json(new
                    {
                        ok = true,
                        abrirModalRevision = true,
                        requiereFaltantes = true
                    });
                }

                // 🔹 4 → CONTENIDO VERIFICADO
                if (revisionId == 4)
                {
                    return Json(new { ok = true, continuarFlujo = true });
                }

                // 🔹 5 → PRIORIDAD DE PROCESO
                if (revisionId == 5)
                {
                    return Json(new { ok = true, continuarFlujo = true });
                }

                // 🔹 6 → DECONTAMINADO
                if (revisionId == 6)
                {
                    return Json(new { ok = true, continuarFlujo = true });
                }

                // 🔹 7 → --
                if (revisionId == 7)
                {
                    return Json(new { ok = true, continuarFlujo = true });
                }

                // 🔹 8 → CODIGO DE PRODUCTO
                if (revisionId == 8)
                {
                    return Json(new { ok = true, continuarFlujo = true });
                }

                // 🔹 9 → ENVOLTORIO VERIFICADO
                if (revisionId == 9)
                {
                    return Json(new { ok = true, continuarFlujo = true });
                }

                // 🔹 10 → MATERIAL REPROCESADO SIN USO
                if (revisionId == 10)
                {
                    return Json(new
                    {
                        ok = true,
                        txt3 = "MATERIAL REPROCESADO SIN USO",
                        mem1 = "NO REGISTRADO"
                    });
                }

                // 🔹 11 → VERIFICACION OPERATIVA
                if (revisionId == 11)
                {
                    return Json(new { ok = true, continuarFlujo = true });
                }

                // 🔹 12 → ENVOLTORIO DETERIORADO
                if (revisionId == 12)
                {
                    return Json(new { ok = true, continuarFlujo = true });
                }

                // 🔹 13 → REPROCESO ENVOLTORIO HUMEDO
                if (revisionId == 13)
                {
                    return Json(new { ok = true, continuarFlujo = true });
                }

                // 🔹 14 → MATERIAL CON REGISTRO DE PACIENTE
                if (revisionId == 14)
                {
                    return Json(new { ok = true, continuarFlujo = true });
                }

                // 🔹 15 → PRODUCTO LIMPIO
                if (revisionId == 15)
                {
                    return Json(new { ok = true, continuarFlujo = true });
                }

                // 🔹 16 → PRODUCTO SUCIO
                if (revisionId == 16)
                {
                    return Json(new { ok = true, continuarFlujo = true });
                }

                // 🔹 17 → --
                if (revisionId == 17)
                {
                    return Json(new { ok = true, continuarFlujo = true });
                }

                // 🔹 18 → --
                if (revisionId == 18)
                {
                    return Json(new { ok = true, continuarFlujo = true });
                }

                // 🔹 19 → --
                if (revisionId == 19)
                {
                    return Json(new { ok = true, continuarFlujo = true });
                }

                // 🔹 20 → --
                if (revisionId == 20)
                {
                    return Json(new { ok = true, continuarFlujo = true });
                }

                // 🔹 21 → --
                if (revisionId == 21)
                {
                    return Json(new { ok = true, continuarFlujo = true });
                }

                // 🔹 22 → --
                if (revisionId == 22)
                {
                    return Json(new { ok = true, continuarFlujo = true });
                }

                // 🔹 23 → --
                if (revisionId == 23)
                {
                    return Json(new { ok = true, continuarFlujo = true });
                }

                // 🔹 24 → REGISTRO CONTROL DE ARMADO
                if (revisionId == 24)
                {
                    return Json(new
                    {
                        ok = true,
                        abrirModalRca = true,
                        requiereControlAdicional = true
                    });
                }

                // 🔹 DEFAULT
                return Json(new { ok = true, continuarFlujo = true });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    ok = false,
                    mensaje = "Error: " + ex.Message
                });
            }
        }

        //valida q rama va dependiendo de sector
        private ResultadoValidacionReuso ValidarReuso(TbRecDetDto detalle, TbRec tbRec, TbReu reuso, IbMat material)
        {
            var sectorRecepcion = (tbRec?.TbRecSecDesDen ?? "").Trim().ToUpper();
            var sectorReuso = (reuso?.TbReuSecDen ?? "").Trim().ToUpper();
            var estadoId = detalle.TbRecDetEstId ?? 0;

            if (string.IsNullOrWhiteSpace(sectorRecepcion))
            {
                return new ResultadoValidacionReuso
                {
                    Ok = false,
                    Mensaje = "No se pudo determinar el sector de la recepción."
                };
            }

            if (string.IsNullOrWhiteSpace(sectorReuso))
            {
                return new ResultadoValidacionReuso
                {
                    Ok = false,
                    Mensaje = "No se pudo determinar el sector del código de reuso."
                };
            }

            if (sectorRecepcion != sectorReuso)
            {
                return new ResultadoValidacionReuso
                {
                    Ok = false,
                    Mensaje = "El sector del código de reuso no coincide con el sector de la recepción."
                };
            }

            if (sectorRecepcion == "CQ")
            {
                if ((material.IB_MAT_CES_SEC ?? 0) <= 0)
                {
                    return new ResultadoValidacionReuso
                    {
                        Ok = false,
                        Mensaje = "No existen unidades pendientes de registro."
                    };
                }
            }

            if (sectorRecepcion == "COB")
            {
                if ((material.IB_MAT_CES_PARTOS ?? 0) <= 0)
                {
                    return new ResultadoValidacionReuso
                    {
                        Ok = false,
                        Mensaje = "No existen unidades pendientes de registro."
                    };
                }
            }

            if (sectorRecepcion == "HMD" || sectorRecepcion == "CCV" || sectorRecepcion == "FPM")
            {
                if (estadoId != 12)
                {
                    return new ResultadoValidacionReuso
                    {
                        Ok = false,
                        Mensaje = "El código de reuso solo puede registrarse con estado 12."
                    };
                }
            }

            return new ResultadoValidacionReuso
            {
                Ok = true
            };
        }


        //valida vencimiento de reuso

        private ResultadoValidacionVen ValidarVencimientoReuso(
                TbReu reuso,
                bool aPanReuVenOpc,
                bool jdeOpc
            )
        {
            // ============================================
            // CASO 1: SE VALIDA VENCIMIENTO
            // ============================================
            if (aPanReuVenOpc)
            {
                var venPm = reuso?.TbReuDti1;

                if (venPm.HasValue && venPm.Value.Date < DateTime.Today)
                {
                    reuso.TbReuBsto = true;
                    reuso.TbReuBstoFec = DateTime.Now;

                    _context.TbReu.Update(reuso);
                    _context.SaveChanges();


                    return new ResultadoValidacionVen
                    {
                        Ok = false,
                        Mensaje = "El vencimiento del dispositivo médico que desea registrar es anterior a la fecha actual. No es posible realizar su registro.",

                        // Reset de datos
                        ReuId = 1,
                        ReuDen = "NO REGISTRADO",
                        MatId = 1,
                        MatDen = "NO REGISTRADO",
                        CodigoReuso = ""
                    };
                }

                // ✔ Válido → sigue a VALIDA_SEC
                return new ResultadoValidacionVen
                {
                    Ok = true,
                    SiguientePaso = "VALIDA_SEC"
                };
            }

            // ============================================
            // CASO 2: NO SE VALIDA VENCIMIENTO
            // ============================================
            if (jdeOpc)
            {
                return new ResultadoValidacionVen
                {
                    Ok = true,
                    SiguientePaso = "VALIDA_REUSOS"
                };
            }

            return new ResultadoValidacionVen
            {
                Ok = true,
                SiguientePaso = "VALIDA_SEC"
            };
        }

        [HttpPost]
        public async Task<IActionResult> ValidarCodigoReuso([FromBody] TbRecDetDto detalle)
        {
            Console.WriteLine($"[ValidarCodigoReuso] Confirmar={detalle.ConfirmarReusoExcedido} | ReuId={detalle.TB_REC_DET_REU_ID} | Est={detalle.IB_EST_ID} | Rev={detalle.TB_REC_DET_REP_ID}");
            try
            {
                var codigoReuso = (detalle.TB_REC_DET_REU_ID ?? "").Trim();

                // 1️⃣ Validación básica
                if (string.IsNullOrWhiteSpace(codigoReuso))
                {
                    return Json(new
                    {
                        ok = false,
                        mensaje = "Ingrese el código de reuso."
                    });
                }

                // 2️⃣ Buscar reuso
                var reuso = await AfmrTbReu(codigoReuso);

                if (reuso == null)
                {
                    return Json(new
                    {
                        ok = false,
                        mensaje = "Código de reuso inexistente."
                    });
                }

                // 3️⃣ Buscar material
                var material = await _context.IbMat
                    .FirstOrDefaultAsync(x => x.IB_MAT_ID == reuso.TbReuMatId);

                if (material == null)
                {
                    return Json(new
                    {
                        ok = false,
                        mensaje = "Material no encontrado para el código de reuso."
                    });
                }

                // 4️⃣ Buscar cabecera
                var tbRec = await _context.TbRec
                    .FirstOrDefaultAsync(x => x.TbRecId == detalle.TB_REC_ID);

                if (tbRec == null)
                {
                    return Json(new
                    {
                        ok = false,
                        mensaje = "No se encontró la cabecera de recepción."
                    });
                }

                // 5️⃣ VALIDACIÓN DE REUSO (sector, etc.)
                var validacion = ValidarReuso(detalle, tbRec, reuso, material);

                if (!validacion.Ok)
                {
                    return Json(new
                    {
                        ok = false,
                        mensaje = validacion.Mensaje
                    });
                }

                // 6️⃣ VALIDACIÓN DE VENCIMIENTO
                bool aPanReuVenOpc = ObtenerOpcionBool("A_PAN_REU_VEN_OPC", true);
                bool jdeOpc = false; // pendiente

                var resultadoVen = ValidarVencimientoReuso(reuso, aPanReuVenOpc, jdeOpc);

                if (!resultadoVen.Ok)
                {
                    return Json(new
                    {
                        ok = false,
                        mensaje = resultadoVen.Mensaje
                    });
                }

                // =========================================================
                // 🔥 7️⃣ VALIDACIÓN DE LÍMITE DE REUSOS
                // =========================================================
                var resultadoReusos = ValidarLimiteReuso(detalle, reuso, material);

                if (!resultadoReusos.Ok)
                {
                    return Json(new
                    {
                        ok = false,
                        mensaje = resultadoReusos.Mensaje,
                        requiereConfirmacion = resultadoReusos.RequiereConfirmacion,
                        bajaAutomatica = resultadoReusos.BajaAutomatica
                    });
                }

                // =========================================================
                // ✔ TODO OK → DEVUELVE DATOS
                // =========================================================
                return Json(new
                {
                    ok = true,
                    mensaje = "Reuso encontrado correctamente.",

                    tbReuId = reuso.TbReuId,
                    tbReuIdForm = reuso.TbReuIdForm,
                    tbReuMatId = reuso.TbReuMatId,

                    ibMatId = material.IB_MAT_ID,
                    ibMatDen = material.IB_MAT_DEN,

                    requiereConfirmacion = false,
                    bajaAutomatica = false
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    ok = false,
                    mensaje = "Error: " + ex.Message
                });
            }
        }

        //VALIDA_REUSOS

        private bool ObtenerOpcionBool(string denominacion, bool valorPorDefecto = false)
        {
            var opcion = _context.APanOpc.FirstOrDefault(x => x.IdDenominacion == denominacion);
            return opcion?.Valor ?? valorPorDefecto;
        }


        //Valida baja de reuso x cantidad
        private ResultadoValidacionReuso ValidarLimiteReuso(
            TbRecDetDto detalle,
            TbReu reuso,
            IbMat material
        )
        {
            // 🔢 Máximo permitido
            int reuMat = material.IB_MAT_REU_OPC_CANT ?? 0;

            // 🔢 Reuso actual
            int reuIni = reuso.TbReuMatOpcReg ?? 1;

            // 🏷️ Estado
            int estId = detalle.IB_EST_ID ?? 0;

            // 🔁 Revisión
            int revisionId = detalle.TB_REC_DET_REP_ID ?? 0;

            // 🔢 Resultado final
            int reuFin = 0;

            // ⚙️ Opción global desde tabla
            bool aPanReuStopOpc = ObtenerOpcionBool("A_PAN_REU_STOP_OPC", true);

            // =========================
            // CÁLCULO REU_FIN (igual a Access)
            // =========================
            if (estId == 12)
            {
                reuFin = 1;
            }
            else
            {
                if (revisionId == 10)
                {
                    reuFin = reuIni;
                }
                else
                {
                    reuFin = reuIni + 1;
                }
            }

            // 📌 Comparación contra límite
            bool superaLimite = reuFin > reuMat;

            if (superaLimite)
            {
                // STOP = TRUE → baja automática
                if (aPanReuStopOpc)
                {
                    reuso.TbReuBsto = true;
                    reuso.TbReuBstoFec = DateTime.Now;
                    reuso.TbReuBstoBcreuId = 2;
                    reuso.TbReuBstoBcreuDen = "Limite de reusos alcanzado.";

                    _context.TbReu.Update(reuso);
                    _context.SaveChanges();

                    return new ResultadoValidacionReuso
                    {
                        Ok = false,
                        BajaAutomatica = true,
                        Mensaje = "El código de reuso fue dado de baja automáticamente por superar el límite."
                    };
                }

                // 🔥 SI YA CONFIRMÓ → DEJAR PASAR
                if (detalle.ConfirmarReusoExcedido)
                {
                    return new ResultadoValidacionReuso
                    {
                        Ok = true
                    };
                }

                // STOP = FALSE → pedir confirmación
                return new ResultadoValidacionReuso
                {
                    Ok = false,
                    RequiereConfirmacion = true,
                    Mensaje = "El elemento ha superado el límite de reusos permitido. ¿Desea continuar?"
                };
            }

            // ✔ Todo OK
            return new ResultadoValidacionReuso
            {
                Ok = true
            };
        }

        //busca en denominacion
        [HttpGet]
        public IActionResult BuscarMaterial(string texto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(texto))
                {
                    return Json(new List<object>());
                }

                texto = texto.Trim();

                var materiales = _context.IbMat
                    .Where(m => m.IB_MAT_DEN != null && m.IB_MAT_DEN.Contains(texto))
                    .OrderBy(m => m.IB_MAT_DEN)
                    .Take(20)
                    .Select(m => new
                    {
                        id = m.IB_MAT_ID,
                        denominacion = m.IB_MAT_DEN
                    })
                    .ToList();

                return Json(materiales);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    ok = false,
                    mensaje = "Error al buscar materiales: " + ex.Message
                });
            }
        }

        [HttpGet]
        public IActionResult BuscarMaterialPorCodigo(string codigo)
        {
            try
            {
                // =========================================================
                // 1) VALIDAR ENTRADA
                // =========================================================
                if (string.IsNullOrWhiteSpace(codigo))
                {
                    return Json(new
                    {
                        ok = false,
                        mensaje = "No se recibió un código."
                    });
                }

                codigo = codigo.Trim();

                // =========================================================
                // 2) INTENTAR CONVERTIR A NÚMERO
                //    Si el operador ingresa un número, también buscamos
                //    por IB_MAT_ID
                // =========================================================
                int codigoNumerico = 0;
                int.TryParse(codigo, out codigoNumerico);

                // =========================================================
                // 3) BUSCAR DIRECTO EN IB_MAT
                //    a) por IB_MAT_ID
                //    b) por IB_MAT_PR
                // =========================================================
                var material = _context.IbMat.FirstOrDefault(m =>
                    (codigoNumerico > 0 && m.IB_MAT_ID == codigoNumerico)
                    || m.IB_MAT_PR == codigo
                || m.IB_MAT_DEN == codigo);

                if (material != null)
                {
                    return Json(new
                    {
                        ok = true,

                        // ID del material
                        ibMatId = material.IB_MAT_ID,
                        denominacion = material.IB_MAT_DEN,

                        // Tipo de material
                        ibMatMtiId = material.IB_MAT_MTI_ID,

                        // Volumen
                        volumen = material.IB_MAT_VOL ?? 0,

                        // Prioridad de proceso
                        ibMatPriOpc = material.IB_MAT_PRI_OPC,

                        // Origen de la búsqueda
                        origen = "IB_MAT",

                        // Mensaje para frontend
                        mensaje = $"Material encontrado: {material.IB_MAT_DEN}"
                    });
                }

                // =========================================================
                // 4) SI NO ESTÁ EN IB_MAT, BUSCAR EN TB_REU
                //    Acá el código ingresado puede ser un código de reuso
                // =========================================================
                var reuso = _context.TbReu.FirstOrDefault(r =>
                    r.TbReuId.ToString() == codigo);

                if (reuso != null)
                {
                    // =====================================================
                    // 5) VALIDAR QUE EL REUSO TENGA MATERIAL ASOCIADO
                    // =====================================================
                    if (!reuso.TbReuMatId.HasValue)
                    {
                        return Json(new
                        {
                            ok = false,
                            mensaje = "El código de reuso no tiene material asociado."
                        });
                    }

                    // =====================================================
                    // 6) BUSCAR EL MATERIAL RELACIONADO AL REUSO
                    // =====================================================
                    var materialDesdeReuso = _context.IbMat.FirstOrDefault(m =>
                        m.IB_MAT_ID == reuso.TbReuMatId.Value);

                    if (materialDesdeReuso != null)
                    {
                        return Json(new
                        {
                            ok = true,

                            // ID del material
                            ibMatId = materialDesdeReuso.IB_MAT_ID,

                            // Tipo de material
                            ibMatMtiId = materialDesdeReuso.IB_MAT_MTI_ID,

                            // Volumen
                            volumen = materialDesdeReuso.IB_MAT_VOL ?? 0,

                            // Prioridad de proceso
                            ibMatPriOpc = materialDesdeReuso.IB_MAT_PRI_OPC,

                            // Origen real de la búsqueda
                            origen = "TB_REU",

                            // Mensaje para frontend
                            mensaje = $"Material encontrado desde reuso: {materialDesdeReuso.IB_MAT_DEN}"
                        });
                    }

                    return Json(new
                    {
                        ok = false,
                        mensaje = "Reuso encontrado pero sin material válido asociado."
                    });
                }

                // =========================================================
                // 7) NO ENCONTRADO
                // =========================================================
                return Json(new
                {
                    ok = false,
                    mensaje = "No se encontró material."
                });
            }
            catch (Exception ex)
            {
                // =========================================================
                // 8) ERROR CONTROLADO
                // =========================================================
                return Json(new
                {
                    ok = false,
                    mensaje = "Error al buscar material: " + ex.Message
                });
            }
        }

        [HttpPost]
        public IActionResult BotAut([FromBody] TbRecDetDto detalle)
        {
            try
            {
                var mensaje = BotAutClick(detalle);

                return Json(new
                {
                    ok = true,
                    mensaje = mensaje ?? "OK"
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    ok = false,
                    mensaje = "Error en BotAut: " + ex.Message
                });
            }
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
                // PASO 0: EJECUTAR BOT_AUT ANTES DE INSERTAR
                // =========================================================
                var mensajeBotAut = BotAutClick(detalle);
                if (!string.IsNullOrEmpty(mensajeBotAut))
                {
                    return Json(new
                    {
                        success = false,
                        mensaje = mensajeBotAut
                    });
                }

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

                // =========================================================
                // PASO 3: SI CONTIENE MÁS DE 1 UNIDAD, ACTUALIZAR IB_MAT
                // =========================================================

                if ((material.IB_MAT_CON_UNID ?? 0) > 1)
                {
                    material.IB_MAT_PTE1_UBI_ID = 22;
                    material.IB_MAT_PTE1_UBI_DEN = "CE Recepcionado";

                    _context.IbMat.Update(material);
                }

                string nombreMaterial = material.IB_MAT_DEN ?? "SIN MATERIAL";

                // =========================================================
                // PASO 4: BUSCAR ESTADO
                // =========================================================
                string nombreEstado = await _context.IbEst
                    .Where(e => e.IbEstId == detalle.IB_EST_ID)
                    .Select(e => e.IbEstDen)
                    .FirstOrDefaultAsync() ?? "SIN ESTADO";

                // =========================================================
                // PASO 5: DEFINIR UDE SEGÚN ESTADO ELEGIDO
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
                // PASO 6: ARMAR DETALLE
                // =========================================================
                var registro = detalle.RegistroControlArmado;

                var entidad = new TbRecDet
                {
                    // RELACIÓN CON CABECERA
                    TbRecId = detalle.TB_REC_ID,

                    // DATOS DE CABECERA
                    TbRecFec = tbRec.TbRecFec,
                    TbRecHor = tbRec.TbRecHorIni,
                    TbRecPerId = tbRec.TbRecPerId,
                    TbRecPerNom = tbRec.TbRecPerNom,
                    TbRecPerApe = !string.IsNullOrWhiteSpace(tbRec.TbRecPerApe)
                    ? tbRec.TbRecPerApe
                    : "NO REGISTRA",
                    TbRecPerCarId = tbRec.TbRecPerCarId,
                    TbRecPerCarDen = tbRec.TbRecPerCarDen,
                    TbRecSecOriId = tbRec.TbRecSecOriId,
                    TbRecSecOriDen = tbRec.TbRecSecOriDen,
                    TbRecSecDesId = tbRec.TbRecSecDesId,
                    TbRecSecDesDen = tbRec.TbRecSecDesDen,
                    TbRecOrtId = tbRec.TbRecOrtId,
                    TbRecOrtDen = tbRec.TbRecOrtDen,
                    TbRecSecPer = tbRec.TbRecSecPer,

                    // DATOS DEL MATERIAL
                    TbRecDetMatId = material.IB_MAT_ID,
                    TbRecDetMatDen = material.IB_MAT_DEN,
                    TbRecDetMatPr = material.IB_MAT_PR,
                    TbRecDetMatMtiId = material.IB_MAT_MTI_ID,
                    TbRecDetMatMtiDen = material.IB_MAT_MTI_DEN,
                    TbRecDetMatEtiId = material.IB_MAT_ETI_ID,
                    TbRecDetMatEtiDen = material.IB_MAT_ETI_DEN,

                    // DATOS CALCULADOS POR BOT_AUT
                    IbMatVol = detalle.TB_REC_DET_VOL,
                    TbRecDetPmat = detalle.TB_REC_DET_PMAT,
                    TbRecDetEstIngId = 22,
                    TbRecDetEstIngDen = "CE Recepcionado",

                    // DATOS DEL ESTADO
                    TbRecDetEstId = detalle.IB_EST_ID,
                    TbRecDetEstDen = nombreEstado,

                    // CANTIDAD
                    TbRecDetCant = detalle.TB_REC_DET_CANT,

                    // DEFAULTS / REGISTRO CONTROL ARMADO
                    TbRecDetVopOpc = registro?.Vop ?? false,
                    TbRecDetRepId = registro?.TbRecDetRevId ?? detalle.TB_REC_DET_REP_ID ?? 1,
                    TbRecDetReuOpc = detalle.TB_REC_DET_REU_OPC,

                                TbRecDetReuId = !string.IsNullOrWhiteSpace(detalle.TB_REC_DET_REU_ID)
                    ? detalle.TB_REC_DET_REU_ID
                    : "1",

                                TbRecDetReuDen = !string.IsNullOrWhiteSpace(detalle.TB_REC_DET_REU_DEN)
                    ? detalle.TB_REC_DET_REU_DEN
                    : "NO REGISTRADO",

                    TbRecDetReuCant = detalle.TB_REC_DET_REU_CANT ?? 0,
                    TbRecDetOrtId = 0,
                    TbRecDetOrtDen = "NO REGISTRA",

                    // CAMPOS QUE VENÍAN CARGADOS
                    TbRecDetProId = 1,
                    TbRecDetProNom = "NO REGISTRA",
                    TbRecDetProApe = "NO REGISTRA",
                    TbRecDetProPtiId = 1,
                    TbRecDetProPtiDen = "NO REGISTRA",
                    TbRecDetPac = "NO REGISTRA",
                    TbRecDetRem = "0",
                    TbRecDetDat = "NO REGISTRA",
                    TbRecDetTxt1 = "NO REGISTRA",
                    TbRecDetTxt2 = "NO REGISTRA",
                    TbRecDetObs = detalle.TbRecDetObs,
                    TbRecDetMde = registro?.TbRecDetMde ?? false,
                    TbRecDetMort = 1,
                    TbRecDetCantMult = 1,

                    // STOCKS DE RECEPCIÓN
                    TbRecDetRecCant = 0,
                    TbRecDetRecStock = detalle.TB_REC_DET_CANT,
                    TbRecDetRecTot = 0,
                    TbRecDetRecUde = 1,
                    TbRecDetStock = 0,
                    TbRecDetTot = 0,

                    // LAVADO
                    TbRecDetLavCant = 0,
                    TbRecDetLavTot = 0,
                    TbRecDetLavUde = udeLav,

                    // DECONTAMINADO
                    TbRecDetDecCant = 0,
                    TbRecDetDecTot = 0,
                    TbRecDetDecUde = udeDec,
                    TbRecDetTraStock = 0,

                    // TRASLADO
                    TbRecDetTraCant = 0,
                    TbRecDetTraUde = udeTra,
                    TbRecDetTraTot = 0,

                    // EMPAQUE
                    TbRecDetEmpCant = 0,
                    TbRecDetEmpTot = 0,
                    TbRecDetEmpUde = udeEmp,

                    // PROCESO
                    TbRecDetProAbo = 0,
                    TbRecDetProCant = 0,
                    TbRecDetProTot = 0,
                    TbRecDetProUde = udePro,
                    TbRecDetSecProcStock = 0,
                    TbRecDetSecProcTot = 0,
                    TbRecDetProcSecStock = 0,

                    // ENTREGA
                    TbRecDetEntTot = 0,
                    TbRecDetEntUde = udeEnt,

                    // SECTOR
                    TbRecDetSecCant = 0,
                    TbRecDetSecStock = 0,
                    TbRecDetSecTot = 0,
                    TbRecDetSecRegStock = 0,
                    TbRecDetSecRegTot = 0,

                    // DEVOLUCIÓN
                    TbRecDetDevCant = 0,

                    // OTROS
                    TbRecDetNum1 = 0,
                    TbRecDetNum2 = registro?.CantidadElementos ?? detalle.TB_REC_DET_NUM_2,
                    TbRecDetNum3 = detalle.TB_REC_DET_NUM_3,
                    TbRecDetTxt3 = registro?.TbRecDetTxt3 ?? detalle.TB_REC_DET_TXT_3,
                    TbRecDetMem1 = registro?.TbRecDetMem1 ?? detalle.TB_REC_DET_MEM_1,
                    TbRecDetDti1 = detalle.TB_REC_DET_DTI_1,
                    TbRecDetVen = detalle.TB_REC_DET_VEN,

                    // STOCKS EXISTENTES
                    TbRecDetEmpStock = detalle.TB_REC_DET_EMP_STOCK,
                    TbRecDetProStock = detalle.TB_REC_DET_PRO_STOCK,
                    TbRecDetLavStock = detalle.TB_REC_DET_LAV_STOCK,
                    TbRecDetEntStock = detalle.TB_REC_DET_ENT_STOCK,
                    TbRecDetDecStock = detalle.TB_REC_DET_DEC_STOCK,
                    TbRecDetEntCant = detalle.TB_REC_DET_ENT_CANT,

                    // SISTEMA
                    TbRecDetPcLog = Environment.MachineName,
                    TbRecDetPcUsr = Environment.UserName,

                    TbRecDetIvisOpc = registro?.Control ?? false,
                    TbRecDetAcajOpc = registro?.ArmadoCaja ?? false,

                    TbRecDetIvisOpcNom = !string.IsNullOrWhiteSpace(registro?.ControladaPor)
                    ? registro.ControladaPor
                    : "NO REGISTRADO",

                                TbRecDetAcajOpcNom = !string.IsNullOrWhiteSpace(registro?.ArmadaPor)
                    ? registro.ArmadaPor
                    : "NO REGISTRA",
                            };


                _context.TbRecDet.Add(entidad);
                await _context.SaveChangesAsync();

                // 🔢 CONSULTAR TOTAL ACTUAL Y SUMAR CANTIDAD INSERTADA
                var totalActual = await _context.TbRec
                    .Where(r => r.TbRecId == detalle.TB_REC_ID)
                    .Select(r => r.TbRecCantTot)
                    .FirstOrDefaultAsync();

                tbRec.TbRecCantTot = (totalActual ?? 0) + (entidad.TbRecDetCant);

                _context.TbRec.Update(tbRec);
                await _context.SaveChangesAsync();


                string zpl = Etiquetas.RecepcionDetalle(
                    material: nombreMaterial,
                    cantidad: detalle.TB_REC_DET_CANT,
                    fecha: tbRec.TbRecFec ?? DateTime.Now,
                    hora: tbRec.TbRecHorIni?.TimeOfDay ?? DateTime.Now.TimeOfDay,
                    nroRecepcion: tbRec.TbRecId,
                    idDetalle: entidad.TbRecDetId
                );

                ImpresionZebra.EnviarAImpresora("ZDesigner GK420t", zpl);

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

                string html = await this.RenderViewToStringAsync(
                    "~/Views/Recepcion/_DetalleTabla.cshtml",
                    lista,
                    true
                );

                return Json(new
                {
                    success = true,
                    mensaje = "✅ Detalle agregado correctamente.",
                    html,
                    totalRecibido = tbRec.TbRecCantTot
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex}");
                return Json(new
                {
                    success = false,
                    mensaje = "Error interno: " + ex.Message
                });
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

        private async Task<TbReu?> AfmrTbReu(string codigoReuso)
        {
            return await _context.TbReu
                .FirstOrDefaultAsync(x => x.TbReuIdForm == codigoReuso);
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

        private AfmrIbMatDatosDto ObtenerDatosAfmrIbMat(IbMat material)
        {
            if (material == null)
            {
                return new AfmrIbMatDatosDto
                {
                    Volumen = 0,
                    Peso = 0,
                    ContenidoUnidad = 0
                };
            }

            return new AfmrIbMatDatosDto
            {
                Volumen = material.IB_MAT_VOL ?? 0,
                Peso = Convert.ToDecimal(material.IB_MAT_PMAT ?? 0),
                ContenidoUnidad = material.IB_MAT_CON_UNID ?? 0
            };
        }



        private string? BotAutClick(TbRecDetDto detalle)
        {
            if (!detalle.IB_MAT_ID.HasValue || detalle.IB_MAT_ID.Value <= 1)
            {
                return "Debe seleccionar un material.";
            }

            var material = AfmrIbMat(detalle.IB_MAT_ID.Value).Result;

            if (material == null)
            {
                return "Material no encontrado.";
            }

            if (material.IB_MAT_REU_OPC == true && detalle.TB_REC_DET_CANT > 1)
            {
                return "Para materiales de reuso la cantidad debe ser 1.";
            }

            var datosMaterial = ObtenerDatosAfmrIbMat(material);

            detalle.TB_REC_DET_VOL = Convert.ToInt32(datosMaterial.Volumen ?? 0);
            detalle.TB_REC_DET_PMAT = Convert.ToSingle(datosMaterial.Peso ?? 0);

            if ((datosMaterial.ContenidoUnidad ?? 0) > 1)
            {
                detalle.TB_REC_DET_EST_ING_ID = 22;
                detalle.TB_REC_DET_EST_ING_DEN = "CE Recepcionado";
            }
            else
            {
                detalle.TB_REC_DET_EST_ING_ID = null;
                detalle.TB_REC_DET_EST_ING_DEN = null;
            }

            IbMatEti? etiqueta = null;

            if (material.IB_MAT_ETI_ID.HasValue)
            {
                etiqueta = AfmrIbMatEti(material.IB_MAT_ETI_ID.Value).Result;

                if (etiqueta == null)
                {
                    return "Etiqueta no encontrada.";
                }
            }

            // ==========================
            // VARIABLES DE VENCIMIENTO
            // ==========================
            bool A_PAN_VEN_OPC = true;
            bool A_PAN_OPC_SEC_OPC = false;
            bool VencimientoFabricante = true;

            DateTime fecha = DateTime.Now;
            int CantDias = 0;
            DateTime vencimiento;

            int tareaRealizarId = 0;

            DateTime? vencFab = null;
            TbReu? reu = null;

            // ==========================
            // 1) ENVOLTORIO o FIJO
            // ==========================
            if (A_PAN_VEN_OPC)
            {
                CantDias = etiqueta?.IB_MAT_ETI_NUM_1 ?? 0;
                vencimiento = fecha.AddDays(CantDias);
            }
            else
            {
                CantDias = 2000;
                vencimiento = fecha.AddDays(CantDias);
            }

            // ==========================
            // 2) SECTOR (PISA)
            // ==========================
            var cabecera = _context.TbRec
                .FirstOrDefault(x => x.TbRecId == detalle.TB_REC_ID);

            if (cabecera == null)
            {
                return "No se encontró la cabecera de recepción.";
            }

            var sector = _context.IbSectores
                .FirstOrDefault(x => x.IbSecId == cabecera.TbRecSecDesId);

            if (A_PAN_OPC_SEC_OPC)
            {
                int? vencimientoSector = sector?.IbSecVen;

                if (vencimientoSector.HasValue)
                {
                    vencimiento = fecha.AddDays(vencimientoSector.Value);
                }
            }

            // ==========================
            // 3) FABRICANTE (PISA)
            // ==========================
            vencFab = null;

            if (detalle.IB_EST_ID == 12)
            {
                if (!string.IsNullOrWhiteSpace(detalle.TB_REC_DET_REU_ID) && detalle.TB_REC_DET_REU_ID != "1")
                {
                    reu = _context.TbReu
                        .FirstOrDefault(x => x.TbReuIdForm == detalle.TB_REC_DET_REU_ID);

                    vencFab = reu?.TbReuDti1;
                }

                if (vencFab.HasValue)
                {
                    vencimiento = vencFab.Value;
                }
            }

            // ==========================
            // 4) FABRICANTE (PISA) MZA
            // ==========================
            vencFab = null;

            if (!string.IsNullOrWhiteSpace(detalle.TB_REC_DET_REU_ID) && detalle.TB_REC_DET_REU_ID != "1")
            {
                reu = _context.TbReu
                    .FirstOrDefault(x => x.TbReuIdForm == detalle.TB_REC_DET_REU_ID);

                vencFab = reu?.TbReuDti1;
            }

            detalle.TB_REC_DET_VEN = vencimiento;

            // ==========================
            // 5) REUSO
            // ==========================
            if (!string.IsNullOrWhiteSpace(detalle.TB_REC_DET_REU_ID) && detalle.TB_REC_DET_REU_ID != "1")
            {
                detalle.TB_REC_DET_REU_OPC = true;

                reu = _context.TbReu
                    .FirstOrDefault(x => x.TbReuIdForm == detalle.TB_REC_DET_REU_ID);

                if (reu == null)
                {
                    return "Código de reuso inexistente.";
                }

                if (reu.TbReuMatId != detalle.IB_MAT_ID)
                {
                    return "El código de reuso no corresponde al material seleccionado.";
                }

                int reuIni = reu.TbReuMatOpcReg ?? 0;
                int reuMax = reu.TbReuMatOpcCant;
                int reuFin = reuIni + (detalle.TB_REC_DET_REP_ID == 10 ? 0 : 1);

                // 🔥 CORRECCIÓN CLAVE
                if (reuFin > reuMax && !detalle.ConfirmarReusoExcedido)
                {
                    return $"El reuso supera el máximo permitido ({reuMax}).";
                }

                detalle.TB_REC_DET_REU_ID = reu.TbReuIdForm;
                detalle.TB_REC_DET_REU_DEN = reu.TbReuMatDen;
                detalle.TB_REC_DET_REU_CANT = reuFin;
                detalle.TB_REC_DET_REU_OPC = true;

                reu.TbReuMatOpcReg = reuFin;
            }
            else
            {
                detalle.TB_REC_DET_REU_OPC = false;
            }

            return null;
        }
    }
}