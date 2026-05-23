namespace ConexionSql.Models.Lavado
{
    public class TbProLavLiberacionChecksDto
    {
        public int TbProLavId { get; set; }

        public bool TbProLavLpaCk1 { get; set; }
        public bool TbProLavLpaCk2 { get; set; }
        public bool TbProLavLpaCk3 { get; set; }

        public bool LiberarLavado { get; set; }
        public string? ResultadoFinalLavado { get; set; }
    }
}
