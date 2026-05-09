using ConexionSql.Interfaces;
using ConexionSql.Models.SP_Busquedas;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;

namespace ConexionSql.Services
{
    public class BusLavadoService : IBusLavadoService
    {
        private readonly string _connectionString;

        public BusLavadoService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<BusLavadoDto> GetLavados(DateTime BUS_FEC_INI, DateTime BUS_FEC_FIN, string BUS_PTI,
                                              string BUS_EST, string BUS_LOT, string BUS_EQU_TEQ, string BUS_EQU_NUM)
        {
            var lista = new List<BusLavadoDto>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_GET_LAV", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BUS_FEC_INI", BUS_FEC_INI);
                    cmd.Parameters.AddWithValue("@BUS_FEC_FIN", BUS_FEC_FIN);
                    cmd.Parameters.AddWithValue("@BUS_PTI", BUS_PTI ?? "");
                    cmd.Parameters.AddWithValue("@BUS_EST", BUS_EST ?? "");
                    cmd.Parameters.AddWithValue("@BUS_LOT", BUS_LOT ?? "");
                    cmd.Parameters.AddWithValue("@BUS_EQU_TEQ", BUS_EQU_TEQ ?? "");
                    cmd.Parameters.AddWithValue("@BUS_EQU_NUM", BUS_EQU_NUM ?? "");

                    con.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            lista.Add(new BusLavadoDto
                            {
                                TB_PRO_LAV_ID = rdr["TB_PRO_LAV_ID"] != DBNull.Value ? Convert.ToInt32(rdr["TB_PRO_LAV_ID"]) : 0,
                                TB_PRO_LAV_FEC = rdr["TB_PRO_LAV_FEC"] != DBNull.Value ? Convert.ToDateTime(rdr["TB_PRO_LAV_FEC"]) : DateTime.MinValue,
                                TB_PRO_LAV_PTI_DEN = rdr["TB_PRO_LAV_PTI_DEN"]?.ToString() ?? "",
                                TB_PRO_LAV_EST_DEN = rdr["TB_PRO_LAV_EST_DEN"]?.ToString() ?? "",
                                TB_PRO_LAV_NUM = rdr["TB_PRO_LAV_NUM"]?.ToString() ?? "",
                                TB_PRO_IB_EQU_TEQ_DEN = rdr["TB_PRO_IB_EQU_TEQ_DEN"]?.ToString() ?? "",
                                // AQUÍ: Leemos como string para que no explote con "NO REGISTRADO"
                                TB_PRO_LAV_EQU_NUM = rdr["TB_PRO_LAV_EQU_NUM"]?.ToString() ?? ""
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}