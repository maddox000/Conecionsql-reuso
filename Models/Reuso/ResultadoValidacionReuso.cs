public class ResultadoValidacionReuso
{
    public bool Ok { get; set; }
    public string Mensaje { get; set; } = "";

    //VALIDA_REUSOS
    public bool RequiereConfirmacion { get; set; }
    public bool BajaAutomatica { get; set; }
}