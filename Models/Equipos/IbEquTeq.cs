using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexionSql.Models.Equipos
{
    [Table("IB_EQU_TEQ")]
    public class IbEquTeq
    {
        [Column("IB_EQU_TEQ_ID")]
        public int IbEquTeqId { get; set; }

        [Column("IB_EQU_TEQ_ID_FORM")]
        public int? IbEquTeqIdForm { get; set; }

        [Column("IB_EQU_TEQ_DEN")]
        public string? IbEquTeqDen { get; set; }

        [Column("IB_EQU_TEQ_OCU")]
        public bool IbEquTeqOcu { get; set; }

        [Column("IB_EQU_PTI_ID")]
        public int? IbEquPtiId { get; set; }

        [Column("IB_EQU_PTI_DEN")]
        public string? IbEquPtiDen { get; set; }
    }
}