using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexionSql.Models.Equipos
{
    [Table("IB_EQU_MAR")]
    public class IbEquMar
    {
        [Column("IB_EQU_MAR_ID")]
        public int IbEquMarId { get; set; }

        [Column("IB_EQU_MAR_ID_FORM")]
        public int? IbEquMarIdForm { get; set; }

        [Column("IB_EQU_MAR_DEN")]
        public string? IbEquMarDen { get; set; }

        [Column("IB_EQU_MAR_OCU")]
        public bool IbEquMarOcu { get; set; }

        [Column("IB_EQU_PVA_ID")]
        public int? IbEquPvaId { get; set; }
    }
}