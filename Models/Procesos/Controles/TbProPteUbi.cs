using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexionSql.Models.Procesos.Controles
{
    [Table("TB_PRO_PTE_UBI")]
    public class TbProPteUbi
    {
        // IB_PTES_UBI_ID
        [Key]
        [Column("IB_PTES_UBI_ID")]
        public int IbPtesUbiId { get; set; }

        // IB_PTES_UBI_DEN
        [Column("IB_PTES_UBI_DEN")]
        public string? IbPtesUbiDen { get; set; }

        // IB_PTES_UBI_OCU
        [Column("IB_PTES_UBI_OCU")]
        public bool IbPtesUbiOcu { get; set; }
    }
}