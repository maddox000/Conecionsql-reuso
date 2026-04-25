using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexionSql.Models.Instrumental
{
    [Table("IB_MAT_CON")]
    public class IbMatCon
    {
        // IB_MAT_INT_ID
        [Key]
        [Column("IB_MAT_INT_ID")]
        public int IbMatIntId { get; set; }

        // IB_MAT_INT_DEN
        [Column("IB_MAT_INT_DEN")]
        public string? IbMatIntDen { get; set; }

        // IB_MAT_INT_ID_FORM
        [Column("IB_MAT_INT_ID_FORM")]
        public int? IbMatIntIdForm { get; set; }

        // IB_MAT_INT_PC_LOG
        [Column("IB_MAT_INT_PC_LOG")]
        public string? IbMatIntPcLog { get; set; }

        // IB_MAT_INT_PC_USR
        [Column("IB_MAT_INT_PC_USR")]
        public string? IbMatIntPcUsr { get; set; }

        // IB_MAT_INT_REG_FEC
        [Column("IB_MAT_INT_REG_FEC")]
        public DateTime? IbMatIntRegFec { get; set; }

        // IB_MAT_INT_REG_HOR
        [Column("IB_MAT_INT_REG_HOR")]
        public DateTime? IbMatIntRegHor { get; set; }

        // IB_MAT_INT_ACT_FEC
        [Column("IB_MAT_INT_ACT_FEC")]
        public DateTime? IbMatIntActFec { get; set; }

        // IB_MAT_INT_PR
        [Column("IB_MAT_INT_PR")]
        public string? IbMatIntPr { get; set; }

        // IB_MAT_INT_MGR_ID
        [Column("IB_MAT_INT_MGR_ID")]
        public int? IbMatIntMgrId { get; set; }

        // IB_MAT_INT_MGR_DEN
        [Column("IB_MAT_INT_MGR_DEN")]
        public string? IbMatIntMgrDen { get; set; }

        // IB_MAT_INT_MAR_ID
        [Column("IB_MAT_INT_MAR_ID")]
        public int? IbMatIntMarId { get; set; }

        // IB_MAT_INT_MAR_DEN
        [Column("IB_MAT_INT_MAR_DEN")]
        public string? IbMatIntMarDen { get; set; }

        // IB_MAT_INT_MAR_CAT
        [Column("IB_MAT_INT_MAR_CAT")]
        public string? IbMatIntMarCat { get; set; }

        // IB_MAT_INT_PRO_ID
        [Column("IB_MAT_INT_PRO_ID")]
        public int? IbMatIntProId { get; set; }

        // IB_MAT_INT_PRO_DEN
        [Column("IB_MAT_INT_PRO_DEN")]
        public string? IbMatIntProDen { get; set; }

        // IB_MAT_INT_PRO_CAT
        [Column("IB_MAT_INT_PRO_CAT")]
        public string? IbMatIntProCat { get; set; }

        // IB_MAT_INT_MAN
        [Column("IB_MAT_INT_MAN")]
        public int? IbMatIntMan { get; set; }

        // IB_MAT_INT_MAN_FEC
        [Column("IB_MAT_INT_MAN_FEC")]
        public DateTime? IbMatIntManFec { get; set; }

        // IB_MAT_INT_MAN_PRO
        [Column("IB_MAT_INT_MAN_PRO")]
        public DateTime? IbMatIntManPro { get; set; }

        // IB_MAT_INT_OCU
        [Column("IB_MAT_INT_OCU")]
        public bool IbMatIntOcu { get; set; }

        // IB_MAT_INT_COS
        [Column("IB_MAT_INT_COS")]
        public int? IbMatIntCos { get; set; }

        // IB_MAT_INT_COS_FEC
        [Column("IB_MAT_INT_COS_FEC")]
        public DateTime? IbMatIntCosFec { get; set; }

        // IB_MAT_INT_IMG_1
        [Column("IB_MAT_INT_IMG_1")]
        public string? IbMatIntImg1 { get; set; }

        // IB_MAT_INT_IMG_2
        [Column("IB_MAT_INT_IMG_2")]
        public string? IbMatIntImg2 { get; set; }

        // IB_MAT_INT_IMG_3
        [Column("IB_MAT_INT_IMG_3")]
        public string? IbMatIntImg3 { get; set; }

        // IB_MAT_INT_IMG_4
        [Column("IB_MAT_INT_IMG_4")]
        public string? IbMatIntImg4 { get; set; }

        // IB_MAT_INT_IMG_5
        [Column("IB_MAT_INT_IMG_5")]
        public string? IbMatIntImg5 { get; set; }

        // IB_MAT_INT_IMG_TOT
        [Column("IB_MAT_INT_IMG_TOT")]
        public int? IbMatIntImgTot { get; set; }

        // IB_MAT_INT_CCO_ID
        [Column("IB_MAT_INT_CCO_ID")]
        public int? IbMatIntCcoId { get; set; }

        // IB_MAT_INT_CCO_DEN
        [Column("IB_MAT_INT_CCO_DEN")]
        public string? IbMatIntCcoDen { get; set; }

        // IB_MAT_INT_LAV_ID
        [Column("IB_MAT_INT_LAV_ID")]
        public int? IbMatIntLavId { get; set; }

        // IB_MAT_INT_LAV_DEN
        [Column("IB_MAT_INT_LAV_DEN")]
        public string? IbMatIntLavDen { get; set; }

        // IB_MAT_INT_LAV_TCI_ID
        [Column("IB_MAT_INT_LAV_TCI_ID")]
        public int? IbMatIntLavTciId { get; set; }

        // IB_MAT_INT_LAV_TCI_DEN
        [Column("IB_MAT_INT_LAV_TCI_DEN")]
        public string? IbMatIntLavTciDen { get; set; }

        // IB_MAT_INT_LAV_TXT
        [Column("IB_MAT_INT_LAV_TXT")]
        public string? IbMatIntLavTxt { get; set; }

        // IB_MAT_INT_LAV_TIM
        [Column("IB_MAT_INT_LAV_TIM")]
        public string? IbMatIntLavTim { get; set; }

        // IB_MAT_INT_ACO_TXT
        [Column("IB_MAT_INT_ACO_TXT")]
        public string? IbMatIntAcoTxt { get; set; }

        // IB_MAT_INT_ACO_TIM
        [Column("IB_MAT_INT_ACO_TIM")]
        public string? IbMatIntAcoTim { get; set; }

        // IB_MAT_INT_TIM_TOT
        [Column("IB_MAT_INT_TIM_TOT")]
        public string? IbMatIntTimTot { get; set; }

        // IB_MAT_INT_UDE_OPC
        [Column("IB_MAT_INT_UDE_OPC")]
        public bool IbMatIntUdeOpc { get; set; }

        // IB_MAT_INT_EDI_NIV_ID
        [Column("IB_MAT_INT_EDI_NIV_ID")]
        public string? IbMatIntEdiNivId { get; set; }

        // IB_MAT_INT_EDI_NIV_DEN
        [Column("IB_MAT_INT_EDI_NIV_DEN")]
        public string? IbMatIntEdiNivDen { get; set; }

        // IB_MAT_INT_EDI_ID
        [Column("IB_MAT_INT_EDI_ID")]
        public string? IbMatIntEdiId { get; set; }

        // IB_MAT_INT_EDI_NOM
        [Column("IB_MAT_INT_EDI_NOM")]
        public string? IbMatIntEdiNom { get; set; }

        // IB_MAT_INT_EDI_APE
        [Column("IB_MAT_INT_EDI_APE")]
        public string? IbMatIntEdiApe { get; set; }

        // IB_MAT_INT_USR_PC
        [Column("IB_MAT_INT_USR_PC")]
        public string? IbMatIntUsrPc { get; set; }

        // IB_MAT_INT_USR_ID
        [Column("IB_MAT_INT_USR_ID")]
        public string? IbMatIntUsrId { get; set; }

        // IB_MAT_INT_USR_FEC
        [Column("IB_MAT_INT_USR_FEC")]
        public DateTime? IbMatIntUsrFec { get; set; }

        // IB_MAT_INT_USR_HOR
        [Column("IB_MAT_INT_USR_HOR")]
        public DateTime? IbMatIntUsrHor { get; set; }

        // IB_MAT_INT_CANT
        [Column("IB_MAT_INT_CANT")]
        public string? IbMatIntCant { get; set; }

        // CODIGO
        [Column("CODIGO")]
        public string? Codigo { get; set; }

        // IB_MAT_INT_NUM_1
        [Column("IB_MAT_INT_NUM_1")]
        public int? IbMatIntNum1 { get; set; }

        // IB_MAT_INT_NUM_2
        [Column("IB_MAT_INT_NUM_2")]
        public int? IbMatIntNum2 { get; set; }

        // IB_MAT_INT_NUM_3
        [Column("IB_MAT_INT_NUM_3")]
        public int? IbMatIntNum3 { get; set; }

        // IB_MAT_INT_TXT_1
        [Column("IB_MAT_INT_TXT_1")]
        public string? IbMatIntTxt1 { get; set; }

        // IB_MAT_INT_TXT_2
        [Column("IB_MAT_INT_TXT_2")]
        public string? IbMatIntTxt2 { get; set; }

        // IB_MAT_INT_TXT_3
        [Column("IB_MAT_INT_TXT_3")]
        public string? IbMatIntTxt3 { get; set; }

        // IB_MAT_INT_DTI_1
        [Column("IB_MAT_INT_DTI_1")]
        public DateTime? IbMatIntDti1 { get; set; }

        // IB_MAT_INT_DTI_2
        [Column("IB_MAT_INT_DTI_2")]
        public DateTime? IbMatIntDti2 { get; set; }

        // IB_MAT_INT_DTI_3
        [Column("IB_MAT_INT_DTI_3")]
        public DateTime? IbMatIntDti3 { get; set; }

        // IB_MAT_INT_MEM_1
        [Column("IB_MAT_INT_MEM_1")]
        public string? IbMatIntMem1 { get; set; }

        // IB_MAT_INT_MEM_2
        [Column("IB_MAT_INT_MEM_2")]
        public string? IbMatIntMem2 { get; set; }

        // IB_MAT_INT_MEN_3
        [Column("IB_MAT_INT_MEN_3")]
        public string? IbMatIntMen3 { get; set; }
    }
}