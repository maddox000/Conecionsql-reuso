namespace ConexionSql.InfoBasica.Dtos
{
    public class IBProveedorDto
    {
        public int Id { get; set; }
        public string Denominacion { get; set; } = string.Empty;
        public bool Oculto { get; set; }
    }
}
