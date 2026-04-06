using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexionSql.Models.Reusos
{
    [Table("TB_REU_PAC")]
    public class TbReuPac
    {
        // TB_REU_PAC_ID
        [Key]
        [Column("TB_REU_PAC_ID")]
        public int TbReuPacId { get; set; }

        // TB_REU_PAC_TB_REU_ID
        [Column("TB_REU_PAC_TB_REU_ID")]
        public int? TbReuPacTbReuId { get; set; }

        // TB_REU_PAC_TB_REC_ID
        [Column("TB_REU_PAC_TB_REC_ID")]
        public int? TbReuPacTbRecId { get; set; }

        // TB_REU_PAC_TB_REU_PAC_FEC
        [Column("TB_REU_PAC_TB_REU_PAC_FEC")]
        public DateTime TbReuPacFec { get; set; }

        // TB_REU_PAC_TB_REU_ID_FORM
        [Column("TB_REU_PAC_TB_REU_ID_FORM")]
        public string? TbReuPacTbReuIdForm { get; set; }

        // TB_REU_PAC_NOM
        [Column("TB_REU_PAC_NOM")]
        public string? TbReuPacNom { get; set; }

        // TB_REU_PAC_APE
        [Column("TB_REU_PAC_APE")]
        public string? TbReuPacApe { get; set; }

        // TB_REU_PAC_HCLI
        [Column("TB_REU_PAC_HCLI")]
        public string? TbReuPacHcli { get; set; }

        // TB_REU_PAC_NDOC
        [Column("TB_REU_PAC_NDOC")]
        public string? TbReuPacNdoc { get; set; }

        // TB_REU_PAC_EDAD
        [Column("TB_REU_PAC_EDAD")]
        public string? TbReuPacEdad { get; set; }

        // TB_REU_PAC_OSOC
        [Column("TB_REU_PAC_OSOC")]
        public string? TbReuPacOsoc { get; set; }

        // TB_REU_PAC_TEL
        [Column("TB_REU_PAC_TEL")]
        public string? TbReuPacTel { get; set; }

        // TB_REU_PAC_OCU
        [Column("TB_REU_PAC_OCU")]
        public bool TbReuPacOcu { get; set; }
    }
}