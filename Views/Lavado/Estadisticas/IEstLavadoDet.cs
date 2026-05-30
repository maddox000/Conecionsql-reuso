using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConexionSql.Interfaces.Lavado
{
    public interface IEstLavadoDet
    {
        Task<List<Dictionary<string, object>>> ObtenerDatosMensualesAsync(
            DateTime desde,
            DateTime hasta,
            string estado,
            string lote,
            string codProd,
            string reuId,
            string den,
            string equipo,
            bool? ctrlLav,
            bool? ctrlProt);
    }
}