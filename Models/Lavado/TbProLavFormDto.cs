using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace ConexionSql.Models.Lavado
{
    public class TbProLavFormDto
    {
        // 🧼 Tipo de Lavado
        public int TipoLavadoId { get; set; }
        public string? TipoLavadoDen { get; set; }

        // ⚙️ Equipo (si no es MANUAL)
        public int? EquipoId { get; set; }
        public string? EquipoDen { get; set; }

        // 🔄 Tipo de Ciclo (si no es MANUAL)
        public int? TipoCicloId { get; set; }
        public string? TipoCicloDen { get; set; }

        // 📅 Fecha y Horas
        public DateTime? Fecha { get; set; }
        public TimeSpan? HoraIni { get; set; }
        public TimeSpan? HoraFin { get; set; }

        // 🖥️ Log
        public string? PcLog { get; set; }
        public string? PcUsr { get; set; }

        // 📋 Combos
        public List<SelectListItem>? TiposLavado { get; set; }
        public List<SelectListItem>? Equipos { get; set; }
        public List<SelectListItem>? TiposCiclo { get; set; }
    }
}
