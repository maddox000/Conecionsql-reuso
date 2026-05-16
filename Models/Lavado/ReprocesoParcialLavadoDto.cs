namespace ConexionSql.Models.Lavado
{
    public class ReprocesoParcialLavadoDto
    {
        public int TbProLavId { get; set; }

        public int MotivoId { get; set; }

        public List<ReprocesoParcialLavadoItemDto> Detalles { get; set; } = new();
    }

    public class ReprocesoParcialLavadoItemDto
    {
        public int TbProLavDetId { get; set; }

        public int Cantidad { get; set; }
    }
}