using ConexionSql.Models.SP_Busquedas;
using System;
using System.Collections.Generic;

namespace ConexionSql.Services.SP_Busquedas.Interfaces
{
    public interface IBusProService
    {
        List<BusProDto> GetProcesos(
            DateTime? FEC_INI,
            DateTime? FEC_FIN,
            string BUS_PTI_DEN,
            string BUS_EST_DEN
        );
    }
}
