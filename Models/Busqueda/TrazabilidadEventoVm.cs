using System;

namespace ConexionSql.Models.Busqueda
{
    public class TrazabilidadEventoVm
    {
        public int CodigoEtiqueta { get; set; }
        public string CodigoReuso { get; set; } = string.Empty;
        public string TipoRegistro { get; set; } = string.Empty;
        public int NumeroProcedimiento { get; set; }
        public DateTime FechaHora { get; set; }
        public string Personal { get; set; } = string.Empty;
        public string Denominacion { get; set; } = string.Empty;
        public string Sector { get; set; } = string.Empty;
        public string Paciente { get; set; } = string.Empty;
    }
}
