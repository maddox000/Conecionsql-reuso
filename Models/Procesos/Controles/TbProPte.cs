using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexionSql.Models.Procesos.Controles
{
    [Table("IB_PRO_PTE")]
    public class TbProPte
    {
        // IB_PTE_ID
        [Key]
        [Column("IB_PTE_ID")]
        public int IbPteId { get; set; }

        // IB_PTE_DEN
        [Column("IB_PTE_DEN")]
        public string? IbPteDen { get; set; }

        // IB_PTE_PTI_ID
        [Column("IB_PTE_PTI_ID")]
        public int? IbPtePtiId { get; set; }

        // IB_PTE_PTI_DEN
        [Column("IB_PTE_PTI_DEN")]
        public string? IbPtePtiDen { get; set; }

        // IB_PTE_PTI_OCU
        [Column("IB_PTE_PTI_OCU")]
        public bool IbPtePtiOcu { get; set; }
    }
}