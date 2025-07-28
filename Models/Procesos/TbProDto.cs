namespace ConexionSql.Models.Procesos
{
    public class TbProDto
    {
        public int? TbProId { get; set; } // ID del proceso
        public int? TbProNum1 { get; set; } // Nro de lote
        public DateTime? TbProFec { get; set; } // Fecha
        public DateTime? TbProHorIni { get; set; } // Hora
        public string? TbProEquDen { get; set; } // Equipo
        public string? TbProTciDen { get; set; } // Tipo de ciclo
        public string? IbProEstDen { get; set; } // Estado del proceso
        public int? TbProCant { get; set; } // Cantidad de unidades
        public string? TbProPtiDen { get; set; } // Tipo de proceso
    }
}
