using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexionSql.Models.Acondicionado
{
    [Table("TB_PRO_ACO")]
    public class TbProAco
    {
        // TB_PRO_ACO_ID
        [Key]
        [Column("TB_PRO_ACO_ID")]
        public int TbProAcoId { get; set; }

        // TB_PRO_ACO_ID_FORM
        [Column("TB_PRO_ACO_ID_FORM")]
        public int? TbProAcoIdForm { get; set; }

        // TB_PRO_ACO_FEC
        [Column("TB_PRO_ACO_FEC")]
        public DateTime? TbProAcoFec { get; set; }

        // TB_PRO_ACO_HOR_INI
        [Column("TB_PRO_ACO_HOR_INI")]
        public DateTime? TbProAcoHorIni { get; set; }

        // TB_PRO_ACO_HOR_FIN
        [Column("TB_PRO_ACO_HOR_FIN")]
        public DateTime? TbProAcoHorFin { get; set; }

        // TB_PRO_ACO_PER_ID
        [Column("TB_PRO_ACO_PER_ID")]
        public int? TbProAcoPerId { get; set; }

        // TB_PRO_ACO_PER_NOM
        [Column("TB_PRO_ACO_PER_NOM")]
        public string? TbProAcoPerNom { get; set; }

        // TB_PRO_ACO_PER_CAR_ID
        [Column("TB_PRO_ACO_PER_CAR_ID")]
        public int? TbProAcoPerCarId { get; set; }

        // TB_PRO_ACO_PER_CAR_DEN
        [Column("TB_PRO_ACO_PER_CAR_DEN")]
        public string? TbProAcoPerCarDen { get; set; }

        // TB_PRO_ACO_PC_LOG
        [Column("TB_PRO_ACO_PC_LOG")]
        public string? TbProAcoPcLog { get; set; }

        // TB_PRO_ACO_PC_USR
        [Column("TB_PRO_ACO_PC_USR")]
        public string? TbProAcoPcUsr { get; set; }

        // TB_PRO_ACO_UPRO
        [Column("TB_PRO_ACO_UPRO")]
        public int? TbProAcoUpro { get; set; }

        // TB_PRO_ACO_CANT
        [Column("TB_PRO_ACO_CANT")]
        public int? TbProAcoCant { get; set; }

        // TB_PRO_ACO_OBS
        [Column("TB_PRO_ACO_OBS")]
        public string? TbProAcoObs { get; set; }

        // TB_PRO_ACO_NUM_1
        [Column("TB_PRO_ACO_NUM_1")]
        public int? TbProAcoNum1 { get; set; }

        // TB_PRO_ACO_NUM_2
        [Column("TB_PRO_ACO_NUM_2")]
        public int? TbProAcoNum2 { get; set; }

        // TB_PRO_ACO_NUM_3
        [Column("TB_PRO_ACO_NUM_3")]
        public int? TbProAcoNum3 { get; set; }

        // TB_PRO_ACO_TXT_1
        [Column("TB_PRO_ACO_TXT_1")]
        public string? TbProAcoTxt1 { get; set; }

        // TB_PRO_ACO_TXT_2
        [Column("TB_PRO_ACO_TXT_2")]
        public string? TbProAcoTxt2 { get; set; }

        // TB_PRO_ACO_TXT_3
        [Column("TB_PRO_ACO_TXT_3")]
        public string? TbProAcoTxt3 { get; set; }

        // TB_PRO_ACO_DTI_1
        [Column("TB_PRO_ACO_DTI_1")]
        public DateTime? TbProAcoDti1 { get; set; }

        // TB_PRO_ACO_DTI_2
        [Column("TB_PRO_ACO_DTI_2")]
        public DateTime? TbProAcoDti2 { get; set; }

        // TB_PRO_ACO_DTI_3
        [Column("TB_PRO_ACO_DTI_3")]
        public DateTime? TbProAcoDti3 { get; set; }

        // TB_PRO_ACO_MEM_1
        [Column("TB_PRO_ACO_MEM_1")]
        public string? TbProAcoMem1 { get; set; }

        // TB_PRO_ACO_MEM_2
        [Column("TB_PRO_ACO_MEM_2")]
        public string? TbProAcoMem2 { get; set; }

        // TB_PRO_ACO_MEM_3
        [Column("TB_PRO_ACO_MEM_3")]
        public string? TbProAcoMem3 { get; set; }

        // TB_PRO_ACO_CLI_ID
        [Column("TB_PRO_ACO_CLI_ID")]
        public int? TbProAcoCliId { get; set; }

        // TB_PRO_ACO_CLI_DEN
        [Column("TB_PRO_ACO_CLI_DEN")]
        public string? TbProAcoCliDen { get; set; }
    }
}

