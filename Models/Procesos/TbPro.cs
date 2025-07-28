using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexionSql.Models.Procesos
{
    [Table("TB_PRO")]
    public class TbPro
    {
        [Column("TB_PRO_ID")]
        public int TbProId { get; set; } 

        [Column("TB_PRO_ID_FORM")]
        public int? TbProIdForm { get; set; }

        [Column("TB_PRO_FEC")]
        public DateTime? TbProFec { get; set; }

        [Column("TB_PRO_HOR_INI")]
        public DateTime? TbProHorIni { get; set; }

        [Column("TB_PRO_HOR_FIN")]
        public DateTime? TbProHorFin { get; set; }

        [Column("TB_PRO_PER_ID")]
        public int? TbProPerId { get; set; }

        [Column("TB_PRO_PER_NOM")]
        public string? TbProPerNom { get; set; }

        [Column("TB_PRO_PER_APE")]
        public string? TbProPerApe { get; set; }

        [Column("TB_PRO_PER_CAR_ID")]
        public int? TbProPerCarId { get; set; }

        [Column("TB_PRO_PER_CAR_DEN")]
        public string? TbProPerCarDen { get; set; }

        [Column("TB_PRO_PC_LOG")]
        public string? TbProPcLog { get; set; }

        [Column("TB_PRO_PC_USR")]
        public string? TbProPcUsr { get; set; }

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

        [Column("TB_PRO_UPRO")]
        public int? TbProUpro { get; set; }

        [Column("TB_PRO_CEXT")]
        public int? TbProCext { get; set; }

        [Column("TB_PRO_PER_ID_EDIT")]
        public int? TbProPerIdEdit { get; set; }

        [Column("TB_PRO_PER_NOM_EDIT")]
        public string? TbProPerNomEdit { get; set; }

        [Column("TB_PRO_PER_APE_EDIT")]
        public string? TbProPerApeEdit { get; set; }

        [Column("TB_PRO_FEC_EDIT")]
        public DateTime? TbProFecEdit { get; set; }

        [Column("TB_PRO_HOR_EDIT")]
        public DateTime? TbProHorEdit { get; set; }

        [Column("TB_PRO_MEM_1")]
        public string? TbProMem1 { get; set; }

        [Column("TB_PRO_MEM_2")]
        public string? TbProMem2 { get; set; }

        [Column("TB_PRO_MEM_3")]
        public string? TbProMem3 { get; set; }

        [Column("IB_PRO_EST_ID")]
        public int? IbProEstId { get; set; }

        [Column("IB_PRO_EST_DEN")]
        public string? IbProEstDen { get; set; }

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

        [Column("TB_PRO_CANT")]
        public int? TbProCant { get; set; }

        [Column("TB_PRO_PROV_ID")]
        public int? TbProProvId { get; set; }

        [Column("TB_PRO_PROV_DEN")]
        public string? TbProProvDen { get; set; }

        [Column("TB_PRO_NUM_1")]
        public int? TbProNum1 { get; set; }

        [Column("TB_PRO_NUM_2")]
        public int? TbProNum2 { get; set; }

        [Column("TB_PRO_NUM_3")]
        public int? TbProNum3 { get; set; }

        [Column("TB_PRO_TXT_1")]
        public string? TbProTxt1 { get; set; }

        [Column("TB_PRO_TXT_2")]
        public string? TbProTxt2 { get; set; }

        [Column("TB_PRO_TXT_3")]
        public string? TbProTxt3 { get; set; }

        [Column("TB_PRO_DTI_1")]
        public DateTime? TbProDti1 { get; set; }

        [Column("TB_PRO_DTI_2")]
        public DateTime? TbProDti2 { get; set; }

        [Column("TB_PRO_DTI_3")]
        public DateTime? TbProDti3 { get; set; }

        [Column("TB_PRO_INI")]
        public DateTime? TbProIni { get; set; }

        [Column("TB_PRO_FIN")]
        public DateTime? TbProFin { get; set; }

        [Column("TB_PRO_EST")]
        public DateTime? TbProEst { get; set; }

        [Column("TB_PRO_AIR")]
        public DateTime? TbProAir { get; set; }

        [Column("TB_PRO_TEMP")]
        public DateTime? TbProTemp { get; set; }

        [Column("TB_PRO_EXTR")]
        public bool? TbProExtr { get; set; }

        [Column("TB_PRO_TIES")]
        public bool? TbProTies { get; set; }

        [Column("TB_PRO_TIAI")]
        public bool? TbProTiai { get; set; }

        [Column("TB_PRO_PCAP")]
        public bool? TbProPcap { get; set; }

        [Column("TB_PRO_EEST")]
        public bool? TbProEest { get; set; }

        [Column("TB_PRO_INI_PER_ID")]
        public int? TbProIniPerId { get; set; }

        [Column("TB_PRO_INI_FEC")]
        public DateTime? TbProIniFec { get; set; }

        [Column("TB_PRO_RGRA")]
        public bool? TbProRgra { get; set; }

        [Column("TB_PRO_ILUM")]
        public bool? TbProIlum { get; set; }

        [Column("TB_PRO_IQVI")]
        public bool? TbProIqvi { get; set; }

        [Column("TB_PRO_IENV")]
        public bool? TbProIenv { get; set; }

        [Column("TB_PRO_DES_PER_ID")]
        public int? TbProDesPerId { get; set; }

        [Column("TB_PRO_DES_FEC")]
        public DateTime? TbProDesFec { get; set; }

        [Column("TB_PRO_IBRE")]
        public bool? TbProIbre { get; set; }

        [Column("TB_PRO_IBRE_PER_ID")]
        public int? TbProIbrePerId { get; set; }

        [Column("TB_PRO_IBRE_FEC")]
        public DateTime? TbProIbreFec { get; set; }

        [Column("TB_PRO_PSCA")]
        public bool TbProPsca { get; set; }

        [Column("TB_PRO_HUME")]
        public bool TbProHume { get; set; }

        [Column("TB_PRO_IBRN")]
        public bool TbProIbrn { get; set; }

        [Column("TB_PRO_PART")]
        public bool TbProPart { get; set; }

        [Column("TB_PRO_DISP_PER_ID")]
        public int? TbProDispPerId { get; set; }

        [Column("TB_PRO_DISP_FEC")]
        public DateTime? TbProDispFec { get; set; }

        [Column("TB_PRO_NUM_4")]
        public int? TbProNum4 { get; set; }

        [Column("TB_PRO_NUM_5")]
        public int? TbProNum5 { get; set; }

        [Column("TB_PRO_TXT_4")]
        public string? TbProTxt4 { get; set; }

        [Column("TB_PRO_TXT_5")]
        public string? TbProTxt5 { get; set; }

        [Column("TB_PRO_DTI_4")]
        public DateTime? TbProDti4 { get; set; }

        [Column("TB_PRO_DTI_5")]
        public DateTime? TbProDti5 { get; set; }

        [Column("TB_PRO_INI_DTI")]
        public DateTime? TbProIniDti { get; set; }

        [Column("TB_PRO_FIN_DTI")]
        public DateTime? TbProFinDti { get; set; }

        [Column("TB_PRO_INI_HOR")]
        public DateTime? TbProIniHor { get; set; }

        [Column("TB_PRO_FIN_HOR")]
        public DateTime? TbProFinHor { get; set; }

        [Column("TB_PRO_PEST_1")]
        public float? TbProPest1 { get; set; }

        [Column("TB_PRO_PEST_2")]
        public float? TbProPest2 { get; set; }

        [Column("TB_PRO_PEST_3")]
        public int? TbProPest3 { get; set; }

        [Column("TB_PRO_PEST_4")]
        public float? TbProPest4 { get; set; }

        [Column("TB_PRO_PEST_TOT")]
        public float? TbProPestTot { get; set; }

        [Column("TB_PRO_AUSU")]
        public bool TbProAusu { get; set; }

        [Column("TB_PRO_PACI")]
        public bool TbProPaci { get; set; }

        [Column("TB_PRO_CLI_ID")]
        public int? TbProCliId { get; set; }

        [Column("TB_PRO_CLI_DEN")]
        public string? TbProCliDen { get; set; }
    }
}

