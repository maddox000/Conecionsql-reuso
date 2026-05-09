using ConexionSql.Models.SP_Busquedas;
using ConexionSql.Services.SP_Busquedas.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;

namespace ConexionSql.Services.SP_Busquedas
{
    public class BusProDetService : IBusProDetService
    {
        private readonly string _connectionString;

        public BusProDetService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<BusProDetDto> GetProcesosDetalle(
            DateTime FEC_INI,
            DateTime FEC_FIN,
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
            var lista = new List<BusProDetDto>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_GET_PRO_DET", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetros según definición del SP
                    cmd.Parameters.AddWithValue("@FEC_INI", FEC_INI);
                    cmd.Parameters.AddWithValue("@FEC_FIN", FEC_FIN);
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
                            lista.Add(new BusProDetDto
                            {
                                TB_PRO_DET_REC_DET_ID = Convert.ToInt32(dr["TB_PRO_DET_REC_DET_ID"]),
                                TB_PRO_DET_REC_DET_MAT_ID = Convert.ToInt32(dr["TB_PRO_DET_REC_DET_MAT_ID"]),
                                TB_PRO_DET_REC_DET_MAT_DEN = dr["TB_PRO_DET_REC_DET_MAT_DEN"].ToString(),
                                TB_PRO_DET_CANT = Convert.ToInt32(dr["TB_PRO_DET_CANT"]),
                                TB_PRO_DET_CANT_MULT = dr["TB_PRO_DET_CANT_MULT"] != DBNull.Value ? Convert.ToInt32(dr["TB_PRO_DET_CANT_MULT"]) : (int?)null,
                                TB_PRO_DET_TXT_3 = dr["TB_PRO_DET_TXT_3"].ToString(),

                                TB_REC_SEC_DES_ID = dr["TB_REC_SEC_DES_ID"] != DBNull.Value ? Convert.ToInt32(dr["TB_REC_SEC_DES_ID"]) : (int?)null,
                                TB_REC_SEC_DES_DEN = dr["TB_REC_SEC_DES_DEN"].ToString(),

                                TB_PRO_ID = Convert.ToInt32(dr["TB_PRO_ID"]),
                                TB_PRO_FEC = dr["TB_PRO_FEC"] != DBNull.Value ? Convert.ToDateTime(dr["TB_PRO_FEC"]) : (DateTime?)null,
                                TB_PRO_HOR_INI = dr["TB_PRO_HOR_INI"].ToString(),
                                TB_PRO_PTI_ID = Convert.ToInt32(dr["TB_PRO_PTI_ID"]),

                                TB_PRO_IB_EQU_TEQ_DEN = dr["TB_PRO_IB_EQU_TEQ_DEN"].ToString(),
                                TB_PRO_EQU_NUM = Convert.ToInt32(dr["TB_PRO_EQU_NUM"]),
                                TB_PRO_EQU_DEN = dr["TB_PRO_EQU_DEN"].ToString(),
                                TB_PRO_EQU_MAR_DEN = dr["TB_PRO_EQU_MAR_DEN"].ToString(),
                                TB_PRO_EQU_MOD = dr["TB_PRO_EQU_MOD"].ToString(),
                                TB_PRO_EQU_SER = dr["TB_PRO_EQU_SER"].ToString(),

                                EQUIPO = dr["EQUIPO"].ToString()
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}
