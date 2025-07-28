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

        // Los siguientes campos se comentan hasta que se usen activamente:

        //// 🏢 ID del sector de origen (referencia a IB_SEC)
        //public int TB_REC_SEC_ORI_ID { get; set; }

        //// 🏢 Nombre del sector de origen
        //public string TB_REC_SEC_ORI_DEN { get; set; }

        //// 🏢 ID del sector de destino (referencia a IB_SEC)
        //public int TB_REC_SEC_DES_ID { get; set; }

        //// 🏢 Nombre del sector de destino
        //public string TB_REC_SEC_DES_DEN { get; set; }
    }
}
