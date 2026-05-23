using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexionSql.Models.Recepciones.Ortopedias
{
    [Table("TB_REC_ORT")]
    public class TbRecOrt
    {
        // TB_REC_ORT_ID
        [Key]
        [Column("TB_REC_ORT_ID")]
        public int TbRecOrtId { get; set; }

        // TB_REC_ORT_ID_FORM
        [Column("TB_REC_ORT_ID_FORM")]
        public int? TbRecOrtIdForm { get; set; }

        // TB_REC_ORT_FEC
        [Column("TB_REC_ORT_FEC")]
        public DateTime? TbRecOrtFec { get; set; }

        // TB_REC_ORT_HOR_INI
        [Column("TB_REC_ORT_HOR_INI")]
        public DateTime? TbRecOrtHorIni { get; set; }

        // TB_REC_ORT_HOR_FIN
        [Column("TB_REC_ORT_HOR_FIN")]
        public DateTime? TbRecOrtHorFin { get; set; }

        // TB_REC_ID
        [Column("TB_REC_ID")]
        public int? TbRecId { get; set; }

        // TB_REC_ORT_PER_ID
        [Column("TB_REC_ORT_PER_ID")]
        public int? TbRecOrtPerId { get; set; }

        // TB_REC_ORT_PER_NOM
        [Column("TB_REC_ORT_PER_NOM")]
        public string? TbRecOrtPerNom { get; set; }

        // TB_REC_ORT_PER_APE
        [Column("TB_REC_ORT_PER_APE")]
        public string? TbRecOrtPerApe { get; set; }

        // TB_REC_ORT_PER_CAR_ID
        [Column("TB_REC_ORT_PER_CAR_ID")]
        public int? TbRecOrtPerCarId { get; set; }

        // TB_REC_ORT_PER_CAR_DEN
        [Column("TB_REC_ORT_PER_CAR_DEN")]
        public string? TbRecOrtPerCarDen { get; set; }

        // TB_REC_ORT_REG_PC_LOG
        [Column("TB_REC_ORT_REG_PC_LOG")]
        public string? TbRecOrtRegPcLog { get; set; }

        // TB_REC_ORT_REG_PC_USR
        [Column("TB_REC_ORT_REG_PC_USR")]
        public string? TbRecOrtRegPcUsr { get; set; }

        // TB_REC_ORT_UPRO
        [Column("TB_REC_ORT_UPRO")]
        public int? TbRecOrtUpro { get; set; }

        // TB_REC_ORT_ORT_ID
        [Column("TB_REC_ORT_ORT_ID")]
        public int? TbRecOrtOrtId { get; set; }

        // TB_REC_ORT_ORT_DEN
        [Column("TB_REC_ORT_ORT_DEN")]
        public string? TbRecOrtOrtDen { get; set; }

        // TB_REC_ORT_ORT_PER
        [Column("TB_REC_ORT_ORT_PER")]
        public string? TbRecOrtOrtPer { get; set; }

        // TB_REC_ORT_REM
        [Column("TB_REC_ORT_REM")]
        public string? TbRecOrtRem { get; set; }

        // TB_REC_ORT_PRO_ID
        [Column("TB_REC_ORT_PRO_ID")]
        public int? TbRecOrtProId { get; set; }

        // TB_REC_ORT_PRO_NOM
        [Column("TB_REC_ORT_PRO_NOM")]
        public string? TbRecOrtProNom { get; set; }

        // TB_REC_ORT_PRO_APE
        [Column("TB_REC_ORT_PRO_APE")]
        public string? TbRecOrtProApe { get; set; }

        // TB_REC_ORT_PAC
        [Column("TB_REC_ORT_PAC")]
        public string? TbRecOrtPac { get; set; }

        // TB_REC_ORT_FEC_PROC
        [Column("TB_REC_ORT_FEC_PROC")]
        public DateTime? TbRecOrtFecProc { get; set; }

        // TB_REC_ORT_HOR_PROC
        [Column("TB_REC_ORT_HOR_PROC")]
        public DateTime? TbRecOrtHorProc { get; set; }

        // TB_REC_ORT_PAC_SSA_DEN
        [Column("TB_REC_ORT_PAC_SSA_DEN")]
        public string? TbRecOrtPacSsaDen { get; set; }

        // TB_REC_ORT_CANT_REC_CIN
        [Column("TB_REC_ORT_CANT_REC_CIN")]
        public int? TbRecOrtCantRecCin { get; set; }

        // TB_REC_ORT_CANT_REC_CIN_CQ
        [Column("TB_REC_ORT_CANT_REC_CIN_CQ")]
        public int? TbRecOrtCantRecCinCq { get; set; }

        // TB_REC_ORT_CANT_REC_CIN_DEV
        [Column("TB_REC_ORT_CANT_REC_CIN_DEV")]
        public int? TbRecOrtCantRecCinDev { get; set; }

        // TB_REC_ORT_CANT_REC_INS
        [Column("TB_REC_ORT_CANT_REC_INS")]
        public int? TbRecOrtCantRecIns { get; set; }

        // TB_REC_ORT_CANT_REC_INS_CQ
        [Column("TB_REC_ORT_CANT_REC_INS_CQ")]
        public int? TbRecOrtCantRecInsCq { get; set; }

        // TB_REC_ORT_CANT_REC_INS_DEV
        [Column("TB_REC_ORT_CANT_REC_INS_DEV")]
        public int? TbRecOrtCantRecInsDev { get; set; }

        // TB_REC_ORT_CANT_REC_EST
        [Column("TB_REC_ORT_CANT_REC_EST")]
        public int? TbRecOrtCantRecEst { get; set; }

        // TB_REC_ORT_CANT_REC_EST_CQ
        [Column("TB_REC_ORT_CANT_REC_EST_CQ")]
        public int? TbRecOrtCantRecEstCq { get; set; }

        // TB_REC_ORT_CANT_REC_EST_DEV
        [Column("TB_REC_ORT_CANT_REC_EST_DEV")]
        public int? TbRecOrtCantRecEstDev { get; set; }

        // TB_REC_ORT_CANT_REC_VS
        [Column("TB_REC_ORT_CANT_REC_VS")]
        public int? TbRecOrtCantRecVs { get; set; }

        // TB_REC_ORT_CANT_REC_VS_CQ
        [Column("TB_REC_ORT_CANT_REC_VS_CQ")]
        public int? TbRecOrtCantRecVsCq { get; set; }

        // TB_REC_ORT_CANT_REC_VS_DEV
        [Column("TB_REC_ORT_CANT_REC_VS_DEV")]
        public int? TbRecOrtCantRecVsDev { get; set; }

        // TB_REC_ORT_CANT_REC
        [Column("TB_REC_ORT_CANT_REC")]
        public int? TbRecOrtCantRec { get; set; }

        // TB_REC_ORT_CANT_CQ
        [Column("TB_REC_ORT_CANT_CQ")]
        public int? TbRecOrtCantCq { get; set; }

        // TB_REC_ORT_CANT_DEV
        [Column("TB_REC_ORT_CANT_DEV")]
        public int? TbRecOrtCantDev { get; set; }

        // TB_REC_ORT_EST
        [Column("TB_REC_ORT_EST")]
        public int? TbRecOrtEst { get; set; }

        // TB_REC_ORT_NOE
        [Column("TB_REC_ORT_NOE")]
        public int? TbRecOrtNoe { get; set; }

        // TB_REC_ORT_OBS_REC
        [Column("TB_REC_ORT_OBS_REC")]
        public string? TbRecOrtObsRec { get; set; }

        // TB_REC_ORT_OBS_CQ
        [Column("TB_REC_ORT_OBS_CQ")]
        public string? TbRecOrtObsCq { get; set; }

        // TB_REC_ORT_OBS_DEV
        [Column("TB_REC_ORT_OBS_DEV")]
        public string? TbRecOrtObsDev { get; set; }

        // TB_REC_ORT_PER_ID_CQ
        [Column("TB_REC_ORT_PER_ID_CQ")]
        public int? TbRecOrtPerIdCq { get; set; }

        // TB_REC_ORT_PER_NOM_CQ
        [Column("TB_REC_ORT_PER_NOM_CQ")]
        public string? TbRecOrtPerNomCq { get; set; }

        // TB_REC_ORT_PER_APE_CQ
        [Column("TB_REC_ORT_PER_APE_CQ")]
        public string? TbRecOrtPerApeCq { get; set; }

        // TB_REC_ORT_PER_CAR_ID_CQ
        [Column("TB_REC_ORT_PER_CAR_ID_CQ")]
        public int? TbRecOrtPerCarIdCq { get; set; }

        // TB_REC_ORT_PER_CAR_DEN_CQ
        [Column("TB_REC_ORT_PER_CAR_DEN_CQ")]
        public string? TbRecOrtPerCarDenCq { get; set; }

        // TB_REC_ORT_CQ_PC_LOG
        [Column("TB_REC_ORT_CQ_PC_LOG")]
        public string? TbRecOrtCqPcLog { get; set; }

        // TB_REC_ORT_CQ_PC_USR
        [Column("TB_REC_ORT_CQ_PC_USR")]
        public string? TbRecOrtCqPcUsr { get; set; }

        // TB_REC_ORT_CQ_FEC
        [Column("TB_REC_ORT_CQ_FEC")]
        public DateTime? TbRecOrtCqFec { get; set; }

        // TB_REC_ORT_CQ_HOR
        [Column("TB_REC_ORT_CQ_HOR")]
        public DateTime? TbRecOrtCqHor { get; set; }

        // TB_REC_ORT_ORT_PER_CQ
        [Column("TB_REC_ORT_ORT_PER_CQ")]
        public string? TbRecOrtOrtPerCq { get; set; }

        // TB_REC_ORT_CQ_EST
        [Column("TB_REC_ORT_CQ_EST")]
        public bool TbRecOrtCqEst { get; set; }

        // TB_REC_ORT_PER_ID_DEV
        [Column("TB_REC_ORT_PER_ID_DEV")]
        public int? TbRecOrtPerIdDev { get; set; }

        // TB_REC_ORT_PER_NOM_DEV
        [Column("TB_REC_ORT_PER_NOM_DEV")]
        public string? TbRecOrtPerNomDev { get; set; }

        // TB_REC_ORT_PER_APE_DEV
        [Column("TB_REC_ORT_PER_APE_DEV")]
        public string? TbRecOrtPerApeDev { get; set; }

        // TB_REC_ORT_PER_CAR_ID_DEV
        [Column("TB_REC_ORT_PER_CAR_ID_DEV")]
        public int? TbRecOrtPerCarIdDev { get; set; }

        // TB_REC_ORT_PER_CAR_DEN_DEV
        [Column("TB_REC_ORT_PER_CAR_DEN_DEV")]
        public string? TbRecOrtPerCarDenDev { get; set; }

        // TB_REC_ORT_DEV_PC_LOG
        [Column("TB_REC_ORT_DEV_PC_LOG")]
        public string? TbRecOrtDevPcLog { get; set; }

        // TB_REC_ORT_DEV_PC_USR
        [Column("TB_REC_ORT_DEV_PC_USR")]
        public string? TbRecOrtDevPcUsr { get; set; }

        // TB_REC_ORT_DEV_FEC
        [Column("TB_REC_ORT_DEV_FEC")]
        public DateTime? TbRecOrtDevFec { get; set; }

        // TB_REC_ORT_DEV_HOR
        [Column("TB_REC_ORT_DEV_HOR")]
        public DateTime? TbRecOrtDevHor { get; set; }

        // TB_REC_ORT_ORT_PER_DEV
        [Column("TB_REC_ORT_ORT_PER_DEV")]
        public string? TbRecOrtOrtPerDev { get; set; }

        // TB_REC_ORT_DEV_EST
        [Column("TB_REC_ORT_DEV_EST")]
        public bool TbRecOrtDevEst { get; set; }

        // TB_REC_ORT_NUM_1
        [Column("TB_REC_ORT_NUM_1")]
        public int? TbRecOrtNum1 { get; set; }

        // TB_REC_ORT_NUM_2
        [Column("TB_REC_ORT_NUM_2")]
        public int? TbRecOrtNum2 { get; set; }

        // TB_REC_ORT_NUM_3
        [Column("TB_REC_ORT_NUM_3")]
        public int? TbRecOrtNum3 { get; set; }

        // TB_REC_ORT_TXT_1
        [Column("TB_REC_ORT_TXT_1")]
        public string? TbRecOrtTxt1 { get; set; }

        // TB_REC_ORT_TXT_2
        [Column("TB_REC_ORT_TXT_2")]
        public string? TbRecOrtTxt2 { get; set; }

        // TB_REC_ORT_TXT_3
        [Column("TB_REC_ORT_TXT_3")]
        public string? TbRecOrtTxt3 { get; set; }

        // TB_REC_ORT_DTI_1
        [Column("TB_REC_ORT_DTI_1")]
        public DateTime? TbRecOrtDti1 { get; set; }

        // TB_REC_ORT_DTI_2
        [Column("TB_REC_ORT_DTI_2")]
        public DateTime? TbRecOrtDti2 { get; set; }

        // TB_REC_ORT_DTI_3
        [Column("TB_REC_ORT_DTI_3")]
        public DateTime? TbRecOrtDti3 { get; set; }

        // TB_REC_ORT_MEM_1
        [Column("TB_REC_ORT_MEM_1")]
        public string? TbRecOrtMem1 { get; set; }

        // TB_REC_ORT_MEM_2
        [Column("TB_REC_ORT_MEM_2")]
        public string? TbRecOrtMem2 { get; set; }

        // TB_REC_ORT_MEM_3
        [Column("TB_REC_ORT_MEM_3")]
        public string? TbRecOrtMem3 { get; set; }

        // TB_REC_ORT_PER_ID_DEV_EST
        [Column("TB_REC_ORT_PER_ID_DEV_EST")]
        public int? TbRecOrtPerIdDevEst { get; set; }

        // TB_REC_ORT_PER_NOM_DEV_EST
        [Column("TB_REC_ORT_PER_NOM_DEV_EST")]
        public string? TbRecOrtPerNomDevEst { get; set; }

        // TB_REC_ORT_PER_APE_DEV_EST
        [Column("TB_REC_ORT_PER_APE_DEV_EST")]
        public string? TbRecOrtPerApeDevEst { get; set; }

        // TB_REC_ORT_PER_CAR_ID_DEV_EST
        [Column("TB_REC_ORT_PER_CAR_ID_DEV_EST")]
        public int? TbRecOrtPerCarIdDevEst { get; set; }

        // TB_REC_ORT_PER_CAR_DEN_DEV_EST
        [Column("TB_REC_ORT_PER_CAR_DEN_DEV_EST")]
        public string? TbRecOrtPerCarDenDevEst { get; set; }

        // TB_REC_ORT_DEV_EST_PC_LOG
        [Column("TB_REC_ORT_DEV_EST_PC_LOG")]
        public string? TbRecOrtDevEstPcLog { get; set; }

        // TB_REC_ORT_DEV_EST_PC_USR
        [Column("TB_REC_ORT_DEV_EST_PC_USR")]
        public string? TbRecOrtDevEstPcUsr { get; set; }

        // TB_REC_ORT_DEV_EST_FEC
        [Column("TB_REC_ORT_DEV_EST_FEC")]
        public DateTime? TbRecOrtDevEstFec { get; set; }

        // TB_REC_ORT_DEV_EST_HOR
        [Column("TB_REC_ORT_DEV_EST_HOR")]
        public DateTime? TbRecOrtDevEstHor { get; set; }

        // TB_REC_ORT_ORT_PER_DEV_EST
        [Column("TB_REC_ORT_ORT_PER_DEV_EST")]
        public string? TbRecOrtOrtPerDevEst { get; set; }

        // TB_REC_ORT_DEV_EST_EST
        [Column("TB_REC_ORT_DEV_EST_EST")]
        public bool TbRecOrtDevEstEst { get; set; }

        // TB_REC_ORT_CANT_REC_CIN_DEV_EST
        [Column("TB_REC_ORT_CANT_REC_CIN_DEV_EST")]
        public int? TbRecOrtCantRecCinDevEst { get; set; }

        // TB_REC_ORT_CANT_REC_INS_DEV_EST
        [Column("TB_REC_ORT_CANT_REC_INS_DEV_EST")]
        public int? TbRecOrtCantRecInsDevEst { get; set; }

        // TB_REC_ORT_CANT_REC_EST_DEV_EST
        [Column("TB_REC_ORT_CANT_REC_EST_DEV_EST")]
        public int? TbRecOrtCantRecEstDevEst { get; set; }

        // TB_REC_ORT_CANT_REC_VS_DEV_EST
        [Column("TB_REC_ORT_CANT_REC_VS_DEV_EST")]
        public int? TbRecOrtCantRecVsDevEst { get; set; }

        // TB_REC_ORT_CANT_DEV_EST
        [Column("TB_REC_ORT_CANT_DEV_EST")]
        public int? TbRecOrtCantDevEst { get; set; }

        // TB_REC_ORT_OBS_DEV_EST
        [Column("TB_REC_ORT_OBS_DEV_EST")]
        public string? TbRecOrtObsDevEst { get; set; }
    }
}