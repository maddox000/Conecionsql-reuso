using ConexionSql.Models.SP_Busquedas;
using System;
using System.Collections.Generic;

namespace ConexionSql.Services.SP_Busquedas.Interfaces
{
    public interface IBus_EntDetService
    {
        List<Bus_EntDetDto> BuscarEntregas(
            int? BUS_CET,
            DateTime? FEC_INI,
            DateTime? FEC_FIN,
            string BUS_DEN,
            string BUS_SEC,
            string BUS_REU,
            string BUS_PAC,
            string BUS_PRO,
            string BUS_PROV,
            string BUS_REM);

        // --- ACÁ AGREGAMOS LA FIRMA DEL NUEVO MÉTODO ---
        List<string> GetSugerencias(string term, string campo, string tabla);
    }
}