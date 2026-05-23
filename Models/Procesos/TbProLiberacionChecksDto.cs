namespace ConexionSql.Models.Procesos
{
    public class TbProLiberacionChecksDto
    {
        public int TbProId { get; set; }

        public bool TbProIenv { get; set; }
        public bool TbProHume { get; set; }
        public bool TbProAusu { get; set; }
        public bool TbProIqvi { get; set; }
        public bool TbProPaci { get; set; }
        public bool TbProIbrn { get; set; }
        public bool TbProIbre { get; set; }
        public string? ResultadoFinalProceso { get; set; }
    }
}