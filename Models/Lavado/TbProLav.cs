using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexionSql.Models.Lavado
{
    [Table("TB_PRO_LAV")]
    public class TbProLav
    {
        [Column("TB_PRO_LAV_ID")]
        public int TbProLavId { get; set; }

        [Column("TB_PRO_LAV_ID_FORM")]
        public int? TbProLavIdForm { get; set; }

        [Column("TB_PRO_LAV_FEC")]
        public DateTime? TbProLavFec { get; set; }

        [Column("TB_PRO_LAV_HOR_INI")]
        public DateTime? TbProLavHorIni { get; set; }

        [Column("TB_PRO_LAV_HOR_FIN")]
        public DateTime? TbProLavHorFin { get; set; }

        [Column("TB_PRO_LAV_PER_ID")]
        public int? TbProLavPerId { get; set; }

        [Column("TB_PRO_LAV_PER_APE")]
        public string? TbProLavPerApe { get; set; }

        [Column("TB_PRO_LAV_PER_NOM")]
        public string? TbProLavPerNom { get; set; }

        [Column("TB_PRO_LAV_PER_CAR_ID")]
        public int? TbProLavPerCarId { get; set; }

        [Column("TB_PRO_LAV_PER_CAR_DEN")]
        public string? TbProLavPerCarDen { get; set; }

        [Column("TB_PRO_LAV_PC_LOG")]
        public string? TbProLavPcLog { get; set; }

        [Column("TB_PRO_LAV_PC_USR")]
        public string? TbProLavPcUsr { get; set; }

        [Column("TB_PRO_LAV_SUP_PC_LOG")]
        public string? TbProLavSupPcLog { get; set; }

        [Column("TB_PRO_LAV_SUP_PC_USR")]
        public string? TbProLavSupPcUsr { get; set; }

        [Column("TB_PRO_LAV_PTI_ID")]
        public int? TbProLavPtiId { get; set; }

        [Column("TB_PRO_LAV_PTI_DEN")]
        public string? TbProLavPtiDen { get; set; }

        [Column("TB_PRO_LAV_TCI_ID")]
        public int? TbProLavTciId { get; set; }

        [Column("TB_PRO_LAV_TCI_DEN")]
        public string? TbProLavTciDen { get; set; }

        [Column("TB_PRO_LAV_EQU_ID")]
        public int? TbProLavEquId { get; set; }

        [Column("TB_PRO_LAV_EQU_DEN")]
        public string? TbProLavEquDen { get; set; }

        [Column("TB_PRO_LAV_EQU_NUM")]
        public string? TbProLavEquNum { get; set; }

        [Column("TB_PRO_IB_EQU_TEQ_ID")]
        public int? TbProIbEquTeqId { get; set; }

        [Column("TB_PRO_IB_EQU_TEQ_DEN")]
        public string? TbProIbEquTeqDen { get; set; }

        [Column("TB_PRO_LAV_EQU_MAR_ID")]
        public int? TbProLavEquMarId { get; set; }

        [Column("TB_PRO_LAV_EQU_MAR_DEN")]
        public string? TbProLavEquMarDen { get; set; }

        [Column("TB_PRO_LAV_EQU_SER")]
        public string? TbProLavEquSer { get; set; }

        [Column("TB_PRO_LAV_EQU_MOD")]
        public string? TbProLavEquMod { get; set; }

        [Column("TB_PRO_LAV_EQU_CAP")]
        public int? TbProLavEquCap { get; set; }

        [Column("TB_PRO_LAV_EQU_CAPU")]
        public int? TbProLavEquCapu { get; set; }

        [Column("TB_PRO_LAV_EQU_CAPR")]
        public int? TbProLavEquCapr { get; set; }

        [Column("TB_PRO_LAV_EQU_PCO")]
        public int? TbProLavEquPco { get; set; }

        [Column("TB_PRO_LAV_EQU_PVE")]
        public int? TbProLavEquPve { get; set; }

        [Column("TB_PRO_LAV_EQU_VOL")]
        public int? TbProLavEquVol { get; set; }

        [Column("TB_PRO_LAV_NUM")]
        public int? TbProLavNum { get; set; }

        [Column("TB_PRO_LAV_UPRO")]
        public int? TbProLavUpro { get; set; }

        [Column("TB_PRO_LAV_EST_ID")]
        public int? TbProLavEstId { get; set; }

        [Column("TB_PRO_LAV_EST_DEN")]
        public string? TbProLavEstDen { get; set; }

        [Column("TB_PRO_LAV_EST_FEC")]
        public DateTime? TbProLavEstFec { get; set; }

        [Column("TB_PRO_LAV_OBS")]
        public string? TbProLavObs { get; set; }

        // Continúa desde campo 39 en adelante...
    }
}
