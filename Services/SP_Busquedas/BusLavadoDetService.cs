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
        private readonly ConexionSqlContext _context;

        public BusLavadoDetService(ConexionSqlContext context)
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
                .FromSqlRaw("EXEC SP_GET_LAV_DET @FEC_INI, @FEC_FIN, @BUS_PTI, @BUS_EST, @BUS_CET, @BUS_DEN, @BUS_SEC, @BUS_REU_ID, @BUS_TPROT",
                    new SqlParameter("@FEC_INI", fecIni),
                    new SqlParameter("@FEC_FIN", fecFin),
                    new SqlParameter("@BUS_PTI", (object?)pti ?? ""),
                    new SqlParameter("@BUS_EST", (object?)est ?? ""),
                    new SqlParameter("@BUS_CET", (object?)cet ?? ""),
                    new SqlParameter("@BUS_DEN", (object?)den ?? ""),
                    new SqlParameter("@BUS_SEC", (object?)sec ?? ""),
                    new SqlParameter("@BUS_REU_ID", (object?)reu ?? ""),
                    new SqlParameter("@BUS_TPROT", (object?)tprot ?? ""))
                .ToListAsync();
            //return await _context.Set<BusLavadoDetDto>()
            //    .FromSqlRaw("EXEC SP_GET_LAV_DET @BUS_FEC_INI, @BUS_FEC_FIN, @BUS_PRO_ID, @BUS_LAV_PTI, @BUS_EST, @BUS_LOT, @BUS_CET, @BUS_REU_ID, @BUS_DEN, @BUS_SEC, @BUS_TPROT",
            //        new SqlParameter("@BUS_FEC_INI", fecIni),
            //        new SqlParameter("@BUS_FEC_FIN", fecFin),
            //        new SqlParameter("@BUS_PRO_ID", DBNull.Value),
            //        new SqlParameter("@BUS_LAV_PTI", (object?)pti ?? DBNull.Value),
            //        new SqlParameter("@BUS_EST", (object?)est ?? DBNull.Value),
            //        new SqlParameter("@BUS_LOT", DBNull.Value),
            //        new SqlParameter("@BUS_CET", string.IsNullOrWhiteSpace(cet) ? DBNull.Value : cet),
            //        new SqlParameter("@BUS_REU_ID", (object?)reu ?? DBNull.Value),
            //        new SqlParameter("@BUS_DEN", (object?)den ?? DBNull.Value),
            //        new SqlParameter("@BUS_SEC", (object?)sec ?? DBNull.Value),
            //        new SqlParameter("@BUS_TPROT", (object?)tprot ?? DBNull.Value))
            //    .ToListAsync();
        }
    }
}