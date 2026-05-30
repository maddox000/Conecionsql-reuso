using ConexionSql.Models.Recepciones;

namespace ConexionSql.Models.Recepciones.Profesionales
{
    public class TbRecProfDto
    {
        public TbRec? Cabecera { get; set; }

        public int? TB_REC_ORT_ID { get; set; }
        public int? TB_REC_ID { get; set; }

        public DateTime? TB_REC_ORT_FEC { get; set; }
        public DateTime? TB_REC_ORT_HOR_INI { get; set; }
        public DateTime? TB_REC_ORT_HOR_FIN { get; set; }

        public int? TB_REC_ORT_PER_ID { get; set; }
        public string? TB_REC_ORT_PER_NOM { get; set; }
        public string? TB_REC_ORT_PER_APE { get; set; }
        public int? TB_REC_ORT_PER_CAR_ID { get; set; }
        public string? TB_REC_ORT_PER_CAR_DEN { get; set; }

        public string? TB_REC_ORT_REG_PC_LOG { get; set; }
        public string? TB_REC_ORT_REG_PC_USR { get; set; }

        public int? TB_REC_ORT_ORT_ID { get; set; }
        public string? TB_REC_ORT_ORT_DEN { get; set; }
        public string? TB_REC_ORT_ORT_PER { get; set; }

        public int? TB_REC_ORT_PRO_ID { get; set; }
        public string? TB_REC_ORT_PRO_NOM { get; set; }
        public string? TB_REC_ORT_PRO_APE { get; set; }

        public string? TB_REC_ORT_PAC { get; set; }

        public DateTime? TB_REC_ORT_FEC_PROC { get; set; }
        public DateTime? TB_REC_ORT_HOR_PROC { get; set; }

        public int? TB_REC_ORT_CANT_REC_CIN { get; set; }
        public int? TB_REC_ORT_CANT_REC_INS { get; set; }
        public int? TB_REC_ORT_CANT_REC_EST { get; set; }
        public int? TB_REC_ORT_CANT_REC_VS { get; set; }

        public int? TB_REC_ORT_CANT_REC { get; set; }
    }
}