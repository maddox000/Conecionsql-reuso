using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ConexionSql.Models.Materiales
{
    [Table("IB_MAT_ETI")]
    public class IbMatEti
    {
        // IB_MAT_ETI_ID
        [Key]
        [Column("IB_MAT_ETI_ID")]
        public int IB_MAT_ETI_ID { get; set; }

        // IB_MAT_ETI_ID_FORM
        [Column("IB_MAT_ETI_ID_FORM")]
        public int? IB_MAT_ETI_ID_FORM { get; set; }

        // IB_MAT_ETI_DEN
        [Column("IB_MAT_ETI_DEN")]
        public string? IB_MAT_ETI_DEN { get; set; }

        // IB_MAT_ETI_COS
        [Column("IB_MAT_ETI_COS")]
        public decimal? IB_MAT_ETI_COS { get; set; }

        // IB_MAT_ETI_PRE
        [Column("IB_MAT_ETI_PRE")]
        public int? IB_MAT_ETI_PRE { get; set; }

        // IB_MAT_ETI_FEC
        [Column("IB_MAT_ETI_FEC")]
        public DateTime? IB_MAT_ETI_FEC { get; set; }

        // IB_MAT_ETI_OCU
        [Column("IB_MAT_ETI_OCU")]
        public bool IB_MAT_ETI_OCU { get; set; }

        // IB_MAT_ETI_TXT_1
        [Column("IB_MAT_ETI_TXT_1")]
        public string? IB_MAT_ETI_TXT_1 { get; set; }

        // IB_MAT_ETI_TXT_2
        [Column("IB_MAT_ETI_TXT_2")]
        public string? IB_MAT_ETI_TXT_2 { get; set; }

        // IB_MAT_ETI_TXT_3
        [Column("IB_MAT_ETI_TXT_3")]
        public string? IB_MAT_ETI_TXT_3 { get; set; }

        // IB_MAT_ETI_NUM_1
        [Column("IB_MAT_ETI_NUM_1")]
        public int? IB_MAT_ETI_NUM_1 { get; set; }

        // IB_MAT_ETI_NUM_2
        [Column("IB_MAT_ETI_NUM_2")]
        public int? IB_MAT_ETI_NUM_2 { get; set; }

        // IB_MAT_ETI_NUM_3
        [Column("IB_MAT_ETI_NUM_3")]
        public int? IB_MAT_ETI_NUM_3 { get; set; }

        // IB_MAT_ETI_DTI_1
        [Column("IB_MAT_ETI_DTI_1")]
        public DateTime? IB_MAT_ETI_DTI_1 { get; set; }

        // IB_MAT_ETI_DTI_2
        [Column("IB_MAT_ETI_DTI_2")]
        public DateTime? IB_MAT_ETI_DTI_2 { get; set; }

        // IB_MAT_ETI_DTI_3
        [Column("IB_MAT_ETI_DTI_3")]
        public DateTime? IB_MAT_ETI_DTI_3 { get; set; }

        // IB_MAT_ETI_MEM_1
        [Column("IB_MAT_ETI_MEM_1")]
        public string? IB_MAT_ETI_MEM_1 { get; set; }

        // IB_MAT_ETI_MEM_2
        [Column("IB_MAT_ETI_MEM_2")]
        public string? IB_MAT_ETI_MEM_2 { get; set; }

        // IB_MAT_ETI_MEN_3
        [Column("IB_MAT_ETI_MEN_3")]
        public string? IB_MAT_ETI_MEN_3 { get; set; }
    }
}