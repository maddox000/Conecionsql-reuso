using System;

namespace ConexionSql.Models.SP_Busquedas
{
    public class BusProDetDto
    {
        // Datos del Detalle (Materiales y Cantidades)
        public int TB_PRO_DET_REC_DET_ID { get; set; }
        public int TB_PRO_DET_REC_DET_MAT_ID { get; set; }
        public string TB_PRO_DET_REC_DET_MAT_DEN { get; set; }
        public int TB_PRO_DET_CANT { get; set; }
        public int? TB_PRO_DET_CANT_MULT { get; set; }
        public string TB_PRO_DET_TXT_3 { get; set; }

        // Datos del Sector
        public int? TB_REC_SEC_DES_ID { get; set; }
        public string TB_REC_SEC_DES_DEN { get; set; }

        // Datos de la Cabecera del Proceso
        public int TB_PRO_ID { get; set; }
        public DateTime? TB_PRO_FEC { get; set; }
        public string TB_PRO_HOR_INI { get; set; }
        public int TB_PRO_PTI_ID { get; set; }

        // Datos del Equipo
        public string TB_PRO_IB_EQU_TEQ_DEN { get; set; }
        public int TB_PRO_EQU_NUM { get; set; }
        public string TB_PRO_EQU_DEN { get; set; }
        public string TB_PRO_EQU_MAR_DEN { get; set; }
        public string TB_PRO_EQU_MOD { get; set; }
        public string TB_PRO_EQU_SER { get; set; }

        // Campo calculado en el SP
        public string EQUIPO { get; set; }
    }
}
