using ConexionSql.Data;
using ConexionSql.Models.Reusos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConexionSql.Controllers.Reuso
{
    public class TbReuPacController : Controller
    {
        private readonly ConexionSqlContext _context;

        public TbReuPacController(ConexionSqlContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult DatosRecepcion([FromBody] dynamic dto)
        {
            try
            {
                int ibMatId = dto.IB_MAT_ID;
                int tbRecId = dto.TB_REC_ID;
                int tbReuId = dto.TB_REU_ID;

                // 🔹 denominación desde IB_MAT
                var material = _context.IbMat
                    .FirstOrDefault(x => x.IB_MAT_ID == ibMatId);

                string denominacion = material?.IB_MAT_DEN ?? "";

                return Json(new
                {
                    ok = true,
                    tbReuId = tbReuId,
                    codigoReuso = tbReuId.ToString("D5"),
                    denominacion = denominacion,
                    recepcion = tbRecId,
                    fecha = DateTime.Now.ToString("dd/MM/yyyy HH:mm")
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    ok = false,
                    mensaje = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] TbReuPacFormDto dto)
        {
            try
            {
                var nuevo = new TbReuPac
                {
                    // 🔗 RELACIONES
                    TbReuPacTbReuId = dto.TB_REU_ID,
                    TbReuPacTbRecId = dto.TB_REC_ID,

                    // 🔥 FECHA
                    TbReuPacFec = DateTime.Now,

                    // 🔥 CÓDIGO REUSO
                    TbReuPacTbReuIdForm = dto.CODIGO_REUSO ?? "",

                    // 🔥 DATOS PACIENTE
                    TbReuPacNom = dto.NOMBRE ?? "",
                    TbReuPacApe = dto.APELLIDO ?? "",
                    TbReuPacHcli = dto.HISTORIA_CLINICA ?? "",
                    TbReuPacNdoc = dto.DOCUMENTO ?? "",
                    TbReuPacEdad = dto.EDAD.ToString(),
                    TbReuPacOsoc = dto.OBRA_SOCIAL ?? "",

                    // 🔥 FIJO
                    TbReuPacTel = "NO REGISTRA",

                    // 🔥 OCUPADO
                    TbReuPacOcu = dto.ELIMINAR
                };

                _context.TbReuPac.Add(nuevo);
                await _context.SaveChangesAsync();

                return Json(new
                {
                    ok = true,
                    mensaje = "✅ Paciente guardado correctamente"
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    ok = false,
                    mensaje = ex.Message
                });
            }
        }
    }
}