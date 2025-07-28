using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexionSql.Models.Lavado
{
    [Table("TB_PRO_LAV_DET")]
    public class TbProLavDet
    {
        // TB_PRO_LAV_DET_ID
        [Key]
        [Column("TB_PRO_LAV_DET_ID")]
        public int TB_PRO_LAV_DET_ID { get; set; }

        // TB_PRO_LAV_DET_PC_LOG
        [Column("TB_PRO_LAV_DET_PC_LOG")]
        public string? TB_PRO_LAV_DET_PC_LOG { get; set; }

        // TB_PRO_LAV_DET_PC_USR
        [Column("TB_PRO_LAV_DET_PC_USR")]
        public string? TB_PRO_LAV_DET_PC_USR { get; set; }

        // TB_PRO_LAV_DET_PRO_LAV_ID
        [Column("TB_PRO_LAV_DET_PRO_LAV_ID")]
        public int? TB_PRO_LAV_DET_PRO_LAV_ID { get; set; }

        // TB_PRO_LAV_DET_PRO_LAV_FEC
        [Column("TB_PRO_LAV_DET_PRO_LAV_FEC")]
        public DateTime? TB_PRO_LAV_DET_PRO_LAV_FEC { get; set; }

        // TB_PRO_LAV_DET_PRO_LAV_HOR
        [Column("TB_PRO_LAV_DET_PRO_LAV_HOR")]
        public DateTime? TB_PRO_LAV_DET_PRO_LAV_HOR { get; set; }

        // TB_PRO_LAV_DET_REC_DET_ID
        [Column("TB_PRO_LAV_DET_REC_DET_ID")]
        public int? TB_PRO_LAV_DET_REC_DET_ID { get; set; }

        // TB_PRO_LAV_DET_SEC_DES_ID
        [Column("TB_PRO_LAV_DET_SEC_DES_ID")]
        public int? TB_PRO_LAV_DET_SEC_DES_ID { get; set; }

        // TB_PRO_LAV_DET_SEC_DES_DEN
        [Column("TB_PRO_LAV_DET_SEC_DES_DEN")]
        public string? TB_PRO_LAV_DET_SEC_DES_DEN { get; set; }

        // TB_PRO_LAV_DET_ORT_ID
        [Column("TB_PRO_LAV_DET_ORT_ID")]
        public int? TB_PRO_LAV_DET_ORT_ID { get; set; }

        // TB_PRO_LAV_DET_ORT_DEN
        [Column("TB_PRO_LAV_DET_ORT_DEN")]
        public string? TB_PRO_LAV_DET_ORT_DEN { get; set; }

        // TB_PRO_LAV_DET_PRO_ID
        [Column("TB_PRO_LAV_DET_PRO_ID")]
        public int? TB_PRO_LAV_DET_PRO_ID { get; set; }

        // TB_PRO_LAV_DET_ORT_PAC
        [Column("TB_PRO_LAV_DET_ORT_PAC")]
        public string? TB_PRO_LAV_DET_ORT_PAC { get; set; }

        // TB_PRO_LAV_DET_ORT_REM
        [Column("TB_PRO_LAV_DET_ORT_REM")]
        public string? TB_PRO_LAV_DET_ORT_REM { get; set; }

        // TB_PRO_LAV_DET_IB_MAT_ID
        [Column("TB_PRO_LAV_DET_IB_MAT_ID")]
        public int? TB_PRO_LAV_DET_IB_MAT_ID { get; set; }

        // TB_PRO_LAV_DET_IB_MAT_PR
        [Column("TB_PRO_LAV_DET_IB_MAT_PR")]
        public string? TB_PRO_LAV_DET_IB_MAT_PR { get; set; }

        // TB_PRO_LAV_DET_IB_MAT_DEN
        [Column("TB_PRO_LAV_DET_IB_MAT_DEN")]
        public string? TB_PRO_LAV_DET_IB_MAT_DEN { get; set; }

        // TB_PRO_LAV_DET_REU_ID
        [Column("TB_PRO_LAV_DET_REU_ID")]
        public string? TB_PRO_LAV_DET_REU_ID { get; set; }

        // TB_PRO_LAV_DET_IB_MAT_MAR_ID
        [Column("TB_PRO_LAV_DET_IB_MAT_MAR_ID")]
        public int? TB_PRO_LAV_DET_IB_MAT_MAR_ID { get; set; }

        // TB_PRO_LAV_DET_IB_MAT_MAR_DEN
        [Column("TB_PRO_LAV_DET_IB_MAT_MAR_DEN")]
        public string? TB_PRO_LAV_DET_IB_MAT_MAR_DEN { get; set; }

        // TB_PRO_LAV_DET_IB_MAT_MAR_CAT
        [Column("TB_PRO_LAV_DET_IB_MAT_MAR_CAT")]
        public string? TB_PRO_LAV_DET_IB_MAT_MAR_CAT { get; set; }

        // TB_PRO_LAV_DET_IB_MAT_PRI_OPC
        [Column("TB_PRO_LAV_DET_IB_MAT_PRI_OPC")]
        public bool TB_PRO_LAV_DET_IB_MAT_PRI_OPC { get; set; }

        // TB_PRO_LAV_DET_IB_MAT_CON_REG
        [Column("TB_PRO_LAV_DET_IB_MAT_CON_REG")]
        public int? TB_PRO_LAV_DET_IB_MAT_CON_REG { get; set; }

        // TB_PRO_LAV_DET_IB_MAT_CON_ACT
        [Column("TB_PRO_LAV_DET_IB_MAT_CON_ACT")]
        public int? TB_PRO_LAV_DET_IB_MAT_CON_ACT { get; set; }

        // TB_PRO_LAV_DET_IB_MAT_ACO_SUP
        [Column("TB_PRO_LAV_DET_IB_MAT_ACO_SUP")]
        public bool TB_PRO_LAV_DET_IB_MAT_ACO_SUP { get; set; }

        // TB_PRO_LAV_DET_REC_DET_CANT
        [Column("TB_PRO_LAV_DET_REC_DET_CANT")]
        public int? TB_PRO_LAV_DET_REC_DET_CANT { get; set; }

        // TB_PRO_LAV_DET_REC_CANT
        [Column("TB_PRO_LAV_DET_REC_CANT")]
        public int? TB_PRO_LAV_DET_REC_CANT { get; set; }

        // TB_PRO_LAV_DET_VOL_MAT
        [Column("TB_PRO_LAV_DET_VOL_MAT")]
        public int? TB_PRO_LAV_DET_VOL_MAT { get; set; }

        // TB_PRO_LAV_DET_VOL_PRO
        [Column("TB_PRO_LAV_DET_VOL_PRO")]
        public int? TB_PRO_LAV_DET_VOL_PRO { get; set; }

        // TB_PRO_LAV_DET_STOCK
        [Column("TB_PRO_LAV_DET_STOCK")]
        public int? TB_PRO_LAV_DET_STOCK { get; set; }

        // TB_PRO_LAV_DET_CANT
        [Column("TB_PRO_LAV_DET_CANT")]
        public int? TB_PRO_LAV_DET_CANT { get; set; }

        // TB_PRO_LAV_DET_TOT
        [Column("TB_PRO_LAV_DET_TOT")]
        public int? TB_PRO_LAV_DET_TOT { get; set; }

        // TB_PRO_LAV_DET_UBIE_ID
        [Column("TB_PRO_LAV_DET_UBIE_ID")]
        public int? TB_PRO_LAV_DET_UBIE_ID { get; set; }

        // TB_PRO_LAV_DET_UBIE_DEN
        [Column("TB_PRO_LAV_DET_UBIE_DEN")]
        public string? TB_PRO_LAV_DET_UBIE_DEN { get; set; }

        // TB_PRO_LAV_DET_REPRO
        [Column("TB_PRO_LAV_DET_REPRO")]
        public bool TB_PRO_LAV_DET_REPRO { get; set; }

        // TB_PRO_LAV_DET_EST_ID
        [Column("TB_PRO_LAV_DET_EST_ID")]
        public int? TB_PRO_LAV_DET_EST_ID { get; set; }

        // TB_PRO_LAV_DET_EST_DEN
        [Column("TB_PRO_LAV_DET_EST_DEN")]
        public string? TB_PRO_LAV_DET_EST_DEN { get; set; }

        // TB_PRO_LAV_DET_EST_FEC
        [Column("TB_PRO_LAV_DET_EST_FEC")]
        public DateTime? TB_PRO_LAV_DET_EST_FEC { get; set; }

        // TB_PRO_LAV_DET_NUM_1
        [Column("TB_PRO_LAV_DET_NUM_1")]
        public int? TB_PRO_LAV_DET_NUM_1 { get; set; }

        // TB_PRO_LAV_DET_NUM_2
        [Column("TB_PRO_LAV_DET_NUM_2")]
        public int? TB_PRO_LAV_DET_NUM_2 { get; set; }

        // TB_PRO_LAV_DET_NUM_3
        [Column("TB_PRO_LAV_DET_NUM_3")]
        public int? TB_PRO_LAV_DET_NUM_3 { get; set; }

        // TB_PRO_LAV_DET_TXT_1
        [Column("TB_PRO_LAV_DET_TXT_1")]
        public string? TB_PRO_LAV_DET_TXT_1 { get; set; }

        // TB_PRO_LAV_DET_TXT_2
        [Column("TB_PRO_LAV_DET_TXT_2")]
        public string? TB_PRO_LAV_DET_TXT_2 { get; set; }

        // TB_PRO_LAV_DET_TXT_3
        [Column("TB_PRO_LAV_DET_TXT_3")]
        public string? TB_PRO_LAV_DET_TXT_3 { get; set; }

        // TB_PRO_LAV_DET_DTI_1
        [Column("TB_PRO_LAV_DET_DTI_1")]
        public DateTime? TB_PRO_LAV_DET_DTI_1 { get; set; }

        // TB_PRO_LAV_DET_DTI_2
        [Column("TB_PRO_LAV_DET_DTI_2")]
        public DateTime? TB_PRO_LAV_DET_DTI_2 { get; set; }

        // TB_PRO_LAV_DET_DTI_3
        [Column("TB_PRO_LAV_DET_DTI_3")]
        public DateTime? TB_PRO_LAV_DET_DTI_3 { get; set; }

        // TB_PRO_LAV_DET_MEM_1
        [Column("TB_PRO_LAV_DET_MEM_1")]
        public string? TB_PRO_LAV_DET_MEM_1 { get; set; }

        // TB_PRO_LAV_DET_MEM_2
        [Column("TB_PRO_LAV_DET_MEM_2")]
        public string? TB_PRO_LAV_DET_MEM_2 { get; set; }

        // TB_PRO_LAV_DET_MEM_3
        [Column("TB_PRO_LAV_DET_MEM_3")]
        public string? TB_PRO_LAV_DET_MEM_3 { get; set; }

        // TB_PRO_LAV_DET_LMAT
        [Column("TB_PRO_LAV_DET_LMAT")]
        public int? TB_PRO_LAV_DET_LMAT { get; set; }

        // TB_PRO_LAV_DET_CANT_MULT
        [Column("TB_PRO_LAV_DET_CANT_MULT")]
        public int? TB_PRO_LAV_DET_CANT_MULT { get; set; }

        // TB_PRO_LAV_DET_CANT_ELIM
        [Column("TB_PRO_LAV_DET_CANT_ELIM")]
        public int? TB_PRO_LAV_DET_CANT_ELIM { get; set; }

        // TB_PRO_LAV_DET_DAT
        [Column("TB_PRO_LAV_DET_DAT")]
        public string? TB_PRO_LAV_DET_DAT { get; set; }
    }
}
