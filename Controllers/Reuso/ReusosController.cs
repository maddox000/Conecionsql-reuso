using ConexionSql.Models.Reuso;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConexionSql.Data;


public class ReusosController : Controller
{
        private readonly ConexionSqlContext _context;

        public ReusosController(ConexionSqlContext context)
        {
            _context = context;
        }

    [HttpGet]
    public IActionResult CrearReusos(string codigo)
    {
        var usuarioId = HttpContext.Session.GetString("UsuarioId");

        if (string.IsNullOrEmpty(usuarioId))
        {
            return RedirectToAction("Index", "Home");
        }

        var personal = _context.IbPers
            .FirstOrDefault(x => x.IbPerId.ToString() == usuarioId);

        var sectores = _context.IbSectores
            .OrderBy(x => x.IbSecDen)
            .ToList();

        ViewBag.ListaSectores = sectores;

        var materiales = _context.IbMat
            .Where(x => x.IB_MAT_REU_OPC == true)
            .OrderBy(x => x.IB_MAT_PR)
            .Select(x => new
            {
                id = x.IB_MAT_ID,
                pr = x.IB_MAT_PR,
                den = x.IB_MAT_DEN,
                reuOpcCant = x.IB_MAT_REU_OPC_CANT,
                vtoDefault = DateTime.Today.AddYears(1).ToString("dd/MM/yyyy") // 🔥 agregado
            })
            .ToList();

        ViewBag.ListaMateriales = materiales;

        var model = new TbReuDto
        {
            TbReuIdForm = codigo,

            TbReuPerId = personal?.IbPerId,
            TbReuPerApe = personal?.IbPerApe,
            TbReuPerNom = personal?.IbPerNom,
            TbReuPerCarId = personal?.IbPerCarId,
            TbReuPerCarDen = personal?.IbPerCarDen
        };

        return View("~/Views/Reusos/CrearReusos.cshtml", model);
    }

    [HttpGet]
    public async Task<IActionResult> ValidarCodigoReusoDisponible(string codigo)
    {
        if (string.IsNullOrWhiteSpace(codigo))
        {
            return Json(new { success = false, mensaje = "Ingrese un código." });
        }

        var resultado = await _context.TbReu
            .Where(x => x.TbReuIdForm == codigo &&
                        x.TbReuSecId == 900 &&
                        x.TbReuMatId == 1)
            .Select(x => new
            {
                x.TbReuId,
                x.TbReuIdForm,
                x.TbReuSecId,
                x.TbReuMatId
            })
            .FirstOrDefaultAsync();

        if (resultado == null)
        {
            return Json(new
            {
                success = false,
                disponible = false,
                mensaje = "Código no disponible."
            });
        }

        return Json(new
        {
            success = true,
            disponible = true,
            codigo = resultado.TbReuIdForm
        });
    }

    [HttpGet]
    public IActionResult ModalBuscarReuso()
    {
        return PartialView("~/Views/Reusos/Modal/_BuscarReuso.cshtml");
    }

    [HttpPost]
    public async Task<IActionResult> ActualizarReuso([FromBody] System.Text.Json.JsonElement data)
    {
        try
        {
            string? GetString(string name)
            {
                if (!data.TryGetProperty(name, out var prop)) return null;
                return prop.ValueKind == System.Text.Json.JsonValueKind.Null ? null : prop.ToString();
            }

            int? GetInt(string name)
            {
                var valor = GetString(name);
                return int.TryParse(valor, out int n) ? n : null;
            }

            var tbReuIdForm = GetString("TbReuIdForm");

            if (string.IsNullOrWhiteSpace(tbReuIdForm))
                return Json(new { success = false, mensaje = "Código de reuso inválido." });

            var reu = await _context.TbReu
                .FirstOrDefaultAsync(x => x.TbReuIdForm == tbReuIdForm);

            if (reu == null)
                return Json(new { success = false, mensaje = "No se encontró el código de reuso." });

            var matId = GetInt("TbReuMatId");

            var material = await _context.IbMat
                .FirstOrDefaultAsync(x => x.IB_MAT_ID == matId);

            if (material == null)
                return Json(new { success = false, mensaje = "Debe seleccionar un material válido." });

            var secId = GetInt("TbReuSecId");

            var sector = await _context.IbSectores
                .FirstOrDefaultAsync(x => x.IbSecId == secId);

            if (sector == null)
                return Json(new { success = false, mensaje = "Debe seleccionar un sector válido." });

            DateTime? vencimiento = null;
            var vtoTexto = GetString("TbReuDti1");

            if (!string.IsNullOrWhiteSpace(vtoTexto))
            {
                if (!DateTime.TryParseExact(
                    vtoTexto,
                    "dd/MM/yyyy",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out DateTime fechaVto))
                {
                    return Json(new { success = false, mensaje = "El vencimiento debe tener formato dd/MM/yyyy." });
                }

                vencimiento = fechaVto;
            }

            reu.TbReuFec = DateTime.Today;
            reu.TbReuHorIni = DateTime.Now;

            reu.TbReuPerId = GetInt("TbReuPerId");
            reu.TbReuPerNom = GetString("TbReuPerNom");
            reu.TbReuPerApe = GetString("TbReuPerApe");
            reu.TbReuPerCarId = GetInt("TbReuPerCarId");
            reu.TbReuPerCarDen = GetString("TbReuPerCarDen");

            reu.TbReuPcLog = Environment.MachineName;
            reu.TbReuPcUsr = Environment.UserName;

            reu.TbReuSecId = sector.IbSecId;
            reu.TbReuSecDen = sector.IbSecDen;

            reu.TbReuMatId = material.IB_MAT_ID;
            reu.TbReuMatDen = material.IB_MAT_DEN;
            reu.TbReuMatMtiId = material.IB_MAT_MTI_ID;
            reu.TbReuMatMtiDen = material.IB_MAT_MTI_DEN;

            reu.TbReuMatMca = GetString("TbReuMatMca") ?? "NO REGISTRADO";
            reu.TbReuMatFab = GetString("TbReuMatFab") ?? "NO REGISTRADO";
            reu.TbReuMatIde = GetString("TbReuMatIde") ?? "NO REGISTRADO";

            reu.TbReuMatOpcCant = GetInt("TbReuMatOpcCant") ?? 0;
            reu.TbReuMatOpcReg = GetInt("TbReuMatOpcReg") ?? 1;

            reu.TbReuTxt1 = GetString("TbReuTxt1") ?? "NO REGISTRADO";
            reu.TbReuDti1 = vencimiento;

            reu.TbReuMem1 = GetString("TbReuMem1") ?? "NO REGISTRADO";

            reu.TbReuEstIngId = 1;
            reu.TbReuEstIngDen = "CE - Asignación código de reuso";
            reu.TbReuEstIngFec = DateTime.Now;

            reu.TbReuBsto = false;
            reu.TbReuBstoBcreuId = 1;
            reu.TbReuProId = 1;
            reu.TbReuProDen = "NO REGISTRADO";

            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true,
                mensaje = "✅ Código de reuso actualizado correctamente."
            });
        }
        catch (Exception ex)
        {
            return Json(new
            {
                success = false,
                mensaje = "Error al actualizar reuso: " + ex.Message
            });
        }
    }
}