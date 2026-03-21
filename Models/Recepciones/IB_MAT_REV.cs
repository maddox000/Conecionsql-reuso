using System.ComponentModel.DataAnnotations.Schema;

namespace ConexionSql.Models.Recepciones
{
    [Table("IB_MAT_REV")]
    public class IbMatRev
    {
        // IB_MAT_REV_ID
        [Column("IB_MAT_REV_ID")]
        public int IbMatRevId { get; set; }

        // IB_MAT_REV_DEN
        [Column("IB_MAT_REV_DEN")]
        public string? IbMatRevDen { get; set; }

        // IB_MAT_REV_OCU
        [Column("IB_MAT_REV_OCU")]
        public bool IbMatRevOcu { get; set; }
    }
}