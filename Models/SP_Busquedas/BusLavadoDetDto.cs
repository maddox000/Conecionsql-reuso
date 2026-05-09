using System;

namespace ConexionSql.Models.SP_Busquedas
{
    public class BusLavadoDetDto
    {
        // --- Datos de la Cabecera de Lavado ---
        public int TB_PRO_LAV_ID { get; set; }
        public DateTime TB_PRO_LAV_FEC { get; set; }
        public string TB_PRO_LAV_PTI_DEN { get; set; }
        public string TB_PRO_LAV_EST { get; set; }
        public string TB_PRO_LAV_NUM { get; set; }

        // --- Datos del Detalle de Recepción ---
        public int TB_REC_DET_ID { get; set; }
        public string TB_REC_DET_MAT_DEN { get; set; }
        public string TB_REC_DET_REU_ID { get; set; }

        // --- Datos del Detalle de Lavado ---
        public int TB_PRO_LAV_DET_CANT { get; set; }
        public string TB_PRO_LAV_DET_MAT_DEN { get; set; }
        public string TB_PRO_LAV_DET_SEC_ID { get; set; }
        public string TB_PRO_LAV_DET_REU_ID { get; set; }
        public string TB_PRO_LAV_DET_PTEST { get; set; }

        // --- Helpers de Formato ---
        public string FechaStr => TB_PRO_LAV_FEC.ToString("dd/MM/yyyy");
        public string HoraStr => TB_PRO_LAV_FEC.ToString("HH:mm");
    }
}
