using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace ConexionSql.Controllers.Procesos.Estadisticas
{
    public class EstProcesosController : Controller
    {
        private readonly string _connectionString;

        public EstProcesosController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IActionResult Index()
        {
            return View("~/Views/Procesos/Estadisticas/EstProcesos.cshtml");
        }

        [HttpPost]
        public async Task<JsonResult> ObtenerDatos(DateTime desde, DateTime hasta, string estadoDen, string cicloDen, string equipoDen, bool soloControles)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_EstProcesos", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BUS_FEC_INI", desde);
                    cmd.Parameters.AddWithValue("@BUS_FEC_FIN", hasta);

                    string estLimpio = (string.IsNullOrWhiteSpace(estadoDen) || estadoDen.Trim().Equals("Todos", StringComparison.OrdinalIgnoreCase)) ? null : estadoDen.Trim();
                    string cicLimpio = (string.IsNullOrWhiteSpace(cicloDen) || cicloDen.Trim().Equals("Todos", StringComparison.OrdinalIgnoreCase)) ? null : cicloDen.Trim();
                    string equLimpio = (string.IsNullOrWhiteSpace(equipoDen) || equipoDen.Trim().Equals("Todos", StringComparison.OrdinalIgnoreCase)) ? null : equipoDen.Trim();

                    cmd.Parameters.AddWithValue("@BUS_EST_DEN", estLimpio ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@BUS_TCI_DEN", cicLimpio ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@BUS_EQU_DEN", equLimpio ?? (object)DBNull.Value);

                    object valorControl = soloControles ? (object)true : DBNull.Value;
                    cmd.Parameters.AddWithValue("@BUS_CTRL_1", valorControl);
                    cmd.Parameters.AddWithValue("@BUS_CTRL_2", valorControl);
                    cmd.Parameters.AddWithValue("@BUS_CTRL_3", valorControl);
                    cmd.Parameters.AddWithValue("@BUS_CTRL_4", valorControl);
                    cmd.Parameters.AddWithValue("@BUS_CTRL_5", valorControl);
                    cmd.Parameters.AddWithValue("@BUS_CTRL_6", valorControl);
                    cmd.Parameters.AddWithValue("@BUS_CTRL_7", valorControl);
                    cmd.Parameters.AddWithValue("@BUS_CTRL_8", valorControl);
                    cmd.Parameters.AddWithValue("@BUS_CTRL_9", valorControl);
                    cmd.Parameters.AddWithValue("@BUS_CTRL_10", valorControl);

                    await conn.OpenAsync();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                }
            }

            // CORREGIDO: Mapea sobre Tables[0] porque eliminamos el primer SELECT detallado del SP
            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                return Json(Array.Empty<object>());
            }

            DataTable dtEstadistica = ds.Tables[0];
            var lista = (from DataRow dr in dtEstadistica.Rows
                         select dtEstadistica.Columns.Cast<DataColumn>().ToDictionary(c => c.ColumnName, c => dr[c])).ToList();

            return Json(lista);
        }

        [HttpGet]
        public JsonResult GetEstados(string term)
        {
            var dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT DISTINCT IB_PRO_EST_DEN FROM IB_PRO_EST WHERE IB_PRO_EST_DEN LIKE @term";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@term", "%" + term + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return Json((from DataRow dr in dt.Rows
                         select new { id = dr["IB_PRO_EST_DEN"].ToString(), label = dr["IB_PRO_EST_DEN"].ToString() }).ToList());
        }

        [HttpGet]
        public JsonResult GetCiclos(string term)
        {
            var dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT DISTINCT TB_PRO_TCI_DEN FROM IB_PRO_TCI WHERE TB_PRO_TCI_DEN LIKE @term";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@term", "%" + term + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return Json((from DataRow dr in dt.Rows
                         select new { id = dr["TB_PRO_TCI_DEN"].ToString(), label = dr["TB_PRO_TCI_DEN"].ToString() }).ToList());
        }

        [HttpGet]
        public JsonResult GetEquipos(string term)
        {
            var dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT DISTINCT (ISNULL(IB_EQU_TEQ_DEN, '') + ' ' + ISNULL(CAST(IB_EQU_NUM AS VARCHAR(10)), '')) AS EquipoCompleto FROM IB_EQU WHERE (ISNULL(IB_EQU_TEQ_DEN, '') + ' ' + ISNULL(CAST(IB_EQU_NUM AS VARCHAR(10)), '')) LIKE @term";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@term", "%" + term + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return Json((from DataRow dr in dt.Rows
                         select new { id = dr["EquipoCompleto"].ToString(), label = dr["EquipoCompleto"].ToString() }).ToList());
        }
    }
}