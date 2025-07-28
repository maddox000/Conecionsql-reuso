using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexionSql.Models.Equipos
{
    [Table("IB_PRO_TCI")]
    public class IbProTci
    {
        // TB_PRO_TCI_ID
        // ✅ Esta es la clave primaria
        [Key]
        [Column("TB_PRO_TCI_ID")]
        public int TbProTciId { get; set; }

        // TB_PRO_TCI_FORM
        [Column("TB_PRO_TCI_FORM")]
        public string? TbProTciForm { get; set; }

        // TB_PRO_TCI_DEN
        [Column("TB_PRO_TCI_DEN")]
        public string? TbProTciDen { get; set; }

        // TB_PRO_PTI_ID
        [Column("TB_PRO_PTI_ID")]
        public int? TbProPtiId { get; set; }

        // TB_PRO_PTI_DEN
        [Column("TB_PRO_PTI_DEN")]
        public string? TbProPtiDen { get; set; }

        // TB_PRO_PTI_CVAC
        [Column("TB_PRO_PTI_CVAC")]
        public int? TbProPtiCvac { get; set; }

        // TB_PRO_PTI_NVAC
        [Column("TB_PRO_PTI_NVAC")]
        public int? TbProPtiNvac { get; set; }

        // TB_PRO_PTI_NVAP
        [Column("TB_PRO_PTI_NVAP")]
        public int? TbProPtiNvap { get; set; }

        // TB_PRO_PTI_TIES
        [Column("TB_PRO_PTI_TIES")]
        public int? TbProPtiTies { get; set; }

        // TB_PRO_PTI_TEES
        [Column("TB_PRO_PTI_TEES")]
        public int? TbProPtiTees { get; set; }

        // TB_PRO_PTI_NSEC
        [Column("TB_PRO_PTI_NSEC")]
        public int? TbProPtiNsec { get; set; }

        // TB_PRO_PTI_TSEC
        [Column("TB_PRO_PTI_TSEC")]
        public int? TbProPtiTsec { get; set; }

        // TB_PRO_PTI_OCU
        [Column("TB_PRO_PTI_OCU")]
        public bool TbProPtiOcu { get; set; }
    }
}
