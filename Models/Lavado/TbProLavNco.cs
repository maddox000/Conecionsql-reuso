using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexionSql.Models.Lavado
{
    [Table("TB_PRO_LAV_NCO")]
    public class TbProLavNco
    {
        // TB_PRO_LAV_NCO_ID
        [Key]
        [Column("TB_PRO_LAV_NCO_ID")]
        public int TB_PRO_LAV_NCO_ID { get; set; }

        // TB_PRO_LAV_NCO_DEN
        [Column("TB_PRO_LAV_NCO_DEN")]
        public string? TB_PRO_LAV_NCO_DEN { get; set; }

        // TB_PRO_LAV_NCO_OCU
        [Column("TB_PRO_LAV_NCO_OCU")]
        public bool TB_PRO_LAV_NCO_OCU { get; set; }
    }
}