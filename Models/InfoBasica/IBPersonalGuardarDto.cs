namespace ConexionSql.Models.InfoBasica
{
    public class IBPersonalGuardarDto
    {
        public int Id { get; set; }

        public string Apellido { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;

        public int CargoId { get; set; }
        public int NivelUsuarioId { get; set; }
        public int SectorId { get; set; }

        public bool Inhabilitado { get; set; }

        public string? Password { get; set; }
        public string? PasswordRepite { get; set; }
    }
}
