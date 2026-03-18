namespace ConexionSql.Models.A_PSW_LOG
{
    public class LoginRequest
    {
        public int Id { get; set; }          // ID del usuario seleccionado
        public string Clave { get; set; } = string.Empty; // contraseña ingresada
    }
}