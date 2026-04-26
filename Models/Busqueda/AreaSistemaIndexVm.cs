using System.Collections.Generic;

namespace ConexionSql.Models.Busqueda
{
    public class AreaSistemaIndexVm
    {
        public string TipoSeleccionado { get; set; } = "personal";
        public string Titulo { get; set; } = "Area de sistema";
        public string ColumnaPrincipal { get; set; } = "Nombre";
        public string ColumnaSecundaria { get; set; } = "Detalle";
        public string ColumnaTerciaria { get; set; } = "Estado";
        public string ColumnaCuarta { get; set; } = "";
        public string ColumnaQuinta { get; set; } = "";
        public string MensajeSinDatos { get; set; } = "No hay datos disponibles.";
        public List<AreaSistemaKpiVm> Kpis { get; set; } = new();
        public List<AreaSistemaActionVm> Acciones { get; set; } = new();
        public List<AreaSistemaRowVm> Filas { get; set; } = new();
        public string SiguienteCodigoProducto { get; set; } = "";
    }

    public class AreaSistemaKpiVm
    {
        public string Etiqueta { get; set; } = string.Empty;
        public int Valor { get; set; }
    }

    public class AreaSistemaActionVm
    {
        public string Texto { get; set; } = string.Empty;
        public string Href { get; set; } = "#";
        public string CssClass { get; set; } = "btn btn-outline-primary btn-sm";
    }

    public class AreaSistemaRowVm
    {
        public string Id { get; set; } = "-";
        public string CodigoProducto { get; set; } = "-";
        public string Principal { get; set; } = "-";
        public string Secundaria { get; set; } = "-";
        public string Terciaria { get; set; } = "-";
        public string UbicacionFisica { get; set; } = "-";
        public string Contenido { get; set; } = "-";
        public string NumeroSerie { get; set; } = "-";
        public string SectorEntrega { get; set; } = "-";
        public string SectorDestino { get; set; } = "-";
        public bool Controlado { get; set; }
        public bool Ocultar { get; set; }
        public bool Trasladados { get; set; }
    }
}