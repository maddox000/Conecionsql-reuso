using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexionSql.Models.Equipos
{
    [Table("IB_PRO_EST")]
    public class IbProEst
    {
        // IB_PRO_EST_ID
        [Key]
        [Column("IB_PRO_EST_ID")]
        public int IbProEstId { get; set; }

        // IB_PRO_EST_ID_FORM
        [Column("IB_PRO_EST_ID_FORM")]
        public int? IbProEstIdForm { get; set; }

        // IB_PRO_EST_DEN
        [Column("IB_PRO_EST_DEN")]
        public string? IbProEstDen { get; set; }

        // IB_PRO_EST_OCU
        [Column("IB_PRO_EST_OCU")]
        public bool IbProEstOcu { get; set; }
    }
}