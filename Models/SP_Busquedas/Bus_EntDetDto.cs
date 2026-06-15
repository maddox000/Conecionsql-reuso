using System;

namespace ConexionSql.Models.SP_Busquedas
{
    public class Bus_EntDetDto
    {
        // Filtros de Búsqueda
        public DateTime? FEC_INI { get; set; }
        public DateTime? FEC_FIN { get; set; }
        public string BUS_DEN { get; set; }
        public string BUS_SEC { get; set; }
        public string BUS_REU { get; set; }
        public int? BUS_CET { get; set; }

        // --- NUEVOS FILTROS ---
        public string BUS_PAC { get; set; }
        public string BUS_PRO { get; set; }
        public string BUS_PROV { get; set; }
        public string BUS_REM { get; set; }

        // Campos Principales de Identificación
        public int TB_ENT_ID { get; set; }
        public DateTime? TB_ENT_FEC { get; set; }
        public TimeSpan? TB_ENT_HOR_INI { get; set; }
        public TimeSpan? TB_ENT_HOR_FIN { get; set; }

        // Sector
        public int? TB_ENT_SEC_ID { get; set; }
        public string TB_ENT_SEC_DEN { get; set; }

        // Datos del Material Detalle
        public int? TB_ENT_DET_REC_DET_MAT_ID { get; set; }
        public string TB_ENT_DET_REC_DET_MAT_DEN { get; set; }
        public int? TB_ENT_DET_REC_DET_MAT_TIP_ID { get; set; }
        public string TB_ENT_DET_REC_DET_MAT_TIP_DEN { get; set; }
        public decimal? TB_ENT_DET_CANT { get; set; }
        public int? TB_ENT_DET_REC_DET_ID { get; set; }

        // Información Adicional (Paciente/Profesional/Reúso/Remito)
        public int? TB_ENT_DET_REC_DET_REU_ID { get; set; }
        public string TB_ENT_DET_REC_DET_PAC { get; set; }
        public int? TB_REC_DET_PRO_ID { get; set; }
        public string TB_REC_DET_PRO_NOM { get; set; }
        public string TB_REC_DET_REM { get; set; }
    }
}