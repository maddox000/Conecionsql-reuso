using ConexionSql.Models.SP_Busquedas;
using System;
using System.Collections.Generic;

namespace ConexionSql.Services.SP_Busquedas.Interfaces
{
    public interface IBusAcoService
    {
        List<BusAcoDto> GetAcondicionados(
            DateTime BUS_FEC_INI,
            DateTime BUS_FEC_FIN,
            string BUS_CET,
            string BUS_ACO_ID,
            string BUS_DEN,
            string BUS_REU_ID,
            string BUS_SEC
        );
    }
}

