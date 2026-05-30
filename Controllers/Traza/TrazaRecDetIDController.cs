using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;

namespace ConexionSql.Controllers.Traza
{
    [Route("Traza/[controller]")]
    public class TrazaRecDetIDController : Controller
    {
        private readonly string _connectionString;

        public TrazaRecDetIDController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? "";
        }

        // URL: https://localhost:7069/Traza/TrazaRecDetID/105240
        [HttpGet]
        [Route("{id?}")]
        public IActionResult Index(int? id)
        {
            ViewBag.IdEtiquetaInicial = id;
            return View("~/Views/Traza/TrazaRecDetID.cshtml");
        }

        [HttpPost]
        [Route("ObtenerFicha")]
        public async Task<JsonResult> ObtenerFicha(int id)
        {
            try
            {
                Dictionary<string, object> ficha = null;
                var listadoHistorial = new List<Dictionary<string, object>>();

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_TrazaRecDetID", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Mapeado exactamente al nuevo parámetro del SP
                        cmd.Parameters.Add("@CODIGO_ETIQUETA", SqlDbType.Int).Value = id;

                        await conn.OpenAsync();
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            // DATASET 1: Ficha Técnica Maestro
                            if (await reader.ReadAsync())
                            {
                                ficha = new Dictionary<string, object>();
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    ficha[reader.GetName(i)] = reader.IsDBNull(i) ? null : reader.GetValue(i);
                                }
                            }

                            // Saltamos en bloque al DATASET 2 (El UNION de las 9 etapas)
                            if (await reader.NextResultAsync())
                            {
                                while (await reader.ReadAsync())
                                {
                                    var paso = new Dictionary<string, object>();
                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {
                                        paso[reader.GetName(i)] = reader.IsDBNull(i) ? null : reader.GetValue(i);
                                    }
                                    listadoHistorial.Add(paso);
                                }
                            }
                        }
                    }
                }

                if (ficha == null)
                    return Json(new { error = true, mensaje = "No se encontraron registros de trazabilidad para esta etiqueta." });

                // Devolvemos las dos estructuras unificadas en la misma respuesta
                return Json(new
                {
                    success = true,
                    data = new
                    {
                        ficha = ficha,
                        historial = listadoHistorial
                    }
                });
            }
            catch (Exception ex)
            {
                return Json(new { error = true, mensaje = "Error en controlador SQL: " + ex.Message });
            }
        }
    }
}