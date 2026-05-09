using System;

namespace ConexionSql.Models.SP_Busquedas
{
    public class BusAcoDto
    {
        // Datos de la Cabecera de Acondicionado
        public int TB_PRO_ACO_ID { get; set; }
        public DateTime? TB_PRO_ACO_FEC { get; set; }
        public string TB_PRO_ACO_HOR_INI { get; set; }
        public string TB_PRO_ACO_UPRO { get; set; }

        // Datos del Detalle de Recepción relacionado
        public int? TB_REC_DET_ID { get; set; }
        public string TB_REC_DET_MAT_DEN { get; set; }
        public string TB_REC_DET_REU_ID { get; set; }
        public int? TB_REC_DET_REU_CANT { get; set; }
        public bool? TB_REC_DET_REU_OPC { get; set; }
        public int? TB_REC_DET_MAT_ID { get; set; }

        // Datos del Detalle de Acondicionado
        public int? TB_PRO_ACO_DET_CANT { get; set; }

        // Datos de Sector / Ubicación
        public int? TB_REC_SEC_DES_ID { get; set; }
        public string TB_REC_SEC_DES_DEN { get; set; }
    }
}
