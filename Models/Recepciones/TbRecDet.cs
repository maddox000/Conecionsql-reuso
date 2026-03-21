
using ConexionSql.Models.Materiales;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ConexionSql.Models.Procesos;


namespace ConexionSql.Models.Recepciones
{
    [Table("TB_REC_DET")]
    public class TbRecDet
    {
        // Parte 1: Campos iniciales básicos
        [Key]
        [Column("TB_REC_DET_ID")]
        public int TbRecDetId { get; set; }

        [Column("TB_REC_DET_ID_FORM")]
        public int? TbRecDetIdForm { get; set; }

        [Column("TB_REC_DET_PC_LOG")]
        public string? TbRecDetPcLog { get; set; }

        [Column("TB_REC_DET_PC_USR")]
        public string? TbRecDetPcUsr { get; set; }

        [Column("TB_REC_ID")]
        public int TbRecId { get; set; }

        [Column("TB_REC_FEC")]
        public DateTime? TbRecFec { get; set; }

        [Column("TB_REC_HOR")]
        public DateTime? TbRecHor { get; set; }

        [Column("TB_REC_PER_ID")]
        public int? TbRecPerId { get; set; }

        [Column("TB_REC_PER_NOM")]
        public string? TbRecPerNom { get; set; }

        [Column("TB_REC_PER_APE")]
        public string? TbRecPerApe { get; set; }

        [Column("TB_REC_PER_CAR_ID")]
        public int? TbRecPerCarId { get; set; }

        [Column("TB_REC_PER_CAR_DEN")]
        public string? TbRecPerCarDen { get; set; }

        [Column("TB_REC_SEC_ORI_ID")]
        public int? TbRecSecOriId { get; set; }

        [Column("TB_REC_SEC_ORI_DEN")]
        public string? TbRecSecOriDen { get; set; }

        [Column("TB_REC_SEC_DES_ID")]
        public int? TbRecSecDesId { get; set; }

        [Column("TB_REC_SEC_DES_DEN")]
        public string? TbRecSecDesDen { get; set; }

        [Column("TB_REC_ORT_ID")]
        public int? TbRecOrtId { get; set; }

        [Column("TB_REC_ORT_DEN")]
        public string? TbRecOrtDen { get; set; }

        [Column("TB_REC_SEC_PER")]
        public string? TbRecSecPer { get; set; }

        [Column("TB_REC_DET_EME_OPC")]
        public bool TbRecDetEmeOpc { get; set; }

        [Column("TB_REC_DET_MAT_ID")]
        public int? TbRecDetMatId { get; set; }

        [Column("TB_REC_DET_MAT_DEN")]
        public string? TbRecDetMatDen { get; set; }

        [Column("TB_REC_DET_MAT_PR")]
        public string? TbRecDetMatPr { get; set; }

        [Column("TB_REC_DET_MAT_MTI_ID")]
        public int? TbRecDetMatMtiId { get; set; }

        [Column("TB_REC_DET_MAT_MTI_DEN")]
        public string? TbRecDetMatMtiDen { get; set; }

        [Column("TB_REC_DET_EST_ING_ID")]
        public int? TbRecDetEstIngId { get; set; }

        [Column("TB_REC_DET_EST_ING_DEN")]
        public string? TbRecDetEstIngDen { get; set; }

        [Column("TB_REC_DET_EST_ID")]
        public int? TbRecDetEstId { get; set; }

        [Column("TB_REC_DET_EST_DEN")]
        public string? TbRecDetEstDen { get; set; }

        [Column("TB_REC_DET_EPR_OPC")]
        public bool TbRecDetEprOpc { get; set; }

        [Column("TB_REC_DET_VEN")]
        public DateTime? TbRecDetVen { get; set; }

        [Column("TB_REC_DET_FEN")]
        public DateTime? TbRecDetFen { get; set; }

        [Column("TB_REC_DET_HEN")]
        public DateTime? TbRecDetHen { get; set; }

        [Column("TB_REC_DET_VOP_OPC")]
        public bool TbRecDetVopOpc { get; set; }

        [Column("TB_REC_DET_REP_ID")]
        public int? TbRecDetRepId { get; set; }

        [Column("TB_REC_DET_REP_TXT")]
        public string? TbRecDetRepTxt { get; set; }

        [Column("TB_REC_DET_REU_OPC")]
        public bool TbRecDetReuOpc { get; set; }

        [Column("TB_REC_DET_REU_ID")]
        public string? TbRecDetReuId { get; set; }

        [Column("TB_REC_DET_REU_DEN")]
        public string? TbRecDetReuDen { get; set; }

        [Column("TB_REC_DET_ORT_ID")]
        public int? TbRecDetOrtId { get; set; }

        [Column("TB_REC_DET_ORT_DEN")]
        public string? TbRecDetOrtDen { get; set; }

        [Column("TB_REC_DET_REU_CANT")]
        public int? TbRecDetReuCant { get; set; }

        [Column("TB_REC_DET_PRO_ID")]
        public int? TbRecDetProId { get; set; }

        [Column("TB_REC_DET_PRO_NOM")]
        public string? TbRecDetProNom { get; set; }

        [Column("TB_REC_DET_PRO_APE")]
        public string? TbRecDetProApe { get; set; }

        [Column("TB_REC_DET_PAC")]
        public string? TbRecDetPac { get; set; }

        [Column("TB_REC_DET_REM")]
        public string? TbRecDetRem { get; set; }

        [Column("TB_REC_DET_OBS")]
        public string? TbRecDetObs { get; set; }

        [Column("TB_REC_DET_MDE")]
        public bool TbRecDetMde { get; set; }

        [Column("TB_REC_DET_MCO")]
        public bool TbRecDetMco { get; set; }

        [Column("TB_REC_DET_REC_CANT")]
        public int? TbRecDetRecCant { get; set; }

        [Column("TB_REC_DET_REC_STOCK")]
        public int? TbRecDetRecStock { get; set; }

        [Column("TB_REC_DET_REC_TOT")]
        public int? TbRecDetRecTot { get; set; }

        [Column("TB_REC_DET_REC_UDE")]
        public int? TbRecDetRecUde { get; set; }

        [Column("TB_REC_DET_CANT")]
        public int TbRecDetCant { get; set; }

        [Column("TB_REC_DET_STOCK")]
        public int? TbRecDetStock { get; set; }

        [Column("TB_REC_DET_TOT")]
        public int? TbRecDetTot { get; set; }

        [Column("TB_REC_DET_LAV_CANT")]
        public int? TbRecDetLavCant { get; set; }

        [Column("TB_REC_DET_LAV_STOCK")]
        public int? TbRecDetLavStock { get; set; }

        [Column("TB_REC_DET_LAV_TOT")]
        public int? TbRecDetLavTot { get; set; }

        [Column("TB_REC_DET_LAV_UDE")]
        public int? TbRecDetLavUde { get; set; }

        [Column("TB_REC_DET_DEC_CANT")]
        public int? TbRecDetDecCant { get; set; }

        [Column("TB_REC_DET_DEC_STOCK")]
        public int? TbRecDetDecStock { get; set; }

        [Column("TB_REC_DET_DEC_TOT")]
        public int? TbRecDetDecTot { get; set; }

        [Column("TB_REC_DET_DEC_UDE")]
        public int? TbRecDetDecUde { get; set; }

        [Column("TB_REC_DET_TRA_CANT")]
        public int? TbRecDetTraCant { get; set; }

        [Column("TB_REC_DET_TRA_STOCK")]
        public int? TbRecDetTraStock { get; set; }

        [Column("TB_REC_DET_TRA_TOT")]
        public int? TbRecDetTraTot { get; set; }

        [Column("TB_REC_DET_TRA_UDE")]
        public int? TbRecDetTraUde { get; set; }

        [Column("TB_REC_DET_EMP_CANT")]
        public int? TbRecDetEmpCant { get; set; }

        [Column("TB_REC_DET_EMP_STOCK")]
        public int? TbRecDetEmpStock { get; set; }

        [Column("TB_REC_DET_EMP_TOT")]
        public int? TbRecDetEmpTot { get; set; }

        [Column("TB_REC_DET_EMP_UDE")]
        public int? TbRecDetEmpUde { get; set; }

        [Column("TB_REC_DET_PRO_ABO")]
        public int? TbRecDetProAbo { get; set; }

        [Column("TB_REC_DET_PRO_CANT")]
        public int? TbRecDetProCant { get; set; }

        [Column("TB_REC_DET_PRO_STOCK")]
        public int? TbRecDetProStock { get; set; }

        [Column("TB_REC_DET_PRO_TOT")]
        public int? TbRecDetProTot { get; set; }

        [Column("TB_REC_DET_PRO_UDE")]
        public int? TbRecDetProUde { get; set; }

        [Column("TB_REC_DET_ENT_CANT")]
        public int? TbRecDetEntCant { get; set; }

        [Column("TB_REC_DET_ENT_STOCK")]
        public int? TbRecDetEntStock { get; set; }

        [Column("TB_REC_DET_ENT_TOT")]
        public int? TbRecDetEntTot { get; set; }

        [Column("TB_REC_DET_ENT_UDE")]
        public int? TbRecDetEntUde { get; set; }

        [Column("TB_REC_DET_SEC_CANT")]
        public int? TbRecDetSecCant { get; set; }

        [Column("TB_REC_DET_SEC_STOCK")]
        public int? TbRecDetSecStock { get; set; }

        [Column("TB_REC_DET_SEC_TOT")]
        public int? TbRecDetSecTot { get; set; }

        [Column("TB_REC_DET_DEV_CANT")]
        public int? TbRecDetDevCant { get; set; }

        [Column("IB_MAT_VOL")]
        public int? IbMatVol { get; set; }

        [Column("TB_REC_DET_NUM_1")]
        public int? TbRecDetNum1 { get; set; }

        [Column("TB_REC_DET_NUM_2")]
        public int? TbRecDetNum2 { get; set; }

        [Column("TB_REC_DET_NUM_3")]
        public int? TbRecDetNum3 { get; set; }

        [Column("TB_REC_DET_TXT_1")]
        public string? TbRecDetTxt1 { get; set; }

        [Column("TB_REC_DET_TXT_2")]
        public string? TbRecDetTxt2 { get; set; }

        [Column("TB_REC_DET_TXT_3")]
        public string? TbRecDetTxt3 { get; set; }

        [Column("TB_REC_DET_DTI_1")]
        public DateTime? TbRecDetDti1 { get; set; }

        [Column("TB_REC_DET_DTI_2")]
        public DateTime? TbRecDetDti2 { get; set; }

        [Column("TB_REC_DET_DTI_3")]
        public DateTime? TbRecDetDti3 { get; set; }

        [Column("TB_REC_DET_MEM_1")]
        public string? TbRecDetMem1 { get; set; }

        [Column("TB_REC_DET_MEM_2")]
        public string? TbRecDetMem2 { get; set; }

        [Column("TB_REC_DET_MEM_3")]
        public string? TbRecDetMem3 { get; set; }

        [Column("TB_REC_DET_SEC_PROC_STOCK")]
        public int? TbRecDetSecProcStock { get; set; }

        [Column("TB_REC_DET_SEC_PROC_TOT")]
        public int? TbRecDetSecProcTot { get; set; }

        [Column("TB_REC_DET_PROC_SEC_STOCK")]
        public int? TbRecDetProcSecStock { get; set; }

        [Column("TB_REC_DET_SEC_REG_STOCK")]
        public int? TbRecDetSecRegStock { get; set; }

        [Column("TB_REC_DET_SEC_REG_TOT")]
        public int? TbRecDetSecRegTot { get; set; }

        [Column("TB_REC_DET_PMAT")]
        public float? TbRecDetPmat { get; set; }

        [Column("TB_REC_DET_MORT")]
        public int? TbRecDetMort { get; set; }

        [Column("TB_REC_DET_VOP_CK_1")]
        public bool TbRecDetVopCk1 { get; set; }

        [Column("TB_REC_DET_VOP_CK_2")]
        public bool TbRecDetVopCk2 { get; set; }

        [Column("TB_REC_DET_VOP_CK_3")]
        public bool TbRecDetVopCk3 { get; set; }

        [Column("TB_REC_DET_VOP_CK_4")]
        public bool TbRecDetVopCk4 { get; set; }

        [Column("TB_REC_DET_VOP_CK_5")]
        public bool TbRecDetVopCk5 { get; set; }

        [Column("TB_REC_DET_IVIS_OPC")]
        public bool TbRecDetIvisOpc { get; set; }

        [Column("TB_REC_DET_IVIS_OPC_NOM")]
        public string? TbRecDetIvisOpcNom { get; set; }

        [Column("TB_REC_DET_ACAJ_OPC")]
        public bool TbRecDetAcajOpc { get; set; }

        [Column("TB_REC_DET_ACAJ_OPC_NOM")]
        public string? TbRecDetAcajOpcNom { get; set; }

        [Column("TB_REC_DET_LOT")]
        public string? TbRecDetLot { get; set; }

        [Column("TB_REC_DET_CANT_MULT")]
        public int? TbRecDetCantMult { get; set; }

        [Column("TB_REC_DET_CANT_ELIM")]
        public int? TbRecDetCantElim { get; set; }

        [Column("TB_REC_DET_DAT")]
        public string? TbRecDetDat { get; set; }

        [Column("TB_REC_DET_MAT_ETI_ID")]
        public int? TbRecDetMatEtiId { get; set; }

        [Column("TB_REC_DET_MAT_ETI_DEN")]
        public string? TbRecDetMatEtiDen { get; set; }

        [Column("TB_REC_DET_PRO_PTI_ID")]
        public int? TbRecDetProPtiId { get; set; }

        [Column("TB_REC_DET_PRO_PTI_DEN")]
        public string? TbRecDetProPtiDen { get; set; }

        [Column("TB_REC_DET_FENT_STOCK")]
        public int? TbRecDetFentStock { get; set; }

        [Column("TB_REC_DET_FENT_TOT")]
        public int? TbRecDetFentTot { get; set; }

        [Column("TB_REC_DET_FREC_STOCK")]
        public int? TbRecDetFrecStock { get; set; }

        [Column("TB_REC_DET_FREC_TOT")]
        public int? TbRecDetFrecTot { get; set; }

        // Relación con IB_MAT (material)
        [ForeignKey("TbRecDetMatId")]

        [Column("TB_REC_DET_TRA_OPC")]
        public bool TbRecDetTraOpc { get; set; }


        [ForeignKey("TbRecDetMatId")]
        public IbMat? IbMat { get; set; }


    }


}
