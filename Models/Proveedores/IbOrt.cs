using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexionSql.Models.Proveedores
{
    [Table("IB_ORT")]
    public class IbOrt
    {
        // IB_ORT_ID
        [Key]
        [Column("IB_ORT_ID")]
        public int IbOrtId { get; set; }

        // IB_ORT_ID_FORM
        [Column("IB_ORT_ID_FORM")]
        public int? IbOrtIdForm { get; set; }

        // IB_ORT_DEN
        [Column("IB_ORT_DEN")]
        public string? IbOrtDen { get; set; }

        // IB_ORT_OCU
        [Column("IB_ORT_OCU")]
        public bool IbOrtOcu { get; set; }

        // IB_ORT_NUM_1
        [Column("IB_ORT_NUM_1")]
        public int? IbOrtNum1 { get; set; }

        // IB_ORT_NUM_2
        [Column("IB_ORT_NUM_2")]
        public int? IbOrtNum2 { get; set; }

        // IB_ORT_NUM_3
        [Column("IB_ORT_NUM_3")]
        public int? IbOrtNum3 { get; set; }

        // IB_ORT_TXT_1
        [Column("IB_ORT_TXT_1")]
        public string? IbOrtTxt1 { get; set; }

        // IB_ORT_TXT_2
        [Column("IB_ORT_TXT_2")]
        public string? IbOrtTxt2 { get; set; }

        // IB_ORT_TXT_3
        [Column("IB_ORT_TXT_3")]
        public string? IbOrtTxt3 { get; set; }

        // IB_ORT_DAT_1
        [Column("IB_ORT_DAT_1")]
        public DateTime? IbOrtDat1 { get; set; }

        // IB_ORT_DAT_2
        [Column("IB_ORT_DAT_2")]
        public DateTime? IbOrtDat2 { get; set; }

        // IB_ORT_DAT_3
        [Column("IB_ORT_DAT_3")]
        public DateTime? IbOrtDat3 { get; set; }

        // IB_ORT_MEM_1
        [Column("IB_ORT_MEM_1")]
        public string? IbOrtMem1 { get; set; }

        // IB_ORT_MEM_2
        [Column("IB_ORT_MEM_2")]
        public string? IbOrtMem2 { get; set; }

        // IB_ORT_MEM_3
        [Column("IB_ORT_MEM_3")]
        public string? IbOrtMem3 { get; set; }
    }
}