using ConexionSql.Models.SP_Busquedas;
using ConexionSql.Services.SP_Busquedas.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;

namespace ConexionSql.Services.SP_Busquedas
{
    public class BusRecDetService : IBusRecDetService
    {
        private readonly string _connectionString;

        public BusRecDetService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<BusRecDetDto> GetRecDet(
            int? BUS_CET,
            DateTime BUS_FEC_INI,
            DateTime BUS_FEC_FIN,
            string BUS_DEN,
            string BUS_SEC_ORI,
            string BUS_SEC_DES,
            string BUS_EST,
            string BUS_MAT_PR,
            string BUS_ORT_DEN,
            string BUS_PAC,
            string BUS_PRO,
            string BUS_REM,
            string BUS_REU_ID,
            DateTime? BUS_FEN,
            bool? BUS_ACAJ_OPC)
        {
            var lista = new List<BusRecDetDto>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Buscar_RecDet", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Configuración de Parámetros
                    cmd.Parameters.AddWithValue("@BUS_CET", (object)BUS_CET ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BUS_FEC_INI", BUS_FEC_INI);
                    cmd.Parameters.AddWithValue("@BUS_FEC_FIN", BUS_FEC_FIN);
                    cmd.Parameters.AddWithValue("@BUS_DEN", string.IsNullOrEmpty(BUS_DEN) ? DBNull.Value : BUS_DEN);
                    cmd.Parameters.AddWithValue("@BUS_SEC_ORI", string.IsNullOrEmpty(BUS_SEC_ORI) ? DBNull.Value : BUS_SEC_ORI);
                    cmd.Parameters.AddWithValue("@BUS_SEC_DES", string.IsNullOrEmpty(BUS_SEC_DES) ? DBNull.Value : BUS_SEC_DES);
                    cmd.Parameters.AddWithValue("@BUS_EST", string.IsNullOrEmpty(BUS_EST) ? DBNull.Value : BUS_EST);
                    cmd.Parameters.AddWithValue("@BUS_MAT_PR", string.IsNullOrEmpty(BUS_MAT_PR) ? DBNull.Value : BUS_MAT_PR);
                    cmd.Parameters.AddWithValue("@BUS_ORT_DEN", string.IsNullOrEmpty(BUS_ORT_DEN) ? DBNull.Value : BUS_ORT_DEN);
                    cmd.Parameters.AddWithValue("@BUS_PAC", string.IsNullOrEmpty(BUS_PAC) ? DBNull.Value : BUS_PAC);
                    cmd.Parameters.AddWithValue("@BUS_PRO", string.IsNullOrEmpty(BUS_PRO) ? DBNull.Value : BUS_PRO);
                    cmd.Parameters.AddWithValue("@BUS_REM", string.IsNullOrEmpty(BUS_REM) ? DBNull.Value : BUS_REM);
                    cmd.Parameters.AddWithValue("@BUS_REU_ID", string.IsNullOrEmpty(BUS_REU_ID) ? DBNull.Value : BUS_REU_ID);
                    cmd.Parameters.AddWithValue("@BUS_FEN", (object)BUS_FEN ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BUS_ACAJ_OPC", (object)BUS_ACAJ_OPC ?? DBNull.Value);

                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var dto = new BusRecDetDto
                            {
                                TB_REC_DET_ID = Convert.ToInt32(dr["TB_REC_DET_ID"]),
                                TB_REC_ID = Convert.ToInt32(dr["TB_REC_ID"]),
                                TB_REC_FEC = dr["TB_REC_FEC"] != DBNull.Value ? Convert.ToDateTime(dr["TB_REC_FEC"]) : (DateTime?)null,
                                TB_REC_HOR_INI = dr["TB_REC_HOR_INI"].ToString(),
                                TB_REC_SEC_ORI_DEN = dr["TB_REC_SEC_ORI_DEN"].ToString(),
                                TB_REC_SEC_DES_DEN = dr["TB_REC_SEC_DES_DEN"].ToString(),
                                TB_REC_ORT_DEN = dr["TB_REC_ORT_DEN"].ToString(),
                                TB_REC_DET_MAT_PR = dr["TB_REC_DET_MAT_PR"].ToString(),
                                TB_REC_DET_MAT_DEN = dr["TB_REC_DET_MAT_DEN"].ToString(),
                                TB_REC_DET_CANT = dr["TB_REC_DET_CANT"] != DBNull.Value ? Convert.ToInt32(dr["TB_REC_DET_CANT"]) : (int?)null,
                                TB_REC_DET_EST_DEN = dr["TB_REC_DET_EST_DEN"].ToString(),
                                TB_REC_DET_PAC = dr["TB_REC_DET_PAC"].ToString(),
                                TB_REC_DET_PRO_NOM = dr["TB_REC_DET_PRO_NOM"].ToString(),
                                TB_REC_DET_LOT = dr["TB_REC_DET_LOT"].ToString(),
                                TB_REC_DET_ACAJ_OPC_NOM = dr["TB_REC_DET_ACAJ_OPC_NOM"].ToString()
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
