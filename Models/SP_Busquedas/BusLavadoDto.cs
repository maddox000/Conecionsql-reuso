using System;

namespace ConexionSql.Models.SP_Busquedas
{
    public class BusLavadoDto
    {
        // --- CABECERA ---
        public int TB_PRO_LAV_ID { get; set; }
        public DateTime TB_PRO_LAV_FEC { get; set; }
        public string? TB_PRO_LAV_PTI_DEN { get; set; }
        public string? TB_PRO_LAV_EST_DEN { get; set; }
        public string? TB_PRO_LAV_NUM { get; set; }

        public string? TB_PRO_IB_EQU_TEQ_DEN { get; set; }
        public string? TB_PRO_LAV_EQU_NUM { get; set; }

        // --- DETALLE (AGREGADO) ---
        public int? TB_PRO_LAV_DET_REC_DET_ID { get; set; }
        public string? TB_PRO_LAV_DET_REU_ID { get; set; }
        public string? TB_PRO_LAV_DET_IB_MAT_DEN { get; set; }
        public string? TB_PRO_LAV_DET_SEC_DES_DEN { get; set; }
        public string? TB_PRO_LAV_DET_PTEST { get; set; }
    }
}