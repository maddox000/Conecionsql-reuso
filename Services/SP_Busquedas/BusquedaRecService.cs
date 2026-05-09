using ConexionSql.Models.SP_Busquedas;
using ConexionSql.Services.SP_Busquedas.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ConexionSql.Services.SP_Busquedas
{
    public class BusquedaRecService : IBusquedaRecService
    {
        private readonly string _connectionString;

        public BusquedaRecService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<RecBusquedaDto> BuscarRec(
            DateTime? FEC_INI, DateTime? FEC_FIN, string BUS_SEC_ORI,
            string BUS_SEC_DES, string BUS_ORT_DEN, string BUS_DEN,
            string BUS_PR, string BUS_REU_ID, string BUS_PAC,
            string BUS_PRO, string BUS_REM, DateTime? BUS_FEN)
        {
            var lista = new List<RecBusquedaDto>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.SP_GET_REC", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 60; // Damos tiempo por si son muchos datos

                    // Limpieza rigurosa de parámetros
                    Func<string, object> CleanParam = (val) =>
                        string.IsNullOrWhiteSpace(val) ? DBNull.Value : (object)val.Trim();

                    cmd.Parameters.Add("@FEC_INI", SqlDbType.Date).Value = (object)FEC_INI ?? DBNull.Value;
                    cmd.Parameters.Add("@FEC_FIN", SqlDbType.Date).Value = (object)FEC_FIN ?? DBNull.Value;
                    cmd.Parameters.Add("@BUS_SEC_ORI", SqlDbType.VarChar).Value = CleanParam(BUS_SEC_ORI);
                    cmd.Parameters.Add("@BUS_SEC_DES", SqlDbType.VarChar).Value = CleanParam(BUS_SEC_DES);
                    cmd.Parameters.Add("@BUS_ORT_DEN", SqlDbType.VarChar).Value = CleanParam(BUS_ORT_DEN);
                    cmd.Parameters.Add("@BUS_DEN", SqlDbType.VarChar).Value = CleanParam(BUS_DEN);
                    cmd.Parameters.Add("@BUS_PR", SqlDbType.VarChar).Value = CleanParam(BUS_PR);
                    cmd.Parameters.Add("@BUS_REU_ID", SqlDbType.VarChar).Value = CleanParam(BUS_REU_ID);
                    cmd.Parameters.Add("@BUS_PAC", SqlDbType.VarChar).Value = CleanParam(BUS_PAC);
                    cmd.Parameters.Add("@BUS_PRO", SqlDbType.VarChar).Value = CleanParam(BUS_PRO);
                    cmd.Parameters.Add("@BUS_REM", SqlDbType.VarChar).Value = CleanParam(BUS_REM);
                    cmd.Parameters.Add("@BUS_FEN", SqlDbType.Date).Value = (object)BUS_FEN ?? DBNull.Value;

                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var dto = new RecBusquedaDto();

                            // Mapeo seguro: Si falla una columna, no perdemos todo el registro
                            dto.TB_REC_ID = dr["TB_REC_ID"] != DBNull.Value ? Convert.ToInt32(dr["TB_REC_ID"]) : 0;
                            dto.TB_REC_FEC = dr["TB_REC_FEC"] != DBNull.Value ? Convert.ToDateTime(dr["TB_REC_FEC"]) : DateTime.MinValue;
                            dto.TB_REC_HOR_INI = dr["TB_REC_HOR_INI"]?.ToString() ?? "";
                            dto.TB_REC_HOR_FIN = dr["TB_REC_HOR_FIN"]?.ToString() ?? "";
                            dto.TB_REC_SEC_ORI_DEN = dr["TB_REC_SEC_ORI_DEN"]?.ToString() ?? "";
                            dto.TB_REC_SEC_DES_DEN = dr["TB_REC_SEC_DES_DEN"]?.ToString() ?? "";
                            dto.TB_REC_ORT_DEN = dr["TB_REC_ORT_DEN"]?.ToString() ?? "";
                            dto.TB_REC_OBS = dr["TB_REC_OBS"]?.ToString() ?? "";
                            dto.TB_REC_MDE = dr["TB_REC_MDE"]?.ToString() ?? "";
                            dto.TB_REC_MCO = dr["TB_REC_MCO"]?.ToString() ?? "";

                            lista.Add(dto);
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
    }
}