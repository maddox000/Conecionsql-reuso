using System;

namespace ConexionSql.Models.Entrega
{
    public class TbEntDetDto
    {
        // 🔗 ID de la cabecera de entrega (referencia a TB_ENT)
        public int? TB_ENT_ID { get; set; }

        // 🆔 ID del detalle (clave primaria en TB_ENT_DET)
        public int TB_ENT_DET_ID { get; set; }

        // 🏷️ ID del detalle de recepción (etiqueta escaneada)
        public int? TB_ENT_DET_REC_DET_ID { get; set; }

        // 📦 ID del material (traído desde TB_REC_DET.IB_MAT_ID)
        public int? IB_MAT_ID { get; set; }

        // 📦 Denominación del material (traído desde TB_REC_DET.TB_REC_DET_MAT_DEN)
        public string? TbEntDetRecDetMatDen { get; set; }

        // 🔢 Cantidad a entregar (validada contra el stock de TB_REC_DET_ENT_CANT)
        public int? TB_ENT_DET_CANT { get; set; }
    }
}
