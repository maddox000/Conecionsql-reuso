using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace ConexionSql.Models.Procesos
{
    public class TbProFormDto
    {
        public int TbProId { get; set; }

        // FECHA / HORA
        public string? TbProFec { get; set; }
        public string? TbProHorIni { get; set; }

        // 🔧 Tipo de Proceso
        public int TipoProcesoId { get; set; }
        public string? TipoProcesoDen { get; set; }

        // 🛠️ Equipo
        public int EquipoId { get; set; }
        public string? EquipoDen { get; set; }

        // 🔄 Tipo de Ciclo
        public int TipoCicloId { get; set; }
        public string? TipoCicloDen { get; set; }

        // 🧾 Listas para combos
        public List<SelectListItem> TiposProceso { get; set; } = new();
        public List<SelectListItem> Equipos { get; set; } = new();
        public List<SelectListItem> TiposCiclo { get; set; } = new();

        public int UsuarioId { get; set; }
        public string? UsuarioNom { get; set; }
        public string? UsuarioApe { get; set; }
        public int? UsuarioCarId { get; set; }
        public string? UsuarioCarDen { get; set; }

        public int? ProveedorId { get; set; }
        public string? ProveedorDen { get; set; }
    }
}