using ConexionSql.Models.SP_Busquedas;
using System;
using System.Collections.Generic;

namespace ConexionSql.Services.SP_Busquedas.Interfaces
{
    public interface IRecDetService
    {
        List<RecDetBusquedaDto> BuscarRecDet(
            DateTime? BUS_FEC_INI, DateTime? BUS_FEC_FIN, string BUS_DEN,
            string BUS_SEC_ORI, string BUS_SEC_DES, string BUS_EST,
            string BUS_MAT_PR, string BUS_ORT_DEN, string BUS_PAC,
            string BUS_PRO, string BUS_REM, string BUS_REU_ID,
            DateTime? BUS_FEN, bool? BUS_ACAJ_OPC, bool? BUS_TRA_OPC,
            int? BUS_CET);

        List<string> ObtenerSugerencias(string term, string campo, string tabla);
    }
}