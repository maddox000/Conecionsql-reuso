using ConexionSql.Models.SP_Busquedas;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace ConexionSql.Services.SP_Busquedas.Interfaces
{
    public interface IBusAcondicionadoService
    {
        Task<IEnumerable<BusAcondicionadoDetDto>> GetAcondicionadosAsync(
            DateTime? fecIni, DateTime? fecFin, string? cet, string? acoId,
            string? den, string? reuId, string? sec);
    }
}