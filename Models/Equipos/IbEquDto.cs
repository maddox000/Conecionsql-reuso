using System;

namespace ConexionSql.Models.Equipos
{
    public class IbEquDto
    {
        public int IbEquId { get; set; }
        public int? IbEquTeqId { get; set; }
        public string? IbEquTeqDen { get; set; }
        public int? IbEquPtiId { get; set; }
        public string? IbEquPtiDen { get; set; }
        public int? IbEquMarId { get; set; }
        public string? IbEquMarDen { get; set; }
        public string? IbEquMod { get; set; }
        public string? IbEquSer { get; set; }
        public int? IbEquNum { get; set; }
        public int IbEquCap { get; set; }
        public int? IbEquCapu { get; set; }
        public int? IbEquPco { get; set; }
        public int? IbEquPve { get; set; }
        public bool IbEquOcu { get; set; }
    }
}

