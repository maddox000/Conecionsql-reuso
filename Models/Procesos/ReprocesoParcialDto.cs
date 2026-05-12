namespace ConexionSql.Models.Procesos
{
    public class ReprocesoParcialDto
    {
        public int TbProId { get; set; }

        public int MotivoId { get; set; }

        public List<ReprocesoParcialItemDto> Detalles { get; set; } = new();
    }

    public class ReprocesoParcialItemDto
    {
        public int TbProDetId { get; set; }

        public int Cantidad { get; set; }
    }
}