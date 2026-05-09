using ConexionSql.Models.SP_Busquedas;
using ConexionSql.Services.SP_Busquedas.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ConexionSql.Services.SP_Busquedas
{
    public class RecDetService : IRecDetService
    {
        private readonly string _connectionString;

        public RecDetService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<RecDetBusquedaDto> BuscarRecDet(
            DateTime? BUS_FEC_INI, DateTime? BUS_FEC_FIN, string BUS_DEN,
            string BUS_SEC_ORI, string BUS_SEC_DES, string BUS_EST,
            string BUS_MAT_PR, string BUS_ORT_DEN, string BUS_PAC,
            string BUS_PRO, string BUS_REM, string BUS_REU_ID,
            DateTime? BUS_FEN, bool? BUS_ACAJ_OPC, bool? BUS_TRA_OPC,
            int? BUS_CET)
        {
            var lista = new List<RecDetBusquedaDto>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.SP_Buscar_RecDet", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Limpieza rigurosa: Si el string es nulo o solo espacios, mandamos NULL a SQL
                    Func<string, object> CleanParam = (val) => string.IsNullOrWhiteSpace(val) ? DBNull.Value : (object)val.Trim();

                    cmd.Parameters.Add("@BUS_CET", SqlDbType.Int).Value = (object)BUS_CET ?? DBNull.Value;
                    cmd.Parameters.Add("@BUS_FEC_INI", SqlDbType.Date).Value = (object)BUS_FEC_INI ?? DBNull.Value;
                    cmd.Parameters.Add("@BUS_FEC_FIN", SqlDbType.Date).Value = (object)BUS_FEC_FIN ?? DBNull.Value;
                    cmd.Parameters.Add("@BUS_DEN", SqlDbType.VarChar).Value = CleanParam(BUS_DEN);
                    cmd.Parameters.Add("@BUS_SEC_ORI", SqlDbType.VarChar).Value = CleanParam(BUS_SEC_ORI);
                    cmd.Parameters.Add("@BUS_SEC_DES", SqlDbType.VarChar).Value = CleanParam(BUS_SEC_DES);
                    cmd.Parameters.Add("@BUS_EST", SqlDbType.VarChar).Value = CleanParam(BUS_EST);
                    cmd.Parameters.Add("@BUS_MAT_PR", SqlDbType.VarChar).Value = CleanParam(BUS_MAT_PR);
                    cmd.Parameters.Add("@BUS_ORT_DEN", SqlDbType.VarChar).Value = CleanParam(BUS_ORT_DEN);
                    cmd.Parameters.Add("@BUS_PAC", SqlDbType.VarChar).Value = CleanParam(BUS_PAC);
                    cmd.Parameters.Add("@BUS_PRO", SqlDbType.VarChar).Value = CleanParam(BUS_PRO);
                    cmd.Parameters.Add("@BUS_REM", SqlDbType.VarChar).Value = CleanParam(BUS_REM);
                    cmd.Parameters.Add("@BUS_REU_ID", SqlDbType.VarChar).Value = CleanParam(BUS_REU_ID);
                    cmd.Parameters.Add("@BUS_FEN", SqlDbType.Date).Value = (object)BUS_FEN ?? DBNull.Value;
                    cmd.Parameters.Add("@BUS_ACAJ_OPC", SqlDbType.Bit).Value = (object)BUS_ACAJ_OPC ?? DBNull.Value;
                    cmd.Parameters.Add("@BUS_TRA_OPC", SqlDbType.Bit).Value = (object)BUS_TRA_OPC ?? DBNull.Value;

                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new RecDetBusquedaDto
                            {
                                TB_REC_ID = dr["TB_REC_ID"] as int?,
                                TB_REC_FEC = dr["TB_REC_FEC"] as DateTime?,
                                TB_REC_HOR_INI = dr["TB_REC_HOR_INI"] as DateTime?,
                                TB_REC_SEC_ORI_ID = dr["TB_REC_SEC_ORI_ID"] as int?,
                                TB_REC_SEC_ORI_DEN = dr["TB_REC_SEC_ORI_DEN"]?.ToString(),
                                TB_REC_SEC_DES_ID = dr["TB_REC_SEC_DES_ID"] as int?,
                                TB_REC_SEC_DES_DEN = dr["TB_REC_SEC_DES_DEN"]?.ToString(),
                                TB_REC_ORT_ID = dr["TB_REC_ORT_ID"] as int?,
                                TB_REC_ORT_DEN = dr["TB_REC_ORT_DEN"]?.ToString(),
                                TB_REC_CANT_TOT = dr["TB_REC_CANT_TOT"] as int?,
                                TB_REC_LOT = dr["TB_REC_LOT"]?.ToString(),
                                TB_REC_DET_ID = dr["TB_REC_DET_ID"] as int?,
                                TB_REC_DET_MAT_ID = dr["TB_REC_DET_MAT_ID"] as int?,
                                TB_REC_DET_MAT_PR = dr["TB_REC_DET_MAT_PR"]?.ToString(),
                                TB_REC_DET_MAT_DEN = dr["TB_REC_DET_MAT_DEN"]?.ToString(),
                                TB_REC_DET_CANT_MULT = dr["TB_REC_DET_CANT_MULT"] as int?,
                                TB_REC_DET_CANT = dr["TB_REC_DET_CANT"] as int?,
                                TB_REC_DET_MDE = dr["TB_REC_DET_MDE"] as bool?,
                                TB_REC_DET_MCO = dr["TB_REC_DET_MCO"] as bool?,
                                TB_REC_DET_VOP_OPC = dr["TB_REC_DET_VOP_OPC"] as bool?,
                                TB_REC_DET_REU_OPC = dr["TB_REC_DET_REU_OPC"] as bool?,
                                TB_REC_DET_EST_ID = dr["TB_REC_DET_EST_ID"] as int?,
                                TB_REC_DET_EST_DEN = dr["TB_REC_DET_EST_DEN"]?.ToString(),
                                TB_REC_DET_EST_ING_ID = dr["TB_REC_DET_EST_ING_ID"] as int?,
                                TB_REC_DET_EST_ING_DEN = dr["TB_REC_DET_EST_ING_DEN"]?.ToString(),
                                TB_REC_DET_LOT = dr["TB_REC_DET_LOT"]?.ToString(),
                                TB_REC_DET_VEN = dr["TB_REC_DET_VEN"] as DateTime?,
                                TB_REC_DET_NUM_3 = dr["TB_REC_DET_NUM_3"] as int?,
                                TB_REC_DET_TXT_3 = dr["TB_REC_DET_TXT_3"]?.ToString(),
                                TB_REC_DET_REU_ID = dr["TB_REC_DET_REU_ID"]?.ToString(),
                                TB_REC_DET_REU_CANT = dr["TB_REC_DET_REU_CANT"] as int?,
                                TB_REC_DET_PAC = dr["TB_REC_DET_PAC"]?.ToString(),
                                TB_REC_DET_PRO_ID = dr["TB_REC_DET_PRO_ID"] as int?,
                                TB_REC_DET_PRO_NOM = dr["TB_REC_DET_PRO_NOM"]?.ToString(),
                                TB_REC_DET_REM = dr["TB_REC_DET_REM"]?.ToString(),
                                TB_REC_DET_FEN = dr["TB_REC_DET_FEN"] as DateTime?,
                                TB_REC_DET_HEN = dr["TB_REC_DET_HEN"] as DateTime?,
                                TB_REC_DET_OBS = dr["TB_REC_DET_OBS"]?.ToString(),
                                TB_REC_DET_PMAT = dr["TB_REC_DET_PMAT"] != DBNull.Value ? Convert.ToDouble(dr["TB_REC_DET_PMAT"]) : (double?)null,
                                TB_REC_DET_MORT = dr["TB_REC_DET_MORT"] as int?,
                                TB_REC_DET_IVIS_OPC = dr["TB_REC_DET_IVIS_OPC"] as bool?,
                                TB_REC_DET_IVIS_OPC_NOM = dr["TB_REC_DET_IVIS_OPC_NOM"]?.ToString(),
                                TB_REC_DET_ACAJ_OPC = dr["TB_REC_DET_ACAJ_OPC"] as bool?,
                                TB_REC_DET_ACAJ_OPC_NOM = dr["TB_REC_DET_ACAJ_OPC_NOM"]?.ToString()
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public List<string> ObtenerSugerencias(string term, string campo, string tabla)
        {
            var sugerencias = new List<string>();
            string query = $"SELECT DISTINCT TOP 10 {campo} FROM {tabla} WITH (NOLOCK) WHERE {campo} LIKE @term + '%' AND {campo} IS NOT NULL ORDER BY {campo}";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@term", term);
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read()) { sugerencias.Add(dr[0].ToString()); }
                    }
                }
            }
            return sugerencias;
        }

        public IEnumerable<object> GetRecolecciones(
                DateTime d1,
                DateTime d2,
                string s1,
                string s2,
                string s3,
                string s4,
                string s5)
        {
            return new List<object>();
        }
    }
}