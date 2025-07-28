using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexionSql.Models.Acondicionado
{
    [Table("TB_PRO_ACO_DET")]
    public class TbProAcoDet
    {
        // TB_PRO_ACO_DET_ID
        [Key]
        [Column("TB_PRO_ACO_DET_ID")]
        public int TbProAcoDetId { get; set; }

        // TB_PRO_ACO_DET_HOR
        [Column("TB_PRO_ACO_DET_HOR")]
        public DateTime? TbProAcoDetHor { get; set; }

        // TB_PRO_ACO_DET_PC_LOG
        [Column("TB_PRO_ACO_DET_PC_LOG")]
        public string? TbProAcoDetPcLog { get; set; }

        // TB_PRO_ACO_DET_PC_USR
        [Column("TB_PRO_ACO_DET_PC_USR")]
        public string? TbProAcoDetPcUsr { get; set; }

        // TB_PRO_ACO_DET_ACO_ID
        [Column("TB_PRO_ACO_DET_ACO_ID")]
        public int? TbProAcoDetAcoId { get; set; }

        // TB_PRO_ACO_DET_REC_DET_ID
        [Column("TB_PRO_ACO_DET_REC_DET_ID")]
        public int? TbProAcoDetRecDetId { get; set; }

        // TB_PRO_ACO_DET_MAT_ID
        [Column("TB_PRO_ACO_DET_MAT_ID")]
        public int? TbProAcoDetMatId { get; set; }

        // TB_PRO_ACO_DET_MAT_DEN
        [Column("TB_PRO_ACO_DET_MAT_DEN")]
        public string? TbProAcoDetMatDen { get; set; }

        // TB_PRO_ACO_DET_MAT_MTI_ID
        [Column("TB_PRO_ACO_DET_MAT_MTI_ID")]
        public int? TbProAcoDetMatMtiId { get; set; }

        // TB_PRO_ACO_DET_MAT_MTI_DEN
        [Column("TB_PRO_ACO_DET_MAT_MTI_DEN")]
        public string? TbProAcoDetMatMtiDen { get; set; }

        // TB_PRO_ACO_DET_MAT_ETI_ID
        [Column("TB_PRO_ACO_DET_MAT_ETI_ID")]
        public int? TbProAcoDetMatEtiId { get; set; }

        // TB_PRO_ACO_DET_MAT_ETI_DEN
        [Column("TB_PRO_ACO_DET_MAT_ETI_DEN")]
        public string? TbProAcoDetMatEtiDen { get; set; }

        // TB_PRO_ACO_DET_REC_DET_CANT
        [Column("TB_PRO_ACO_DET_REC_DET_CANT")]
        public int? TbProAcoDetRecDetCant { get; set; }

        // TB_PRO_ACO_DET_EMP_STOCK
        [Column("TB_PRO_ACO_DET_EMP_STOCK")]
        public int? TbProAcoDetEmpStock { get; set; }

        // TB_PRO_ACO_DET_EMP_CANT
        [Column("TB_PRO_ACO_DET_EMP_CANT")]
        public int? TbProAcoDetEmpCant { get; set; }

        // TB_PRO_ACO_DET_EMP_TOT
        [Column("TB_PRO_ACO_DET_EMP_TOT")]
        public int? TbProAcoDetEmpTot { get; set; }

        // TB_PRO_ACO_DET_PRO_STOCK
        [Column("TB_PRO_ACO_DET_PRO_STOCK")]
        public int? TbProAcoDetProStock { get; set; }

        // TB_PRO_ACO_DET_REU_ID
        [Column("TB_PRO_ACO_DET_REU_ID")]
        public string? TbProAcoDetReuId { get; set; }

        // TB_PRO_ACO_DET_CANT
        [Column("TB_PRO_ACO_DET_CANT")]
        public int? TbProAcoDetCant { get; set; }

        // TB_PRO_ACO_DET_SEC_DES_ID
        [Column("TB_PRO_ACO_DET_SEC_DES_ID")]
        public int? TbProAcoDetSecDesId { get; set; }

        // TB_PRO_ACO_DET_SEC_DES_DEN
        [Column("TB_PRO_ACO_DET_SEC_DES_DEN")]
        public string? TbProAcoDetSecDesDen { get; set; }

        // TB_PRO_ACO_DET_SEC_ORI_ID
        [Column("TB_PRO_ACO_DET_SEC_ORI_ID")]
        public int? TbProAcoDetSecOriId { get; set; }

        // TB_PRO_ACO_DET_SEC_ORI_DEN
        [Column("TB_PRO_ACO_DET_SEC_ORI_DEN")]
        public string? TbProAcoDetSecOriDen { get; set; }

        // TB_PRO_ACO_DET_MAT_VOL
        [Column("TB_PRO_ACO_DET_MAT_VOL")]
        public int? TbProAcoDetMatVol { get; set; }

        // TB_PRO_ACO_DET_NUM_1
        [Column("TB_PRO_ACO_DET_NUM_1")]
        public int? TbProAcoDetNum1 { get; set; }

        // TB_PRO_ACO_DET_NUM_2
        [Column("TB_PRO_ACO_DET_NUM_2")]
        public int? TbProAcoDetNum2 { get; set; }

        // TB_PRO_ACO_DET_NUM_3
        [Column("TB_PRO_ACO_DET_NUM_3")]
        public int? TbProAcoDetNum3 { get; set; }

        // TB_PRO_ACO_DET_TXT_1
        [Column("TB_PRO_ACO_DET_TXT_1")]
        public string? TbProAcoDetTxt1 { get; set; }

        // TB_PRO_ACO_DET_TXT_2
        [Column("TB_PRO_ACO_DET_TXT_2")]
        public string? TbProAcoDetTxt2 { get; set; }

        // TB_PRO_ACO_DET_TXT_3
        [Column("TB_PRO_ACO_DET_TXT_3")]
        public string? TbProAcoDetTxt3 { get; set; }

        // TB_PRO_ACO_DET_DTI_1
        [Column("TB_PRO_ACO_DET_DTI_1")]
        public DateTime? TbProAcoDetDti1 { get; set; }

        // TB_PRO_ACO_DET_DTI_2
        [Column("TB_PRO_ACO_DET_DTI_2")]
        public DateTime? TbProAcoDetDti2 { get; set; }

        // TB_PRO_ACO_DET_DTI_3
        [Column("TB_PRO_ACO_DET_DTI_3")]
        public DateTime? TbProAcoDetDti3 { get; set; }

        // TB_PRO_ACO_DET_MEM_1
        [Column("TB_PRO_ACO_DET_MEM_1")]
        public string? TbProAcoDetMem1 { get; set; }

        // TB_PRO_ACO_DET_MEM_2
        [Column("TB_PRO_ACO_DET_MEM_2")]
        public string? TbProAcoDetMem2 { get; set; }

        // TB_PRO_ACO_DET_MEM_3
        [Column("TB_PRO_ACO_DET_MEM_3")]
        public string? TbProAcoDetMem3 { get; set; }

        // TB_PRO_ACO_DET_CANT_MULT
        [Column("TB_PRO_ACO_DET_CANT_MULT")]
        public int? TbProAcoDetCantMult { get; set; }

        // TB_PRO_ACO_DET_CANT_ELIM
        [Column("TB_PRO_ACO_DET_CANT_ELIM")]
        public int? TbProAcoDetCantElim { get; set; }

        // TB_PRO_ACO_DET_DAT
        [Column("TB_PRO_ACO_DET_DAT")]
        public string? TbProAcoDetDat { get; set; }
    }
}
