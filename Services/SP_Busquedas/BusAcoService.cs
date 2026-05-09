using ConexionSql.Models.SP_Busquedas;
using ConexionSql.Services.SP_Busquedas.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;

namespace ConexionSql.Services.SP_Busquedas
{
    public class BusAcoService : IBusAcoService
    {
        private readonly string _connectionString;

        public BusAcoService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<BusAcoDto> GetAcondicionados(
            DateTime BUS_FEC_INI,
            DateTime BUS_FEC_FIN,
            string BUS_CET,
            string BUS_ACO_ID,
            string BUS_DEN,
            string BUS_REU_ID,
            string BUS_SEC)
        {
            var lista = new List<BusAcoDto>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.SP_TEST_ACO", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetros del SP_TEST_ACO
                    cmd.Parameters.AddWithValue("@BUS_FEC_INI", BUS_FEC_INI);
                    cmd.Parameters.AddWithValue("@BUS_FEC_FIN", BUS_FEC_FIN);
                    cmd.Parameters.AddWithValue("@BUS_CET", string.IsNullOrEmpty(BUS_CET) ? DBNull.Value : BUS_CET);
                    cmd.Parameters.AddWithValue("@BUS_ACO_ID", string.IsNullOrEmpty(BUS_ACO_ID) ? DBNull.Value : BUS_ACO_ID);
                    cmd.Parameters.AddWithValue("@BUS_DEN", string.IsNullOrEmpty(BUS_DEN) ? DBNull.Value : BUS_DEN);
                    cmd.Parameters.AddWithValue("@BUS_REU_ID", string.IsNullOrEmpty(BUS_REU_ID) ? DBNull.Value : BUS_REU_ID);
                    cmd.Parameters.AddWithValue("@BUS_SEC", string.IsNullOrEmpty(BUS_SEC) ? DBNull.Value : BUS_SEC);

                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var dto = new BusAcoDto
                            {
                                TB_PRO_ACO_ID = Convert.ToInt32(dr["TB_PRO_ACO_ID"]),
                                TB_PRO_ACO_FEC = dr["TB_PRO_ACO_FEC"] != DBNull.Value ? Convert.ToDateTime(dr["TB_PRO_ACO_FEC"]) : (DateTime?)null,
                                TB_PRO_ACO_HOR_INI = dr["TB_PRO_ACO_HOR_INI"].ToString(),
                                TB_PRO_ACO_UPRO = dr["TB_PRO_ACO_UPRO"].ToString(),

                                TB_REC_DET_ID = dr["TB_REC_DET_ID"] != DBNull.Value ? Convert.ToInt32(dr["TB_REC_DET_ID"]) : (int?)null,
                                TB_REC_DET_MAT_DEN = dr["TB_REC_DET_MAT_DEN"].ToString(),
                                TB_REC_DET_REU_ID = dr["TB_REC_DET_REU_ID"].ToString(),
                                TB_REC_DET_REU_CANT = dr["TB_REC_DET_REU_CANT"] != DBNull.Value ? Convert.ToInt32(dr["TB_REC_DET_REU_CANT"]) : (int?)null,
                                TB_REC_DET_REU_OPC = dr["TB_REC_DET_REU_OPC"] != DBNull.Value ? Convert.ToBoolean(dr["TB_REC_DET_REU_OPC"]) : (bool?)null,
                                TB_REC_DET_MAT_ID = dr["TB_REC_DET_MAT_ID"] != DBNull.Value ? Convert.ToInt32(dr["TB_REC_DET_MAT_ID"]) : (int?)null,

                                TB_PRO_ACO_DET_CANT = dr["TB_PRO_ACO_DET_CANT"] != DBNull.Value ? Convert.ToInt32(dr["TB_PRO_ACO_DET_CANT"]) : (int?)null,

                                TB_REC_SEC_DES_ID = dr["TB_REC_SEC_DES_ID"] != DBNull.Value ? Convert.ToInt32(dr["TB_REC_SEC_DES_ID"]) : (int?)null,
                                TB_REC_SEC_DES_DEN = dr["TB_REC_SEC_DES_DEN"].ToString()
                            };
                            lista.Add(dto);
                        }
                    }
                }
            }
            return lista;
        }
    }
}
