using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient; // O Microsoft.Data.SqlClient según tu proyecto
using Dapper; // Asegúrate de tener instalado el paquete NuGet 'Dapper'
using ConexionSql.Models; // Cambiá "TuProyecto" por el nombre real de tu namespace

namespace ConexionSql.Controllers
{
    public class RecepcionesController : Controller
    {
        private readonly string _connectionString;

        // El constructor recibe la configuración para sacar la conexión a la DB
        public RecepcionesController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // 1. Acción que carga la página B_10_T por primera vez
        public IActionResult B_10_T()
        {
            return View();
        }

        // 2. Acción AJAX que ejecuta el SP_GET_REC
        [HttpPost]
        public async Task<IActionResult> GetRecepciones(DateTime fec_ini, DateTime fec_fin, string den, string sec, string est)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    // Mapeo de parámetros para el SP
                    var parametros = new DynamicParameters();
                    parametros.Add("@FEC_INI", fec_ini);
                    parametros.Add("@FEC_FIN", fec_fin);
                    parametros.Add("@DEN_PAR", den ?? "");
                    parametros.Add("@SEC_PAR", sec ?? "");
                    parametros.Add("@EST_PAR", est ?? "");

                    // Ejecución del SP y mapeo automático a la lista del ViewModel
                    var resultado = await db.QueryAsync<RecepcionViewModel>(
                        "dbo.SP_GET_REC",
                        parametros,
                        commandType: CommandType.StoredProcedure
                    );

                    return Json(resultado);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al consultar: " + ex.Message });
            }
        }
    }
}
