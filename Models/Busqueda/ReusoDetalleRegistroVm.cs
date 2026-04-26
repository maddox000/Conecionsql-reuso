using System;

namespace ConexionSql.Models.Busqueda
{
    public class ReusoDetalleRegistroVm
    {
        public int CodigoEtiqueta { get; set; }
        public int NumeroProcedimiento { get; set; }
        public DateTime FechaHora { get; set; }
        public string Paciente { get; set; } = string.Empty;
        public string HistoriaClinica { get; set; } = string.Empty;
        public string Sector { get; set; } = string.Empty;
        public string CodigoReuso { get; set; } = string.Empty;
    }
}