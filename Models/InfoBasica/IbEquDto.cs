using System.Collections.Generic;

namespace ConexionSql.Models.InfoBasica
{
    public class IbEquDto
    {
        // --- DATOS DEL EQUIPO ---
        public int IbEquId { get; set; }
        public int IbEquTeqId { get; set; }
        public string? IbEquTeqDen { get; set; }
        public int IbEquPtiId { get; set; }
        public string? IbEquPtiDen { get; set; }
        public int IbEquMarId { get; set; }
        public string? IbEquMarDen { get; set; }
        public string? IbEquMod { get; set; }
        public string? IbEquSer { get; set; }
        public string? IbEquNum { get; set; }
        public bool IbEquOcu { get; set; }

        // --- CARACTERÍSTICAS ---
        public string? IbEquAlt { get; set; }
        public string? IbEquAnc { get; set; }
        public string? IbEquPro { get; set; }
        public string? IbEquCap { get; set; }
        public string? IbEquPorc { get; set; }
        public string? IbEquCapu { get; set; }
        public string? IbEquLmat { get; set; }

        // --- VALORES DE PROCESO ---
        public decimal IbEquPco { get; set; }
        public decimal IbEquPcoCoef { get; set; }
        public decimal IbEquPve { get; set; }

        // --- NUEVO: La lista de detalles que viene de la grilla dinámica ---
        public List<IbEquPtiDetDto> Detalles { get; set; } = new List<IbEquPtiDetDto>();
    }

    // DTO secundario para las filas de volumen permitido (IB_EQU_PTI_DET)
    public class IbEquPtiDetDto
    {
        public int IbEquPtiDetId { get; set; }
        public int IbEquPtiDetEquId { get; set; }
        public int IbEquPtiDetTciId { get; set; }
        public string? IbEquPtiDetTciDen { get; set; }
        public decimal IbEquPtiDetVol { get; set; }
        public bool IbEquPtiDetOcu { get; set; }
    }

    // Agregalo al final de IbEquDto.cs (antes de cerrar el namespace)
    public class IbEquGrillaDto
    {
        public int IbEquId { get; set; }
        public string? IbEquTeqDen { get; set; }
        public string? IbEquMarDen { get; set; }
        public string? IbEquMod { get; set; }
        public string? IbEquSer { get; set; }
        public string? IbEquNum { get; set; }
        public bool IbEquOcu { get; set; }
    }
}