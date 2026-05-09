using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ConexionSql.Models.SP_Busquedas;
using ConexionSql.Services.SP_Busquedas.Interfaces; // Nueva referencia
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Baxen.Services
{
    public class BusLavadoDetService : IBusLavadoDetService
    {
        private readonly string _connectionString;

        public BusLavadoDetService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<BusLavadoDetDto>> GetLavadoDetalleAsync(
            DateTime fecIni,
            DateTime fecFin,
            string pti = "",
            string est = "",
            string cet = "",
            string den = "",
            string sec = "",
            string reu = "",
            string tprot = "")
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@FEC_INI", fecIni, DbType.Date);
                parameters.Add("@FEC_FIN", fecFin, DbType.Date);
                parameters.Add("@BUS_PTI", pti ?? "");
                parameters.Add("@BUS_EST", est ?? "");
                parameters.Add("@BUS_CET", cet ?? "");
                parameters.Add("@BUS_DEN", den ?? "");
                parameters.Add("@BUS_SEC", sec ?? "");
                parameters.Add("@BUS_REU_ID", reu ?? "");
                parameters.Add("@BUS_TPROT", tprot ?? "");

                var result = await db.QueryAsync<BusLavadoDetDto>(
                    "SP_GET_LAV_DET",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return result.ToList();
            }
        }
    }
}