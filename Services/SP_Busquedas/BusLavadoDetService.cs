using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ConexionSql.Data;
using ConexionSql.Models.SP_Busquedas;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConexionSql.Services.SP_Busquedas.Interfaces;


namespace ConexionSql.Services.SP_Busquedas
{
    public class BusLavadoDetService : IBusLavadoDetService
    {
        private readonly ApplicationDbContext _context;

        public BusLavadoDetService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<BusLavadoDetDto>> GetLavadoDetalleAsync(
                DateTime fecIni,
                DateTime fecFin,
                string pti = "",
                string est = "",
                string cet = "",
                string den = "",
                string sec = "",
                string reu = "",
                string tprot = "")
                    {
                        return await _context.Set<BusLavadoDetDto>()
                            .FromSqlRaw("EXEC SP_GET_LAV_DET @BUS_FEC_INI, @BUS_FEC_FIN, @BUS_PRO_ID, @BUS_LAV_PTI, @BUS_EST, @BUS_LOT, @BUS_CET, @BUS_REU_ID, @BUS_DEN, @BUS_SEC, @BUS_TPROT",
                                new SqlParameter("@BUS_FEC_INI", fecIni),
                                new SqlParameter("@BUS_FEC_FIN", fecFin),
                                new SqlParameter("@BUS_PRO_ID", DBNull.Value),
                                new SqlParameter("@BUS_LAV_PTI", string.IsNullOrWhiteSpace(pti) ? DBNull.Value : pti),
                                new SqlParameter("@BUS_EST", string.IsNullOrWhiteSpace(est) ? DBNull.Value : est),
                                new SqlParameter("@BUS_LOT", DBNull.Value),
                                new SqlParameter("@BUS_CET", string.IsNullOrWhiteSpace(cet) ? DBNull.Value : cet),
                                new SqlParameter("@BUS_REU_ID", string.IsNullOrWhiteSpace(reu) ? DBNull.Value : reu),
                                new SqlParameter("@BUS_DEN", string.IsNullOrWhiteSpace(den) ? DBNull.Value : den),
                                new SqlParameter("@BUS_SEC", string.IsNullOrWhiteSpace(sec) ? DBNull.Value : sec),
                                new SqlParameter("@BUS_TPROT", string.IsNullOrWhiteSpace(tprot) ? DBNull.Value : tprot))
                            .ToListAsync();
        }

        //public async Task<IEnumerable<BusLavadoDetDto>> GetLavadoDetalleAsync(
        //    DateTime? fecIni, DateTime? fecFin, int? proId, string? pti,
        //    string? est, string? lot, int? cet, string? reuId,
        //    string? den, string? sec, string? tprot)
        //{
        //    return await _context.Set<BusLavadoDetDto>()
        //        .FromSqlRaw("EXEC SP_GET_LAV_DET @BUS_FEC_INI, @BUS_FEC_FIN, @BUS_PRO_ID, @BUS_LAV_PTI, @BUS_EST, @BUS_LOT, @BUS_CET, @BUS_REU_ID, @BUS_DEN, @BUS_SEC, @BUS_TPROT",
        //            new SqlParameter("@BUS_FEC_INI", (object?)fecIni ?? DBNull.Value),
        //            new SqlParameter("@BUS_FEC_FIN", (object?)fecFin ?? DBNull.Value),
        //            new SqlParameter("@BUS_PRO_ID", (object?)proId ?? DBNull.Value),
        //            new SqlParameter("@BUS_LAV_PTI", (object?)pti ?? DBNull.Value),
        //            new SqlParameter("@BUS_EST", (object?)est ?? DBNull.Value),
        //            new SqlParameter("@BUS_LOT", (object?)lot ?? DBNull.Value),
        //            new SqlParameter("@BUS_CET", (object?)cet ?? DBNull.Value),
        //            new SqlParameter("@BUS_REU_ID", (object?)reuId ?? DBNull.Value),
        //            new SqlParameter("@BUS_DEN", (object?)den ?? DBNull.Value),
        //            new SqlParameter("@BUS_SEC", (object?)sec ?? DBNull.Value),
        //            new SqlParameter("@BUS_TPROT", (object?)tprot ?? DBNull.Value))
        //        .ToListAsync();
        //}
    }
}