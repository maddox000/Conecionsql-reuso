namespace ConexionSql.Models.IbPer
{
    public class IbPerDto
    {
        public int IbPerId { get; set; }
        public string IbPerNom { get; set; }
        public string IbPerApe { get; set; }
        public int? IbPerUniId { get; set; }  // Para que funcione el combo en insert
        public int? IbPerCarId { get; set; }
        public int? IbSecId { get; set; }

        public string? IbPerUniDen { get; set; }
        public string? IbPerCarDen { get; set; }
        public string? IbSecDen { get; set; }

        public string? IbPerLeg { get; set; }     // ← FALTABA
        public string? IbPerPas { get; set; }     // ← FALTABA
        public string? IbPsw { get; set; }
    }
}