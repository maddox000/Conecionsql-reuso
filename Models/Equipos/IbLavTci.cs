using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexionSql.Models.Equipos
{
    [Table("IB_LAV_TCI")]
    public class IbLavTci
    {
        // IB_LAV_TCI_ID
        [Key]
        [Column("IB_LAV_TCI_ID")]
        public int IbLavTciId { get; set; }

        // IB_LAV_TCI_ID_FORM
        [Column("IB_LAV_TCI_ID_FORM")]
        public int? IbLavTciIdForm { get; set; }

        // IB_LAV_TCI_DEN
        [Column("IB_LAV_TCI_DEN")]
        public string? IbLavTciDen { get; set; }

        // IB_LAV_TCI_OCU
        [Column("IB_LAV_TCI_OCU")]
        public bool IbLavTciOcu { get; set; }
    }
}

