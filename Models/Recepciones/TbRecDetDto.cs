using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexionSql.Models.Recepciones
{
    public class TbRecDetDto
    {
        // 🆔 ID del detalle (clave primaria en TB_REC_DET)
        public int TB_REC_DET_ID { get; set; }

        // 🔗 ID de la cabecera de recepción (referencia a TB_REC)
        public int TB_REC_ID { get; set; }

        // 📦 ID del material seleccionado (referencia a IB_MAT)
        public int? IB_MAT_ID { get; set; }

        // 📦 Denominación del material (se completa automáticamente al insertar)
        public string? TbRecDetMatDen { get; set; }

        // 🔢 Cantidad ingresada en el detalle
        public int TB_REC_DET_CANT { get; set; }

        // 🏷️ ID del estado seleccionado (referencia a IB_EST)
        public int? IB_EST_ID { get; set; }
        public string? IB_EST_DEN { get; set; }

        // 📦 Stocks específicos según el estado
        public int TB_REC_DET_EMP_STOCK { get; set; }
        public int TB_REC_DET_PRO_STOCK { get; set; }
        public int TB_REC_DET_LAV_STOCK { get; set; }
        public int TB_REC_DET_ENT_STOCK { get; set; }

        // 🔧 Stock para DECONTAMINADO
        public int TB_REC_DET_DEC_STOCK { get; set; }

        // 📦 Cantidad entregada (campo para ENTREGADO)
        public int TB_REC_DET_ENT_CANT { get; set; }

        public int? TB_REC_DET_NUM_2 { get; set; }
        public int? TB_REC_DET_NUM_3 { get; set; }
        public string? TB_REC_DET_TXT_3 { get; set; }
        public DateTime? TB_REC_DET_DTI_1 { get; set; }

        //🏢 ID del sector de destino(referencia a IB_SEC)
        public int TB_REC_SEC_DES_ID { get; set; }

        // TB_REC_DET_MAT_PR (Código producto)
        public string? TB_REC_DET_MAT_PR { get; set; }

        // TB_REC_DET_REU_ID (Código reuso)
        public string? TB_REC_DET_REU_ID { get; set; }

        // TB_REC_DET_REP_ID (Revisión)
        public int? TB_REC_DET_REP_ID { get; set; }

        public decimal? TB_REC_DET_ALT { get; set; }
        public decimal? TB_REC_DET_ANC { get; set; }
        public decimal? TB_REC_DET_PRO { get; set; }
        public int? TB_REC_DET_VOL { get; set; }

        public int? TB_REC_DET_EST_ING_ID { get; set; }
        public string? TB_REC_DET_EST_ING_DEN { get; set; }

        public float? TB_REC_DET_PMAT { get; set; }

        public string? TB_REC_DET_REU_DEN { get; set; }

        public int? TB_REC_DET_MAT_ETI_ID { get; set; }
        public string? TB_REC_DET_MAT_ETI_DEN { get; set; }

        public int? TB_REC_DET_CANT_MULT { get; set; }
        public int? TB_REC_DET_CANT_ELIM { get; set; }
        public int? TB_REC_DET_REC_CANT { get; set; }
        public int? TB_REC_DET_REC_STOCK { get; set; }
        public int? TB_REC_DET_REC_TOT { get; set; }
        public int? TB_REC_DET_REC_UDE { get; set; }

        public int? TB_REC_DET_STOCK { get; set; }
        public int? TB_REC_DET_TOT { get; set; }

        public int? TB_REC_DET_LAV_CANT { get; set; }
        public int? TB_REC_DET_LAV_TOT { get; set; }
        public int? TB_REC_DET_LAV_UDE { get; set; }

        public int? TB_REC_DET_DEC_CANT { get; set; }
        public int? TB_REC_DET_DEC_TOT { get; set; }
        public int? TB_REC_DET_DEC_UDE { get; set; }

        public int? TB_REC_DET_TRA_CANT { get; set; }
        public int? TB_REC_DET_TRA_STOCK { get; set; }
        public int? TB_REC_DET_TRA_TOT { get; set; }
        public int? TB_REC_DET_TRA_UDE { get; set; }

        public int? TB_REC_DET_EMP_CANT { get; set; }
        public int? TB_REC_DET_EMP_TOT { get; set; }
        public int? TB_REC_DET_EMP_UDE { get; set; }

        public int? TB_REC_DET_PRO_ABO { get; set; }
        public int? TB_REC_DET_PRO_CANT { get; set; }
        public int? TB_REC_DET_PRO_TOT { get; set; }
        public int? TB_REC_DET_PRO_UDE { get; set; }

        public int? TB_REC_DET_ENT_TOT { get; set; }
        public int? TB_REC_DET_ENT_UDE { get; set; }

        public int? TB_REC_DET_SEC_CANT { get; set; }
        public int? TB_REC_DET_SEC_STOCK { get; set; }
        public int? TB_REC_DET_SEC_TOT { get; set; }

        public int? TB_REC_DET_DEV_CANT { get; set; }

        public int? TB_REC_DET_NUM_1 { get; set; }

        public string? TB_REC_DET_TXT_1 { get; set; }
        public string? TB_REC_DET_TXT_2 { get; set; }

        public DateTime? TB_REC_DET_DTI_2 { get; set; }
        public DateTime? TB_REC_DET_DTI_3 { get; set; }

        public string? TB_REC_DET_MEM_1 { get; set; }
        public string? TB_REC_DET_MEM_2 { get; set; }
        public string? TB_REC_DET_MEM_3 { get; set; }

        public int? TB_REC_DET_SEC_PROC_STOCK { get; set; }
        public int? TB_REC_DET_SEC_PROC_TOT { get; set; }
        public int? TB_REC_DET_PROC_SEC_STOCK { get; set; }
        public int? TB_REC_DET_SEC_REG_STOCK { get; set; }
        public int? TB_REC_DET_SEC_REG_TOT { get; set; }

        public int? TB_REC_DET_MORT { get; set; }

        public string? TB_REC_DET_IVIS_OPC_NOM { get; set; }
        public string? TB_REC_DET_ACAJ_OPC_NOM { get; set; }

        public string? TB_REC_DET_LOT { get; set; }
        public string? TB_REC_DET_DAT { get; set; }

        public int? TB_REC_DET_PRO_PTI_ID { get; set; }
        public string? TB_REC_DET_PRO_PTI_DEN { get; set; }

        public int? TB_REC_DET_FENT_STOCK { get; set; }
        public int? TB_REC_DET_FENT_TOT { get; set; }
        public int? TB_REC_DET_FREC_STOCK { get; set; }
        public int? TB_REC_DET_FREC_TOT { get; set; }

        public bool TB_REC_DET_EME_OPC { get; set; }
        public bool TB_REC_DET_EPR_OPC { get; set; }
        public bool TB_REC_DET_VOP_OPC { get; set; }
        public bool TB_REC_DET_REU_OPC { get; set; }
        public bool TB_REC_DET_MDE { get; set; }
        public bool TB_REC_DET_MCO { get; set; }

        public bool TB_REC_DET_VOP_CK_1 { get; set; }
        public bool TB_REC_DET_VOP_CK_2 { get; set; }
        public bool TB_REC_DET_VOP_CK_3 { get; set; }
        public bool TB_REC_DET_VOP_CK_4 { get; set; }
        public bool TB_REC_DET_VOP_CK_5 { get; set; }

        public bool TB_REC_DET_IVIS_OPC { get; set; }
        public bool TB_REC_DET_ACAJ_OPC { get; set; }
        public bool TB_REC_DET_TRA_OPC { get; set; }

        public string? TbRecDetReuId { get; set; }
        public int? TbRecDetMatId { get; set; }

        public int? TbRecDetEstId { get; set; }
        public DateTime? TB_REC_DET_VEN { get; set; }
        public int? TB_REC_DET_REU_CANT { get; set; }

        public RegistroControlArmadoDto? RegistroControlArmado { get; set; }
    }
}