using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexionSql.Models.Lavado
{
    [Table("TB_PRO_LAV")]
    public class TbProLav
    {
        [Column("TB_PRO_LAV_ID")]
        public int TbProLavId { get; set; }

        [Column("TB_PRO_LAV_ID_FORM")]
        public int? TbProLavIdForm { get; set; }

        [Column("TB_PRO_LAV_FEC")]
        public DateTime? TbProLavFec { get; set; }

        [Column("TB_PRO_LAV_HOR_INI")]
        public DateTime? TbProLavHorIni { get; set; }

        [Column("TB_PRO_LAV_HOR_FIN")]
        public DateTime? TbProLavHorFin { get; set; }

        [Column("TB_PRO_LAV_PER_ID")]
        public int? TbProLavPerId { get; set; }

        [Column("TB_PRO_LAV_PER_APE")]
        public string? TbProLavPerApe { get; set; }

        [Column("TB_PRO_LAV_PER_NOM")]
        public string? TbProLavPerNom { get; set; }

        [Column("TB_PRO_LAV_PER_CAR_ID")]
        public int? TbProLavPerCarId { get; set; }

        [Column("TB_PRO_LAV_PER_CAR_DEN")]
        public string? TbProLavPerCarDen { get; set; }

        [Column("TB_PRO_LAV_PC_LOG")]
        public string? TbProLavPcLog { get; set; }

        [Column("TB_PRO_LAV_PC_USR")]
        public string? TbProLavPcUsr { get; set; }

        [Column("TB_PRO_LAV_SUP_PC_LOG")]
        public string? TbProLavSupPcLog { get; set; }

        [Column("TB_PRO_LAV_SUP_PC_USR")]
        public string? TbProLavSupPcUsr { get; set; }

        [Column("TB_PRO_LAV_PTI_ID")]
        public int? TbProLavPtiId { get; set; }

        [Column("TB_PRO_LAV_PTI_DEN")]
        public string? TbProLavPtiDen { get; set; }

        [Column("TB_PRO_LAV_TCI_ID")]
        public int? TbProLavTciId { get; set; }

        [Column("TB_PRO_LAV_TCI_DEN")]
        public string? TbProLavTciDen { get; set; }

        [Column("TB_PRO_LAV_EQU_ID")]
        public int? TbProLavEquId { get; set; }

        [Column("TB_PRO_LAV_EQU_DEN")]
        public string? TbProLavEquDen { get; set; }

        [Column("TB_PRO_LAV_EQU_NUM")]
        public string? TbProLavEquNum { get; set; }

        [Column("TB_PRO_IB_EQU_TEQ_ID")]
        public int? TbProIbEquTeqId { get; set; }

        [Column("TB_PRO_IB_EQU_TEQ_DEN")]
        public string? TbProIbEquTeqDen { get; set; }

        [Column("TB_PRO_LAV_EQU_MAR_ID")]
        public int? TbProLavEquMarId { get; set; }

        [Column("TB_PRO_LAV_EQU_MAR_DEN")]
        public string? TbProLavEquMarDen { get; set; }

        [Column("TB_PRO_LAV_EQU_SER")]
        public string? TbProLavEquSer { get; set; }

        [Column("TB_PRO_LAV_EQU_MOD")]
        public string? TbProLavEquMod { get; set; }

        [Column("TB_PRO_LAV_EQU_CAP")]
        public int? TbProLavEquCap { get; set; }

        [Column("TB_PRO_LAV_EQU_CAPU")]
        public int? TbProLavEquCapu { get; set; }

        [Column("TB_PRO_LAV_EQU_CAPR")]
        public int? TbProLavEquCapr { get; set; }

        [Column("TB_PRO_LAV_EQU_PCO")]
        public int? TbProLavEquPco { get; set; }

        [Column("TB_PRO_LAV_EQU_PVE")]
        public int? TbProLavEquPve { get; set; }

        [Column("TB_PRO_LAV_EQU_VOL")]
        public int? TbProLavEquVol { get; set; }

        [Column("TB_PRO_LAV_NUM")]
        public int? TbProLavNum { get; set; }

        [Column("TB_PRO_LAV_UPRO")]
        public int? TbProLavUpro { get; set; }

        [Column("TB_PRO_LAV_EST_ID")]
        public int? TbProLavEstId { get; set; }

        [Column("TB_PRO_LAV_EST_DEN")]
        public string? TbProLavEstDen { get; set; }

        [Column("TB_PRO_LAV_EST_FEC")]
        public DateTime? TbProLavEstFec { get; set; }

        [Column("TB_PRO_LAV_OBS")]
        public string? TbProLavObs { get; set; }

        [Column("TB_PRO_LAV_PEST_1")]
        public int? TbProLavPest1 { get; set; }

        [Column("TB_PRO_LAV_PEST_2")]
        public int? TbProLavPest2 { get; set; }

        [Column("TB_PRO_LAV_PEST_3")]
        public int? TbProLavPest3 { get; set; }

        [Column("TB_PRO_LAV_PEST_4")]
        public int? TbProLavPest4 { get; set; }

        [Column("TB_PRO_LAV_PEST_TOT")]
        public int? TbProLavPestTot { get; set; }

        [Column("TB_PRO_LAV_DETG_MAR_ID")]
        public int? TbProLavDetgMarId { get; set; }

        [Column("TB_PRO_LAV_DETG_MAR_DEN")]
        public string? TbProLavDetgMarDen { get; set; }

        [Column("TB_PRO_LAV_DETG_LOT")]
        public string? TbProLavDetgLot { get; set; }

        [Column("TB_PRO_LAV_DETG_VEN")]
        public string? TbProLavDetgVen { get; set; }

        [Column("TB_PRO_LAV_DETG_DIL_ID")]
        public int? TbProLavDetgDilId { get; set; }

        [Column("TB_PRO_LAV_DETG_DIL_DEN")]
        public string? TbProLavDetgDilDen { get; set; }

        [Column("TB_PRO_LAV_DETG_CTO_ID")]
        public int? TbProLavDetgCtoId { get; set; }

        [Column("TB_PRO_LAV_DETG_CTO_DEN")]
        public string? TbProLavDetgCtoDen { get; set; }

        [Column("TB_PRO_LAV_UBIE_ID")]
        public int? TbProLavUbieId { get; set; }

        [Column("TB_PRO_LAV_UBIE_DEN")]
        public string? TbProLavUbieDen { get; set; }

        [Column("TB_PRO_LAV_CONT_ID")]
        public int? TbProLavContId { get; set; }

        [Column("TB_PRO_LAV_CONT_DEN")]
        public string? TbProLavContDen { get; set; }

        [Column("TB_PRO_LAV_UBIE_OPC")]
        public bool TbProLavUbieOpc { get; set; }

        [Column("TB_PRO_LAV_CONL_OPC")]
        public bool TbProLavConlOpc { get; set; }

        [Column("TB_PRO_LAV_LPA_PER_ID")]
        public int TbProLavLpaPerId { get; set; }

        [Column("TB_PRO_LAV_LPA_PER_NOM")]
        public string? TbProLavLpaPerNom { get; set; }

        [Column("TB_PRO_LAV_LPA_FEC")]
        public DateTime? TbProLavLpaFec { get; set; }

        [Column("TB_PRO_LAV_LPA_CK_1")]
        public bool TbProLavLpaCk1 { get; set; }

        [Column("TB_PRO_LAV_LPA_CK_2")]
        public bool TbProLavLpaCk2 { get; set; }

        [Column("TB_PRO_LAV_LPA_CK_3")]
        public bool TbProLavLpaCk3 { get; set; }

        [Column("TB_PRO_LAV_LPA_CK_4")]
        public bool TbProLavLpaCk4 { get; set; }

        [Column("TB_PRO_LAV_LPA_CK_5")]
        public bool TbProLavLpaCk5 { get; set; }

        [Column("TB_PRO_LAV_LMAT")]
        public int? TbProLavLmat { get; set; }

        [Column("TB_PRO_LAV_CLI_ID")]
        public int? TbProLavCliId { get; set; }

        [Column("TB_PRO_LAV_CLI_DEN")]
        public string? TbProLavCliDen { get; set; }

        [Column("TB_PRO_DEC_LAV_TEMP")]
        public double? TbProDecLavTemp { get; set; }

        [Column("TB_PRO_DEC_AGU_VOL")]
        public double? TbProDecAguVol { get; set; }

        [Column("TB_PRO_DEC_DET_VOL")]
        public double? TbProDecDetVol { get; set; }

        [Column("TB_PRO_LAV_PTE_IB_PTE_ID_1")]
        public int? TbProLavPteIbPteId1 { get; set; }

        [Column("TB_PRO_LAV_PTE_IB_PTE_DEN_1")]
        public string? TbProLavPteIbPteDen1 { get; set; }

        [Column("TB_PRO_LAV_PTE_IB_PTE_CANT_1")]
        public int? TbProLavPteIbPteCant1 { get; set; }

        [Column("TB_PRO_LAV_PTE_IB_PTE_ID_2")]
        public int? TbProLavPteIbPteId2 { get; set; }

        [Column("TB_PRO_LAV_PTE_IB_PTE_DEN_2")]
        public string? TbProLavPteIbPteDen2 { get; set; }

        [Column("TB_PRO_LAV_PTE_IB_PTE_CANT_2")]
        public int? TbProLavPteIbPteCant2 { get; set; }

        [Column("TB_PRO_LAV_PTE_IB_PTE_ID_3")]
        public int? TbProLavPteIbPteId3 { get; set; }

        [Column("TB_PRO_LAV_PTE_IB_PTE_DEN_3")]
        public string? TbProLavPteIbPteDen3 { get; set; }

        [Column("TB_PRO_LAV_PTE_IB_PTE_CANT_3")]
        public int? TbProLavPteIbPteCant3 { get; set; }

        [Column("TB_PRO_LAV_PTE_IB_PTE_ID_4")]
        public int? TbProLavPteIbPteId4 { get; set; }

        [Column("TB_PRO_LAV_PTE_IB_PTE_DEN_4")]
        public string? TbProLavPteIbPteDen4 { get; set; }

        [Column("TB_PRO_LAV_PTE_IB_PTE_CANT_4")]
        public int? TbProLavPteIbPteCant4 { get; set; }

        [Column("TB_PRO_LAV_PTE_IB_PTE_ID_5")]
        public int? TbProLavPteIbPteId5 { get; set; }

        [Column("TB_PRO_LAV_PTE_IB_PTE_DEN_5")]
        public string? TbProLavPteIbPteDen5 { get; set; }

        [Column("TB_PRO_LAV_PTE_IB_PTE_CANT_5")]
        public int? TbProLavPteIbPteCant5 { get; set; }

        [Column("TB_PRO_LAV_PTE_IB_PTE_ID_6")]
        public int? TbProLavPteIbPteId6 { get; set; }

        [Column("TB_PRO_LAV_PTE_IB_PTE_DEN_6")]
        public string? TbProLavPteIbPteDen6 { get; set; }

        [Column("TB_PRO_LAV_PTE_IB_PTE_CANT_6")]
        public int? TbProLavPteIbPteCant6 { get; set; }

        [Column("TB_PRO_LAV_MTE_IB_PTE_ID_1")]
        public int? TbProLavMteIbPteId1 { get; set; }

        [Column("TB_PRO_LAV_MTE_IB_PTE_DEN_1")]
        public string? TbProLavMteIbPteDen1 { get; set; }

        [Column("TB_PRO_LAV_MTE_IB_PTE_CANT_1")]
        public int? TbProLavMteIbPteCant1 { get; set; }

        [Column("TB_PRO_LAV_MTE_IB_PTE_ID_2")]
        public int? TbProLavMteIbPteId2 { get; set; }

        [Column("TB_PRO_LAV_MTE_IB_PTE_DEN_2")]
        public string? TbProLavMteIbPteDen2 { get; set; }

        [Column("TB_PRO_LAV_MTE_IB_PTE_CANT_2")]
        public int? TbProLavMteIbPteCant2 { get; set; }

        [Column("TB_PRO_LAV_MTE_IB_PTE_ID_3")]
        public int? TbProLavMteIbPteId3 { get; set; }

        [Column("TB_PRO_LAV_MTE_IB_PTE_DEN_3")]
        public string? TbProLavMteIbPteDen3 { get; set; }

        [Column("TB_PRO_LAV_MTE_IB_PTE_CANT_3")]
        public int? TbProLavMteIbPteCant3 { get; set; }

        [Column("TB_PRO_LAV_MTE_IB_PTE_ID_4")]
        public int? TbProLavMteIbPteId4 { get; set; }

        [Column("TB_PRO_LAV_MTE_IB_PTE_DEN_4")]
        public string? TbProLavMteIbPteDen4 { get; set; }

        [Column("TB_PRO_LAV_MTE_IB_PTE_CANT_4")]
        public int? TbProLavMteIbPteCant4 { get; set; }

        [Column("TB_PRO_LAV_MTE_IB_PTE_ID_5")]
        public int? TbProLavMteIbPteId5 { get; set; }

        [Column("TB_PRO_LAV_MTE_IB_PTE_DEN_5")]
        public string? TbProLavMteIbPteDen5 { get; set; }

        [Column("TB_PRO_LAV_MTE_IB_PTE_CANT_5")]
        public int? TbProLavMteIbPteCant5 { get; set; }

        [Column("TB_PRO_LAV_MTE_IB_PTE_ID_6")]
        public int? TbProLavMteIbPteId6 { get; set; }

        [Column("TB_PRO_LAV_MTE_IB_PTE_DEN_6")]
        public string? TbProLavMteIbPteDen6 { get; set; }

        [Column("TB_PRO_LAV_MTE_IB_PTE_CANT_6")]
        public int? TbProLavMteIbPteCant6 { get; set; }

        [Column("TB_PRO_LAV_NUM_1")]
        public int? TbProLavNum1 { get; set; }

        [Column("TB_PRO_LAV_NUM_2")]
        public int? TbProLavNum2 { get; set; }

        [Column("TB_PRO_LAV_NUM_3")]
        public int? TbProLavNum3 { get; set; }

        [Column("TB_PRO_LAV_NUM_4")]
        public int? TbProLavNum4 { get; set; }

        [Column("TB_PRO_LAV_NUM_5")]
        public int? TbProLavNum5 { get; set; }

        [Column("TB_PRO_LAV_TXT_1")]
        public string? TbProLavTxt1 { get; set; }

        [Column("TB_PRO_LAV_TXT_2")]
        public string? TbProLavTxt2 { get; set; }

        [Column("TB_PRO_LAV_TXT_3")]
        public string? TbProLavTxt3 { get; set; }

        [Column("TB_PRO_LAV_TXT_4")]
        public string? TbProLavTxt4 { get; set; }

        [Column("TB_PRO_LAV_TXT_5")]
        public string? TbProLavTxt5 { get; set; }

        [Column("TB_PRO_LAV_DTI_1")]
        public DateTime? TbProLavDti1 { get; set; }

        [Column("TB_PRO_LAV_DTI_2")]
        public DateTime? TbProLavDti2 { get; set; }

        [Column("TB_PRO_LAV_DTI_3")]
        public DateTime? TbProLavDti3 { get; set; }

        [Column("TB_PRO_LAV_DTI_4")]
        public DateTime? TbProLavDti4 { get; set; }

        [Column("TB_PRO_LAV_DTI_5")]
        public DateTime? TbProLavDti5 { get; set; }

        [Column("TB_PRO_LAV_INI")]
        public DateTime? TbProLavIni { get; set; }

        [Column("TB_PRO_LAV_FIN")]
        public DateTime? TbProLavFin { get; set; }

        [Column("TB_PRO_LAV_INI_HOR")]
        public DateTime? TbProLavIniHor { get; set; }

        [Column("TB_PRO_LAV_FIN_HOR")]
        public DateTime? TbProLavFinHor { get; set; }

        [Column("TB_PRO_LAV_1")]
        public int? TbProLav1 { get; set; }

        [Column("TB_PRO_LAV_2")]
        public int? TbProLav2 { get; set; }

        [Column("TB_PRO_LAV_3")]
        public int? TbProLav3 { get; set; }

        [Column("TB_PRO_LAV_4")]
        public int? TbProLav4 { get; set; }

        [Column("TB_PRO_LAV_5")]
        public int? TbProLav5 { get; set; }

        [Column("TB_PRO_LAV_6")]
        public int? TbProLav6 { get; set; }

        [Column("TB_PRO_LAV_7")]
        public int? TbProLav7 { get; set; }

        [Column("TB_PRO_LAV_8")]
        public int? TbProLav8 { get; set; }

        [Column("TB_PRO_LAV_9")]
        public int? TbProLav9 { get; set; }

        [Column("TB_PRO_LAV_10")]
        public int? TbProLav10 { get; set; }

        [Column("TB_PRO_LAV_11")]
        public int? TbProLav11 { get; set; }

        [Column("TB_PRO_LAV_12")]
        public int? TbProLav12 { get; set; }

        [Column("TB_PRO_LAV_13")]
        public int? TbProLav13 { get; set; }

        [Column("TB_PRO_LAV_14")]
        public int? TbProLav14 { get; set; }

        [Column("TB_PRO_LAV_15")]
        public int? TbProLav15 { get; set; }

        [Column("TB_PRO_LAV_16")]
        public int? TbProLav16 { get; set; }

        [Column("TB_PRO_LAV_17")]
        public int? TbProLav17 { get; set; }

        [Column("TB_PRO_LAV_18")]
        public int? TbProLav18 { get; set; }

        [Column("TB_PRO_LAV_19")]
        public int? TbProLav19 { get; set; }

        [Column("TB_PRO_LAV_20")]
        public int? TbProLav20 { get; set; }

        [Column("TB_PRO_LAV_21")]
        public int? TbProLav21 { get; set; }

        [Column("TB_PRO_LAV_22")]
        public int? TbProLav22 { get; set; }

        [Column("TB_PRO_LAV_23")]
        public int? TbProLav23 { get; set; }

        [Column("TB_PRO_LAV_24")]
        public int? TbProLav24 { get; set; }

        [Column("TB_PRO_LAV_25")]
        public int? TbProLav25 { get; set; }

        [Column("TB_PRO_LAV_26")]
        public int? TbProLav26 { get; set; }

        [Column("TB_PRO_LAV_27")]
        public int? TbProLav27 { get; set; }

        [Column("TB_PRO_LAV_28")]
        public int? TbProLav28 { get; set; }
    }
}
