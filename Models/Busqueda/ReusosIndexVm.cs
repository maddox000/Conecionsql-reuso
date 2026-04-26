using System.Collections.Generic;

namespace ConexionSql.Models.Busqueda
{
    public class ReusosIndexVm
    {
        public string CodigoReuso { get; set; } = string.Empty;
        public string Denominacion { get; set; } = string.Empty;
        public string Sector { get; set; } = string.Empty;
        public bool DataUnavailable { get; set; }
        public List<ReusoResumenVm> Reusos { get; set; } = new();
        public List<TrazabilidadEventoVm> Historial { get; set; } = new();
        public ReusoDetalleVm? DetalleSeleccionado { get; set; }
    }
}
