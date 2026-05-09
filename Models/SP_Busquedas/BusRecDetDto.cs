using System;

namespace ConexionSql.Models.SP_Busquedas
{
    public class BusRecDetDto
    {
        // Campos Principales de Identificación
        public int TB_REC_DET_ID { get; set; }
        public int TB_REC_ID { get; set; }
        public DateTime? TB_REC_FEC { get; set; }
        public string TB_REC_HOR_INI { get; set; }

        // Origen y Destino
        public int? TB_REC_SEC_ORI_ID { get; set; }
        public string TB_REC_SEC_ORI_DEN { get; set; }
        public int? TB_REC_SEC_DES_ID { get; set; }
        public string TB_REC_SEC_DES_DEN { get; set; }

        // Orden de Trabajo / Denominación
        public int? TB_REC_ORT_ID { get; set; }
        public string TB_REC_ORT_DEN { get; set; }
        public int? TB_REC_CANT_TOT { get; set; }
        public string TB_REC_LOT { get; set; }

        // Datos del Material Detalle
        public int? TB_REC_DET_MAT_ID { get; set; }
        public string TB_REC_DET_MAT_PR { get; set; }
        public string TB_REC_DET_MAT_DEN { get; set; }
        public int? TB_REC_DET_CANT_MULT { get; set; }
        public int? TB_REC_DET_CANT { get; set; }

        // Opciones y Flags
        public string TB_REC_DET_MDE { get; set; }
        public string TB_REC_DET_MCO { get; set; }
        public bool? TB_REC_DET_VOP_OPC { get; set; }
        public bool? TB_REC_DET_REU_OPC { get; set; }

        // Estados
        public int? TB_REC_DET_EST_ID { get; set; }
        public string TB_REC_DET_EST_DEN { get; set; }
        public int? TB_REC_DET_EST_ING_ID { get; set; }
        public string TB_REC_DET_EST_ING_DEN { get; set; }

        // Lotes y Vencimientos
        public string TB_REC_DET_LOT { get; set; }
        public DateTime? TB_REC_DET_VEN { get; set; }

        // Información Adicional (Paciente/Profesional)
        public string TB_REC_DET_NUM_3 { get; set; }
        public string TB_REC_DET_TXT_3 { get; set; }
        public string TB_REC_DET_REU_ID { get; set; }
        public int? TB_REC_DET_REU_CANT { get; set; }
        public string TB_REC_DET_PAC { get; set; }
        public int? TB_REC_DET_PRO_ID { get; set; }
        public string TB_REC_DET_PRO_NOM { get; set; }

        // Entrega y Observaciones
        public string TB_REC_DET_REM { get; set; }
        public DateTime? TB_REC_DET_FEN { get; set; }
        public string TB_REC_DET_HEN { get; set; }
        public string TB_REC_DET_OBS { get; set; }
        public string TB_REC_DET_PMAT { get; set; }
        public string TB_REC_DET_MORT { get; set; }

        // Opciones de Caja y Visibilidad
        public bool? TB_REC_DET_IVIS_OPC { get; set; }
        public string TB_REC_DET_IVIS_OPC_NOM { get; set; }
        public bool? TB_REC_DET_ACAJ_OPC { get; set; }
        public string TB_REC_DET_ACAJ_OPC_NOM { get; set; }
    }
}
