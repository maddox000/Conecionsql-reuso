using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ConexionSql.Interfaces.Lavado;

namespace ConexionSql.Services.Lavado
{
    public class EstLavadoDetService : IEstLavadoDet
    {
        private readonly string _connectionString;

        public EstLavadoDetService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<Dictionary<string, object>>> ObtenerDatosMensualesAsync(
            DateTime desde, DateTime hasta, string estado, string lote,
            string codProd, string reuId, string den, string equipo,
            bool? ctrlLav, bool? ctrlProt)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Reporte_LavadosDet_Mensual", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Fechas
                    cmd.Parameters.AddWithValue("@BUS_FEC_INI", desde);
                    cmd.Parameters.AddWithValue("@BUS_FEC_FIN", hasta);

                    // Filtros opcionales con lógica de nulos
                    cmd.Parameters.AddWithValue("@BUS_EST", string.IsNullOrEmpty(estado) ? DBNull.Value : (object)estado);
                    cmd.Parameters.AddWithValue("@BUS_LOT", string.IsNullOrEmpty(lote) ? DBNull.Value : (object)lote);
                    cmd.Parameters.AddWithValue("@BUS_COD_PROD", string.IsNullOrEmpty(codProd) ? DBNull.Value : (object)codProd);
                    cmd.Parameters.AddWithValue("@BUS_REU_ID", string.IsNullOrEmpty(reuId) ? DBNull.Value : (object)reuId);
                    cmd.Parameters.AddWithValue("@BUS_DEN", string.IsNullOrEmpty(den) ? DBNull.Value : (object)den);
                    cmd.Parameters.AddWithValue("@BUS_EQU", string.IsNullOrEmpty(equipo) ? DBNull.Value : (object)equipo);

                    // Bits / Checkboxes
                    cmd.Parameters.AddWithValue("@BUS_CTRL_LAV", (object)ctrlLav ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BUS_CTRL_PROT", (object)ctrlProt ?? DBNull.Value);

                    await conn.OpenAsync();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd)) { da.Fill(dt); }
                }
            }

            // Mapeo dinámico a Diccionario para el JSON
            return (from DataRow dr in dt.Rows
                    select dt.Columns.Cast<DataColumn>().ToDictionary(
                        c => c.ColumnName,
                        c => dr[c] == DBNull.Value ? null : dr[c]
                    )).ToList();
        }
    }
}