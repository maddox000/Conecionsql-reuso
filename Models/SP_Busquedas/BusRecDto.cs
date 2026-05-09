using System;

namespace ConexionSql.Models.SP_Busquedas
{
    public class BusRecDto
    {
        // Campos de identificación y tiempos
        public int TB_REC_ID { get; set; }
        public DateTime? TB_REC_FEC { get; set; }
        public string TB_REC_HOR_INI { get; set; }
        public string TB_REC_HOR_FIN { get; set; }

        // Sectores
        public string TB_REC_SEC_ORI_DEN { get; set; }
        public string TB_REC_SEC_DES_DEN { get; set; }

        // Datos de Orden y Referencia
        public string TB_REC_ORT_DEN { get; set; }
        public string TB_REC_OBS { get; set; }

        // Metadata / Campos adicionales del SELECT
        public string TB_REC_MDE { get; set; }
        public string TB_REC_MCO { get; set; }
    }
}
