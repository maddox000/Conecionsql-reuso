public class ResultadoValidacionVen
{
    public bool Ok { get; set; }
    public string? Mensaje { get; set; }

    // Reset
    public int ReuId { get; set; }
    public string? ReuDen { get; set; }
    public int MatId { get; set; }
    public string? MatDen { get; set; }
    public string? CodigoReuso { get; set; }

    // Flujo
    public string? SiguientePaso { get; set; }
}