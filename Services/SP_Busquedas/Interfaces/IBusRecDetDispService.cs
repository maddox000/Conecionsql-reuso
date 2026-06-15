using System.Collections.Generic;
using System.Threading.Tasks;
using ConexionSql.Models.SP_Busquedas.SP_BusRecDetDisp;

namespace ConexionSql.Services.SP_Busquedas.Interfaces // Asegúrate de que esta carpeta exista y sea correcta
{
    public interface IBusRecDetDispService
    {
        /// <summary>
        /// Obtiene el listado de detalles de recepción disponibles por etapa.
        /// </summary>
        /// <param name="request">Filtros de búsqueda</param>
        /// <returns>Lista de resultados mapeados al DTO de respuesta</returns>
        Task<IEnumerable<BusRecDetDispResponse>> ObtenerListadoAsync(BusRecDetDispRequest request);
    }
}
