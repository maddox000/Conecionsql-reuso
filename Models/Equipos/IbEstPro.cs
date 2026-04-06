using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexionSql.Models.Equipos
{
    [Table("IB_EST_PRO")]
    public class IbEstPro
    {
        // IB_EST_PROV_ID
        [Key]
        [Column("IB_EST_PROV_ID")]
        public int IbEstProvId { get; set; }

        // IB_EST_PROV_DEN
        [Column("IB_EST_PROV_DEN")]
        public string? IbEstProvDen { get; set; }

        // IB_EST_PROV_OCU
        [Column("IB_EST_PROV_OCU")]
        public bool IbEstProvOcu { get; set; }
    }
}