using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexionSql.Models.Recepciones
{
    [Table("TB_REC")]
    public class TbRec
    {
        // TB_REC_ID
        [Key]
        [Column("TB_REC_ID")]
        public int TbRecId { get; set; }

        // TB_REC_ID_FORM
        [Column("TB_REC_ID_FORM")]
        public int? TbRecIdForm { get; set; }

        // TB_REC_FEC
        [Column("TB_REC_FEC")]
        public DateTime? TbRecFec { get; set; }

        // TB_REC_HOR_INI
        [Column("TB_REC_HOR_INI")]
        public DateTime? TbRecHorIni { get; set; }

        // TB_REC_HOR_FIN
        [Column("TB_REC_HOR_FIN")]
        public DateTime? TbRecHorFin { get; set; }

        // TB_REC_PER_ID
        [Column("TB_REC_PER_ID")]
        public int? TbRecPerId { get; set; }

        // TB_REC_PER_NOM
        [Column("TB_REC_PER_NOM")]
        public string? TbRecPerNom { get; set; }

        // TB_REC_PER_APE
        [Column("TB_REC_PER_APE")]
        public string? TbRecPerApe { get; set; }

        // TB_REC_PER_CAR_ID
        [Column("TB_REC_PER_CAR_ID")]
        public int? TbRecPerCarId { get; set; }

        // TB_REC_PER_CAR_DEN
        [Column("TB_REC_PER_CAR_DEN")]
        public string? TbRecPerCarDen { get; set; }

        // TB_REC_PC_LOG
        [Column("TB_REC_PC_LOG")]
        public string? TbRecPcLog { get; set; }

        // TB_REC_PC_USR
        [Column("TB_REC_PC_USR")]
        public string? TbRecPcUsr { get; set; }

        // TB_REC_SEC_ORI_ID
        [Column("TB_REC_SEC_ORI_ID")]
        public int? TbRecSecOriId { get; set; }

        // TB_REC_SEC_ORI_DEN
        [Column("TB_REC_SEC_ORI_DEN")]
        public string? TbRecSecOriDen { get; set; }

        // TB_REC_ORT_ID
        [Column("TB_REC_ORT_ID")]
        public int? TbRecOrtId { get; set; }

        // TB_REC_ORT_DEN
        [Column("TB_REC_ORT_DEN")]
        public string? TbRecOrtDen { get; set; }

        // TB_REC_SEC_DES_ID
        [Column("TB_REC_SEC_DES_ID")]
        public int? TbRecSecDesId { get; set; }

        // TB_REC_SEC_DES_DEN
        [Column("TB_REC_SEC_DES_DEN")]
        public string? TbRecSecDesDen { get; set; }

        // TB_REC_SEC_PER
        [Column("TB_REC_SEC_PER")]
        public string? TbRecSecPer { get; set; }

        // TB_REC_OBS
        [Column("TB_REC_OBS")]
        public string? TbRecObs { get; set; }

        // TB_REC_CANT_TOT
        [Column("TB_REC_CANT_TOT")]
        public int? TbRecCantTot { get; set; }

        // TB_REC_PER_ID_EDIT
        [Column("TB_REC_PER_ID_EDIT")]
        public int? TbRecPerIdEdit { get; set; }

        // TB_REC_PER_NOM_EDIT
        [Column("TB_REC_PER_NOM_EDIT")]
        public string? TbRecPerNomEdit { get; set; }

        // TB_REC_PER_APE_EDIT
        [Column("TB_REC_PER_APE_EDIT")]
        public string? TbRecPerApeEdit { get; set; }

        // TB_REC_FEC_EDIT
        [Column("TB_REC_FEC_EDIT")]
        public DateTime? TbRecFecEdit { get; set; }

        // TB_REC_HOR_EDIT
        [Column("TB_REC_HOR_EDIT")]
        public DateTime? TbRecHorEdit { get; set; }

        // TB_REC_MDE
        [Column("TB_REC_MDE")]
        public bool TbRecMde { get; set; }

        // TB_REC_MCO
        [Column("TB_REC_MCO")]
        public bool TbRecMco { get; set; }

        // TB_REC_NUM_1
        [Column("TB_REC_NUM_1")]
        public int? TbRecNum1 { get; set; }

        // TB_REC_NUM_2
        [Column("TB_REC_NUM_2")]
        public int? TbRecNum2 { get; set; }

        // TB_REC_NUM_3
        [Column("TB_REC_NUM_3")]
        public int? TbRecNum3 { get; set; }

        // TB_REC_TXT_1
        [Column("TB_REC_TXT_1")]
        public string? TbRecTxt1 { get; set; }

        // TB_REC_TXT_2
        [Column("TB_REC_TXT_2")]
        public string? TbRecTxt2 { get; set; }

        // TB_REC_TXT_3
        [Column("TB_REC_TXT_3")]
        public string? TbRecTxt3 { get; set; }

        // TB_REC_DTI_1
        [Column("TB_REC_DTI_1")]
        public DateTime? TbRecDti1 { get; set; }

        // TB_REC_DTI_2
        [Column("TB_REC_DTI_2")]
        public DateTime? TbRecDti2 { get; set; }

        // TB_REC_DTI_3
        [Column("TB_REC_DTI_3")]
        public DateTime? TbRecDti3 { get; set; }

        // TB_REC_MEM_1
        [Column("TB_REC_MEM_1")]
        public string? TbRecMem1 { get; set; }

        // TB_REC_MEM_2
        [Column("TB_REC_MEM_2")]
        public string? TbRecMem2 { get; set; }

        // TB_REC_MEM_3
        [Column("TB_REC_MEM_3")]
        public string? TbRecMem3 { get; set; }

        // TB_REC_LOT
        [Column("TB_REC_LOT")]
        public string? TbRecLot { get; set; }

        // TB_REC_CLI_ID
        [Column("TB_REC_CLI_ID")]
        public int? TbRecCliId { get; set; }

        // TB_REC_CLI_DEN
        [Column("TB_REC_CLI_DEN")]
        public string? TbRecCliDen { get; set; }
    }
}

