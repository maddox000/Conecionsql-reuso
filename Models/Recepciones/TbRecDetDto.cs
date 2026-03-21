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

        // Los siguientes campos se comentan hasta que se usen activamente:

        //// 🏢 ID del sector de origen (referencia a IB_SEC)
        //public int TB_REC_SEC_ORI_ID { get; set; }

        //// 🏢 Nombre del sector de origen
        //public string TB_REC_SEC_ORI_DEN { get; set; }

        //// 🏢 ID del sector de destino (referencia a IB_SEC)
        //public int TB_REC_SEC_DES_ID { get; set; }

        //// 🏢 Nombre del sector de destino
        //public string TB_REC_SEC_DES_DEN { get; set; }

        // TB_REC_DET_MAT_PR (Código producto)
        public string? TB_REC_DET_MAT_PR { get; set; }

        // TB_REC_DET_REU_ID (Código reuso)
        public string? TB_REC_DET_REU_ID { get; set; }

        // TB_REC_DET_REP_ID (Revisión)
        public int? TB_REC_DET_REP_ID { get; set; }
    }
}
