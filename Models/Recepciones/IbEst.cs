using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexionSql.Models.Estados
{
    [Table("IB_EST")]
    public class IbEst
    {
        // IB_EST_ID
        [Key]
        [Column("IB_EST_ID")]
        public int IbEstId { get; set; }

        // IB_EST_ID_FORM
        [Column("IB_EST_ID_FORM")]
        public int? IbEstIdForm { get; set; }

        // IB_EST_DEN
        [Column("IB_EST_DEN")]
        public string? IbEstDen { get; set; }

        // IB_EST_LIST
        [Column("IB_EST_LIST")]
        public int? IbEstList { get; set; }

        // IB_EST_OCU
        [Column("IB_EST_OCU")]
        public bool IbEstOcu { get; set; }
    }
}
