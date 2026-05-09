using System;

namespace ConexionSql.Models.Procesos
{
    public class TbProDetDto
    {
        // 🔑 Clave primaria
        public int TB_PRO_DET_ID { get; set; }

        // 🔗 Relación con proceso principal
        public int? TB_PRO_ID { get; set; }

        // 🏷️ Etiqueta de recepción
        public int TB_PRO_DET_REC_DET_ID { get; set; }

        // 📦 Material
        public int TB_PRO_DET_REC_DET_MAT_ID { get; set; }
        public string? TB_PRO_DET_REC_DET_MAT_DEN { get; set; }

        // 🧪 Tipo de material
        public int? TB_PRO_DET_REC_DET_MAT_TIP_ID { get; set; }
        public string? TB_PRO_DET_REC_DET_MAT_TIP_DEN { get; set; }

        // 🔢 Cantidades
        public int? TB_PRO_DET_REC_DET_CANT { get; set; }
        public int? TB_PRO_DET_REC_DET_PRO_STOCK { get; set; }
        public int? TB_PRO_DET_REC_DET_PRO_CANT { get; set; }
        public int? TB_PRO_DET_REC_DET_PRO_TOT { get; set; }

        // 🏭 Sector destino
        public int? TB_REC_SEC_DES_ID { get; set; }
        public string? TB_REC_SEC_DES_DEN { get; set; }

        // 📄 Código reutilización
        public string? TB_PRO_DET_REC_DET_REU_ID { get; set; }

        // 📦 Cantidad a procesar (puede diferir del recibido)
        public int? TB_PRO_DET_CANT { get; set; }

        // ✅ Controlado / Aprobado
        public int? TB_PRO_DET_CANT_CTRL { get; set; }
        public int? TB_PRO_DET_CANT_ABO { get; set; }

        // 🧾 Observaciones
        public string? TB_PRO_DET_MEM_1 { get; set; }

        // 👤 Usuario / máquina
        public string? TB_PRO_DET_PC_LOG { get; set; }
        public string? TB_PRO_DET_PC_USR { get; set; }

        // 📅 Fecha
        public DateTime? TB_PRO_FEC { get; set; }
        // 🔥 REC
        public int? TB_PRO_DET_REC_ID { get; set; }

        // 🔥 SECTORES ORIGEN
        public int? TB_REC_SEC_ORI_ID { get; set; }
        public string? TB_REC_SEC_ORI_DEN { get; set; }

        // 🔥 ORIGEN / LOTE
        public int? TB_REC_ORT_ID { get; set; }
        public string? TB_REC_ORT_DEN { get; set; }
        public string? TB_COD_TEX_LOT { get; set; }

        // 🔥 VOLUMEN
        public int? IB_MAT_VOL { get; set; }

        // 🔥 EQUIPO / CAPACIDAD
        public int IB_EQU_CAP { get; set; }
        public int? IB_EQU_CAPU { get; set; }
        public int? IB_EQU_CAPR { get; set; }
        public int? IB_EQU_PCO { get; set; }
        public int? IB_EQU_PVE { get; set; }

        // 🔥 PROCESO
        public int? TB_PRO_PTI_ID { get; set; }
        public string? TB_PRO_PTI_DEN { get; set; }
        public int? TB_PRO_EQU_ID { get; set; }
        public int? TB_PRO_IB_EQU_TEQ_ID { get; set; }
        public string? TB_PRO_IB_EQU_TEQ_DEN { get; set; }
        public int? TB_PRO_EQU_NUM { get; set; }
        public string? TB_PRO_EQU_DEN { get; set; }
        public int? TB_PRO_EQU_MAR_ID { get; set; }
        public string? TB_PRO_EQU_MAR_DEN { get; set; }
        public string? TB_PRO_EQU_MOD { get; set; }
        public string? TB_PRO_EQU_SER { get; set; }
        public int? TB_PRO_TCI_ID { get; set; }
        public string? TB_PRO_TCI_DEN { get; set; }

        // 🔥 NUM / TXT
        public int? TB_PRO_DET_NUM_1 { get; set; }
        public int? TB_PRO_DET_NUM_2 { get; set; }
        public int? TB_PRO_DET_NUM_3 { get; set; }

        public string? TB_PRO_DET_TXT_1 { get; set; }
        public string? TB_PRO_DET_TXT_2 { get; set; }
        public string? TB_PRO_DET_TXT_3 { get; set; }

        // 🔥 FECHAS AUX
        public DateTime? TB_PRO_DET_DTI_1 { get; set; }
        public DateTime? TB_PRO_DET_DTI_2 { get; set; }
        public DateTime? TB_PRO_DET_DTI_3 { get; set; }

        // 🔥 MEMOS
        public string? TB_PRO_DET_MEM_2 { get; set; }
        public string? TB_PRO_DET_MEM_3 { get; set; }

        // 🔥 ESTADO
        public bool TB_PRO_DET_REPRO { get; set; }
        public int? TB_PRO_DET_EST_ID { get; set; }
        public string? TB_PRO_DET_EST_DEN { get; set; }
        public DateTime? TB_PRO_DET_EST_FEC { get; set; }

        // 🔥 MULT / ELIM
        public int? TB_PRO_DET_CANT_MULT { get; set; }
        public int? TB_PRO_DET_CANT_ELIM { get; set; }
    }
}
