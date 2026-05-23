using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexionSql.Models.Procesos
{
    [Table("IB_PRO_DET_EST")]
    public class IbProDetEst
    {
        // IB_PRO_DET_EST_ID
        [Key]
        [Column("IB_PRO_DET_EST_ID")]
        public int IbProDetEstId { get; set; }

        // IB_PRO_DET_EST_DEN
        [Column("IB_PRO_DET_EST_DEN")]
        public string IbProDetEstDen { get; set; } = string.Empty;

        // IB_PRO_DET_EST_OCU
        [Column("IB_PRO_DET_EST_OCU")]
        public bool IbProDetEstOcu { get; set; }
    }
}