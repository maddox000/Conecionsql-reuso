using ConexionSql.Models.A_PSW_LOG;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ConexionSql.Controllers.A_PSW_LOG
{
    public class APswLogController : Controller
    {
        private readonly IConfiguration _configuration;

        public APswLogController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Validar([FromBody] LoginRequest request)
        {
            using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                using (SqlCommand cmd = new SqlCommand("SP_A_PSW_LOG_VALIDAR", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", request.Id);
                    cmd.Parameters.AddWithValue("@Clave", request.Clave);

                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            HttpContext.Session.SetString("UsuarioId", dr["IB_PER_ID"]?.ToString() ?? "");

                            return Json(new
                            {
                                ok = true,
                                id = dr["IB_PER_ID"].ToString()
                            });
                        }
                        else
                        {
                            return Json(new { ok = false, mensaje = "Clave incorrecta." });
                        }
                    }
                }
            }
        }

        [HttpGet]
        public IActionResult Buscar(string texto)
        {
            var lista = new List<object>();

            using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                using (SqlCommand cmd = new SqlCommand("SP_A_PSW_LOG_BUSCAR", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Texto", texto ?? "");

                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new
                            {
                                id = dr["IB_PER_ID"],
                                nombre = dr["IB_PER_NOM"]?.ToString(),
                                apellido = dr["IB_PER_APE"]?.ToString(),
                                cargo = dr["IB_PER_CAR_DEN"]?.ToString(),
                                unidadId = dr["IB_PER_UNI_ID"],
                                unidad = dr["IB_PER_UNI_DEN"]?.ToString()
                            });
                        }
                    }
                }
            }

            return Json(lista);
        }
    }
}

public class LoginRequest
{
    public int Id { get; set; }
    public string Clave { get; set; } = string.Empty;
}