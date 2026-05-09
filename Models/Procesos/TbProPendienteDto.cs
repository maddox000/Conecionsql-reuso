namespace ConexionSql.Models.Procesos
{
    public class TbProPendienteDto
    {
        public int? TbProId { get; set; }

        public int? IbProEstId { get; set; }

        public DateTime? TbProFec { get; set; }

        public DateTime? TbProHorIni { get; set; }
    }
}