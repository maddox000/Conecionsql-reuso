using System;

namespace ConexionSql.Models.Sectores
{
    public class IbSecDto
    {
        // IB_SEC_ID
        public int IbSecId { get; set; }

        // IB_SEC_ID_FORM
        public int? IbSecIdForm { get; set; }

        // IB_SEC_DEN
        public string? IbSecDen { get; set; }

        // IB_SEC_OCU
        public bool IbSecOcu { get; set; }

        // IB_SEC_DES_ID
        public int? IbSecDesId { get; set; }

        // IB_SEC_DES_DEN
        public string? IbSecDesDen { get; set; }

        // IB_SEC_EM
        public string? IbSecEm { get; set; }

        // IB_SEC_TRA_OPC
        public bool IbSecTraOpc { get; set; }

        // IB_SEC_VEN_OPC
        public bool IbSecVenOpc { get; set; }

        // IB_SEC_VEN
        public int? IbSecVen { get; set; }

        // IB_SEC_GRU_ID
        public int? IbSecGruId { get; set; }

        // IB_SEC_GRU_DEN
        public string? IbSecGruDen { get; set; }
    }
}