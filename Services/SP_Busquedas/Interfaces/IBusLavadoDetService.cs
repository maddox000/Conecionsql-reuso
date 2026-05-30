

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConexionSql.Models.SP_Busquedas;

namespace ConexionSql.Services.SP_Busquedas.Interfaces
{
    public interface IBusLavadoDetService
    {
        Task<IEnumerable<BusLavadoDetDto>> GetLavadoDetalleAsync(

            DateTime fecIni,
            DateTime fecFin,
            string pti = "",
            string est = "",
            string cet = "",
            string den = "",
            string sec = "",
            string reu = "",
            string tprot = "");


    }
}
