using System;
using System.Collections.Generic;

namespace ConexionSql.Models.Busqueda
{
    public class EstadisticasIndexVm
    {
        public int? CodigoEtiqueta { get; set; }
        public int? CodigoReuso { get; set; }
        public int? NumeroProcedimiento { get; set; }
        public string Personal { get; set; } = string.Empty;
        public string FiltroValidationMessage { get; set; } = string.Empty;
        public DateTime FechaDesde { get; set; } = DateTime.Today.AddDays(-10);
        public DateTime FechaHasta { get; set; } = DateTime.Today;
        public bool DataUnavailable { get; set; }
        public List<TrazabilidadEventoVm> Registros { get; set; } = new();
    }
}