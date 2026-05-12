// Models/Procesos/TbProNco.cs

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexionSql.Models.Procesos
{
    [Table("TB_PRO_NCO")]
    public class TbProNco
    {
        // TB_PRO_NCO_ID
        [Key]
        [Column("TB_PRO_NCO_ID")]
        public int TbProNcoId { get; set; }

        // TB_PRO_NCO_DEN
        [Column("TB_PRO_NCO_DEN")]
        public string? TbProNcoDen { get; set; }

        // TB_PRO_NCO_OCU
        [Column("TB_PRO_NCO_OCU")]
        public bool TbProNcoOcu { get; set; }

        // TB_PRO_NCO_EST_ID
        [Column("TB_PRO_NCO_EST_ID")]
        public int? TbProNcoEstId { get; set; }
    }
}