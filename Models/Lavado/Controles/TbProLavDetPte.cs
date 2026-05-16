using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexionSql.Models.Lavado.Controles
{
    [Table("TB_PRO_LAV_DET_PTE")]
    public class TbProLavDetPte
    {
        [Column("TB_PRO_LAV_DET_PTE_ID")]
        public int TbProLavDetPteId { get; set; }

        [Column("TB_PRO_LAV_ID")]
        public int? TbProLavId { get; set; }

        [Column("TB_PRO_LAV_FEC")]
        public DateTime? TbProLavFec { get; set; }

        [Column("TB_PRO_LAV_PTE_ID")]
        public int? TbProLavPteId { get; set; }

        [Column("TB_PRO_LAV_PTE_DEN")]
        public string? TbProLavPteDen { get; set; }

        [Column("TB_PRO_LAV_PTE_PTI_ID")]
        public int? TbProLavPtePtiId { get; set; }

        [Column("TB_PRO_LAV_PTE_PTI_DEN")]
        public string? TbProLavPtePtiDen { get; set; }

        [Column("TB_PRO_LAV_PTE_EQU_ID")]
        public int? TbProLavPteEquId { get; set; }

        [Column("TB_PRO_LAV_PTE_EQU_DEN")]
        public string? TbProLavPteEquDen { get; set; }

        [Column("TB_PRO_LAV_PTE_IDE")]
        public string? TbProLavPteIde { get; set; }

        [Column("TB_PRO_LAV_DET_TES_UBI_ID")]
        public int? TbProLavDetTesUbiId { get; set; }

        [Column("TB_PRO_LAV_DET_TES_UBI_DEN")]
        public string? TbProLavDetTesUbiDen { get; set; }

        [Column("TB_PRO_LAV_PTE_CANT")]
        public int? TbProLavPteCant { get; set; }

        [Column("TB_PRO_LAV_PTE_RES_ID")]
        public int? TbProLavPteResId { get; set; }

        [Column("TB_PRO_LAV_PTE_RES_DEN")]
        public string? TbProLavPteResDen { get; set; }

        [Column("TB_PRO_LAV_DET_TES_NUM_1")]
        public int? TbProLavDetTesNum1 { get; set; }

        [Column("TB_PRO_LAV_DET_TES_NUM_2")]
        public int? TbProLavDetTesNum2 { get; set; }

        [Column("TB_PRO_LAV_DET_TES_NUM_3")]
        public int? TbProLavDetTesNum3 { get; set; }

        [Column("TB_PRO_LAV_DET_TES_TXT_1")]
        public string? TbProLavDetTesTxt1 { get; set; }

        [Column("TB_PRO_LAV_DET_TES_TXT_2")]
        public string? TbProLavDetTesTxt2 { get; set; }

        [Column("TB_PRO_LAV_DET_TES_TXT_3")]
        public string? TbProLavDetTesTxt3 { get; set; }

        [Column("TB_PRO_LAV_DET_TES_DTI_1")]
        public DateTime? TbProLavDetTesDti1 { get; set; }

        [Column("TB_PRO_LAV_DET_TES_DTI_2")]
        public DateTime? TbProLavDetTesDti2 { get; set; }

        [Column("TB_PRO_LAV_DET_TES_DTI_3")]
        public DateTime? TbProLavDetTesDti3 { get; set; }

        [Column("TB_PRO_LAV_DET_TES_MEM_1")]
        public string? TbProLavDetTesMem1 { get; set; }

        [Column("TB_PRO_LAV_DET_TES_MEM_2")]
        public string? TbProLavDetTesMem2 { get; set; }

        [Column("TB_PRO_LAV_DET_TES_MEM_3")]
        public string? TbProLavDetTesMem3 { get; set; }

        [Column("TB_PRO_PTE_LOT")]
        public string? TbProLavPteLot { get; set; }

        [Column("TB_PRO_PTE_VEN")]
        public DateTime? TbProLavPteVen { get; set; }

        [Column("TB_PRO_LAV_DET_PTE_PROD_BRAND")]
        public string? TbProLavDetPteProdBrand { get; set; }

        [Column("TB_PRO_LAV_DET_PTE_PROD_NAME")]
        public string? TbProLavDetPteProdName { get; set; }

        [Column("TB_PRO_LAV_DET_PTE_PROD_MANUF_DATE")]
        public DateTime? TbProLavDetPteProdManufDate { get; set; }

        [Column("TB_PRO_LAV_DET_PTE_EQU_NAME")]
        public string? TbProLavDetPteEquName { get; set; }

        [Column("TB_PRO_LAV_DET_PTE_EQU_SERN")]
        public string? TbProLavDetPteEquSern { get; set; }

        [Column("TB_PRO_LAV_DET_PTE_TICKET_NUMB")]
        public string? TbProLavDetPteTicketNumb { get; set; }

        [Column("TB_PRO_LAV_DET_PTE_CREAT_TEST")]
        public string? TbProLavDetPteCreatTest { get; set; }

        [Column("TB_PRO_LAV_DET_PTE_USR_NAME")]
        public string? TbProLavDetPteUsrName { get; set; }

        [Column("TB_PRO_LAV_DET_PTE_RES_EST_ID")]
        public int? TbProLavDetPteResEstId { get; set; }

        [Column("TB_PRO_LAV_DET_PTE_EQU_POS")]
        public string? TbProLavDetPteEquPos { get; set; }
    }
}