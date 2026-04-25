using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexionSql.Models.Acondicionado
{
    public class TbProAcoDetDto
    {
        // TB_PRO_ACO_DET_ID
        [Key]
        [Column("TB_PRO_ACO_DET_ID")]
        public int TbProAcoDetId { get; set; }

        // TB_PRO_ACO_DET_ACO_ID
        [Column("TB_PRO_ACO_DET_ACO_ID")]
        public int? TbProAcoDetAcoId { get; set; }

        // TB_PRO_ACO_DET_MAT_ID
        [Column("TB_PRO_ACO_DET_MAT_ID")]
        public int? TbProAcoDetMatId { get; set; }

        // TB_PRO_ACO_DET_MAT_DEN
        [Column("TB_PRO_ACO_DET_MAT_DEN")]
        public string? TbProAcoDetMatDen { get; set; }

        // TB_PRO_ACO_DET_CANT
        [Column("TB_PRO_ACO_DET_CANT")]
        public int? TbProAcoDetCant { get; set; }

        // TB_PRO_ACO_DET_EMP_STOCK
        [Column("TB_PRO_ACO_DET_EMP_STOCK")]
        public int? TbProAcoDetEmpStock { get; set; }

        // TB_PRO_ACO_DET_EMP_CANT
        [Column("TB_PRO_ACO_DET_EMP_CANT")]
        public int? TbProAcoDetEmpCant { get; set; }

        // TB_PRO_ACO_DET_EMP_TOT
        [Column("TB_PRO_ACO_DET_EMP_TOT")]
        public int? TbProAcoDetEmpTot { get; set; }

        // TB_PRO_ACO_DET_SEC_ORI_ID
        [Column("TB_PRO_ACO_DET_SEC_ORI_ID")]
        public int? TbProAcoDetSecOriId { get; set; }

        // TB_PRO_ACO_DET_SEC_ORI_DEN
        [Column("TB_PRO_ACO_DET_SEC_ORI_DEN")]
        public string? TbProAcoDetSecOriDen { get; set; }

        // TB_PRO_ACO_DET_SEC_DES_ID
        [Column("TB_PRO_ACO_DET_SEC_DES_ID")]
        public int? TbProAcoDetSecDesId { get; set; }

        // TB_PRO_ACO_DET_SEC_DES_DEN
        [Column("TB_PRO_ACO_DET_SEC_DES_DEN")]
        public string? TbProAcoDetSecDesDen { get; set; }

        // TB_PRO_ACO_DET_PC_LOG
        [Column("TB_PRO_ACO_DET_PC_LOG")]
        public string? TbProAcoDetPcLog { get; set; }

        // TB_PRO_ACO_DET_PC_USR
        [Column("TB_PRO_ACO_DET_PC_USR")]
        public string? TbProAcoDetPcUsr { get; set; }

        // TB_PRO_ACO_DET_HOR
        [Column("TB_PRO_ACO_DET_HOR")]
        public DateTime? TbProAcoDetHor { get; set; }

        // TB_PRO_ACO_DET_REC_DET_ID
        [Column("TB_PRO_ACO_DET_REC_DET_ID")]
        public int? TbProAcoDetRecDetId { get; set; }

        // TB_PRO_ACO_DET_REC_DET_CANT
        [Column("TB_PRO_ACO_DET_REC_DET_CANT")]
        public int? TbProAcoDetRecDetCant { get; set; }

        // TB_PRO_ACO_DET_REU_ID
        [Column("TB_PRO_ACO_DET_REU_ID")]
        public string? TbProAcoDetReuId { get; set; }

        // TB_PRO_ACO_DET_MAT_ETI_DEN
        [Column("TB_PRO_ACO_DET_MAT_ETI_DEN")]
        public string? TbProAcoDetMatEtiDen { get; set; }
    }
}
