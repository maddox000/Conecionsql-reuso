using System;

namespace ConexionSql.Models.SP_Busquedas
{
    public class BusLavadoDto
    {
        public int TB_PRO_LAV_ID { get; set; }
        public DateTime TB_PRO_LAV_FEC { get; set; }
        public string? TB_PRO_LAV_PTI_DEN { get; set; }
        public string? TB_PRO_LAV_EST_DEN { get; set; }
        public string? TB_PRO_LAV_NUM { get; set; } // Lote
        public string? TB_PRO_IB_EQU_TEQ_DEN { get; set; }
        public string? TB_PRO_LAV_EQU_NUM { get; set; } // AQUÍ: Cambiado a string para aceptar "NO REGISTRADO"
    }
}