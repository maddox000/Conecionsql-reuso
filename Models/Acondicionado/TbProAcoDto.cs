using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexionSql.Models.Acondicionado
{
    public class TbProAcoDto
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
    }
}
