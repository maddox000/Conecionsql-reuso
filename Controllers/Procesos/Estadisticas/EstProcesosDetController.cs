using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace ConexionSql.Controllers.Procesos.Estadisticas
{
    [Route("Procesos/Estadisticas/[controller]")]
    public class EstProcesosDetController : Controller
    {
        private readonly string _connectionString;

        public EstProcesosDetController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? "";
        }

        // URL de acceso: https://localhost:7069/Procesos/Estadisticas/EstProcesosDet
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("~/Views/Procesos/Estadisticas/EstProcesosDet.cshtml");
        }

        [HttpPost]
        [Route("ObtenerDatos")]
        public async Task<JsonResult> ObtenerDatos(DateTime desde, DateTime hasta, string tipoProceso,
            string tipoCiclo, string estado, string equipo, string sectorOrigen, string sectorDestino,
            string denominacion, bool codigoReuso)
        {
            try
            {
                var datos = new List<Dictionary<string, object>>();

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    // CORRECCIÓN ACÁ: Apunta exactamente al nombre real de tu procedimiento almacenado
                    using (SqlCommand cmd = new SqlCommand("dbo.SP_EstadisticaProcesosDet", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 120;

                        // Mapeo exacto de parámetros correspondientes al SP
                        cmd.Parameters.Add("@BUS_FEC_INI", SqlDbType.DateTime).Value = desde;
                        cmd.Parameters.Add("@BUS_FEC_FIN", SqlDbType.DateTime).Value = hasta;
                        cmd.Parameters.Add("@BUS_TIP_PRO", SqlDbType.VarChar).Value = (string.IsNullOrWhiteSpace(tipoProceso) || tipoProceso == "MUESTRA_COL_TODO") ? DBNull.Value : (object)tipoProceso.Trim();
                        cmd.Parameters.Add("@BUS_TIP_CIC", SqlDbType.VarChar).Value = (string.IsNullOrWhiteSpace(tipoCiclo) || tipoCiclo == "MUESTRA_COL_TODO") ? DBNull.Value : (object)tipoCiclo.Trim();
                        cmd.Parameters.Add("@BUS_EST", SqlDbType.VarChar).Value = (string.IsNullOrWhiteSpace(estado) || estado == "MUESTRA_COL_TODO") ? DBNull.Value : (object)estado.Trim();
                        cmd.Parameters.Add("@BUS_EQU", SqlDbType.VarChar).Value = (string.IsNullOrWhiteSpace(equipo) || equipo == "MUESTRA_COL_TODO") ? DBNull.Value : (object)equipo.Trim();
                        cmd.Parameters.Add("@BUS_SEC_ORI", SqlDbType.VarChar).Value = (string.IsNullOrWhiteSpace(sectorOrigen) || sectorOrigen == "MUESTRA_COL_TODO") ? DBNull.Value : (object)sectorOrigen.Trim();
                        cmd.Parameters.Add("@BUS_SEC_DES", SqlDbType.VarChar).Value = (string.IsNullOrWhiteSpace(sectorDestino) || sectorDestino == "MUESTRA_COL_TODO") ? DBNull.Value : (object)sectorDestino.Trim();
                        cmd.Parameters.Add("@BUS_DEN", SqlDbType.VarChar).Value = (string.IsNullOrWhiteSpace(denominacion) || denominacion == "MUESTRA_COL_TODO") ? DBNull.Value : (object)denominacion.Trim();
                        cmd.Parameters.Add("@BUS_REU", SqlDbType.Bit).Value = codigoReuso ? 1 : 0;

                        await conn.OpenAsync();
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var fila = new Dictionary<string, object>();
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    fila[reader.GetName(i)] = reader.IsDBNull(i) ? null : reader.GetValue(i);
                                }
                                datos.Add(fila);
                            }
                        }
                    }
                }

                return Json(datos);
            }
            catch (Exception ex)
            {
                return Json(new { error = true, mensaje = "Error de SQL: " + ex.Message });
            }
        }

        #region Métodos para Autocompletar
        [HttpGet]
        [Route("GetTipoProceso")]
        public async Task<JsonResult> GetTipoProceso(string term) =>
            Json(await ObtenerSugerenciasFiltro("SELECT DISTINCT TOP 10 IB_EQU_PTI_DEN as label FROM IB_EQU_PTI WHERE IB_EQU_PTI_DEN LIKE @t", term));

        [HttpGet]
        [Route("GetTipoCiclo")]
        public async Task<JsonResult> GetTipoCiclo(string term) =>
            Json(await ObtenerSugerenciasFiltro("SELECT DISTINCT TOP 10 IB_PRO_TCI_DEN as label FROM IB_PRO_TCI WHERE IB_PRO_TCI_DEN LIKE @t", term));

        [HttpGet]
        [Route("GetEstados")]
        public async Task<JsonResult> GetEstados(string term) =>
            Json(await ObtenerSugerenciasFiltro("SELECT DISTINCT TOP 10 IB_PRO_EST_DEN as label FROM IB_PRO_EST WHERE IB_PRO_EST_DEN LIKE @t", term));

        [HttpGet]
        [Route("GetEquipos")]
        public async Task<JsonResult> GetEquipos(string term) =>
            Json(await ObtenerSugerenciasFiltro("SELECT DISTINCT TOP 10 (E.IB_EQU_TEQ_DEN + ' ' + CAST(E.IB_EQU_NUM AS VARCHAR(50))) as label FROM IB_EQU E WHERE (E.IB_EQU_TEQ_DEN + ' ' + CAST(E.IB_EQU_NUM AS VARCHAR(50))) LIKE @t", term));

        [HttpGet]
        [Route("GetSectores")]
        public async Task<JsonResult> GetSectores(string term) =>
            Json(await ObtenerSugerenciasFiltro("SELECT DISTINCT TOP 10 IB_SEC_DEN as label FROM IB_SEC WHERE IB_SEC_DEN LIKE @t", term));

        [HttpGet]
        [Route("GetDenominaciones")]
        public async Task<JsonResult> GetDenominaciones(string term) =>
            Json(await ObtenerSugerenciasFiltro("SELECT DISTINCT TOP 10 IB_MAT_DEN as label FROM IB_MAT WHERE IB_MAT_DEN LIKE @t", term));

        private async Task<List<object>> ObtenerSugerenciasFiltro(string sql, string termino)
        {
            var sugerencias = new List<object>();
            if (string.IsNullOrEmpty(termino)) return sugerencias;

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@t", "%" + termino + "%");
                        await conn.OpenAsync();
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                string valor = reader["label"]?.ToString() ?? "";
                                sugerencias.Add(new { label = valor, value = valor });
                            }
                        }
                    }
                }
            }
            catch { /* Silencioso para UX */ }
            return sugerencias;
        }
        #endregion
    }
}