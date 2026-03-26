namespace ConexionSql.Models.Recepciones
{
    public class BuscarMaterialResponseDto
    {
        public bool Ok { get; set; }
        public string Mensaje { get; set; } = string.Empty;

        public int? IbMatId { get; set; }
        public string? IbMatDen { get; set; }

        // "IB_MAT_ID" | "IB_MAT_PR" | "TB_REU"
        public string? Origen { get; set; }

        // útil para lógica posterior
        public bool VieneDeReuso { get; set; }

        public int? Volumen { get; set; }
        public int? IbMatMtiId { get; set; }
    }
}