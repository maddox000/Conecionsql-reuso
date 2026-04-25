using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexionSql.Models.Profesionales
{
    [Table("IB_PRO")]
    public class IbPro
    {
        // IB_PRO_ID
        [Key]
        [Column("IB_PRO_ID")]
        public int IbProId { get; set; }

        // IB_PRO_ID_FORM
        [Column("IB_PRO_ID_FORM")]
        public int? IbProIdForm { get; set; }

        // IB_PRO_NOM
        [Column("IB_PRO_NOM")]
        public string? IbProNom { get; set; }

        // IB_PRO_APE
        [Column("IB_PRO_APE")]
        public string? IbProApe { get; set; }

        // IB_PRO_TEL
        [Column("IB_PRO_TEL")]
        public string? IbProTel { get; set; }

        // IB_PRO_TMO
        [Column("IB_PRO_TMO")]
        public string? IbProTmo { get; set; }

        // IB_PRO_CON
        [Column("IB_PRO_CON")]
        public string? IbProCon { get; set; }

        // IB_PRO_PC_LOG
        [Column("IB_PRO_PC_LOG")]
        public string? IbProPcLog { get; set; }

        // IB_PRO_PC_USR
        [Column("IB_PRO_PC_USR")]
        public string? IbProPcUsr { get; set; }

        // IB_PRO_OCU
        [Column("IB_PRO_OCU")]
        public bool IbProOcu { get; set; }

        // IB_PRO_IB_SEC_DES_ID
        [Column("IB_PRO_IB_SEC_DES_ID")]
        public int? IbProSecDesId { get; set; }

        // IB_PRO_PER_AUT
        [Column("IB_PRO_PER_AUT")]
        public string? IbProPerAut { get; set; }

        // IB_PRO_EM
        [Column("IB_PRO_EM")]
        public string? IbProEm { get; set; }
    }
}