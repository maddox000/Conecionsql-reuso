using ConexionSql.Data;
using ConexionSql.Models.Lavado;
using ConexionSql.Models.Lavado.Controles;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ConexionSql.Controllers.Lavado.Controles
{
    public class TbProLavControlController : Controller
    {
        private readonly ConexionSqlContext _context;

        public TbProLavControlController(ConexionSqlContext context)
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

                int tbProLavId = GetInt("TB_PRO_LAV_ID");

                if (tbProLavId <= 0)
                    return Json(new { success = false, mensaje = "TB_PRO_LAV_ID inválido." });

                var cabecera = _context.TbProLav.FirstOrDefault(x => x.TbProLavId == tbProLavId);

                if (cabecera == null)
                    return Json(new { success = false, mensaje = "No se encontró la cabecera del lavado." });

                var nuevo = new TbProLavDetPte
                {
                    TbProLavId = tbProLavId,
                    TbProLavFec = DateTime.Now,

                    TbProLavPteId = GetInt("TB_PRO_PTE_ID"),
                    TbProLavPteDen = GetString("TB_PRO_PTE_DEN"),

                    TbProLavPtePtiId = cabecera.TbProLavPtiId,
                    TbProLavPtePtiDen = cabecera.TbProLavPtiDen,

                    TbProLavPteEquId = cabecera.TbProLavEquId,
                    TbProLavPteEquDen = cabecera.TbProLavEquDen,

                    TbProLavPteIde = GetString("TB_PRO_PTE_IDE"),

                    TbProLavDetTesUbiId = GetInt("TB_PRO_DET_TES_UBI_ID"),
                    TbProLavDetTesUbiDen = GetString("TB_PRO_DET_TES_UBI_DEN"),

                    TbProLavPteCant = GetInt("TB_PRO_PTE_CANT", 1),

                    TbProLavPteResId = 1,
                    TbProLavPteResDen = "EN PROCESO",

                    TbProLavDetTesNum1 = GetInt("TB_PRO_DET_TES_NUM_1"),
                    TbProLavDetTesNum2 = GetInt("TB_PRO_DET_TES_NUM_2"),
                    TbProLavDetTesNum3 = GetInt("TB_PRO_DET_TES_NUM_3"),

                    TbProLavDetTesTxt1 = GetString("TB_PRO_DET_TES_TXT_1"),
                    TbProLavDetTesTxt2 = GetString("TB_PRO_DET_TES_TXT_2"),
                    TbProLavDetTesTxt3 = GetString("TB_PRO_DET_TES_TXT_3"),

                    TbProLavDetTesDti1 = GetDateTime("TB_PRO_DET_TES_DTI_1"),
                    TbProLavDetTesDti2 = GetDateTime("TB_PRO_DET_TES_DTI_2"),
                    TbProLavDetTesDti3 = GetDateTime("TB_PRO_DET_TES_DTI_3"),

                    TbProLavDetTesMem1 = GetString("TB_PRO_DET_TES_MEM_1"),
                    TbProLavDetTesMem2 = GetString("TB_PRO_DET_TES_MEM_2"),
                    TbProLavDetTesMem3 = GetString("TB_PRO_DET_TES_MEM_3"),

                    TbProLavPteLot = GetString("TB_PRO_PTE_LOT") ?? "0",
                    TbProLavPteVen = GetDateTime("TB_PRO_PTE_VEN"),

                    
                    TbProLavDetPteProdBrand = GetString("TB_PRO_DET_PTE_PROD_BRAND") ?? "NO REGISTRADO",
                    TbProLavDetPteProdName = GetString("TB_PRO_DET_PTE_PROD_NAME") ?? "NO REGISTRADO",
                    TbProLavDetPteProdManufDate = GetDateTime("TB_PRO_DET_PTE_PROD_MANUF_DATE"),

                    TbProLavDetPteEquName = GetString("TB_PRO_DET_PTE_EQU_NAME") ?? "NO REGISTRADO",
                    TbProLavDetPteEquSern = GetString("TB_PRO_DET_PTE_EQU_SERN") ?? "NO REGISTRADO",
                    TbProLavDetPteEquPos = GetString("TB_PRO_DET_PTE_EQU_POS") ?? "NO REGISTRADO",

                    TbProLavDetPteTicketNumb = GetString("TB_PRO_DET_PTE_TICKET_NUMB") ?? "NO REGISTRADO",
                    TbProLavDetPteCreatTest = GetString("TB_PRO_DET_PTE_CREAT_TEST"),
                    TbProLavDetPteUsrName = GetString("TB_PRO_DET_PTE_USR_NAME") ?? "NO REGISTRADO",

                    TbProLavDetPteResEstId = 1
                };

                _context.TbProLavDetPte.Add(nuevo);

                int ubicacion = nuevo.TbProLavDetTesUbiId ?? 0;

                switch (ubicacion)
                {
                    case 1: cabecera.TbProLav1 = -1; break;
                    case 2: cabecera.TbProLav2 = -1; break;
                    case 3: cabecera.TbProLav3 = -1; break;
                    case 4: cabecera.TbProLav4 = -1; break;
                    case 5: cabecera.TbProLav5 = -1; break;
                    case 6: cabecera.TbProLav6 = -1; break;
                    case 7: cabecera.TbProLav7 = -1; break;
                    case 8: cabecera.TbProLav8 = -1; break;
                    case 9: cabecera.TbProLav9 = -1; break;
                    case 28: cabecera.TbProLav28 = -1; break;
                }

                _context.SaveChanges();

                return Json(new { success = true });
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
        public IActionResult ObtenerControlesPorLavado(int tbProLavId)
        {
            try
            {
                var lista = _context.TbProLavDetPte
                    .Where(x => x.TbProLavId == tbProLavId)
                    .OrderBy(x => x.TbProLavDetPteId)
                    .Select(x => new
                    {
                        tbProLavDetPteId = x.TbProLavDetPteId,
                        tbProPteDen = x.TbProLavPteDen,
                        tbProPteIde = x.TbProLavPteIde,
                        tbProDetTesUbiDen = x.TbProLavDetTesUbiDen,
                        tbProPteCant = x.TbProLavPteCant,
                        tbProPteResId = x.TbProLavPteResId,
                        tbProPteResDen = x.TbProLavPteResDen
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
