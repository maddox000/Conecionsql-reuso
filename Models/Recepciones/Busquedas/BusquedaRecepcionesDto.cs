namespace ConexionSql.Models.Recepciones.Busquedas
{
    public class BusquedaRecepcionesDto
    {
        // TB_REC_DET_ID
        public int CodigoEtiqueta { get; set; }

        // TB_REC_ID
        public int Recepcion { get; set; }

        // TB_REC_FEC
        public DateTime Fecha { get; set; }

        // TB_REC_SEC_DES_DEN
        public string? Sector { get; set; }

        // IB_MAT_DEN
        public string? Denominacion { get; set; }

        // TB_REC_DET_CANT
        public int Cantidad { get; set; }
    }
}
