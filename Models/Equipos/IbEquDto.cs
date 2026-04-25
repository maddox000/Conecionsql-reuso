using System;

namespace ConexionSql.Models.Equipos
{
    public class IbEquDto
    {
        public int IbEquId { get; set; }
        public int? IbEquIdForm { get; set; }

        public int? IbEquTeqId { get; set; }
        public string? IbEquTeqDen { get; set; }

        public int? IbEquPtiId { get; set; }
        public string? IbEquPtiDen { get; set; }

        public int? IbEquMarId { get; set; }
        public string? IbEquMarDen { get; set; }

        public string? IbEquMod { get; set; }
        public string? IbEquSer { get; set; }
        public int? IbEquNum { get; set; }

        public int? IbEquAlt { get; set; }
        public int? IbEquAnc { get; set; }
        public int? IbEquPro { get; set; }
        public int? IbEquPorc { get; set; }
        public int? IbEquCap { get; set; }
        public int? IbEquCapu { get; set; }

        public int? IbEquCagCant { get; set; }
        public int? IbEquCagVal { get; set; }
        public int? IbEquCag { get; set; }

        public int? IbEquCaiCant { get; set; }
        public int? IbEquCaiVal { get; set; }
        public string? IbEquCai { get; set; }

        public int? IbEquCelCant { get; set; }
        public int? IbEquCelVal { get; set; }
        public int? IbEquCel { get; set; }

        public int? IbEquCesCant { get; set; }
        public int? IbEquCesVal { get; set; }
        public int? IbEquCes { get; set; }

        public int? IbEquPteCant { get; set; }
        public int? IbEquPteVal { get; set; }
        public int? IbEquPte { get; set; }

        public int? IbEquPco { get; set; }
        public int? IbEquPcoCoef { get; set; }
        public int? IbEquPve { get; set; }

        public string? IbEquTxt1 { get; set; }
        public string? IbEquTxt2 { get; set; }
        public string? IbEquTxt3 { get; set; }

        public int? IbEquNum1 { get; set; }
        public int? IbEquNum2 { get; set; }
        public int? IbEquNum3 { get; set; }

        public DateTime? IbEquDti1 { get; set; }
        public DateTime? IbEquDti2 { get; set; }
        public DateTime? IbEquDti3 { get; set; }

        public bool IbEquOcu { get; set; }
        public int? IbEquLmat { get; set; }

        // Campo visual usado por ViewEquipo.cshtml
        //public string? TipoCiclo { get; set; }
    }
}