using ConexionSql.Services.InfoBasica.Interfaces;
using ConexionSql.Models.InfoBasica;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System; // <-- AGREGADO para manejar DBNull y Convert

namespace ConexionSql.Services.InfoBasica
{
    public class IbEquiposService : IIbEquiposService
    {
        private readonly string _connectionString;

        public IbEquiposService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? "";
        }

        public async Task<IEnumerable<IbEquTeqDto>> ObtenerTiposEquipoAsync()
        {
            var lista = new List<IbEquTeqDto>();

            string query = @"
                SELECT 
                    IB_EQU_TEQ_ID, 
                    IB_EQU_TEQ_DEN, 
                    IB_EQU_PTI_ID, 
                    IB_EQU_PTI_DEN 
                FROM dbo.IB_EQU_TEQ 
                WHERE IB_EQU_TEQ_DEN IS NOT NULL 
                  AND IB_EQU_TEQ_OCU = 0 
                ORDER BY IB_EQU_TEQ_DEN;";

            using (var con = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand(query, con))
                {
                    await con.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            lista.Add(new IbEquTeqDto
                            {
                                IbEquTeqId = reader.GetInt32(reader.GetOrdinal("IB_EQU_TEQ_ID")),
                                IbEquTeqDen = reader.GetString(reader.GetOrdinal("IB_EQU_TEQ_DEN")),
                                IbEquPtiId = reader.GetInt32(reader.GetOrdinal("IB_EQU_PTI_ID")),
                                IbEquPtiDen = reader.GetString(reader.GetOrdinal("IB_EQU_PTI_DEN"))
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<IEnumerable<IbEquMarDto>> ObtenerMarcasAsync()
        {
            var lista = new List<IbEquMarDto>();

            string query = @"
                SELECT 
                    IB_EQU_MAR_ID, 
                    IB_EQU_MAR_DEN 
                FROM dbo.IB_EQU_MAR 
                WHERE IB_EQU_MAR_DEN IS NOT NULL 
                  AND IB_EQU_MAR_OCU = 0 
                ORDER BY IB_EQU_MAR_DEN;";

            using (var con = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand(query, con))
                {
                    await con.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            lista.Add(new IbEquMarDto
                            {
                                IbEquMarId = reader.GetInt32(reader.GetOrdinal("IB_EQU_MAR_ID")),
                                IbEquMarDen = reader.GetString(reader.GetOrdinal("IB_EQU_MAR_DEN"))
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<IEnumerable<IbProTciDto>> ObtenerTiposCicloAsync()
        {
            var lista = new List<IbProTciDto>();

            string query = @"
                SELECT 
                    TB_PRO_TCI_ID, 
                    TB_PRO_TCI_DEN, 
                    TB_PRO_PTI_ID 
                FROM dbo.IB_PRO_TCI 
                WHERE TB_PRO_PTI_OCU = 0 
                ORDER BY TB_PRO_TCI_DEN;";

            using (var con = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand(query, con))
                {
                    await con.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            lista.Add(new IbProTciDto
                            {
                                TbProTciId = reader.GetInt32(reader.GetOrdinal("TB_PRO_TCI_ID")),
                                TbProTciDen = reader.GetString(reader.GetOrdinal("TB_PRO_TCI_DEN")),
                                TbProPtiId = reader.GetInt32(reader.GetOrdinal("TB_PRO_PTI_ID"))
                            });
                        }
                    }
                }
            }
            return lista;
        }

        // =========================================================================================
        // --- NUEVO: MÉTODO PARA OBTENER EL LISTADO COMPLETO (GRILLA PRINCIPAL)
        // =========================================================================================
        public async Task<IEnumerable<IbEquGrillaDto>> ObtenerTodosAsync()
        {
            var lista = new List<IbEquGrillaDto>();

            string query = @"
                SELECT 
                    IB_EQU_ID, 
                    IB_EQU_TEQ_DEN, 
                    IB_EQU_MAR_DEN, 
                    IB_EQU_MOD, 
                    IB_EQU_SER, 
                    IB_EQU_NUM, 
                    IB_EQU_OCU 
                FROM dbo.IB_EQU 
                ORDER BY IB_EQU_ID DESC;"; // Traemos los últimos cargados primero

            using (var con = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand(query, con))
                {
                    await con.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            lista.Add(new IbEquGrillaDto
                            {
                                IbEquId = reader.GetInt32(reader.GetOrdinal("IB_EQU_ID")),
                                IbEquTeqDen = reader.IsDBNull(reader.GetOrdinal("IB_EQU_TEQ_DEN")) ? null : reader.GetString(reader.GetOrdinal("IB_EQU_TEQ_DEN")),
                                IbEquMarDen = reader.IsDBNull(reader.GetOrdinal("IB_EQU_MAR_DEN")) ? null : reader.GetString(reader.GetOrdinal("IB_EQU_MAR_DEN")),
                                IbEquMod = reader.IsDBNull(reader.GetOrdinal("IB_EQU_MOD")) ? null : reader.GetString(reader.GetOrdinal("IB_EQU_MOD")),
                                IbEquSer = reader.IsDBNull(reader.GetOrdinal("IB_EQU_SER")) ? null : reader.GetString(reader.GetOrdinal("IB_EQU_SER")),
                                IbEquNum = reader.IsDBNull(reader.GetOrdinal("IB_EQU_NUM")) ? null : reader.GetString(reader.GetOrdinal("IB_EQU_NUM")),
                                IbEquOcu = Convert.ToBoolean(reader["IB_EQU_OCU"])
                            });
                        }
                    }
                }
            }
            return lista;
        }

        // =========================================================================================
        // --- MÉTODOS PARA GUARDAR EL EQUIPO Y SUS DETALLES DE VOLUMEN (ALTA Y MODIFICACIÓN)
        // =========================================================================================

        public async Task<bool> GuardarEquipoAsync(IbEquDto equipo)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                await con.OpenAsync();

                // Iniciamos la transacción para asegurar que la cabecera y el detalle se guarden juntos
                using (var trans = con.BeginTransaction())
                {
                    try
                    {
                        int equipoId = equipo.IbEquId;

                        if (equipoId == 0)
                        {
                            // ---------- ALTA: INSERTAR CABECERA ----------
                            string queryInsertCab = @"
                                INSERT INTO dbo.IB_EQU (
                                    IB_EQU_TEQ_ID, IB_EQU_TEQ_DEN, IB_EQU_PTI_ID, IB_EQU_PTI_DEN,
                                    IB_EQU_MAR_ID, IB_EQU_MAR_DEN, IB_EQU_MOD, IB_EQU_SER,
                                    IB_EQU_NUM, IB_EQU_OCU, IB_EQU_ALT, IB_EQU_ANC,
                                    IB_EQU_PRO, IB_EQU_CAP, IB_EQU_PORC, IB_EQU_CAPU,
                                    IB_EQU_LMAT, IB_EQU_PCO, IB_EQU_PCO_COEF, IB_EQU_PVE
                                ) VALUES (
                                    @TeqId, @TeqDen, @PtiId, @PtiDen,
                                    @MarId, @MarDen, @Mod, @Ser,
                                    @Num, @Ocu, @Alt, @Anc,
                                    @Pro, @Cap, @Porc, @Capu,
                                    @Lmat, @Pco, @PcoCoef, @Pve
                                ); SELECT SCOPE_IDENTITY();";

                            using (var cmd = new SqlCommand(queryInsertCab, con, trans))
                            {
                                AsignarParametrosCabecera(cmd, equipo);
                                equipoId = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                            }
                        }
                        else
                        {
                            // ---------- MODIFICACIÓN: UPDATE CABECERA ----------
                            string queryUpdateCab = @"
                                UPDATE dbo.IB_EQU SET 
                                    IB_EQU_TEQ_ID = @TeqId, IB_EQU_TEQ_DEN = @TeqDen, 
                                    IB_EQU_PTI_ID = @PtiId, IB_EQU_PTI_DEN = @PtiDen,
                                    IB_EQU_MAR_ID = @MarId, IB_EQU_MAR_DEN = @MarDen, 
                                    IB_EQU_MOD = @Mod, IB_EQU_SER = @Ser,
                                    IB_EQU_NUM = @Num, IB_EQU_OCU = @Ocu, 
                                    IB_EQU_ALT = @Alt, IB_EQU_ANC = @Anc,
                                    IB_EQU_PRO = @Pro, IB_EQU_CAP = @Cap, 
                                    IB_EQU_PORC = @Porc, IB_EQU_CAPU = @Capu,
                                    IB_EQU_LMAT = @Lmat, IB_EQU_PCO = @Pco, 
                                    IB_EQU_PCO_COEF = @PcoCoef, IB_EQU_PVE = @Pve
                                WHERE IB_EQU_ID = @Id;";

                            using (var cmd = new SqlCommand(queryUpdateCab, con, trans))
                            {
                                cmd.Parameters.AddWithValue("@Id", equipo.IbEquId);
                                AsignarParametrosCabecera(cmd, equipo);
                                await cmd.ExecuteNonQueryAsync();
                            }

                            // Limpiamos los detalles viejos para reemplazarlos por los nuevos que manda la grilla
                            string queryDeleteDet = "DELETE FROM dbo.IB_EQU_PTI_DET WHERE IB_EQU_PTI_DET_EQU_ID = @Id;";
                            using (var cmdDel = new SqlCommand(queryDeleteDet, con, trans))
                            {
                                cmdDel.Parameters.AddWithValue("@Id", equipo.IbEquId);
                                await cmdDel.ExecuteNonQueryAsync();
                            }
                        }

                        // ---------- GUARDAR DETALLES DE VOLUMEN (GRILLA) ----------
                        if (equipo.Detalles != null && equipo.Detalles.Count > 0)
                        {
                            string queryInsertDet = @"
                                INSERT INTO dbo.IB_EQU_PTI_DET (
                                    IB_EQU_PTI_DET_EQU_ID, IB_EQU_PTI_DET_TCI_ID, 
                                    IB_EQU_PTI_DET_TCI_DEN, IB_EQU_PTI_DET_VOL, IB_EQU_PTI_DET_OCU
                                ) VALUES (
                                    @EquId, @TciId, @TciDen, @Vol, @DetOcu
                                );";

                            foreach (var det in equipo.Detalles)
                            {
                                using (var cmdDet = new SqlCommand(queryInsertDet, con, trans))
                                {
                                    cmdDet.Parameters.AddWithValue("@EquId", equipoId);
                                    cmdDet.Parameters.AddWithValue("@TciId", det.IbEquPtiDetTciId);
                                    cmdDet.Parameters.AddWithValue("@TciDen", det.IbEquPtiDetTciDen ?? (object)DBNull.Value);
                                    cmdDet.Parameters.AddWithValue("@Vol", det.IbEquPtiDetVol);
                                    cmdDet.Parameters.AddWithValue("@DetOcu", det.IbEquPtiDetOcu ? 1 : 0);

                                    await cmdDet.ExecuteNonQueryAsync();
                                }
                            }
                        }

                        // Si llegamos hasta acá sin errores, confirmamos la transacción
                        trans.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        // Si algo falla (ej: error de SQL), cancelamos todo para que no queden datos a medias
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        // ====================================================================
        // --- MÉTODO PARA OBTENER UN EQUIPO POR ID (PARA EDITAR)
        // ====================================================================
        public async Task<IbEquDto?> ObtenerEquipoPorIdAsync(int id)
        {
            IbEquDto? equipo = null;

            using (var con = new SqlConnection(_connectionString))
            {
                await con.OpenAsync();

                // 1. Buscamos los datos de la cabecera
                string queryCab = @"
                    SELECT 
                        IB_EQU_ID, IB_EQU_TEQ_ID, IB_EQU_TEQ_DEN, IB_EQU_PTI_ID, IB_EQU_PTI_DEN,
                        IB_EQU_MAR_ID, IB_EQU_MAR_DEN, IB_EQU_MOD, IB_EQU_SER, IB_EQU_NUM,
                        IB_EQU_OCU, IB_EQU_ALT, IB_EQU_ANC, IB_EQU_PRO, IB_EQU_CAP, 
                        IB_EQU_PORC, IB_EQU_CAPU, IB_EQU_LMAT, IB_EQU_PCO, IB_EQU_PCO_COEF, IB_EQU_PVE
                    FROM dbo.IB_EQU 
                    WHERE IB_EQU_ID = @Id;";

                using (var cmd = new SqlCommand(queryCab, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            equipo = new IbEquDto
                            {
                                IbEquId = reader.GetInt32(reader.GetOrdinal("IB_EQU_ID")),
                                IbEquTeqId = reader.GetInt32(reader.GetOrdinal("IB_EQU_TEQ_ID")),
                                IbEquTeqDen = reader.IsDBNull(reader.GetOrdinal("IB_EQU_TEQ_DEN")) ? null : reader.GetString(reader.GetOrdinal("IB_EQU_TEQ_DEN")),
                                IbEquPtiId = reader.GetInt32(reader.GetOrdinal("IB_EQU_PTI_ID")),
                                IbEquPtiDen = reader.IsDBNull(reader.GetOrdinal("IB_EQU_PTI_DEN")) ? null : reader.GetString(reader.GetOrdinal("IB_EQU_PTI_DEN")),
                                IbEquMarId = reader.GetInt32(reader.GetOrdinal("IB_EQU_MAR_ID")),
                                IbEquMarDen = reader.IsDBNull(reader.GetOrdinal("IB_EQU_MAR_DEN")) ? null : reader.GetString(reader.GetOrdinal("IB_EQU_MAR_DEN")),
                                IbEquMod = reader.IsDBNull(reader.GetOrdinal("IB_EQU_MOD")) ? null : reader.GetString(reader.GetOrdinal("IB_EQU_MOD")),
                                IbEquSer = reader.IsDBNull(reader.GetOrdinal("IB_EQU_SER")) ? null : reader.GetString(reader.GetOrdinal("IB_EQU_SER")),
                                IbEquNum = reader.IsDBNull(reader.GetOrdinal("IB_EQU_NUM")) ? null : reader.GetString(reader.GetOrdinal("IB_EQU_NUM")),
                                IbEquOcu = Convert.ToBoolean(reader["IB_EQU_OCU"]),
                                IbEquAlt = reader.IsDBNull(reader.GetOrdinal("IB_EQU_ALT")) ? null : reader.GetString(reader.GetOrdinal("IB_EQU_ALT")),
                                IbEquAnc = reader.IsDBNull(reader.GetOrdinal("IB_EQU_ANC")) ? null : reader.GetString(reader.GetOrdinal("IB_EQU_ANC")),
                                IbEquPro = reader.IsDBNull(reader.GetOrdinal("IB_EQU_PRO")) ? null : reader.GetString(reader.GetOrdinal("IB_EQU_PRO")),
                                IbEquCap = reader.IsDBNull(reader.GetOrdinal("IB_EQU_CAP")) ? null : reader.GetString(reader.GetOrdinal("IB_EQU_CAP")),
                                IbEquPorc = reader.IsDBNull(reader.GetOrdinal("IB_EQU_PORC")) ? null : reader.GetString(reader.GetOrdinal("IB_EQU_PORC")),
                                IbEquCapu = reader.IsDBNull(reader.GetOrdinal("IB_EQU_CAPU")) ? null : reader.GetString(reader.GetOrdinal("IB_EQU_CAPU")),
                                IbEquLmat = reader.IsDBNull(reader.GetOrdinal("IB_EQU_LMAT")) ? null : reader.GetString(reader.GetOrdinal("IB_EQU_LMAT")),
                                IbEquPco = Convert.ToDecimal(reader["IB_EQU_PCO"]),
                                IbEquPcoCoef = Convert.ToDecimal(reader["IB_EQU_PCO_COEF"]),
                                IbEquPve = Convert.ToDecimal(reader["IB_EQU_PVE"]),
                                Detalles = new List<IbEquPtiDetDto>() // Inicializamos la lista vacía
                            };
                        }
                    }
                }

                // 2. Si el equipo existe, buscamos las filas de volumen de la grilla
                if (equipo != null)
                {
                    string queryDet = @"
                        SELECT 
                            IB_EQU_PTI_DET_ID, IB_EQU_PTI_DET_EQU_ID, IB_EQU_PTI_DET_TCI_ID, 
                            IB_EQU_PTI_DET_TCI_DEN, IB_EQU_PTI_DET_VOL, IB_EQU_PTI_DET_OCU
                        FROM dbo.IB_EQU_PTI_DET
                        WHERE IB_EQU_PTI_DET_EQU_ID = @Id;";

                    using (var cmdDet = new SqlCommand(queryDet, con))
                    {
                        cmdDet.Parameters.AddWithValue("@Id", id);
                        using (var reader = await cmdDet.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                equipo.Detalles.Add(new IbEquPtiDetDto
                                {
                                    IbEquPtiDetId = reader.GetInt32(reader.GetOrdinal("IB_EQU_PTI_DET_ID")),
                                    IbEquPtiDetEquId = reader.GetInt32(reader.GetOrdinal("IB_EQU_PTI_DET_EQU_ID")),
                                    IbEquPtiDetTciId = reader.GetInt32(reader.GetOrdinal("IB_EQU_PTI_DET_TCI_ID")),
                                    IbEquPtiDetTciDen = reader.IsDBNull(reader.GetOrdinal("IB_EQU_PTI_DET_TCI_DEN")) ? null : reader.GetString(reader.GetOrdinal("IB_EQU_PTI_DET_TCI_DEN")),
                                    IbEquPtiDetVol = Convert.ToDecimal(reader["IB_EQU_PTI_DET_VOL"]),
                                    IbEquPtiDetOcu = Convert.ToBoolean(reader["IB_EQU_PTI_DET_OCU"])
                                });
                            }
                        }
                    }
                }
            }

            return equipo;
        }

        // Método auxiliar privado para limpiar el código y no repetir los parámetros
        private void AsignarParametrosCabecera(SqlCommand cmd, IbEquDto equipo)
        {
            cmd.Parameters.AddWithValue("@TeqId", equipo.IbEquTeqId);
            cmd.Parameters.AddWithValue("@TeqDen", equipo.IbEquTeqDen ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@PtiId", equipo.IbEquPtiId);
            cmd.Parameters.AddWithValue("@PtiDen", equipo.IbEquPtiDen ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@MarId", equipo.IbEquMarId);
            cmd.Parameters.AddWithValue("@MarDen", equipo.IbEquMarDen ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Mod", equipo.IbEquMod ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Ser", equipo.IbEquSer ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Num", equipo.IbEquNum ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Ocu", equipo.IbEquOcu ? 1 : 0);

            // Textos descriptivos de características
            cmd.Parameters.AddWithValue("@Alt", equipo.IbEquAlt ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Anc", equipo.IbEquAnc ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Pro", equipo.IbEquPro ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Cap", equipo.IbEquCap ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Porc", equipo.IbEquPorc ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Capu", equipo.IbEquCapu ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Lmat", equipo.IbEquLmat ?? (object)DBNull.Value);

            // Valores decimales
            cmd.Parameters.AddWithValue("@Pco", equipo.IbEquPco);
            cmd.Parameters.AddWithValue("@PcoCoef", equipo.IbEquPcoCoef);
            cmd.Parameters.AddWithValue("@Pve", equipo.IbEquPve);
        }
    }
}