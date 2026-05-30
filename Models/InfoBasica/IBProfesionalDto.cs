namespace ConexionSql.InfoBasica.Dtos
{
    public class IBProfesionalDto
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public bool Oculto { get; set; }
    }
}