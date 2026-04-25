using System;

namespace ConexionSql.Models.Proveedores
{
    public class IbOrtDto
    {
        public int IbOrtId { get; set; }
        public int? IbOrtIdForm { get; set; }
        public string? IbOrtDen { get; set; }
        public bool IbOrtOcu { get; set; }

        public int? IbOrtNum1 { get; set; }
        public int? IbOrtNum2 { get; set; }
        public int? IbOrtNum3 { get; set; }

        public string? IbOrtTxt1 { get; set; }
        public string? IbOrtTxt2 { get; set; }
        public string? IbOrtTxt3 { get; set; }

        public DateTime? IbOrtDat1 { get; set; }
        public DateTime? IbOrtDat2 { get; set; }
        public DateTime? IbOrtDat3 { get; set; }

        public string? IbOrtMem1 { get; set; }
        public string? IbOrtMem2 { get; set; }
        public string? IbOrtMem3 { get; set; }
    }
}