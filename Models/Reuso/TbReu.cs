using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexionSql.Models.Reuso
{
    [Table("TB_REU")]
    public class TbReu
    {
        // =========================
        // PRIMARY KEY
        // =========================
        [Key]
        [Column("TB_REU_ID")]
        public int TbReuId { get; set; }

        // =========================
        // GENERALES
        // =========================
        [Column("TB_REU_ID_FORM")]
        public string? TbReuIdForm { get; set; }

        [Column("TB_REU_FEC")]
        public DateTime? TbReuFec { get; set; }

        [Column("TB_REU_HOR_INI")]
        public DateTime? TbReuHorIni { get; set; }

        [Column("TB_REU_HOR_FIN")]
        public DateTime? TbReuHorFin { get; set; }

        // =========================
        // PERSONAL
        // =========================
        [Column("TB_REU_PER_ID")]
        public int? TbReuPerId { get; set; }

        [Column("TB_REU_PER_NOM")]
        public string? TbReuPerNom { get; set; }

        [Column("TB_REU_PER_APE")]
        public string? TbReuPerApe { get; set; }

        [Column("TB_REU_PER_CAR_ID")]
        public int? TbReuPerCarId { get; set; }

        [Column("TB_REU_PER_CAR_DEN")]
        public string? TbReuPerCarDen { get; set; }

        // =========================
        // SISTEMA
        // =========================
        [Column("TB_REU_PC_LOG")]
        public string? TbReuPcLog { get; set; }

        [Column("TB_REU_PC_USR")]
        public string? TbReuPcUsr { get; set; }

        // =========================
        // SECTOR
        // =========================
        [Column("TB_REU_SEC_ID")]
        public int? TbReuSecId { get; set; }

        [Column("TB_REU_SEC_DEN")]
        public string? TbReuSecDen { get; set; }

        // =========================
        // MATERIAL
        // =========================
        [Column("TB_REU_MAT_ID")]
        public int? TbReuMatId { get; set; }

        [Column("TB_REU_MAT_DEN")]
        public string? TbReuMatDen { get; set; }

        [Column("TB_REU_MAT_MTI_ID")]
        public int? TbReuMatMtiId { get; set; }

        [Column("TB_REU_MAT_MTI_DEN")]
        public string? TbReuMatMtiDen { get; set; }

        [Column("TB_REU_MAT_MCA")]
        public string? TbReuMatMca { get; set; }

        [Column("TB_REU_MAT_FAB")]
        public string? TbReuMatFab { get; set; }

        [Column("TB_REU_MAT_IDE")]
        public string? TbReuMatIde { get; set; }

        // =========================
        // OPCIONES
        // =========================
        [Column("TB_REU_MAT_OPC_CANT")]
        public int TbReuMatOpcCant { get; set; }

        [Column("TB_REU_MAT_OPC_REG")]
        public int? TbReuMatOpcReg { get; set; }

        // =========================
        // PROCESOS
        // =========================
        [Column("TB_REU_PROC_1")]
        public int? TbReuProc1 { get; set; }

        [Column("TB_REU_PROC_2")]
        public int? TbReuProc2 { get; set; }

        [Column("TB_REU_PROC_3")]
        public int? TbReuProc3 { get; set; }

        // =========================
        // NUM / TXT / FECHA
        // =========================
        [Column("TB_REU_NUM_1")]
        public int? TbReuNum1 { get; set; }

        [Column("TB_REU_NUM_2")]
        public int? TbReuNum2 { get; set; }

        [Column("TB_REU_NUM_3")]
        public int? TbReuNum3 { get; set; }

        [Column("TB_REU_TXT_1")]
        public string? TbReuTxt1 { get; set; }

        [Column("TB_REU_TXT_2")]
        public string? TbReuTxt2 { get; set; }

        [Column("TB_REU_TXT_3")]
        public string? TbReuTxt3 { get; set; }

        [Column("TB_REU_DTI_1")]
        public DateTime? TbReuDti1 { get; set; }

        [Column("TB_REU_DTI_2")]
        public DateTime? TbReuDti2 { get; set; }

        [Column("TB_REU_DTI_3")]
        public DateTime? TbReuDti3 { get; set; }

        // =========================
        // MEMOS
        // =========================
        [Column("TB_REU_MEM_1")]
        public string? TbReuMem1 { get; set; }

        [Column("TB_REU_MEM_2")]
        public string? TbReuMem2 { get; set; }

        [Column("TB_REU_MEM_3")]
        public string? TbReuMem3 { get; set; }

        // =========================
        // ESTADO
        // =========================
        [Column("TB_REU_EST_ING_ID")]
        public int? TbReuEstIngId { get; set; }

        [Column("TB_REU_EST_ING_DEN")]
        public string? TbReuEstIngDen { get; set; }

        [Column("TB_REU_EST_ING_FEC")]
        public DateTime? TbReuEstIngFec { get; set; }

        // =========================
        // FLAGS
        // =========================
        [Column("TB_REU_NHMD")]
        public bool? TbReuNhmd { get; set; }

        [Column("TB_REU_NHMD_FEC")]
        public DateTime? TbReuNhmdFec { get; set; }

        [Column("TB_REU_BSTO_FEC")]
        public DateTime? TbReuBstoFec { get; set; }

        [Column("TB_REU_BSTO")]
        public bool? TbReuBsto { get; set; }

        // =========================
        // BSTO
        // =========================
        [Column("TB_REU_BSTO_PER_ID")]
        public int? TbReuBstoPerId { get; set; }

        [Column("TB_REU_BSTO_PER_NOM")]
        public string? TbReuBstoPerNom { get; set; }

        [Column("TB_REU_BSTO_BCREU_ID")]
        public int? TbReuBstoBcreuId { get; set; }

        [Column("TB_REU_BSTO_BCREU_DEN")]
        public string? TbReuBstoBcreuDen { get; set; }

        // =========================
        // RELACIONES
        // =========================
        [Column("TB_REU_REC_DET_ID")]
        public int? TbReuRecDetId { get; set; }

        [Column("TB_REU_PRO_ID")]
        public int? TbReuProId { get; set; }

        [Column("TB_REU_PRO_DEN")]
        public string? TbReuProDen { get; set; }

        // =========================
        // FINAL
        // =========================
        [Column("TB_REU_FENT")]
        public bool TbReuFent { get; set; }

        [Column("TB_REU_FENT_FEC")]
        public DateTime? TbReuFentFec { get; set; }
    }
}