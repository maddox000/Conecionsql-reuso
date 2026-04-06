using System;

namespace ConexionSql.Models.Reusos
{
    public class TbReuPacDto
    {
        // TB_REU_PAC_ID
        public int TbReuPacId { get; set; }

        // TB_REU_PAC_TB_REU_ID
        public int? TbReuPacTbReuId { get; set; }

        // TB_REU_PAC_TB_REC_ID
        public int? TbReuPacTbRecId { get; set; }

        // TB_REU_PAC_TB_REU_PAC_FEC
        public DateTime TbReuPacFec { get; set; }

        // TB_REU_PAC_TB_REU_ID_FORM
        public string? TbReuPacTbReuIdForm { get; set; }

        // TB_REU_PAC_NOM
        public string? TbReuPacNom { get; set; }

        // TB_REU_PAC_APE
        public string? TbReuPacApe { get; set; }

        // TB_REU_PAC_HCLI
        public string? TbReuPacHcli { get; set; }

        // TB_REU_PAC_NDOC
        public string? TbReuPacNdoc { get; set; }

        // TB_REU_PAC_EDAD
        public string? TbReuPacEdad { get; set; }

        // TB_REU_PAC_OSOC
        public string? TbReuPacOsoc { get; set; }

        // TB_REU_PAC_TEL
        public string? TbReuPacTel { get; set; }

        // TB_REU_PAC_OCU
        public bool TbReuPacOcu { get; set; }
    }
}