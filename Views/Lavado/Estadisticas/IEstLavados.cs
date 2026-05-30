using System;
using System.Data;
using System.Threading.Tasks;

namespace ConexionSql.Views.Lavado.Estadisticas
{
    public interface IEstLavados
    {
        // Contrato para pedir los datos al SP_EstadisticaLavados
        Task<DataTable> GetEstadisticaLavadosAsync(DateTime fechaDesde, DateTime fechaHasta, int? estadoId, string equipo, int? cicloId);
    }
}
