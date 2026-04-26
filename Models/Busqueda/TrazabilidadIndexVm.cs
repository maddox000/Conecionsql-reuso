using System;
using System.Collections.Generic;

namespace ConexionSql.Models.Busqueda
{
    public class TrazabilidadIndexVm
    {
        public string Denominacion { get; set; } = string.Empty;
        public int? CodigoEtiqueta { get; set; }
        public string CodigoReuso { get; set; } = string.Empty;
        public DateTime FechaDesde { get; set; } = DateTime.Today.AddDays(-10);
        public DateTime FechaHasta { get; set; } = DateTime.Today;
        public bool DataUnavailable { get; set; }
        public List<TrazabilidadEventoVm> Eventos { get; set; } = new();
    }
}
