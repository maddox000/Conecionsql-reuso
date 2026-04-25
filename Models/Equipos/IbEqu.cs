using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexionSql.Models.Equipos
{
    [Table("IB_EQU")]
    public class IbEqu
    {
        [Column("IB_EQU_ID")]
        public int IbEquId { get; set; }

        [Column("IB_EQU_ID_FORM")]
        public int? IbEquIdForm { get; set; }

        [Column("IB_EQU_TEQ_ID")]
        public int? IbEquTeqId { get; set; }

        [Column("IB_EQU_TEQ_DEN")]
        public string? IbEquTeqDen { get; set; }

        [Column("IB_EQU_PTI_ID")]
        public int? IbEquPtiId { get; set; }

        [Column("IB_EQU_PTI_DEN")]
        public string? IbEquPtiDen { get; set; }

        [Column("IB_EQU_MAR_ID")]
        public int? IbEquMarId { get; set; }

        [Column("IB_EQU_MAR_DEN")]
        public string? IbEquMarDen { get; set; }

        [Column("IB_EQU_MOD")]
        public string? IbEquMod { get; set; }

        [Column("IB_EQU_SER")]
        public string? IbEquSer { get; set; }

        [Column("IB_EQU_NUM")]
        public int? IbEquNum { get; set; }

        [Column("IB_EQU_ALT")]
        public int? IbEquAlt { get; set; }

        [Column("IB_EQU_ANC")]
        public int? IbEquAnc { get; set; }

        [Column("IB_EQU_PRO")]
        public int? IbEquPro { get; set; }

        [Column("IB_EQU_PORC")]
        public int? IbEquPorc { get; set; }

        [Column("IB_EQU_CAP")]
        public int? IbEquCap { get; set; }

        [Column("IB_EQU_CAPU")]
        public int? IbEquCapu { get; set; }

        [Column("IB_EQU_CAG_CANT")]
        public int? IbEquCagCant { get; set; }

        [Column("IB_EQU_CAG_VAL")]
        public int? IbEquCagVal { get; set; }

        [Column("IB_EQU_CAG")]
        public int? IbEquCag { get; set; }

        [Column("IB_EQU_CAI_CANT")]
        public int? IbEquCaiCant { get; set; }

        [Column("IB_EQU_CAI_VAL")]
        public int? IbEquCaiVal { get; set; }

        [Column("IB_EQU_CAI")]
        public string? IbEquCai { get; set; }

        [Column("IB_EQU_CEL_CANT")]
        public int? IbEquCelCant { get; set; }

        [Column("IB_EQU_CEL_VAL")]
        public int? IbEquCelVal { get; set; }

        [Column("IB_EQU_CEL")]
        public int? IbEquCel { get; set; }

        [Column("IB_EQU_CES_CANT")]
        public int? IbEquCesCant { get; set; }

        [Column("IB_EQU_CES_VAL")]
        public int? IbEquCesVal { get; set; }

        [Column("IB_EQU_CES")]
        public int? IbEquCes { get; set; }

        [Column("IB_EQU_PTE_CANT")]
        public int? IbEquPteCant { get; set; }

        [Column("IB_EQU_PTE_VAL")]
        public int? IbEquPteVal { get; set; }

        [Column("IB_EQU_PTE")]
        public int? IbEquPte { get; set; }

        [Column("IB_EQU_PCO")]
        public int? IbEquPco { get; set; }

        [Column("IB_EQU_PCO_COEF")]
        public int? IbEquPcoCoef { get; set; }

        [Column("IB_EQU_PVE")]
        public int? IbEquPve { get; set; }

        [Column("IB_EQU_TXT_1")]
        public string? IbEquTxt1 { get; set; }

        [Column("IB_EQU_TXT_2")]
        public string? IbEquTxt2 { get; set; }

        [Column("IB_EQU_TXT_3")]
        public string? IbEquTxt3 { get; set; }

        [Column("IB_EQU_NUM_1")]
        public int? IbEquNum1 { get; set; }

        [Column("IB_EQU_NUM_2")]
        public int? IbEquNum2 { get; set; }

        [Column("IB_EQU_NUM_3")]
        public int? IbEquNum3 { get; set; }

        [Column("IB_EQU_DTI_1")]
        public DateTime? IbEquDti1 { get; set; }

        [Column("IB_EQU_DTI_2")]
        public DateTime? IbEquDti2 { get; set; }

        [Column("IB_EQU_DTI_3")]
        public DateTime? IbEquDti3 { get; set; }

        [Column("IB_EQU_OCU")]
        public bool IbEquOcu { get; set; }

        [Column("IB_EQU_LMAT")]
        public int? IbEquLmat { get; set; }
    }
}

