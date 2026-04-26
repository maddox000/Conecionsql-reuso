using System;
using System.Collections.Generic;

namespace ConexionSql.Models.Busqueda
{
    public class ReusoDetalleVm
    {
        public string CodigoReuso { get; set; } = string.Empty;
        public string Usuario { get; set; } = string.Empty;
        public string Cargo { get; set; } = string.Empty;
        public DateTime? FechaHora { get; set; }
        public string Sector { get; set; } = string.Empty;
        public string CodigoProducto { get; set; } = string.Empty;
        public string Denominacion { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public string Identificacion { get; set; } = string.Empty;
        public string Fabricante { get; set; } = string.Empty;
        public string NumeroLote { get; set; } = string.Empty;
        public DateTime? Vencimiento { get; set; }
        public int ReusosPermitidos { get; set; }
        public int ReusosRegistrados { get; set; }
        public string Observaciones { get; set; } = string.Empty;
        public string UbicacionFisica { get; set; } = string.Empty;
        public DateTime? FechaRegistro { get; set; }
        public bool BajaProducto { get; set; }
        public DateTime? FechaBaja { get; set; }
        public string MotivoBaja { get; set; } = string.Empty;
        public string RealizadoPor { get; set; } = string.Empty;
        public List<ReusoDetalleRegistroVm> Registros { get; set; } = new();
    }
}