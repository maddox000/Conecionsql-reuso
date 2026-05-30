using System.ComponentModel.DataAnnotations;

namespace ConexionSql.Models.InfoBasica
{
    public class IBPersonalDto
    {
        [Key]
        public int PersonalId { get; set; }

        public string Apellido { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Cargo { get; set; } = string.Empty;
        public string NivelUsuario { get; set; } = string.Empty;
        public string Sector { get; set; } = string.Empty;
        public bool Inhabilitado { get; set; }
    }
}