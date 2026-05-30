using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient; // Usando el paquete correcto

namespace ConexionSql.Controllers.Traza
{
    [Route("Traza/[controller]")]
    public class TrazaReuIDController : Controller
    {
        private readonly string _connectionString;

        public TrazaReuIDController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? "";
        }

        [HttpGet]
        [Route("{id?}")]
        public IActionResult Index(string id)
        {
            ViewBag.IdReu = id;
            return View("~/Views/Traza/TrazaReuID.cshtml");
        }

        [HttpPost]
        [Route("ObtenerFicha")]
        public async Task<JsonResult> ObtenerFicha(string id)
        {
            try
            {
                Dictionary<string, object> ficha = null;
                var historial = new List<Dictionary<string, object>>();

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    // Encabezado
                    using (SqlCommand cmd = new SqlCommand("SP_TrazaReuID", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@BUS_REU_ID", SqlDbType.VarChar, 50).Value = id;
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                ficha = new Dictionary<string, object>();
                                for (int i = 0; i < reader.FieldCount; i++)
                                    ficha[reader.GetName(i)] = reader.IsDBNull(i) ? null : reader.GetValue(i);
                            }
                        }
                    }

                    // Detalle
                    using (SqlCommand cmdDet = new SqlCommand("SP_TrazaReuIDDet", conn))
                    {
                        cmdDet.CommandType = CommandType.StoredProcedure;
                        cmdDet.Parameters.Add("@REU_ID", SqlDbType.VarChar, 50).Value = id;
                        using (var reader = await cmdDet.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var fila = new Dictionary<string, object>();
                                for (int i = 0; i < reader.FieldCount; i++)
                                    fila[reader.GetName(i)] = reader.IsDBNull(i) ? null : reader.GetValue(i);
                                historial.Add(fila);
                            }
                        }
                    }
                }
                return Json(new { success = true, data = new { ficha, historial } });
            }
            catch (Exception ex) { return Json(new { error = true, mensaje = ex.Message }); }
        }
    }
}