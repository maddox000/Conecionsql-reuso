using System.ComponentModel.DataAnnotations.Schema;

namespace ConexionSql.Models.IbPer
{
    [Table("IB_PER_UNI")]
    public class IbPerUni
    {
        [Column("IB_PER_UNI_ID")]
        public int IbPerUniId { get; set; }

        [Column("IB_PER_UNI_ID_FORM")]
        public int? IbPerUniIdForm { get; set; }

        [Column("IB_UNI_DEN")]
        public string IbUniDen { get; set; } = null!;

        [Column("IB_UNI_OCU")]
        public bool IbUniOcu { get; set; }
    }
}


