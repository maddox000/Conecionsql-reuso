using ConexionSql.Models.SP_Busquedas;
using ConexionSql.Services.SP_Busquedas.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;

namespace ConexionSql.Services.SP_Busquedas
{
    public class BusRecService : IBusRecService
    {
        private readonly string _connectionString;

        public BusRecService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<BusRecDto> GetRecs(
            DateTime FEC_INI,
            DateTime FEC_FIN,
            string BUS_SEC_ORI,
            string BUS_SEC_DES,
            string BUS_ORT_DEN,
            string BUS_DEN,
            string BUS_PR,
            string BUS_REU_ID,
            string BUS_PAC,
            string BUS_PRO,
            string BUS_REM,
            DateTime? BUS_FEN)
        {
            var lista = new List<BusRecDto>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.SP_GET_REC", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Configuración de Parámetros según el SP
                    cmd.Parameters.AddWithValue("@FEC_INI", FEC_INI);
                    cmd.Parameters.AddWithValue("@FEC_FIN", FEC_FIN);
                    cmd.Parameters.AddWithValue("@BUS_SEC_ORI", BUS_SEC_ORI ?? "");
                    cmd.Parameters.AddWithValue("@BUS_SEC_DES", BUS_SEC_DES ?? "");
                    cmd.Parameters.AddWithValue("@BUS_ORT_DEN", BUS_ORT_DEN ?? "");
                    cmd.Parameters.AddWithValue("@BUS_DEN", BUS_DEN ?? "");
                    cmd.Parameters.AddWithValue("@BUS_PR", BUS_PR ?? "");
                    cmd.Parameters.AddWithValue("@BUS_REU_ID", BUS_REU_ID ?? "");
                    cmd.Parameters.AddWithValue("@BUS_PAC", BUS_PAC ?? "");
                    cmd.Parameters.AddWithValue("@BUS_PRO", BUS_PRO ?? "");
                    cmd.Parameters.AddWithValue("@BUS_REM", BUS_REM ?? "");
                    cmd.Parameters.AddWithValue("@BUS_FEN", (object)BUS_FEN ?? DBNull.Value);

                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var dto = new BusRecDto
                            {
                                TB_REC_ID = Convert.ToInt32(dr["TB_REC_ID"]),
                                TB_REC_FEC = dr["TB_REC_FEC"] != DBNull.Value ? Convert.ToDateTime(dr["TB_REC_FEC"]) : (DateTime?)null,
                                TB_REC_HOR_INI = dr["TB_REC_HOR_INI"].ToString(),
                                TB_REC_HOR_FIN = dr["TB_REC_HOR_FIN"].ToString(),
                                TB_REC_SEC_ORI_DEN = dr["TB_REC_SEC_ORI_DEN"].ToString(),
                                TB_REC_SEC_DES_DEN = dr["TB_REC_SEC_DES_DEN"].ToString(),
                                TB_REC_ORT_DEN = dr["TB_REC_ORT_DEN"].ToString(),
                                TB_REC_OBS = dr["TB_REC_OBS"].ToString(),
                                TB_REC_MDE = dr["TB_REC_MDE"].ToString(),
                                TB_REC_MCO = dr["TB_REC_MCO"].ToString()
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
