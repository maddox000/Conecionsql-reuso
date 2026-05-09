using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using ConexionSql.Models.SP_Busquedas;
using ConexionSql.Services.SP_Busquedas.Interfaces;

namespace ConexionSql.Services.SP_Busquedas
{
    public class BusAcondicionadoService : IBusAcondicionadoService
    {
        private readonly string? _connectionString;

        public BusAcondicionadoService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<BusAcondicionadoDetDto>> GetAcondicionadosAsync(
            DateTime? fecIni, DateTime? fecFin, string? cet, string? acoId,
            string? den, string? reuId, string? sec)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@BUS_FEC_INI", fecIni);
                p.Add("@BUS_FEC_FIN", fecFin);
                p.Add("@BUS_CET", cet);
                p.Add("@BUS_ACO_ID", acoId);
                p.Add("@BUS_DEN", den);
                p.Add("@BUS_REU_ID", reuId);
                p.Add("@BUS_SEC", sec);

                return await db.QueryAsync<BusAcondicionadoDetDto>(
                    "dbo.SP_TEST_ACO", p, commandType: CommandType.StoredProcedure);
            }
        }
    }
}