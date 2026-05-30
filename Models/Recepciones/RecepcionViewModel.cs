using System;

namespace ConexionSql.Models
{
    public class RecepcionViewModel
    {
        public int TB_REC_ID { get; set; }
        public DateTime TB_REC_FEC { get; set; }
        public string TB_REC_HOR_INI { get; set; }
        public string TB_REC_HOR_FIN { get; set; }
        public string TB_REC_SEC_ORI_DEN { get; set; }
        public string TB_REC_SEC_DES_DEN { get; set; }
        public string TB_REC_MDE { get; set; }
        public string TB_REC_MCO { get; set; }
    }
}
