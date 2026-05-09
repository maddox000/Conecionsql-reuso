using System;

namespace ConexionSql.Models.SP_Busquedas
{
    public class BusProDto
    {
        // Identificación y Tiempos
        public int TB_PRO_ID { get; set; }
        public string TB_PRO_NUM_1 { get; set; }
        public DateTime? TB_PRO_FEC { get; set; }
        public string TB_PRO_HOR_INI { get; set; }

        // Datos del Equipo (Viene concatenado del SP)
        public string EQUIPO { get; set; }

        // Ciclo y Usuario
        public string TB_PRO_TCI_DEN { get; set; }
        public string TB_PRO_UPRO { get; set; }

        // Estado
        public int IB_PRO_EST_ID { get; set; }
        public string IB_PRO_EST_DEN { get; set; }

        // Programa / PTI
        public int TB_PRO_PTI_ID { get; set; }
        public string TB_PRO_PTI_DEN { get; set; }
    }
}
