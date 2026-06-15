using System;

namespace ConexionSql.Models.SP_Busquedas.SP_BusRecDetDisp
{
    public class BusRecDetDispRequest
    {
        public DateTime? BusFecIni { get; set; }
        public DateTime? BusFecFin { get; set; }
        public string? BusSecOriDen { get; set; }
        public string? BusSecDesDen { get; set; }
        public string? BusDeno { get; set; }
        public string? BusCet { get; set; }
        public string? BusEtapa { get; set; }
        public int? BusMatMtiId { get; set; }
    }

    public class BusRecDetDispResponse
    {
        public string? CodigoEtiqueta { get; set; }
        public string? Denominacion { get; set; }
        public string? SectorOrigen { get; set; }
        public string? SectorDestino { get; set; }
        public int Recibidos { get; set; }
        public int Lavado { get; set; }
        public int Desinfeccion { get; set; }
        public int Traslado { get; set; }
        public int Acondicionado { get; set; }
        public int Esterilizado { get; set; }
        public int Entrega { get; set; }
    }
}
