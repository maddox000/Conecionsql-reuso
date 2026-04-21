using ConexionSql.Data;
using ConexionSql.Models.Procesos.Controles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace ConexionSql.Controllers.Procesos.Controles
{
    public class TbProControlController : Controller
    {
        private readonly ConexionSqlContext _context;

        public TbProControlController(ConexionSqlContext context)
        {
            _context = context;
        }



        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] JsonElement dto)
        {
            try
            {
                int GetInt(string nombre, int porDefecto = 0)
                {
                    if (dto.TryGetProperty(nombre, out var prop))
                    {
                        if (prop.ValueKind == JsonValueKind.Number && prop.TryGetInt32(out var n))
                            return n;

                        if (prop.ValueKind == JsonValueKind.String && int.TryParse(prop.GetString(), out var s))
                            return s;
                    }

                    return porDefecto;
                }

                string? GetString(string nombre)
                {
                    if (dto.TryGetProperty(nombre, out var prop))
                    {
                        if (prop.ValueKind == JsonValueKind.String)
                            return prop.GetString();

                        if (prop.ValueKind != JsonValueKind.Null && prop.ValueKind != JsonValueKind.Undefined)
                            return prop.ToString();
                    }

                    return null;
                }

                DateTime? GetDateTime(string nombre)
                {
                    if (dto.TryGetProperty(nombre, out var prop))
                    {
                        if (prop.ValueKind == JsonValueKind.String &&
                            DateTime.TryParse(prop.GetString(), out var fecha))
                            return fecha;
                    }

                    return null;
                }

                int tbProId = GetInt("TB_PRO_ID");

                if (tbProId <= 0)
                {
                    return Json(new { success = false, mensaje = "TB_PRO_ID inválido." });
                }

                var cabecera = _context.TbPro.FirstOrDefault(x => x.TbProId == tbProId);

                if (cabecera == null)
                {
                    return Json(new { success = false, mensaje = "No se encontró la cabecera del proceso." });
                }

                var nuevo = new TbProDetPte
                {
                    TbProId = tbProId,
                    TbProFec = DateTime.Now,

                    TbProPteId = GetInt("TB_PRO_PTE_ID"),
                    TbProPteDen = GetString("TB_PRO_PTE_DEN"),

                    TbProPtePtiId = cabecera.TbProPtiId,
                    TbProPtePtiDen = cabecera.TbProPtiDen,

                    TbProPteEquId = cabecera.TbProEquId,
                    TbProPteEquDen = cabecera.TbProEquDen,

                    TbProPteIde = GetString("TB_PRO_PTE_IDE"),

                    TbProDetTesUbiId = GetInt("TB_PRO_DET_TES_UBI_ID"),
                    TbProDetTesUbiDen = GetString("TB_PRO_DET_TES_UBI_DEN"),

                    TbProPteCant = GetInt("TB_PRO_PTE_CANT", 1),

                    TbProPteResId = 1,
                    TbProPteResDen = "EN PROCESO",

                    TbProDetTesNum1 = GetInt("TB_PRO_DET_TES_NUM_1"),
                    TbProDetTesNum2 = GetInt("TB_PRO_DET_TES_NUM_2"),
                    TbProDetTesNum3 = GetInt("TB_PRO_DET_TES_NUM_3"),

                    TbProDetTesTxt1 = GetString("TB_PRO_DET_TES_TXT_1"),
                    TbProDetTesTxt2 = GetString("TB_PRO_DET_TES_TXT_2"),
                    TbProDetTesTxt3 = GetString("TB_PRO_DET_TES_TXT_3"),

                    TbProDetTesDti1 = GetDateTime("TB_PRO_DET_TES_DTI_1"),
                    TbProDetTesDti2 = GetDateTime("TB_PRO_DET_TES_DTI_2"),
                    TbProDetTesDti3 = GetDateTime("TB_PRO_DET_TES_DTI_3"),

                    TbProDetTesMem1 = GetString("TB_PRO_DET_TES_MEM_1"),
                    TbProDetTesMem2 = GetString("TB_PRO_DET_TES_MEM_2"),
                    TbProDetTesMem3 = GetString("TB_PRO_DET_TES_MEM_3"),

                    TbProPteLot = GetString("TB_PRO_PTE_LOT") ?? "0",
                    TbProPteVen = GetDateTime("TB_PRO_PTE_VEN"),

                    TbProDetPteCantElim = GetInt("TB_PRO_DET_PTE_CANT_ELIM"),
                    TbProDetPteProdBrand = GetString("TB_PRO_DET_PTE_PROD_BRAND") ?? "NO REGISTRADO",
                    TbProDetPteProdName = GetString("TB_PRO_DET_PTE_PROD_NAME") ?? "NO REGISTRADO",
                    TbProDetPteProdManufDate = GetDateTime("TB_PRO_DET_PTE_PROD_MANUF_DATE"),

                    TbProDetPteEquName = GetString("TB_PRO_DET_PTE_EQU_NAME") ?? "NO REGISTRADO",
                    TbProDetPteEquSern = GetString("TB_PRO_DET_PTE_EQU_SERN") ?? "NO REGISTRADO",
                    TbProDetPteEquPos = GetString("TB_PRO_DET_PTE_EQU_POS") ?? "NO REGISTRADO",

                    TbProDetPteTicketNumb = GetString("TB_PRO_DET_PTE_TICKET_NUMB") ?? "NO REGISTRADO",
                    TbProDetPteCreatTest = GetString("TB_PRO_DET_PTE_CREAT_TEST"),
                    TbProDetPteUsrName = GetString("TB_PRO_DET_PTE_USR_NAME") ?? "NO REGISTRADO",

                    TbProDetPteResEstId = 1
                };

                _context.TbProDetPte.Add(nuevo);

                int ubicacion = nuevo.TbProDetTesUbiId ?? 0;

                switch (ubicacion)
                {
                    case 1: cabecera.TbPro1 = -1; break;
                    case 2: cabecera.TbPro2 = -1; break;
                    case 3: cabecera.TbPro3 = -1; break;
                    case 4: cabecera.TbPro4 = -1; break;
                    case 5: cabecera.TbPro5 = -1; break;
                    case 6: cabecera.TbPro6 = -1; break;
                    case 7: cabecera.TbPro7 = -1; break;
                    case 8: cabecera.TbPro8 = -1; break;
                    case 9: cabecera.TbPro9 = -1; break;
                    case 28: cabecera.TbPro28 = -1; break;
                }

                _context.SaveChanges();

                return Json(new
                {
                    success = true
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult ObtenerTiposControl()
        {
            var lista = _context.TbProPte
                .Where(x => !x.IbPtePtiOcu)
                .Select(x => new
                {
                    IB_PTE_ID = x.IbPteId,
                    IB_PTE_DEN = x.IbPteDen
                })
                .ToList();

            return Ok(lista);
        }

        [HttpGet]
        public IActionResult ObtenerUbicacionesControl()
        {
            var lista = _context.TbProPteUbi
                .Where(x => !x.IbPtesUbiOcu)
                .Select(x => new
                {
                    IB_PTES_UBI_ID = x.IbPtesUbiId,
                    IB_PTES_UBI_DEN = x.IbPtesUbiDen
                })
                .ToList();

            return Ok(lista);
        }

        [HttpGet]
        public IActionResult ObtenerControlesPorProceso(int tbProId)
        {
            try
            {
                var lista = _context.TbProDetPte
                    .Where(x => x.TbProId == tbProId)
                    .OrderBy(x => x.TbProDetPteId)
                    .Select(x => new
                    {
                        tbProDetPteId = x.TbProDetPteId,
                        tbProPteDen = x.TbProPteDen,
                        tbProPteIde = x.TbProPteIde,
                        tbProDetTesUbiDen = x.TbProDetTesUbiDen,
                        tbProPteCant = x.TbProPteCant
                    })
                    .ToList();

                return Json(new { success = true, data = lista });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message });
            }
        }

    }
}