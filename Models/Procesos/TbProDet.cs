using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexionSql.Models.Procesos
{
    [Table("TB_PRO_DET")]
    public class TbProDet
    {
        [Column("TB_PRO_DET_ID")]
        public int TbProDetId { get; set; }

        [Column("TB_PRO_DET_PC_LOG")]
        public string? TbProDetPcLog { get; set; }

        [Column("TB_PRO_DET_PC_USR")]
        public string? TbProDetPcUsr { get; set; }

        [Column("TB_PRO_ID")]
        public int? TbProId { get; set; }

        [Column("TB_PRO_DET_REC_DET_ID")]
        public int? TbProDetRecDetId { get; set; }

        [Column("TB_PRO_DET_REC_DET_MAT_ID")]
        public int? TbProDetRecDetMatId { get; set; }

        [Column("TB_PRO_DET_REC_DET_MAT_DEN")]
        public string? TbProDetRecDetMatDen { get; set; }

        [Column("TB_PRO_DET_REC_DET_MAT_TIP_ID")]
        public int? TbProDetRecDetMatTipId { get; set; }

        [Column("TB_PRO_DET_REC_DET_MAT_TIP_DEN")]
        public string? TbProDetRecDetMatTipDen { get; set; }

        [Column("TB_PRO_DET_REC_DET_CANT")]
        public int? TbProDetRecDetCant { get; set; }

        [Column("TB_PRO_DET_REC_DET_PRO_STOCK")]
        public int? TbProDetRecDetProStock { get; set; }

        [Column("TB_PRO_DET_REC_DET_PRO_CANT")]
        public int? TbProDetRecDetProCant { get; set; }

        [Column("TB_PRO_DET_REC_DET_PRO_TOT")]
        public int? TbProDetRecDetProTot { get; set; }

        [Column("TB_PRO_DET_REC_ID")]
        public int? TbProDetRecId { get; set; }

        [Column("TB_PRO_DET_REC_DET_REU_ID")]
        public string? TbProDetRecDetReuId { get; set; }

        [Column("TB_PRO_DET_CANT")]
        public int? TbProDetCant { get; set; }

        [Column("TB_PRO_DET_CANT_CTRL")]
        public int? TbProDetCantCtrl { get; set; }

        [Column("TB_PRO_DET_CANT_ABO")]
        public int? TbProDetCantAbo { get; set; }

        [Column("TB_REC_SEC_DES_ID")]
        public int? TbRecSecDesId { get; set; }

        [Column("TB_REC_SEC_DES_DEN")]
        public string? TbRecSecDesDen { get; set; }

        [Column("TB_REC_ORT_ID")]
        public int? TbRecOrtId { get; set; }

        [Column("TB_REC_ORT_DEN")]
        public string? TbRecOrtDen { get; set; }

        [Column("TB_COD_TEX_LOT")]
        public string? TbCodTexLot { get; set; }

        [Column("TB_REC_SEC_ORI_ID")]
        public int? TbRecSecOriId { get; set; }

        [Column("TB_REC_SEC_ORI_DEN")]
        public string? TbRecSecOriDen { get; set; }

        [Column("IB_MAT_VOL")]
        public int? IbMatVol { get; set; }

        [Column("IB_EQU_CAP")]
        public int IbEquCap { get; set; }

        [Column("IB_EQU_CAPU")]
        public int? IbEquCapu { get; set; }

        [Column("IB_EQU_CAPR")]
        public int? IbEquCapr { get; set; }

        [Column("IB_EQU_PCO")]
        public int? IbEquPco { get; set; }

        [Column("IB_EQU_PVE")]
        public int? IbEquPve { get; set; }

        [Column("TB_PRO_PTI_ID")]
        public int? TbProPtiId { get; set; }

        [Column("TB_PRO_PTI_DEN")]
        public string? TbProPtiDen { get; set; }

        [Column("TB_PRO_EQU_ID")]
        public int? TbProEquId { get; set; }

        [Column("TB_PRO_IB_EQU_TEQ_ID")]
        public int? TbProIbEquTeqId { get; set; }

        [Column("TB_PRO_IB_EQU_TEQ_DEN")]
        public string? TbProIbEquTeqDen { get; set; }

        [Column("TB_PRO_EQU_NUM")]
        public int? TbProEquNum { get; set; }

        [Column("TB_PRO_EQU_DEN")]
        public string? TbProEquDen { get; set; }

        [Column("TB_PRO_EQU_MAR_ID")]
        public int? TbProEquMarId { get; set; }

        [Column("TB_PRO_EQU_MAR_DEN")]
        public string? TbProEquMarDen { get; set; }

        [Column("TB_PRO_EQU_MOD")]
        public string? TbProEquMod { get; set; }

        [Column("TB_PRO_EQU_SER")]
        public string? TbProEquSer { get; set; }

        [Column("TB_PRO_TCI_ID")]
        public int? TbProTciId { get; set; }

        [Column("TB_PRO_TCI_DEN")]
        public string? TbProTciDen { get; set; }

        [Column("TB_PRO_FEC")]
        public DateTime? TbProFec { get; set; }

        [Column("TB_PRO_DET_NUM_1")]
        public int? TbProDetNum1 { get; set; }

        [Column("TB_PRO_DET_NUM_2")]
        public int? TbProDetNum2 { get; set; }

        [Column("TB_PRO_DET_NUM_3")]
        public int? TbProDetNum3 { get; set; }

        [Column("TB_PRO_DET_TXT_1")]
        public string? TbProDetTxt1 { get; set; }

        [Column("TB_PRO_DET_TXT_2")]
        public string? TbProDetTxt2 { get; set; }

        [Column("TB_PRO_DET_TXT_3")]
        public string? TbProDetTxt3 { get; set; }

        [Column("TB_PRO_DET_DTI_1")]
        public DateTime? TbProDetDti1 { get; set; }

        [Column("TB_PRO_DET_DTI_2")]
        public DateTime? TbProDetDti2 { get; set; }

        [Column("TB_PRO_DET_DTI_3")]
        public DateTime? TbProDetDti3 { get; set; }

        [Column("TB_PRO_DET_MEM_1")]
        public string? TbProDetMem1 { get; set; }

        [Column("TB_PRO_DET_MEM_2")]
        public string? TbProDetMem2 { get; set; }

        [Column("TB_PRO_DET_MEM_3")]
        public string? TbProDetMem3 { get; set; }

        [Column("TB_PRO_DET_REPRO")]
        public bool TbProDetRepro { get; set; }

        [Column("TB_PRO_DET_EST_ID")]
        public int? TbProDetEstId { get; set; }

        [Column("TB_PRO_DET_EST_DEN")]
        public string? TbProDetEstDen { get; set; }

        [Column("TB_PRO_DET_EST_FEC")]
        public DateTime? TbProDetEstFec { get; set; }

        [Column("TB_PRO_DET_CANT_MULT")]
        public int? TbProDetCantMult { get; set; }

        [Column("TB_PRO_DET_CANT_ELIM")]
        public int? TbProDetCantElim { get; set; }

        [Column("TB_PRO_DET_IMG")]
        public string? TbProDetImg { get; set; }
    }
}