namespace ConexionSql.Models.Estados
{
    public class IbEstDto
    {
        // ID del estado
        public int IbEstId { get; set; }

        // Denominación del estado
        public string? IbEstDen { get; set; }

        // Para uso general si necesitás mostrar algo más adelante
        public string? DescripcionCompleta => IbEstDen;
    }
}
