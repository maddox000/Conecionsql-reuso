using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexionSql.Models.Sectores
{
    [Table("IB_SEC")]
    public class IbSec
    {
        // IB_SEC_ID
        [Key]
        [Column("IB_SEC_ID")]
        public int IbSecId { get; set; }

        // IB_SEC_ID_FORM
        [Column("IB_SEC_ID_FORM")]
        public int? IbSecIdForm { get; set; }

        // IB_SEC_DEN
        [Column("IB_SEC_DEN")]
        public string? IbSecDen { get; set; }

        // IB_SEC_OCU
        [Column("IB_SEC_OCU")]
        public bool IbSecOcu { get; set; }

        // IB_SEC_DES_ID
        [Column("IB_SEC_DES_ID")]
        public int? IbSecDesId { get; set; }

        // IB_SEC_DES_DEN
        [Column("IB_SEC_DES_DEN")]
        public string? IbSecDesDen { get; set; }

        // IB_SEC_EM
        [Column("IB_SEC_EM")]
        public string? IbSecEm { get; set; }

        // IB_SEC_TRA_OPC
        [Column("IB_SEC_TRA_OPC")]
        public bool IbSecTraOpc { get; set; }

        // IB_SEC_VEN_OPC
        [Column("IB_SEC_VEN_OPC")]
        public bool IbSecVenOpc { get; set; }

        // IB_SEC_VEN
        [Column("IB_SEC_VEN")]
        public int? IbSecVen { get; set; }

        // IB_SEC_GRU_ID
        [Column("IB_SEC_GRU_ID")]
        public int? IbSecGruId { get; set; }

        // IB_SEC_GRU_DEN
        [Column("IB_SEC_GRU_DEN")]
        public string? IbSecGruDen { get; set; }
    }
}
