using System.ComponentModel.DataAnnotations.Schema;

namespace ConexionSql.Models.IbPer
{
    [Table("IB_PER_CAR")]
    public class IbPerCar
    {
        [Column("IB_PER_CAR_ID")]
        public int IbPerCarId { get; set; }

        [Column("IB_PER_CAR_ID_FORM")]
        public int? IbPerCarIdForm { get; set; }

        [Column("IB_PER_CAR_DEN")]
        public string IbPerCarDen { get; set; } = null!;

        [Column("IB_PER_CAR_OCU_")]
        public bool IbPerCarOcu { get; set; }
    }
}

