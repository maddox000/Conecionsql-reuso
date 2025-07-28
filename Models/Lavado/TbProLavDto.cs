namespace ConexionSql.Models.Lavado
{
    public class TbProLavDto
    {
        public int? TbProLavId { get; set; } // ID del proceso de lavado
        public int? TbProLavNum1 { get; set; } // Nro de lote
        public DateTime? TbProLavFec { get; set; } // Fecha
        public DateTime? TbProLavHorIni { get; set; } // Hora
        public string? TbProLavEquDen { get; set; } // Equipo
        public string? TbProLavTciDen { get; set; } // Tipo de ciclo
        public string? TbProLavEstDen { get; set; } // Estado del proceso
        public int? TbProLavCant { get; set; } // Cantidad de unidades
        public string? TbProLavPtiDen { get; set; } // Tipo de proceso
    }
}
