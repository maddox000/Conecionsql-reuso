using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexionSql.Models.Equipos
{
    [Table("IB_EQU_PTI")]
    public class IbEquPti
    {
        // IB_EQU_PTI_ID
        [Column("IB_EQU_PTI_ID")]
        public int IbEquPtiId { get; set; }

        // IB_EQU_PTI_ID_FORM
        [Column("IB_EQU_PTI_ID_FORM")]
        public int? IbEquPtiIdForm { get; set; }

        // IB_EQU_PTI_DEN
        [Column("IB_EQU_PTI_DEN")]
        public string? IbEquPtiDen { get; set; }

        // IB_EQU_PTI_OCU
        [Column("IB_EQU_PTI_OCU")]
        public bool IbEquPtiOcu { get; set; }

        // IB_EQU_PTI_TXT_1
        [Column("IB_EQU_PTI_TXT_1")]
        public string? IbEquPtiTxt1 { get; set; }

        // IB_EQU_PTI_TXT_2
        [Column("IB_EQU_PTI_TXT_2")]
        public string? IbEquPtiTxt2 { get; set; }

        // IB_EQU_PTI_TXT_3
        [Column("IB_EQU_PTI_TXT_3")]
        public string? IbEquPtiTxt3 { get; set; }

        // IB_EQU_PTI_NUM_1
        [Column("IB_EQU_PTI_NUM_1")]
        public int? IbEquPtiNum1 { get; set; }

        // IB_EQU_PTI_NUM_2
        [Column("IB_EQU_PTI_NUM_2")]
        public int? IbEquPtiNum2 { get; set; }

        // IB_EQU_PTI_NUM_3
        [Column("IB_EQU_PTI_NUM_3")]
        public int? IbEquPtiNum3 { get; set; }

        // IB_EQU_PTI_DTI_1
        [Column("IB_EQU_PTI_DTI_1")]
        public DateTime? IbEquPtiDti1 { get; set; }

        // IB_EQU_PTI_DTI_2
        [Column("IB_EQU_PTI_DTI_2")]
        public DateTime? IbEquPtiDti2 { get; set; }

        // IB_EQU_PTI_DTI_3
        [Column("IB_EQU_PTI_DTI_3")]
        public DateTime? IbEquPtiDti3 { get; set; }
    }
}
