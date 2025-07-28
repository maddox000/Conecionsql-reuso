using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexionSql.Models.IbPer
{
    [Table("IB_PER")]
    public class IbPer
    {
        [Column("IB_PER_ID")]
        public int IbPerId { get; set; }

        [Column("IB_PER_ID_FORM")]
        public int? IbPerIdForm { get; set; }

        [Column("IB_PER_LEG")]
        public string? IbPerLeg { get; set; }

        [Column("IB_PER_NOM")]
        public string? IbPerNom { get; set; }

        [Column("IB_PER_APE")]
        public string? IbPerApe { get; set; }

        [Column("IB_PER_DOM")]
        public string? IbPerDom { get; set; }

        [Column("IB_PER_CPO")]
        public string? IbPerCpo { get; set; }

        [Column("IB_PER_LOC")]
        public string? IbPerLoc { get; set; }

        [Column("IB_PER_PRO")]
        public string? IbPerPro { get; set; }

        [Column("IB_PER_TEL")]
        public string? IbPerTel { get; set; }

        [Column("IB_PER_TEM")]
        public string? IbPerTem { get; set; }

        [Column("IB_PER_UNI_ID")]
        public int? IbPerUniId { get; set; }

        [Column("IB_PER_UNI_DEN")]
        public string? IbPerUniDen { get; set; }

        [Column("IB_PER_PAS")]
        public string? IbPerPas { get; set; }

        [Column("IB_PER_FEC")]
        public DateTime? IbPerFec { get; set; }

        [Column("IB_PER_CAR_ID")]
        public int? IbPerCarId { get; set; }

        [Column("IB_PER_CAR_DEN")]
        public string? IbPerCarDen { get; set; }

        [Column("IB_PSW")]
        public string? IbPsw { get; set; }

        [Column("IB_SEC_ID")]
        public int? IbSecId { get; set; }

        [Column("IB_SEC_DEN")]
        public string? IbSecDen { get; set; }

        [Column("IB_PER_OCU")]
        public bool? IbPerOcu { get; set; }

        [Column("IB_PER_PC_LOG")]
        public string? IbPerPcLog { get; set; }

        [Column("IB_PER_PC_USR")]
        public string? IbPerPcUsr { get; set; }

        [Column("IB_PER_CBAR")]
        public string? IbPerCbar { get; set; }
    }
}


