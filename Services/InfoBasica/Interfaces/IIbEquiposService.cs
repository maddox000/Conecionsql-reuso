using ConexionSql.Models.InfoBasica;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConexionSql.Services.InfoBasica.Interfaces
{
    public interface IIbEquiposService
    {
        Task<IEnumerable<IbEquTeqDto>> ObtenerTiposEquipoAsync();
        Task<IEnumerable<IbEquMarDto>> ObtenerMarcasAsync();
        Task<IEnumerable<IbProTciDto>> ObtenerTiposCicloAsync();
        Task<bool> GuardarEquipoAsync(IbEquDto equipo);

        // --- NUEVO MÉTODO PARA EDITAR ---
        Task<IbEquDto?> ObtenerEquipoPorIdAsync(int id);

        Task<IEnumerable<IbEquGrillaDto>> ObtenerTodosAsync();
    }
}