using ConexionSql.Models.SP_Busquedas;
using ConexionSql.Services.SP_Busquedas.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;

namespace ConexionSql.Services.SP_Busquedas
{
    public class BusProService : IBusProService
    {
        private readonly string _connectionString;

        public BusProService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<BusProDto> GetProcesos(DateTime? FEC_INI, DateTime? FEC_FIN, string BUS_PTI_DEN, string BUS_EST_DEN)
        {
            var lista = new List<BusProDto>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_TB_PRO", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // El SP ya tiene gestión interna de ISNULL para fechas, 
                    // pero se las pasamos si el usuario las elige.
                    cmd.Parameters.AddWithValue("@FEC_INI", (object)FEC_INI ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FEC_FIN", (object)FEC_FIN ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BUS_PTI_DEN", string.IsNullOrEmpty(BUS_PTI_DEN) ? DBNull.Value : BUS_PTI_DEN);
                    cmd.Parameters.AddWithValue("@BUS_EST_DEN", string.IsNullOrEmpty(BUS_EST_DEN) ? DBNull.Value : BUS_EST_DEN);

                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new BusProDto
                            {
                                TB_PRO_ID = Convert.ToInt32(dr["TB_PRO_ID"]),
                                TB_PRO_NUM_1 = dr["TB_PRO_NUM_1"].ToString(),
                                TB_PRO_FEC = dr["TB_PRO_FEC"] != DBNull.Value ? Convert.ToDateTime(dr["TB_PRO_FEC"]) : (DateTime?)null,
                                TB_PRO_HOR_INI = dr["TB_PRO_HOR_INI"].ToString(),
                                EQUIPO = dr["EQUIPO"].ToString(),
                                TB_PRO_TCI_DEN = dr["TB_PRO_TCI_DEN"].ToString(),
                                TB_PRO_UPRO = dr["TB_PRO_UPRO"].ToString(),
                                IB_PRO_EST_ID = Convert.ToInt32(dr["IB_PRO_EST_ID"]),
                                IB_PRO_EST_DEN = dr["IB_PRO_EST_DEN"].ToString(),
                                TB_PRO_PTI_ID = Convert.ToInt32(dr["TB_PRO_PTI_ID"]),
                                TB_PRO_PTI_DEN = dr["TB_PRO_PTI_DEN"].ToString()
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}
