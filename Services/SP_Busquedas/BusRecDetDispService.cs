using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Dapper;
using ConexionSql.Models.SP_Busquedas.SP_BusRecDetDisp;
using ConexionSql.Services.SP_Busquedas.Interfaces;
using Microsoft.Extensions.Configuration;

namespace ConexionSql.Services.SP_Busquedas
{
    public class BusRecDetDispService : IBusRecDetDispService
    {
        private readonly string _connectionString;

        public BusRecDetDispService(IConfiguration configuration)
        {
            // Si GetConnectionString devuelve null, asignamos un string vacío para satisfacer al compilador
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        }

        public async Task<IEnumerable<BusRecDetDispResponse>> ObtenerListadoAsync(BusRecDetDispRequest request)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BUS_FEC_INI", request.BusFecIni, DbType.Date);
                parameters.Add("@BUS_FEC_FIN", request.BusFecFin, DbType.Date);
                parameters.Add("@BUS_SEC_ORI_DEN", request.BusSecOriDen, DbType.AnsiString, size: 200);
                parameters.Add("@BUS_SEC_DES_DEN", request.BusSecDesDen, DbType.AnsiString, size: 200);
                parameters.Add("@BUS_DENO", request.BusDeno, DbType.AnsiString, size: 200);
                parameters.Add("@BUS_CET", request.BusCet, DbType.AnsiString, size: 50);
                parameters.Add("@BUS_ETAPA", request.BusEtapa, DbType.AnsiString, size: 10);

                // CLAVALE ESTA LÍNEA QUE ES LA QUE FALTA:
                parameters.Add("@BUS_MAT_MTI_ID", request.BusMatMtiId, DbType.Int32);

                return await db.QueryAsync<BusRecDetDispResponse>(
                    "SP_BusRecDetDispon",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );
            }
        }
    }
}
