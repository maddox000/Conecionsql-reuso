namespace ConexionSql.Models.Recepciones
{
    public class RegistroControlArmadoDto
    {
        public bool Control { get; set; }
        public string? ControladaPor { get; set; }

        public bool ArmadoCaja { get; set; }
        public string? ArmadaPor { get; set; }

        public int? EstadoCajaId { get; set; }
        public string? EstadoCajaDen { get; set; }

        public int? CantidadElementos { get; set; }
        public string? FaltantesObservaciones { get; set; }

        public int? TbRecDetRevId { get; set; }
        public string? TbRecDetRev { get; set; }

        public bool TbRecDetMde { get; set; }
        public bool Vop { get; set; }
        public bool TbRecMco { get; set; }
    }
}