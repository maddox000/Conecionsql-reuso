using System;

namespace ConexionSql.Models.SP_Busquedas
{
    public class BusLavadoDetDto
    {
        // Cabecera
        public int? TB_PRO_LAV_ID { get; set; }
        public DateTime? TB_PRO_LAV_FEC { get; set; }
        public string? TB_PRO_LAV_PTI_DEN { get; set; }
        public string? TB_PRO_LAV_EST_DEN { get; set; }
        public int? TB_PRO_LAV_NUM { get; set; }

        // Recepción
        public int? TB_REC_DET_ID { get; set; }
        public string? TB_REC_DET_MAT_DEN { get; set; }
        public string? TB_REC_DET_REU_ID { get; set; }

        // Lavado detalle
        public int? TB_PRO_LAV_DET_CANT { get; set; }
        public string? TB_PRO_LAV_DET_IB_MAT_DEN { get; set; }
        public int? TB_PRO_LAV_DET_SEC_DES_ID { get; set; }
        public string? TB_PRO_LAV_DET_REU_ID { get; set; }
        public string? TB_PRO_LAV_DET_PTEST { get; set; }

        public string FechaStr =>
            TB_PRO_LAV_FEC?.ToString("dd/MM/yyyy") ?? "";

        public string HoraStr =>
            TB_PRO_LAV_FEC?.ToString("HH:mm") ?? "";
    }
}