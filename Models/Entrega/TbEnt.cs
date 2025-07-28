using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexionSql.Models.Entrega
{
    [Table("TB_ENT")]
    public class TbEnt
    {
        [Column("TB_ENT_ID")]
        public int TbEntId { get; set; }

        [Column("TB_ENT_ID_FORM")]
        public int? TbEntIdForm { get; set; }

        [Column("TB_ENT_FEC")]
        public DateTime? TbEntFec { get; set; }

        [Column("TB_ENT_HOR_INI")]
        public DateTime? TbEntHorIni { get; set; }

        [Column("TB_ENT_HOR_FIN")]
        public DateTime? TbEntHorFin { get; set; }

        [Column("TB_ENT_PER_ID")]
        public int? TbEntPerId { get; set; }

        [Column("TB_ENT_PER_NOM")]
        public string? TbEntPerNom { get; set; }

        [Column("TB_ENT_PER_APE")]
        public string? TbEntPerApe { get; set; }

        [Column("TB_ENT_PER_CAR_ID")]
        public int? TbEntPerCarId { get; set; }

        [Column("TB_ENT_PER_CAR_DEN")]
        public string? TbEntPerCarDen { get; set; }

        [Column("TB_ENT_PC_LOG")]
        public string? TbEntPcLog { get; set; }

        [Column("TB_ENT_PC_USR")]
        public string? TbEntPcUsr { get; set; }

        [Column("TB_ENT_SEC_ID")]
        public int? TbEntSecId { get; set; }

        [Column("TB_ENT_SEC_DEN")]
        public string? TbEntSecDen { get; set; }

        [Column("TB_ENT_SEC_PER")]
        public string? TbEntSecPer { get; set; }

        [Column("TB_ENT_OBS")]
        public string? TbEntObs { get; set; }

        [Column("TB_ENT_CANT_TOT")]
        public int? TbEntCantTot { get; set; }

        [Column("TB_ENT_PER_ID_EDIT")]
        public int? TbEntPerIdEdit { get; set; }

        [Column("TB_ENT_PER_NOM_EDIT")]
        public string? TbEntPerNomEdit { get; set; }

        [Column("TB_ENT_PER_APE_EDIT")]
        public string? TbEntPerApeEdit { get; set; }

        [Column("TB_ENT_FEC_EDIT")]
        public DateTime? TbEntFecEdit { get; set; }

        [Column("TB_ENT_HOR_EDIT")]
        public DateTime? TbEntHorEdit { get; set; }

        [Column("TB_ENT_NUM_1")]
        public int? TbEntNum1 { get; set; }

        [Column("TB_ENT_NUM_2")]
        public int? TbEntNum2 { get; set; }

        [Column("TB_ENT_NUM_3")]
        public int? TbEntNum3 { get; set; }

        [Column("TB_ENT_NUM_4")]
        public int? TbEntNum4 { get; set; }

        [Column("TB_ENT_NUM_5")]
        public int? TbEntNum5 { get; set; }

        [Column("TB_ENT_TXT_1")]
        public string? TbEntTxt1 { get; set; }

        [Column("TB_ENT_TXT_2")]
        public string? TbEntTxt2 { get; set; }

        [Column("TB_ENT_TXT_3")]
        public string? TbEntTxt3 { get; set; }

        [Column("TB_ENT_TXT_4")]
        public string? TbEntTxt4 { get; set; }

        [Column("TB_ENT_TXT_5")]
        public string? TbEntTxt5 { get; set; }

        [Column("TB_ENT_DTI_1")]
        public DateTime? TbEntDti1 { get; set; }

        [Column("TB_ENT_DTI_2")]
        public DateTime? TbEntDti2 { get; set; }

        [Column("TB_ENT_DTI_3")]
        public DateTime? TbEntDti3 { get; set; }

        [Column("TB_ENT_DTI_4")]
        public DateTime? TbEntDti4 { get; set; }

        [Column("TB_ENT_DTI_5")]
        public DateTime? TbEntDti5 { get; set; }

        [Column("TB_ENT_MEM_1")]
        public string? TbEntMem1 { get; set; }

        [Column("TB_ENT_MEM_2")]
        public string? TbEntMem2 { get; set; }

        [Column("TB_ENT_MEM_3")]
        public string? TbEntMem3 { get; set; }

        [Column("TB_ENT_CK_1")]
        public bool? TbEntCk1 { get; set; }

        [Column("TB_ENT_CK_2")]
        public bool? TbEntCk2 { get; set; }

        [Column("TB_ENT_CK_3")]
        public bool? TbEntCk3 { get; set; }

        [Column("TB_ENT_CK_4")]
        public bool? TbEntCk4 { get; set; }

        [Column("TB_ENT_CK_5")]
        public bool? TbEntCk5 { get; set; }

        [Column("TB_ENT_BIT_1")]
        public bool? TbEntBit1 { get; set; }

        [Column("TB_ENT_BIT_2")]
        public bool? TbEntBit2 { get; set; }

        [Column("TB_ENT_BIT_3")]
        public bool? TbEntBit3 { get; set; }

        [Column("TB_ENT_CKL_1")]
        public bool? TbEntCkl1 { get; set; }

        [Column("TB_ENT_CKL_2")]
        public bool? TbEntCkl2 { get; set; }

        [Column("TB_ENT_CKL_3")]
        public bool? TbEntCkl3 { get; set; }

        [Column("TB_ENT_CKL_4")]
        public bool? TbEntCkl4 { get; set; }

        [Column("TB_ENT_CKL_5")]
        public bool? TbEntCkl5 { get; set; }

        [Column("TB_ENT_CKL_6")]
        public bool? TbEntCkl6 { get; set; }

        [Column("TB_ENT_PAC")]
        public string? TbEntPac { get; set; }

        [Column("TB_ENT_CLI_ID")]
        public int? TbEntCliId { get; set; }

        [Column("TB_ENT_CLI_DEN")]
        public string? TbEntCliDen { get; set; }

        [Column("TB_ENT_SEC_ORI_ID")]
        public int? TbEntSecOriId { get; set; }

        [Column("TB_ENT_SEC_ORI_DEN")]
        public string? TbEntSecOriDen { get; set; }

        [Column("TB_ENT_TRANSP_OPC_ID")]
        public int? TbEntTranspOpcId { get; set; }

        [Column("TB_ENT_TRANSP_OPC_DEN")]
        public string? TbEntTranspOpcDen { get; set; }
    }
}
