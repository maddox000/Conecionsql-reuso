using System;

namespace ConexionSql.Models.Entrega
{
    public class TbEntDto
    {
        // 📅 Fecha de la entrega
        public DateTime? TB_ENT_FEC { get; set; }

        // 🕒 Hora de inicio
        public DateTime? TB_ENT_HOR_INI { get; set; }

        // 🕒 Hora de fin
        public DateTime? TB_ENT_HOR_FIN { get; set; }

        // 👤 ID del personal (valor del combo)
        public int? TB_ENT_PER_ID { get; set; }

        // 👤 Nombre del personal (texto mostrado en el combo)
        public string? TB_ENT_PER_NOM { get; set; }

        // 🏢 ID del sector destino (valor del combo)
        public int? TB_ENT_SEC_ID { get; set; }

        // 🏢 Denominación del sector (texto mostrado en el combo)
        public string? TB_ENT_SEC_DEN { get; set; }

        // 👤 Personal del sector
        public string? TB_ENT_SEC_PER { get; set; }

        // 📝 Observaciones
        public string? TB_ENT_OBS { get; set; }

        // 🔢 Cantidad total de elementos entregados (se calcula desde los detalles)
        public int? TB_ENT_CANT_TOT { get; set; }
    }
}