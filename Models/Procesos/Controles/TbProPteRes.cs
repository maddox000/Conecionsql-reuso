using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexionSql.Models.Procesos.Controles
{
    [Table("TB_PRO_PTE_RES")]
    public class TbProPteRes
    {
        // TB_PRO_PTE_RES_ID
        [Key]
        [Column("TB_PRO_PTE_RES_ID")]
        public int TbProPteResId { get; set; }

        // TB_PRO_PTE_RES_DEN
        [Column("TB_PRO_PTE_RES_DEN")]
        public string TbProPteResDen { get; set; } = string.Empty;

        // TB_PRO_PTE_RES_OCU
        [Column("TB_PRO_PTE_RES_OCU")]
        public bool TbProPteResOcu { get; set; }
    }
}