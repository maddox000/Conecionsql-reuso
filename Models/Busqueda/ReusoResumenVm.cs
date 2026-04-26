using System;

namespace ConexionSql.Models.Busqueda
{
    public class ReusoResumenVm
    {
        public string CodigoReuso { get; set; } = string.Empty;
        public string Denominacion { get; set; } = string.Empty;
        public string TipoMaterial { get; set; } = string.Empty;
        public string Sector { get; set; } = string.Empty;
        public int ReusosPermitidos { get; set; }
        public int ReusosRegistrados { get; set; }
        public DateTime? UltimaFecha { get; set; }
    }
}
