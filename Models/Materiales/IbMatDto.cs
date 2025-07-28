namespace ConexionSql.Models.Materiales
{
    public class IbMatDto
    {
        // IB_MAT_ID
        public int IbMatId { get; set; }

        // IB_MAT_DEN
        public string? IbMatDen { get; set; }

        // IB_MAT_MAR_DEN
        public string? IbMatMarDen { get; set; }

        // IB_MAT_PRO_DEN
        public string? IbMatProDen { get; set; }

        // IB_MAT_MTI_DEN
        public string? IbMatMtiDen { get; set; }

        // Para mostrar algo combinado como "Denominación - Marca"
        public string DescripcionCompleta => $"{IbMatDen} ({IbMatMarDen})";
    }
}
