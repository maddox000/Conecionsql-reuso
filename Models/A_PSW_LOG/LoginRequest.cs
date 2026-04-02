namespace ConexionSql.Models.A_PSW_LOG
{
    public class LoginRequest
    {
        public int Id { get; set; }          // ID del usuario
        public string Clave { get; set; } = string.Empty;

        public int FormId { get; set; }      // FORM_ID (Access)
        public int EditId { get; set; }      // 1 = Nuevo / 2 = Editar
    }
}