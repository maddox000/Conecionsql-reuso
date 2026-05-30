namespace ConexionSql.Models.InfoBasica
{
    public class IbEquTeqDto
    {
        public int IbEquTeqId { get; set; }
        public string? IbEquTeqDen { get; set; }
        public int IbEquPtiId { get; set; }
        public string? IbEquPtiDen { get; set; }
    }

    public class IbEquMarDto
    {
        public int IbEquMarId { get; set; }
        public string? IbEquMarDen { get; set; }
    }

    // --- NUEVO: DTO para el combo de la grilla inferior ---
    public class IbProTciDto
    {
        public int TbProTciId { get; set; }
        public string? TbProTciDen { get; set; }
        public int TbProPtiId { get; set; }
    }
}
