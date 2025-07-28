using System;

namespace ConexionSql.Models.Lavado
{
    public class TbProLavDetDto
    {
        // 🔑 Clave primaria
        public int TB_PRO_LAV_DET_ID { get; set; }

        // 🔗 Relación con proceso principal
        public int? TB_PRO_LAV_ID { get; set; }

        // 🏷️ Etiqueta de recepción
        public int TB_PRO_LAV_DET_REC_DET_ID { get; set; }

        // 📦 Material
        public int TB_PRO_LAV_DET_REC_DET_MAT_ID { get; set; }
        public string? TB_PRO_LAV_DET_REC_DET_MAT_DEN { get; set; }

        // 🧪 Tipo de material
        public int? TB_PRO_LAV_DET_REC_DET_MAT_TIP_ID { get; set; }
        public string? TB_PRO_LAV_DET_REC_DET_MAT_TIP_DEN { get; set; }

        // 🔢 Cantidades
        public int? TB_PRO_LAV_DET_REC_DET_CANT { get; set; }
        public int? TB_PRO_LAV_DET_REC_DET_PRO_STOCK { get; set; }
        public int? TB_PRO_LAV_DET_REC_DET_PRO_CANT { get; set; }
        public int? TB_PRO_LAV_DET_REC_DET_PRO_TOT { get; set; }

        // 🏭 Sector destino
        public int? TB_REC_SEC_DES_ID { get; set; }
        public string? TB_REC_SEC_DES_DEN { get; set; }

        // 📄 Código reutilización
        public string? TB_PRO_LAV_DET_REC_DET_REU_ID { get; set; }

        // 📦 Cantidad a procesar (puede diferir del recibido)
        public int? TB_PRO_LAV_DET_CANT { get; set; }

        // ✅ Controlado / Aprobado
        public int? TB_PRO_LAV_DET_CANT_CTRL { get; set; }
        public int? TB_PRO_LAV_DET_CANT_ABO { get; set; }

        // 🧾 Observaciones
        public string? TB_PRO_LAV_DET_MEM_1 { get; set; }

        // 👤 Usuario / máquina
        public string? TB_PRO_LAV_DET_PC_LOG { get; set; }
        public string? TB_PRO_LAV_DET_PC_USR { get; set; }

        // 📅 Fecha
        public DateTime? TB_PRO_LAV_FEC { get; set; }
    }
}

