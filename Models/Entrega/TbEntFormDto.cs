using System;

namespace ConexionSql.Models.Entrega // ✅ corregido el namespace según tu carpeta real
{
    /// <summary>
    /// DTO para representar la cabecera de una entrega.
    /// Se usa al crear una nueva entrega (formulario principal).
    /// </summary>
    public class TbEntFormDto
    {
        // 📅 Fecha de la entrega
        public DateTime? TB_ENT_FEC { get; set; }

        // 🕐 Hora de inicio (formato HH:mm)
        public string TB_ENT_HOR_INI { get; set; }

        // 🕓 Hora de fin (formato HH:mm)
        public string TB_ENT_HOR_FIN { get; set; }

        // 👤 ID del personal que realiza la entrega
        public int TB_ENT_PER_ID { get; set; }

        // 👤 Nombre del personal (opcional, para mostrar en combos)
        public string TB_ENT_PER_NOM { get; set; }

        // 🏢 ID del sector destino
        public int TB_ENT_SEC_ID { get; set; }

        // 🏢 Denominación del sector destino
        public string TB_ENT_SEC_DEN { get; set; }

        // 🔢 Cantidad total entregada (se acumula desde los detalles)
        public int TB_ENT_CANT_TOT { get; set; }
    }
}
