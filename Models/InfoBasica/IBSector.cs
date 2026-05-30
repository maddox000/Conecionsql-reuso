using System.ComponentModel.DataAnnotations;

namespace ConexionSql.Models.InfoBasica
{
    public class IBSector
    {
        [Key]
        public int SectorId { get; set; }

        public string SectorDenominacion { get; set; } = string.Empty;

        public string SectorDestino { get; set; } = string.Empty;

        public bool ActivarTraslados { get; set; }

        public bool Oculto { get; set; }
    }
}
