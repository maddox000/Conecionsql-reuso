using ConexionSql.Models.SP_Busquedas;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        //// 1. Coincidir con los parámetros que espera el Controller
        //List<RecDetBusquedaDto> BuscarRecDet(
        //    DateTime? BUS_FEC_INI, DateTime? BUS_FEC_FIN, string BUS_DEN,
        //    string BUS_SEC_ORI, string BUS_SEC_DES, string BUS_EST,
        //    string BUS_MAT_PR, string BUS_ORT_DEN, string BUS_PAC,
        //    string BUS_PRO, string BUS_REM, string BUS_REU_ID,
        //    DateTime? BUS_FEN, bool? BUS_ACAJ_OPC, bool? BUS_TRA_OPC,
        //    int? BUS_CET);

        //// 2. Simplificar para que coincida con la llamada del Controller (CS1061)
        //List<string> ObtenerSugerencias(string term);

        // 3. Agregar el método que falta para que RecDetService no de error (CS0535)
        IEnumerable<object> GetRecolecciones(DateTime d1, DateTime d2, string s1, string s2, string s3, string s4, string s5);
  
    }
}