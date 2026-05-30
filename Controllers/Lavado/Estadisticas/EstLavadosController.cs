using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ConexionSql.Controllers.Lavado.Estadisticas
{
    public class EstLavadosController : Controller
    {
        private readonly string _connectionString;

        public EstLavadosController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IActionResult Index()
        {
            return View("~/Views/Lavado/Estadisticas/EstLavados.cshtml");
        }

        [HttpPost]
        public async Task<JsonResult> ObtenerDatos(DateTime desde, DateTime hasta, int? estadoId, string estadoDen, string equipo, int? cicloId, string cicloDen, string txt2)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_EstadisticaLavados", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BUS_FEC_INI", desde);
                    cmd.Parameters.AddWithValue("@BUS_FEC_FIN", hasta);

                    // Usamos una lógica más limpia para los nulos
                    cmd.Parameters.AddWithValue("@BUS_EST_ID", (object)estadoId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BUS_EST_DEN", string.IsNullOrEmpty(estadoDen) ? DBNull.Value : (object)estadoDen);
                    cmd.Parameters.AddWithValue("@BUS_EQU", string.IsNullOrEmpty(equipo) ? DBNull.Value : (object)equipo);
                    cmd.Parameters.AddWithValue("@BUS_TCI_ID", (object)cicloId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BUS_TCI_DEN", string.IsNullOrEmpty(cicloDen) ? DBNull.Value : (object)cicloDen);
                    cmd.Parameters.AddWithValue("@BUS_TXT2", string.IsNullOrEmpty(txt2) ? DBNull.Value : (object)txt2);

                    await conn.OpenAsync();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd)) { da.Fill(dt); }
                }
            }
            var lista = (from DataRow dr in dt.Rows
                         select dt.Columns.Cast<DataColumn>().ToDictionary(c => c.ColumnName, c => dr[c])).ToList();
            return Json(lista);
        }

        [HttpGet]
        public JsonResult GetEstados(string term)
        {
            var dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT IB_PRO_EST_ID as id, IB_PRO_EST_DEN as label FROM IB_PRO_EST WHERE IB_PRO_EST_DEN LIKE @term";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@term", "%" + term + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return Json((from DataRow dr in dt.Rows select new { id = dr["id"], label = dr["label"] }).ToList());
        }

        [HttpGet]
        public JsonResult GetCiclos(string term)
        {
            var dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT IB_LAV_TCI_ID as id, IB_LAV_TCI_DEN as label FROM IB_LAV_TCI WHERE IB_LAV_TCI_DEN LIKE @term";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@term", "%" + term + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return Json((from DataRow dr in dt.Rows select new { id = dr["id"], label = dr["label"] }).ToList());
        }

        [HttpGet]
        public JsonResult GetEquipos(string term)
        {
            var dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT IB_EQU_ID as id, (IB_EQU_TEQ_DEN + ' ' + IB_EQU_NUM) as label FROM IB_EQU WHERE (IB_EQU_TEQ_DEN + ' ' + IB_EQU_NUM) LIKE @term";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@term", "%" + term + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return Json((from DataRow dr in dt.Rows select new { id = dr["id"], label = dr["label"] }).ToList());
        }

        // NUEVO MÉTODO PARA MOTIVOS
        [HttpGet]
        public JsonResult GetMotivos(string term)
        {
            var dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                // Buscamos los motivos ya existentes en la tabla para sugerir
                string sql = "SELECT DISTINCT TOP 10 TB_PRO_LAV_TXT_2 as label FROM TB_PRO_LAV WHERE TB_PRO_LAV_TXT_2 LIKE @term AND TB_PRO_LAV_TXT_2 IS NOT NULL";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@term", "%" + term + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            // Como no suele haber un ID de motivo (es texto libre), mandamos el label como ID también
            return Json((from DataRow dr in dt.Rows select new { id = dr["label"], label = dr["label"] }).ToList());
        }
    }
}