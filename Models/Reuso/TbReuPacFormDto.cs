namespace ConexionSql.Models.Reusos
{
    public class TbReuPacFormDto
    {
        public int TB_REU_ID { get; set; }
        public int TB_REC_ID { get; set; }
        public string? CODIGO_REUSO { get; set; }
        public string? NOMBRE { get; set; }
        public string? APELLIDO { get; set; }
        public string? HISTORIA_CLINICA { get; set; }
        public string? DOCUMENTO { get; set; }
        public int EDAD { get; set; }
        public string? OBRA_SOCIAL { get; set; }
        public bool ELIMINAR { get; set; }
    }
}