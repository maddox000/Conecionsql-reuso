using ConexionSql.Models.Recepciones;


namespace ConexionSql.Models.Recepciones.Ortopedias
{
    public class TbRecOrtDto
    {
        public TbRec? Cabecera { get; set; }
        public int? TB_REC_ORT_ID { get; set; }
        public int? TB_REC_ID { get; set; }

        public int? TB_REC_ORT_PER_ID { get; set; }
        public string? TB_REC_ORT_PER_NOM { get; set; }
        public string? TB_REC_ORT_PER_APE { get; set; }
        public int? TB_REC_ORT_PER_CAR_ID { get; set; }
        public string? TB_REC_ORT_PER_CAR_DEN { get; set; }

        public string? TB_REC_ORT_REG_PC_LOG { get; set; }
        public string? TB_REC_ORT_REG_PC_USR { get; set; }

        public DateTime? TB_REC_ORT_FEC { get; set; }
        public DateTime? TB_REC_ORT_HOR_INI { get; set; }
        public DateTime? TB_REC_ORT_HOR_FIN { get; set; }

        public int? TB_REC_ORT_UPRO { get; set; }

        public int? TB_REC_ORT_ORT_ID { get; set; }
        public string? TB_REC_ORT_ORT_DEN { get; set; }
        public string? TB_REC_ORT_ORT_PER { get; set; }

        public string? TB_REC_ORT_REM { get; set; }

        public int? TB_REC_ORT_PRO_ID { get; set; }
        public string? TB_REC_ORT_PRO_NOM { get; set; }
        public string? TB_REC_ORT_PRO_APE { get; set; }

        public string? TB_REC_ORT_PAC { get; set; }

        public DateTime? TB_REC_ORT_FEC_PROC { get; set; }
        public DateTime? TB_REC_ORT_HOR_PROC { get; set; }

        public string? TB_REC_ORT_OBS_REC { get; set; }

        public int? TB_REC_ORT_CANT_REC_CIN { get; set; }
        public int? TB_REC_ORT_CANT_REC_INS { get; set; }
        public int? TB_REC_ORT_CANT_REC_EST { get; set; }
        public int? TB_REC_ORT_CANT_REC_VS { get; set; }

        public int? TB_REC_ORT_CANT_REC { get; set; }

        public int? TB_REC_ORT_CANT_REC_CIN_CQ { get; set; }
        public int? TB_REC_ORT_CANT_REC_CIN_DEV { get; set; }

        public int? TB_REC_ORT_CANT_REC_INS_CQ { get; set; }
        public int? TB_REC_ORT_CANT_REC_INS_DEV { get; set; }

        public int? TB_REC_ORT_CANT_REC_EST_CQ { get; set; }
        public int? TB_REC_ORT_CANT_REC_EST_DEV { get; set; }

        public int? TB_REC_ORT_CANT_REC_VS_CQ { get; set; }
        public int? TB_REC_ORT_CANT_REC_VS_DEV { get; set; }

        public int? TB_REC_ORT_CANT_CQ { get; set; }
        public int? TB_REC_ORT_CANT_DEV { get; set; }

        public int? TB_REC_ORT_DEV_EST_EST { get; set; }

        public int? TB_REC_ORT_CANT_REC_CIN_DEV_EST { get; set; }
        public int? TB_REC_ORT_CANT_REC_INS_DEV_EST { get; set; }
        public int? TB_REC_ORT_CANT_REC_EST_DEV_EST { get; set; }
        public int? TB_REC_ORT_CANT_REC_VS_DEV_EST { get; set; }

        public int? TB_REC_ORT_CANT_DEV_EST { get; set; }

        public int? TB_REC_ORT_NUM_1 { get; set; }
        public int? TB_REC_ORT_NUM_2 { get; set; }
        public int? TB_REC_ORT_NUM_3 { get; set; }

        public string? TB_REC_ORT_TXT_1 { get; set; }
        public string? TB_REC_ORT_TXT_2 { get; set; }
        public string? TB_REC_ORT_TXT_3 { get; set; }

        public string? TB_REC_ORT_MEM_1 { get; set; }
        public string? TB_REC_ORT_MEM_2 { get; set; }
        public string? TB_REC_ORT_MEM_3 { get; set; }

        public int? TB_REC_ORT_PER_ID_DEV_EST { get; set; }
        public string? TB_REC_ORT_PER_NOM_DEV_EST { get; set; }
        public string? TB_REC_ORT_PER_APE_DEV_EST { get; set; }

        public int? TB_REC_ORT_PER_CAR_ID_DEV_EST { get; set; }
        public string? TB_REC_ORT_PER_CAR_DEN_DEV_EST { get; set; }

        public string? TB_REC_ORT_DEV_EST_PC_LOG { get; set; }
        public string? TB_REC_ORT_DEV_EST_PC_USR { get; set; }

        public string? TB_REC_ORT_ORT_PER_DEV_EST { get; set; }
    }
}