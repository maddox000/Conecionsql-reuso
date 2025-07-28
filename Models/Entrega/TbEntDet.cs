using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexionSql.Models.Entrega
{
    [Table("TB_ENT_DET")]
    public class TbEntDet
    {
        [Column("TB_ENT_DET_ID")]
        public int TbEntDetId { get; set; }

        [Column("TB_ENT_ID")]
        public int? TbEntId { get; set; }

        [Column("TB_ENT_DET_PC_LOG")]
        public string? TbEntDetPcLog { get; set; }

        [Column("TB_ENT_DET_PC_USR")]
        public string? TbEntDetPcUsr { get; set; }

        [Column("TB_ENT_DET_REC_DET_ID")]
        public int? TbEntDetRecDetId { get; set; }

        [Column("TB_ENT_DET_REC_DET_MAT_ID")]
        public int? TbEntDetRecDetMatId { get; set; }

        [Column("TB_ENT_DET_REC_DET_MAT_DEN")]
        public string? TbEntDetRecDetMatDen { get; set; }

        [Column("TB_ENT_DET_REC_DET_MAT_TIP_ID")]
        public int? TbEntDetRecDetMatTipId { get; set; }

        [Column("TB_ENT_DET_REC_DET_MAT_TIP_DEN")]
        public string? TbEntDetRecDetMatTipDen { get; set; }

        [Column("TB_ENT_DET_REC_DET_CANT")]
        public int? TbEntDetRecDetCant { get; set; }

        [Column("TB_ENT_DET_REC_DET_ENT_STOCK")]
        public int? TbEntDetRecDetEntStock { get; set; }

        [Column("TB_ENT_DET_REC_DET_ENT_CANT")]
        public int? TbEntDetRecDetEntCant { get; set; }

        [Column("TB_ENT_DET_REC_DET_ENT_TOT")]
        public int? TbEntDetRecDetEntTot { get; set; }

        [Column("TB_ENT_DET_REC_ID")]
        public int? TbEntDetRecId { get; set; }

        [Column("TB_ENT_DET_REC_DET_REU_ID")]
        public string? TbEntDetRecDetReuId { get; set; }

        [Column("TB_ENT_DET_CANT")]
        public int? TbEntDetCant { get; set; }

        [Column("TB_ENT_DET_REC_DET_PAC")]
        public string? TbEntDetRecDetPac { get; set; }

        [Column("TB_REC_DET_PRO_ID")]
        public int? TbRecDetProId { get; set; }

        [Column("TB_REC_DET_PRO_NOM")]
        public string? TbRecDetProNom { get; set; }

        [Column("TB_REC_DET_PRO_APE")]
        public string? TbRecDetProApe { get; set; }

        [Column("TB_REC_DET_REM")]
        public string? TbRecDetRem { get; set; }

        [Column("TB_ENT_SEC_ID")]
        public int? TbEntSecId { get; set; }

        [Column("TB_ENT_SEC_DEN")]
        public string? TbEntSecDen { get; set; }

        [Column("TB_ENT_FEC")]
        public DateTime? TbEntFec { get; set; }

        [Column("TB_ENT_DET_NUM_1")]
        public int? TbEntDetNum1 { get; set; }

        [Column("TB_ENT_DET_NUM_2")]
        public int? TbEntDetNum2 { get; set; }

        [Column("TB_ENT_DET_NUM_3")]
        public int? TbEntDetNum3 { get; set; }

        [Column("TB_ENT_DET_TXT_1")]
        public string? TbEntDetTxt1 { get; set; }

        [Column("TB_ENT_DET_TXT_2")]
        public string? TbEntDetTxt2 { get; set; }

        [Column("TB_ENT_DET_TXT_3")]
        public string? TbEntDetTxt3 { get; set; }

        [Column("TB_ENT_DET_DTI_1")]
        public DateTime? TbEntDetDti1 { get; set; }

        [Column("TB_ENT_DET_DTI_2")]
        public DateTime? TbEntDetDti2 { get; set; }

        [Column("TB_ENT_DET_DTI_3")]
        public DateTime? TbEntDetDti3 { get; set; }

        [Column("TB_ENT_DET_MEM_1")]
        public string? TbEntDetMem1 { get; set; }

        [Column("TB_ENT_DET_MEM_2")]
        public string? TbEntDetMem2 { get; set; }

        [Column("TB_ENT_DET_MEM_3")]
        public string? TbEntDetMem3 { get; set; }

        [Column("TB_ENT_DET_CKL_1")]
        public bool? TbEntDetCkl1 { get; set; }

        [Column("TB_ENT_DET_CKL_2")]
        public bool? TbEntDetCkl2 { get; set; }

        [Column("TB_ENT_DET_CKL_3")]
        public bool? TbEntDetCkl3 { get; set; }

        [Column("TB_ENT_DET_CKL_4")]
        public bool? TbEntDetCkl4 { get; set; }

        [Column("TB_ENT_DET_CKL_5")]
        public bool? TbEntDetCkl5 { get; set; }

        [Column("TB_ENT_DET_CKL_6")]
        public bool? TbEntDetCkl6 { get; set; }

        [Column("TB_ENT_DET_BIT_1")]
        public bool? TbEntDetBit1 { get; set; }

        [Column("TB_ENT_DET_BIT_2")]
        public bool? TbEntDetBit2 { get; set; }

        [Column("TB_ENT_DET_BIT_3")]
        public bool? TbEntDetBit3 { get; set; }

        [Column("TB_ENT_DET_CANT_MULT")]
        public int? TbEntDetCantMult { get; set; }

        [Column("TB_ENT_DET_CANT_ELIM")]
        public int? TbEntDetCantElim { get; set; }

        [Column("TB_ENT_DET_DAT")]
        public string? TbEntDetDat { get; set; }

        [Column("TB_ENT_DET_MAT_ETI_ID")]
        public int? TbEntDetMatEtiId { get; set; }

        [Column("TB_ENT_DET_MAT_ETI_DEN")]
        public string? TbEntDetMatEtiDen { get; set; }

        [Column("TB_ENT_DET_PRO_PTI_ID")]
        public int? TbEntDetProPtiId { get; set; }

        [Column("TB_ENT_DET_PRO_PTI_DEN")]
        public string? TbEntDetProPtiDen { get; set; }

        [Column("TB_ENT_DET_TRANSP_OPC_ID")]
        public int? TbEntDetTranspOpcId { get; set; }

        [Column("TB_ENT_DET_TRANSP_OPC_DEN")]
        public string? TbEntDetTranspOpcDen { get; set; }
    }
}
