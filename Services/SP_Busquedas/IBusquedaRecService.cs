using ConexionSql.Models.SP_Busquedas;
using System;
using System.Collections.Generic;

namespace ConexionSql.Services.SP_Busquedas.Interfaces
{
    public interface IBusquedaRecService
    {
        List<RecBusquedaDto> BuscarRec(
            DateTime? FEC_INI, DateTime? FEC_FIN, string BUS_SEC_ORI,
            string BUS_SEC_DES, string BUS_ORT_DEN, string BUS_DEN,
            string BUS_PR, string BUS_REU_ID, string BUS_PAC,
            string BUS_PRO, string BUS_REM, DateTime? BUS_FEN);

        List<string> ObtenerSugerencias(string term, string campo, string tabla);
    }
}