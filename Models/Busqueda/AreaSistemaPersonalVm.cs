namespace ConexionSql.Models.Busqueda
{
    public class AreaSistemaPersonalVm
    {
        public int IbPerId { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public string? Cargo { get; set; }
        public string? Seccion { get; set; }
    }
}
