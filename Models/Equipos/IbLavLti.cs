using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexionSql.Models.Equipos
{
    [Table("IB_LAV_LTI")]
    public class IbLavLti
    {
        // IB_LAV_LTI_ID
        [Key]
        [Column("IB_LAV_LTI_ID")]
        public int IbLavLtiId { get; set; }

        // IB_LAV_LTI_ID_FORM
        [Column("IB_LAV_LTI_ID_FORM")]
        public int? IbLavLtiIdForm { get; set; }

        // IB_LAV_LTI_DEN
        [Column("IB_LAV_LTI_DEN")]
        public string? IbLavLtiDen { get; set; }

        // IB_LAV_LTI_OCU
        [Column("IB_LAV_LTI_OCU")]
        public bool IbLavLtiOcu { get; set; }
    }
}
