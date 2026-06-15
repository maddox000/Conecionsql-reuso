using ConexionSql.Models.SP_Busquedas;
using ConexionSql.Services.SP_Busquedas.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;

namespace ConexionSql.Services.SP_Busquedas
{
    public class Bus_EntDetService : IBus_EntDetService
    {
        private readonly string _connectionString;

        public Bus_EntDetService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Bus_EntDetDto> BuscarEntregas(
            int? BUS_CET,
            DateTime? FEC_INI,
            DateTime? FEC_FIN,
            string BUS_DEN,
            string BUS_SEC,
            string BUS_REU,
            string BUS_PAC,
            string BUS_PRO,
            string BUS_PROV,
            string BUS_REM)
        {
            var lista = new List<Bus_EntDetDto>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_BusEntDet", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetros originales
                    cmd.Parameters.AddWithValue("@BUS_CET", (object)BUS_CET ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FEC_INI", (object)FEC_INI ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FEC_FIN", (object)FEC_FIN ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BUS_DEN", string.IsNullOrEmpty(BUS_DEN) ? DBNull.Value : BUS_DEN);
                    cmd.Parameters.AddWithValue("@BUS_SEC", string.IsNullOrEmpty(BUS_SEC) ? DBNull.Value : BUS_SEC);
                    cmd.Parameters.AddWithValue("@BUS_REU", string.IsNullOrEmpty(BUS_REU) ? DBNull.Value : BUS_REU);

                    // --- NUEVOS PARÁMETROS ---
                    cmd.Parameters.AddWithValue("@BUS_PAC", string.IsNullOrEmpty(BUS_PAC) ? DBNull.Value : BUS_PAC);
                    cmd.Parameters.AddWithValue("@BUS_PRO", string.IsNullOrEmpty(BUS_PRO) ? DBNull.Value : BUS_PRO);
                    cmd.Parameters.AddWithValue("@BUS_PROV", string.IsNullOrEmpty(BUS_PROV) ? DBNull.Value : BUS_PROV);
                    cmd.Parameters.AddWithValue("@BUS_REM", string.IsNullOrEmpty(BUS_REM) ? DBNull.Value : BUS_REM);

                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var dto = new Bus_EntDetDto
                            {
                                TB_ENT_ID = Convert.ToInt32(dr["TB_ENT_ID"]),
                                TB_ENT_FEC = dr["TB_ENT_FEC"] != DBNull.Value ? Convert.ToDateTime(dr["TB_ENT_FEC"]) : (DateTime?)null,
                                TB_ENT_HOR_INI = dr["TB_ENT_HOR_INI"] != DBNull.Value ?
                                (dr["TB_ENT_HOR_INI"] is TimeSpan ? (TimeSpan?)dr["TB_ENT_HOR_INI"] : ((DateTime)dr["TB_ENT_HOR_INI"]).TimeOfDay) : null,
                                TB_ENT_SEC_ID = dr["TB_ENT_SEC_ID"] != DBNull.Value ? Convert.ToInt32(dr["TB_ENT_SEC_ID"]) : (int?)null,
                                TB_ENT_SEC_DEN = dr["TB_ENT_SEC_DEN"].ToString(),
                                TB_ENT_DET_REC_DET_MAT_ID = dr["TB_ENT_DET_REC_DET_MAT_ID"] != DBNull.Value ? Convert.ToInt32(dr["TB_ENT_DET_REC_DET_MAT_ID"]) : (int?)null,
                                TB_ENT_DET_REC_DET_MAT_DEN = dr["TB_ENT_DET_REC_DET_MAT_DEN"].ToString(),
                                TB_ENT_DET_REC_DET_MAT_TIP_ID = dr["TB_ENT_DET_REC_DET_MAT_TIP_ID"] != DBNull.Value ? Convert.ToInt32(dr["TB_ENT_DET_REC_DET_MAT_TIP_ID"]) : (int?)null,
                                TB_ENT_DET_REC_DET_MAT_TIP_DEN = dr["TB_ENT_DET_REC_DET_MAT_TIP_DEN"].ToString(),
                                TB_ENT_DET_REC_DET_REU_ID = dr["TB_ENT_DET_REC_DET_REU_ID"] != DBNull.Value ? Convert.ToInt32(dr["TB_ENT_DET_REC_DET_REU_ID"]) : (int?)null,
                                TB_ENT_DET_REC_DET_PAC = dr["TB_ENT_DET_REC_DET_PAC"].ToString(),
                                TB_REC_DET_PRO_ID = dr["TB_REC_DET_PRO_ID"] != DBNull.Value ? Convert.ToInt32(dr["TB_REC_DET_PRO_ID"]) : (int?)null,
                                TB_REC_DET_PRO_NOM = dr["TB_REC_DET_PRO_NOM"].ToString(),
                                TB_REC_DET_REM = dr["TB_REC_DET_REM"].ToString(),
                                TB_ENT_DET_CANT = dr["TB_ENT_DET_CANT"] != DBNull.Value ? Convert.ToDecimal(dr["TB_ENT_DET_CANT"]) : (decimal?)null,
                                TB_ENT_DET_REC_DET_ID = dr["TB_ENT_DET_REC_DET_ID"] != DBNull.Value ? Convert.ToInt32(dr["TB_ENT_DET_REC_DET_ID"]) : (int?)null
                            };
                            lista.Add(dto);
                        }
                    }
                }
            }
            return lista;
        }

        // --- AUTOCOMPLETAR ---
        public List<string> GetSugerencias(string term, string campo, string tabla)
        {
            var resultados = new List<string>();

            // 1. SEGURIDAD: Sumamos las nuevas tablas y campos permitidos
            var tablasPermitidas = new List<string> { "TB_REC_DET", "TB_REU", "IB_MAT", "IB_SEC", "IB_PRO", "IB_ORT" };
            var camposPermitidos = new List<string> {
                "TB_REC_DET_ID",
                "TB_REU_ID_FORM",
                "IB_MAT_DEN",
                "IB_SEC_DEN",
                "TB_REC_DET_PAC",
                "TB_REC_DET_REM",
                "IB_ORT_DEN",
                "IB_PRO_APE + ' ' + IB_PRO_NOM" // Se permite esta concatenación exacta para el profesional
            };

            if (!tablasPermitidas.Contains(tabla) || !camposPermitidos.Contains(campo))
            {
                return resultados;
            }

            // 2. Separar lo que escribió el usuario por espacios
            var palabras = term.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (palabras.Length == 0) return resultados;

            // 3. Armar la consulta SQL dinámicamente
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var condiciones = new List<string>();
                for (int i = 0; i < palabras.Length; i++)
                {
                    condiciones.Add($"{campo} LIKE @p{i}");
                }

                string whereClause = string.Join(" AND ", condiciones);
                string query = $"SELECT DISTINCT TOP 20 {campo} FROM {tabla} WHERE {whereClause}";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    for (int i = 0; i < palabras.Length; i++)
                    {
                        cmd.Parameters.AddWithValue($"@p{i}", "%" + palabras[i] + "%");
                    }

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            resultados.Add(reader[0].ToString());
                        }
                    }
                }
            }

            return resultados;
        }
    }
}