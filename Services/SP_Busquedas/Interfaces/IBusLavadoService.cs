using ConexionSql.Models.SP_Busquedas;
using System;
using System.Collections.Generic;

namespace ConexionSql.Interfaces
{
    public interface IBusLavadoService
    {
        List<BusLavadoDto> GetLavados(DateTime BUS_FEC_INI, DateTime BUS_FEC_FIN, string BUS_PTI,
                                      string BUS_EST, string BUS_LOT, string BUS_EQU_TEQ, string BUS_EQU_NUM);
    }
}