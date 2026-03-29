namespace ConexionSql.Models.Lavado
{
    public class TbProLavDto
    {
        public int? TbProLavId { get; set; } // ID del proceso de lavado
        public int? TbProLavNum1 { get; set; } // Nro de lote

        public DateTime? TbProLavFec { get; set; } // Fecha del proceso
        public DateTime? TbProLavHorIni { get; set; } // Hora inicio del proceso
        public DateTime? TbProLavHorFin { get; set; } // Hora fin del proceso

        public int? TbProLavPtiId { get; set; } // ID tipo de lavado
        public string? TbProLavPtiDen { get; set; } // Tipo de proceso / lavado

        public int? TbProLavEquId { get; set; } // ID equipo
        public string? TbProLavEquDen { get; set; } // Equipo

        public int? TbProLavTciId { get; set; } // ID tipo de ciclo
        public string? TbProLavTciDen { get; set; } // Tipo de ciclo

        public string? TbProLavEstDen { get; set; } // Estado del proceso
        public int? TbProLavCant { get; set; } // Cantidad de unidades
    }
}
