using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace ConexionSql.Controllers.Lavado.Estadisticas
{
    public class EstLavadoDetController : Controller
    {
        private readonly string _connectionString;

        public EstLavadoDetController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? "";
        }

        public IActionResult Index() => View("~/Views/Lavado/Estadisticas/EstLavadoDet.cshtml");

        [HttpPost]
        public async Task<JsonResult> ObtenerDatos(DateTime desde, DateTime hasta, string estado, string lote,
        string codProd, string reuId, string den, string equipo, bool? ctrlLav, bool? ctrlProt)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_Reporte_LavadosDet_Mensual", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@BUS_FEC_INI", SqlDbType.DateTime).Value = desde;
                        cmd.Parameters.Add("@BUS_FEC_FIN", SqlDbType.DateTime).Value = hasta;

                        cmd.Parameters.Add("@BUS_EST", SqlDbType.VarChar).Value = (string.IsNullOrWhiteSpace(estado) || estado == "MUESTRA_COL_TODO") ? DBNull.Value : (object)estado.Trim();
                        cmd.Parameters.Add("@BUS_LOT", SqlDbType.VarChar).Value = (string.IsNullOrWhiteSpace(lote) || lote == "MUESTRA_COL_TODO") ? DBNull.Value : (object)lote.Trim();
                        cmd.Parameters.Add("@BUS_COD_PROD", SqlDbType.VarChar).Value = (string.IsNullOrWhiteSpace(codProd) || codProd == "MUESTRA_COL_TODO") ? DBNull.Value : (object)codProd.Trim();
                        cmd.Parameters.Add("@BUS_REU_ID", SqlDbType.VarChar).Value = (string.IsNullOrWhiteSpace(reuId) || reuId == "MUESTRA_COL_TODO") ? DBNull.Value : (object)reuId.Trim();
                        cmd.Parameters.Add("@BUS_DEN", SqlDbType.VarChar).Value = (string.IsNullOrWhiteSpace(den) || den == "MUESTRA_COL_TODO") ? DBNull.Value : (object)den.Trim();
                        cmd.Parameters.Add("@BUS_EQU", SqlDbType.VarChar).Value = (string.IsNullOrWhiteSpace(equipo) || equipo == "MUESTRA_COL_TODO") ? DBNull.Value : (object)equipo.Trim();

                        cmd.Parameters.Add("@BUS_CTRL_LAV", SqlDbType.Bit).Value = ctrlLav.HasValue && ctrlLav.Value ? 1 : DBNull.Value;
                        cmd.Parameters.Add("@BUS_CTRL_PROT", SqlDbType.Bit).Value = ctrlProt.HasValue && ctrlProt.Value ? 1 : DBNull.Value;

                        await conn.OpenAsync();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd)) { da.Fill(dt); }
                    }
                }

                if (dt.Rows.Count == 0)
                {
                    return Json(new { error = "Sin datos" });
                }

                var lista = (from DataRow dr in dt.Rows
                             select dt.Columns.Cast<DataColumn>().ToDictionary(c => c.ColumnName, c => dr[c] == DBNull.Value ? null : dr[c])).ToList();
                return Json(lista);
            }
            catch (Exception ex)
            {
                return Json(new { error = "Error de SQL: " + ex.Message });
            }
        }

        #region Métodos Autocomplete
        [HttpGet] public JsonResult GetProductosCod(string term) => GetAuto("SELECT DISTINCT TOP 10 TB_PRO_LAV_DET_IB_MAT_PR as label FROM TB_PRO_LAV_DET WHERE TB_PRO_LAV_DET_IB_MAT_PR LIKE @t", term);
        [HttpGet] public JsonResult GetProductosDen(string term) => GetAuto("SELECT DISTINCT TOP 10 TB_PRO_LAV_DET_IB_MAT_DEN as label FROM TB_PRO_LAV_DET WHERE TB_PRO_LAV_DET_IB_MAT_DEN LIKE @t", term);

        // CORRECCIÓN AQUÍ: Se agregó "L" como alias de la tabla para que L.TB_PRO_LAV_EQU_NUM pueda compilar sin romper la BD
        [HttpGet] public JsonResult GetEquipos(string term) => GetAuto("SELECT DISTINCT TOP 10 (TB_PRO_LAV_EQU_DEN + ' ' + L.TB_PRO_LAV_EQU_NUM) as label FROM TB_PRO_LAV L WHERE (TB_PRO_LAV_EQU_DEN + ' ' + L.TB_PRO_LAV_EQU_NUM) LIKE @t", term);
        [HttpGet] public JsonResult GetEstadosReporte(string term) => GetAuto("SELECT DISTINCT TOP 10 TB_PRO_LAV_EST_DEN as label FROM TB_PRO_LAV WHERE TB_PRO_LAV_EST_DEN LIKE @t", term);

        private JsonResult GetAuto(string sql, string term)
        {
            DataTable dt = new DataTable();
            using (SqlConnection c = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, c);
                cmd.Parameters.AddWithValue("@t", "%" + term + "%");
                new SqlDataAdapter(cmd).Fill(dt);
            }
            return Json((from DataRow dr in dt.Rows select new { label = dr["label"].ToString() }).ToList());
        }
        #endregion
    }
}