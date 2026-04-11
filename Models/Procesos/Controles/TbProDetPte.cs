using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexionSql.Models.Procesos.Controles
{
    [Table("TB_PRO_DET_PTE")]
    public class TbProDetPte
    {
        // TB_PRO_DET_PTE_ID
        [Key]
        [Column("TB_PRO_DET_PTE_ID")]
        public int TbProDetPteId { get; set; }

        // TB_PRO_ID
        [Column("TB_PRO_ID")]
        public int TbProId { get; set; }

        // TB_PRO_FEC
        [Column("TB_PRO_FEC")]
        public DateTime? TbProFec { get; set; }

        // TB_PRO_PTE_ID
        [Column("TB_PRO_PTE_ID")]
        public int? TbProPteId { get; set; }

        // TB_PRO_PTE_DEN
        [Column("TB_PRO_PTE_DEN")]
        public string? TbProPteDen { get; set; }

        // TB_PRO_PTE_PTI_ID
        [Column("TB_PRO_PTE_PTI_ID")]
        public int? TbProPtePtiId { get; set; }

        // TB_PRO_PTE_PTI_DEN
        [Column("TB_PRO_PTE_PTI_DEN")]
        public string? TbProPtePtiDen { get; set; }

        // TB_PRO_PTE_EQU_ID
        [Column("TB_PRO_PTE_EQU_ID")]
        public int? TbProPteEquId { get; set; }

        // TB_PRO_PTE_EQU_DEN
        [Column("TB_PRO_PTE_EQU_DEN")]
        public string? TbProPteEquDen { get; set; }

        // TB_PRO_PTE_IDE
        [Column("TB_PRO_PTE_IDE")]
        public string? TbProPteIde { get; set; }

        // TB_PRO_DET_TES_UBI_ID
        [Column("TB_PRO_DET_TES_UBI_ID")]
        public int? TbProDetTesUbiId { get; set; }

        // TB_PRO_DET_TES_UBI_DEN
        [Column("TB_PRO_DET_TES_UBI_DEN")]
        public string? TbProDetTesUbiDen { get; set; }

        // TB_PRO_PTE_CANT
        [Column("TB_PRO_PTE_CANT")]
        public int? TbProPteCant { get; set; }

        // TB_PRO_PTE_RES_ID
        [Column("TB_PRO_PTE_RES_ID")]
        public int? TbProPteResId { get; set; }

        // TB_PRO_PTE_RES_DEN
        [Column("TB_PRO_PTE_RES_DEN")]
        public string? TbProPteResDen { get; set; }

        // TB_PRO_DET_TES_NUM_1
        [Column("TB_PRO_DET_TES_NUM_1")]
        public decimal? TbProDetTesNum1 { get; set; }

        // TB_PRO_DET_TES_NUM_2
        [Column("TB_PRO_DET_TES_NUM_2")]
        public decimal? TbProDetTesNum2 { get; set; }

        // TB_PRO_DET_TES_NUM_3
        [Column("TB_PRO_DET_TES_NUM_3")]
        public decimal? TbProDetTesNum3 { get; set; }

        // TB_PRO_DET_TES_TXT_1
        [Column("TB_PRO_DET_TES_TXT_1")]
        public string? TbProDetTesTxt1 { get; set; }

        // TB_PRO_DET_TES_TXT_2
        [Column("TB_PRO_DET_TES_TXT_2")]
        public string? TbProDetTesTxt2 { get; set; }

        // TB_PRO_DET_TES_TXT_3
        [Column("TB_PRO_DET_TES_TXT_3")]
        public string? TbProDetTesTxt3 { get; set; }

        // TB_PRO_DET_TES_DTI_1
        [Column("TB_PRO_DET_TES_DTI_1")]
        public DateTime? TbProDetTesDti1 { get; set; }

        // TB_PRO_DET_TES_DTI_2
        [Column("TB_PRO_DET_TES_DTI_2")]
        public DateTime? TbProDetTesDti2 { get; set; }

        // TB_PRO_DET_TES_DTI_3
        [Column("TB_PRO_DET_TES_DTI_3")]
        public DateTime? TbProDetTesDti3 { get; set; }

        // TB_PRO_DET_TES_MEM_1
        [Column("TB_PRO_DET_TES_MEM_1")]
        public string? TbProDetTesMem1 { get; set; }

        // TB_PRO_DET_TES_MEM_2
        [Column("TB_PRO_DET_TES_MEM_2")]
        public string? TbProDetTesMem2 { get; set; }

        // TB_PRO_DET_TES_MEM_3
        [Column("TB_PRO_DET_TES_MEM_3")]
        public string? TbProDetTesMem3 { get; set; }

        // TB_PRO_PTE_LOT
        [Column("TB_PRO_PTE_LOT")]
        public string? TbProPteLot { get; set; }

        // TB_PRO_PTE_VEN
        [Column("TB_PRO_PTE_VEN")]
        public DateTime? TbProPteVen { get; set; }

        // TB_PRO_DET_PTE_CANT_ELIM
        [Column("TB_PRO_DET_PTE_CANT_ELIM")]
        public int? TbProDetPteCantElim { get; set; }

        // TB_PRO_DET_PTE_PROD_BRAND
        [Column("TB_PRO_DET_PTE_PROD_BRAND")]
        public string? TbProDetPteProdBrand { get; set; }

        // TB_PRO_DET_PTE_PROD_NAME
        [Column("TB_PRO_DET_PTE_PROD_NAME")]
        public string? TbProDetPteProdName { get; set; }

        // TB_PRO_DET_PTE_PROD_MANUF_DATE
        [Column("TB_PRO_DET_PTE_PROD_MANUF_DATE")]
        public DateTime? TbProDetPteProdManufDate { get; set; }

        // TB_PRO_DET_PTE_EQU_NAME
        [Column("TB_PRO_DET_PTE_EQU_NAME")]
        public string? TbProDetPteEquName { get; set; }

        // TB_PRO_DET_PTE_EQU_SERN
        [Column("TB_PRO_DET_PTE_EQU_SERN")]
        public string? TbProDetPteEquSern { get; set; }

        // TB_PRO_DET_PTE_EQU_POS
        [Column("TB_PRO_DET_PTE_EQU_POS")]
        public string? TbProDetPteEquPos { get; set; }

        // TB_PRO_DET_PTE_TICKET_NUMB
        [Column("TB_PRO_DET_PTE_TICKET_NUMB")]
        public string? TbProDetPteTicketNumb { get; set; }

        // TB_PRO_DET_PTE_CREAT_TEST
        [Column("TB_PRO_DET_PTE_CREAT_TEST")]
        public string? TbProDetPteCreatTest { get; set; }

        // TB_PRO_DET_PTE_USR_NAME
        [Column("TB_PRO_DET_PTE_USR_NAME")]
        public string? TbProDetPteUsrName { get; set; }

        // TB_PRO_DET_PTE_RES_EST_ID
        [Column("TB_PRO_DET_PTE_RES_EST_ID")]
        public int? TbProDetPteResEstId { get; set; }
    }
}