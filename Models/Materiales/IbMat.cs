using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ConexionSql.Models.Materiales
{
    [Table("IB_MAT")]
    public class IbMat
    {
        [Key]
        [Column("IB_MAT_ID")]
        public int IB_MAT_ID { get; set; }

        [Column("IB_MAT_ID_FORM")]
        public int? IB_MAT_ID_FORM { get; set; }

        [Column("IB_MAT_REG_FEC")]
        public DateTime? IB_MAT_REG_FEC { get; set; }

        [Column("IB_MAT_REG_HOR")]
        public DateTime? IB_MAT_REG_HOR { get; set; }

        [Column("IB_MAT_ACT_FEC")]
        public DateTime? IB_MAT_ACT_FEC { get; set; }

        [Column("IB_MAT_PR")]
        public string? IB_MAT_PR { get; set; }

        [Column("IB_MAT_DEN")]
        public string? IB_MAT_DEN { get; set; }

        [Column("IB_MAT_MTI_ID")]
        public int? IB_MAT_MTI_ID { get; set; }

        [Column("IB_MAT_MTI_DEN")]
        public string? IB_MAT_MTI_DEN { get; set; }

        [Column("IB_MAT_MAR_ID")]
        public int? IB_MAT_MAR_ID { get; set; }

        [Column("IB_MAT_MAR_DEN")]
        public string? IB_MAT_MAR_DEN { get; set; }

        [Column("IB_MAT_MAR_CAT")]
        public string? IB_MAT_MAR_CAT { get; set; }

        [Column("IB_MAT_PRO_ID")]
        public int? IB_MAT_PRO_ID { get; set; }

        [Column("IB_MAT_PRO_DEN")]
        public string? IB_MAT_PRO_DEN { get; set; }

        [Column("IB_MAT_PRO_CAT")]
        public string? IB_MAT_PRO_CAT { get; set; }

        [Column("IB_MAT_MGR_ID")]
        public int? IB_MAT_MGR_ID { get; set; }

        [Column("IB_MAT_MGR_DEN")]
        public string? IB_MAT_MGR_DEN { get; set; }

        [Column("IB_MAT_VEN")]
        public DateTime? IB_MAT_VEN { get; set; }

        [Column("IB_MAT_MAN")]
        public int? IB_MAT_MAN { get; set; }

        [Column("IB_MAT_MAN_FEC")]
        public DateTime? IB_MAT_MAN_FEC { get; set; }

        [Column("IB_MAT_MAN_PRO")]
        public DateTime? IB_MAT_MAN_PRO { get; set; }

        [Column("IB_MAT_REU_CANT")]
        public int? IB_MAT_REU_CANT { get; set; }

        [Column("IB_MAT_REU_CANT_MAN")]
        public int? IB_MAT_REU_CANT_MAN { get; set; }

        [Column("IB_MAT_CON_UNID")]
        public int? IB_MAT_CON_UNID { get; set; }

        [Column("IB_MAT_CON_ACT")]
        public int? IB_MAT_CON_ACT { get; set; }

        [Column("IB_MAT_CON_DIF")]
        public int? IB_MAT_CON_DIF { get; set; }

        [Column("IB_MAT_OCU")]
        public bool IB_MAT_OCU { get; set; }

        [Column("IB_MAT_PRI_OPC")]
        public bool IB_MAT_PRI_OPC { get; set; }

        [Column("IB_MAT_CON_OPC")]
        public bool IB_MAT_CON_OPC { get; set; }

        [Column("IB_MAT_VOP_OPC")]
        public bool IB_MAT_VOP_OPC { get; set; }

        [Column("IB_MAT_VOP_OPC_FORM")]
        public int? IB_MAT_VOP_OPC_FORM { get; set; }

        [Column("IB_MAT_VOP_ACO_OPC_FORM")]
        public int? IB_MAT_VOP_ACO_OPC_FORM { get; set; }

        [Column("IB_MAT_REU_OPC")]
        public bool IB_MAT_REU_OPC { get; set; }

        [Column("IB_MAT_REU_OPC_CANT")]
        public int? IB_MAT_REU_OPC_CANT { get; set; }

        [Column("IB_MAT_ETI_ENT_OPC")]
        public bool IB_MAT_ETI_ENT_OPC { get; set; }

        [Column("IB_MAT_CANT")]
        public int? IB_MAT_CANT { get; set; }

        [Column("IB_MAT_STOCK")]
        public int? IB_MAT_STOCK { get; set; }

        [Column("IB_MAT_STOCK_HMD")]
        public int? IB_MAT_STOCK_HMD { get; set; }

        [Column("IB_MAT_TEMP")]
        public int? IB_MAT_TEMP { get; set; }

        [Column("IB_MAT_TEMP_HMD")]
        public int? IB_MAT_TEMP_HMD { get; set; }

        [Column("IB_MAT_QPO")]
        public int? IB_MAT_QPO { get; set; }

        [Column("IB_MAT_QPO_HMD")]
        public int? IB_MAT_QPO_HMD { get; set; }

        [Column("IB_MAT_LAV")]
        public int? IB_MAT_LAV { get; set; }

        [Column("IB_MAT_LAV_HMD")]
        public int? IB_MAT_LAV_HMD { get; set; }

        [Column("IB_MAT_ACO")]
        public int? IB_MAT_ACO { get; set; }

        [Column("IB_MAT_ACO_HMD")]
        public int? IB_MAT_ACO_HMD { get; set; }

        [Column("IB_MAT_ACO_FALT")]
        public string? IB_MAT_ACO_FALT { get; set; }

        [Column("IB_MAT_ACO_ACO_SUP")]
        public bool IB_MAT_ACO_ACO_SUP { get; set; }

        [Column("IB_MAT_TCE")]
        public int? IB_MAT_TCE { get; set; }

        [Column("IB_MAT_ETI1_CTO")]
        public int? IB_MAT_ETI1_CTO { get; set; }

        [Column("IB_MAT_ETI1_SEL_ID")]
        public int? IB_MAT_ETI1_SEL_ID { get; set; }

        [Column("IB_MAT_ETI1_SEL_DEN")]
        public string? IB_MAT_ETI1_SEL_DEN { get; set; }

        [Column("IB_MAT_ETI1_SEL_CAN")]
        public int? IB_MAT_ETI1_SEL_CAN { get; set; }

        [Column("IB_MAT_ETI2_ID")]
        public int? IB_MAT_ETI2_ID { get; set; }

        [Column("IB_MAT_ETI2_DEN")]
        public string? IB_MAT_ETI2_DEN { get; set; }

        [Column("IB_MAT_ETI2_CAN")]
        public int? IB_MAT_ETI2_CAN { get; set; }

        [Column("IB_MAT_ETI2_CEN")]
        public int? IB_MAT_ETI2_CEN { get; set; }

        [Column("IB_MAT_ETI2_CTO")]
        public int? IB_MAT_ETI2_CTO { get; set; }

        [Column("IB_MAT_ETI2_SEL_ID")]
        public int? IB_MAT_ETI2_SEL_ID { get; set; }


        [Column("IB_MAT_ETI2_SEL_DEN")]
        public string? IB_MAT_ETI2_SEL_DEN { get; set; }

        [Column("IB_MAT_ETI2_SEL_CAN")]
        public int? IB_MAT_ETI2_SEL_CAN { get; set; }

        [Column("IB_MAT_ETI_VENC")]
        public int? IB_MAT_ETI_VENC { get; set; }

        [Column("IB_MAT_PTE1_ID")]
        public int? IB_MAT_PTE1_ID { get; set; }

        [Column("IB_MAT_PTE1_DEN")]
        public string? IB_MAT_PTE1_DEN { get; set; }

        [Column("IB_MAT_PTE1_CAN")]
        public int? IB_MAT_PTE1_CAN { get; set; }

        [Column("IB_MAT_PTE1_UBI_ID")]
        public int? IB_MAT_PTE1_UBI_ID { get; set; }

        [Column("IB_MAT_PTE1_UBI_DEN")]
        public string? IB_MAT_PTE1_UBI_DEN { get; set; }

        [Column("IB_MAT_PTE2_ID")]
        public int? IB_MAT_PTE2_ID { get; set; }

        [Column("IB_MAT_PTE2_DEN")]
        public string? IB_MAT_PTE2_DEN { get; set; }

        [Column("IB_MAT_PTE2_CAN")]
        public int? IB_MAT_PTE2_CAN { get; set; }

        [Column("IB_MAT_PTE2_UBI_ID")]
        public int? IB_MAT_PTE2_UBI_ID { get; set; }

        [Column("IB_MAT_PTE2_UBI_DEN")]
        public string? IB_MAT_PTE2_UBI_DEN { get; set; }

        [Column("IB_MAT_PTE3_ID")]
        public int? IB_MAT_PTE3_ID { get; set; }

        [Column("IB_MAT_PTE3_DEN")]
        public string? IB_MAT_PTE3_DEN { get; set; }

        [Column("IB_MAT_PTE3_CAN")]
        public int? IB_MAT_PTE3_CAN { get; set; }

        [Column("IB_MAT_PTE3_UBI_ID")]
        public int? IB_MAT_PTE3_UBI_ID { get; set; }

        [Column("IB_MAT_PTE3_UBI_DEN")]
        public string? IB_MAT_PTE3_UBI_DEN { get; set; }

        [Column("IB_MAT_PTE4_ID")]
        public int? IB_MAT_PTE4_ID { get; set; }

        [Column("IB_MAT_PTE4_DEN")]
        public string? IB_MAT_PTE4_DEN { get; set; }

        [Column("IB_MAT_PTE4_CAN")]
        public int? IB_MAT_PTE4_CAN { get; set; }

        [Column("IB_MAT_PTE4_UBI_ID")]
        public int? IB_MAT_PTE4_UBI_ID { get; set; }

        [Column("IB_MAT_PTE4_UBI_DEN")]
        public string? IB_MAT_PTE4_UBI_DEN { get; set; }

        [Column("IB_MAT_PTE_TOT")]
        public int? IB_MAT_PTE_TOT { get; set; }

        [Column("IB_MAT_ALT")]
        public int? IB_MAT_ALT { get; set; }

        [Column("IB_MAT_ANC")]
        public int? IB_MAT_ANC { get; set; }

        [Column("IB_MAT_PRO")]
        public int? IB_MAT_PRO { get; set; }

        [Column("IB_MAT_VOL")]
        public int? IB_MAT_VOL { get; set; }

        [Column("IB_MAT_IMG_1")]
        public string? IB_MAT_IMG_1 { get; set; }

        [Column("IB_MAT_IMG_2")]
        public string? IB_MAT_IMG_2 { get; set; }

        [Column("IB_MAT_IMG_3")]
        public string? IB_MAT_IMG_3 { get; set; }

        [Column("IB_MAT_IMG_4")]
        public string? IB_MAT_IMG_4 { get; set; }

        [Column("IB_MAT_IMG_5")]
        public string? IB_MAT_IMG_5 { get; set; }

        [Column("IB_MAT_IMG_TOT")]
        public int? IB_MAT_IMG_TOT { get; set; }

        [Column("IB_MAT_CCO_ID")]
        public int? IB_MAT_CCO_ID { get; set; }

        [Column("IB_MAT_CCO_DEN")]
        public string? IB_MAT_CCO_DEN { get; set; }

        [Column("IB_MAT_LAV_ID")]
        public int? IB_MAT_LAV_ID { get; set; }

        [Column("IB_MAT_LAV_DEN")]
        public string? IB_MAT_LAV_DEN { get; set; }

        [Column("IB_MAT_LAV_TCI_ID")]
        public int? IB_MAT_LAV_TCI_ID { get; set; }

        [Column("IB_MAT_LAV_TCI_DEN")]
        public string? IB_MAT_LAV_TCI_DEN { get; set; }

        [Column("IB_MAT_LAV_TXT")]
        public string? IB_MAT_LAV_TXT { get; set; }

        [Column("IB_MAT_LAV_TIM")]
        public int? IB_MAT_LAV_TIM { get; set; }

        [Column("IB_MAT_ACO_TXT")]
        public string? IB_MAT_ACO_TXT { get; set; }

        [Column("IB_MAT_ACO_TIM")]
        public int? IB_MAT_ACO_TIM { get; set; }

        [Column("IB_MAT_ETI_TXT")]
        public string? IB_MAT_ETI_TXT { get; set; }

        [Column("IB_MAT_ETI_TIM")]
        public int? IB_MAT_ETI_TIM { get; set; }

        [Column("IB_MAT_REC_TIM")]
        public int? IB_MAT_REC_TIM { get; set; }

        [Column("IB_MAT_PRO_TIM")]
        public int? IB_MAT_PRO_TIM { get; set; }

        [Column("IB_MAT_ENT_TIM")]
        public int? IB_MAT_ENT_TIM { get; set; }

        [Column("IB_MAT_EST_TIM_TOT")]
        public int? IB_MAT_EST_TIM_TOT { get; set; }

        [Column("IB_MAT_PROC1_ID")]
        public int? IB_MAT_PROC1_ID { get; set; }

        [Column("IB_MAT_PROC1_DEN")]
        public string? IB_MAT_PROC1_DEN { get; set; }

        [Column("IB_MAT_PROC1_TCI_ID")]
        public int? IB_MAT_PROC1_TCI_ID { get; set; }

        [Column("IB_MAT_PROC1_TCI_DEN")]
        public string? IB_MAT_PROC1_TCI_DEN { get; set; }

        [Column("IB_MAT_PROC2_ID")]
        public int? IB_MAT_PROC2_ID { get; set; }

        [Column("IB_MAT_PROC2_DEN")]
        public string? IB_MAT_PROC2_DEN { get; set; }

        [Column("IB_MAT_PROC2_TCI_ID")]
        public int? IB_MAT_PROC2_TCI_ID { get; set; }

        [Column("IB_MAT_PROC2_TCI_DEN")]
        public string? IB_MAT_PROC2_TCI_DEN { get; set; }

        [Column("IB_PMA_SEL")]
        public bool IB_PMA_SEL { get; set; }

        [Column("IB_MST_SEL")]
        public bool IB_MST_SEL { get; set; }

        [Column("IB_MCO_SEL")]
        public bool IB_MCO_SEL { get; set; }

        [Column("IB_MAT_REC_DET_CONT")]
        public bool IB_MAT_REC_DET_CONT { get; set; }

        [Column("IB_MGR_ID")]
        public int? IB_MGR_ID { get; set; }

        [Column("IB_MGR_DEN")]
        public string? IB_MGR_DEN { get; set; }

        [Column("IB_MAT_TXT_1")]
        public string? IB_MAT_TXT_1 { get; set; }

        [Column("IB_MAT_TXT_2")]
        public string? IB_MAT_TXT_2 { get; set; }

        [Column("IB_MAT_TXT_3")]
        public string? IB_MAT_TXT_3 { get; set; }

        [Column("IB_MAT_NUM_1")]
        public int? IB_MAT_NUM_1 { get; set; }

        [Column("IB_MAT_NUM_2")]
        public int? IB_MAT_NUM_2 { get; set; }

        [Column("IB_MAT_NUM_3")]
        public int? IB_MAT_NUM_3 { get; set; }

        [Column("IB_MAT_DAT_1")]
        public DateTime? IB_MAT_DAT_1 { get; set; }

        [Column("IB_MAT_DAT_2")]
        public DateTime? IB_MAT_DAT_2 { get; set; }

        [Column("IB_MAT_DAT_3")]
        public DateTime? IB_MAT_DAT_3 { get; set; }

        [Column("IB_MAT_MEM_1")]
        public string? IB_MAT_MEM_1 { get; set; }

        [Column("IB_MAT_MEN_2")]
        public string? IB_MAT_MEN_2 { get; set; }

        [Column("IB_MAT_MEN_3")]
        public string? IB_MAT_MEN_3 { get; set; }

        [Column("IB_MAT_PC_LOG")]
        public string? IB_MAT_PC_LOG { get; set; }

        [Column("IB_MAT_PC_USR")]
        public string? IB_MAT_PC_USR { get; set; }

        [Column("IB_MAT_STOCK_PARTOS")]
        public int? IB_MAT_STOCK_PARTOS { get; set; }

        [Column("IB_MAT_TEMP_PARTOS")]
        public int? IB_MAT_TEMP_PARTOS { get; set; }

        [Column("IB_MAT_QPO_PARTOS")]
        public int? IB_MAT_QPO_PARTOS { get; set; }

        [Column("IB_MAT_LAV_PARTOS")]
        public int? IB_MAT_LAV_PARTOS { get; set; }

        [Column("IB_MAT_ACO_PARTOS")]
        public int? IB_MAT_ACO_PARTOS { get; set; }

        [Column("IB_MAT_TCE_PARTOS")]
        public int? IB_MAT_TCE_PARTOS { get; set; }

        [Column("IB_MAT_CES_HMD")]
        public int? IB_MAT_CES_HMD { get; set; }

        [Column("IB_MAT_CES_PARTOS")]
        public int? IB_MAT_CES_PARTOS { get; set; }

        [Column("IB_MAT_ETI_REC_OPC")]
        public bool IB_MAT_ETI_REC_OPC { get; set; }

        [Column("IB_MAT_STOCK_SEC")]
        public int? IB_MAT_STOCK_SEC { get; set; }

        [Column("IB_MAT_TEMP_SEC")]
        public int? IB_MAT_TEMP_SEC { get; set; }

        [Column("IB_MAT_QPO_SEC")]
        public int? IB_MAT_QPO_SEC { get; set; }

        [Column("IB_MAT_LAV_SEC")]
        public int? IB_MAT_LAV_SEC { get; set; }

        [Column("IB_MAT_ACO_SEC")]
        public int? IB_MAT_ACO_SEC { get; set; }

        [Column("IB_MAT_TCE_SEC")]
        public int? IB_MAT_TCE_SEC { get; set; }

        [Column("IB_MAT_CES_SEC")]
        public int? IB_MAT_CES_SEC { get; set; }

        [Column("IB_MAT_CANT_HMD")]
        public int? IB_MAT_CANT_HMD { get; set; }

        [Column("IB_MAT_CANT_PARTOS")]
        public int? IB_MAT_CANT_PARTOS { get; set; }

        [Column("IB_MAT_STOCK_NFAR")]
        public int? IB_MAT_STOCK_NFAR { get; set; }

        [Column("IB_MAT_STOCK_NHMD")]
        public int? IB_MAT_STOCK_NHMD { get; set; }

        [Column("IB_MAT_BIT_1")]
        public bool? IB_MAT_BIT_1 { get; set; }

        [Column("IB_MAT_BIT_2")]
        public bool? IB_MAT_BIT_2 { get; set; }

        [Column("IB_MAT_BIT_3")]
        public bool? IB_MAT_BIT_3 { get; set; }

        [Column("IB_MAT_PMAT")]
        public double? IB_MAT_PMAT { get; set; }

        [Column("IB_MAT_CES_PROV1")]
        public int? IB_MAT_CES_PROV1 { get; set; }

        [Column("IB_MAT_CES_PROV2")]
        public int? IB_MAT_CES_PROV2 { get; set; }

        [Column("IB_MAT_CES_PROV3")]
        public int? IB_MAT_CES_PROV3 { get; set; }

        [Column("IB_MAT_CES_PROV4")]
        public int? IB_MAT_CES_PROV4 { get; set; }

        [Column("IB_MAT_CES_PROV5")]
        public int? IB_MAT_CES_PROV5 { get; set; }

        [Column("IB_MAT_STOCK_HMD_OPC")]
        public bool IB_MAT_STOCK_HMD_OPC { get; set; }

        [Column("IB_MAT_STOCK_HMD_MIN")]
        public int? IB_MAT_STOCK_HMD_MIN { get; set; }

        [Column("IB_MAT_STOCK_HMD_CRIT")]
        public int? IB_MAT_STOCK_HMD_CRIT { get; set; }

        [Column("IB_MAT_QPO_CCV")]
        public int? IB_MAT_QPO_CCV { get; set; }

        [Column("IB_MAT_LAV_CCV")]
        public int? IB_MAT_LAV_CCV { get; set; }

        [Column("IB_MAT_ACO_CCV")]
        public int? IB_MAT_ACO_CCV { get; set; }

        [Column("IB_MAT_TCE_CCV")]
        public int? IB_MAT_TCE_CCV { get; set; }

        [Column("IB_MAT_CES_CCV")]
        public int? IB_MAT_CES_CCV { get; set; }

        [Column("IB_MAT_STOCK_NCQ")]
        public int? IB_MAT_STOCK_NCQ { get; set; }

        [Column("IB_MAT_STOCK_NCCV")]
        public int? IB_MAT_STOCK_NCCV { get; set; }

        [Column("IB_MAT_STOCK_NPARTOS")]
        public int? IB_MAT_STOCK_NPARTOS { get; set; }

        [Column("IB_MAT_STOCK_NENDO")]
        public int? IB_MAT_STOCK_NENDO { get; set; }

        [Column("IB_LMAT_MULT")]
        public int? IB_LMAT_MULT { get; set; }

        [Column("IB_MAT_STOCK_UCQ")]
        public int? IB_MAT_STOCK_UCQ { get; set; }

        [Column("IB_MAT_STOCK_UHMD")]
        public int? IB_MAT_STOCK_UHMD { get; set; }

        [Column("IB_MAT_STOCK_UCCV")]
        public int? IB_MAT_STOCK_UCCV { get; set; }

        [Column("IB_MAT_STOCK_UPARTOS")]
        public int? IB_MAT_STOCK_UPARTOS { get; set; }

        [Column("IB_MAT_STOCK_UENDO")]
        public int? IB_MAT_STOCK_UENDO { get; set; }

        [Column("IB_MAT_STOCK_UFPM")]
        public int? IB_MAT_STOCK_UFPM { get; set; }


        [Column("IB_MAT_ETI1_CAN")]
        public int? IB_MAT_ETI1_CAN { get; set; }



    }
}
