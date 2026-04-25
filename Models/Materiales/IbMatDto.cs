namespace ConexionSql.Models.Materiales
{
    public class IbMatDto
    {
        public int IbMatId { get; set; }
        public int? IbMatIdForm { get; set; }

        public DateTime? IbMatRegFec { get; set; }
        public DateTime? IbMatRegHor { get; set; }
        public DateTime? IbMatActFec { get; set; }

        public string? IbMatPr { get; set; }
        public string? IbMatDen { get; set; }

        public int? IbMatMtiId { get; set; }
        public string? IbMatMtiDen { get; set; }

        public int? IbMatMarId { get; set; }
        public string? IbMatMarDen { get; set; }
        public string? IbMatMarCat { get; set; }

        public int? IbMatProId { get; set; }
        public string? IbMatProDen { get; set; }
        public string? IbMatProCat { get; set; }

        public int? IbMatMgrId { get; set; }
        public string? IbMatMgrDen { get; set; }

        public DateTime? IbMatVen { get; set; }

        public int? IbMatMan { get; set; }
        public DateTime? IbMatManFec { get; set; }
        public DateTime? IbMatManPro { get; set; }

        public int? IbMatReuCant { get; set; }
        public int? IbMatReuCantMan { get; set; }

        public int? IbMatConUnid { get; set; }
        public int? IbMatConAct { get; set; }
        public int? IbMatConDif { get; set; }

        public bool IbMatOcu { get; set; }

        public bool IbMatPriOpc { get; set; }
        public bool IbMatConOpc { get; set; }
        public bool IbMatVopOpc { get; set; }

        public int? IbMatVopOpcForm { get; set; }
        public int? IbMatVopAcoOpcForm { get; set; }

        public bool IbMatReuOpc { get; set; }
        public int? IbMatReuOpcCant { get; set; }

        public bool IbMatEtiEntOpc { get; set; }

        public int? IbMatCant { get; set; }
        public int? IbMatStock { get; set; }

        public int? IbMatTemp { get; set; }
        public int? IbMatQpo { get; set; }

        public int? IbMatLav { get; set; }
        public int? IbMatAco { get; set; }

        public string? IbMatAcoFalt { get; set; }

        public int? IbMatTce { get; set; }

        public int? IbMatAlt { get; set; }
        public int? IbMatAnc { get; set; }
        public int? IbMatPro { get; set; }
        public int? IbMatVol { get; set; }

        public string? IbMatImg1 { get; set; }
        public string? IbMatImg2 { get; set; }
        public string? IbMatImg3 { get; set; }

        public int? IbMatCcoId { get; set; }
        public string? IbMatCcoDen { get; set; }

        public int? IbMatLavId { get; set; }
        public string? IbMatLavDen { get; set; }

        public int? IbMatLavTciId { get; set; }
        public string? IbMatLavTciDen { get; set; }

        public string? IbMatLavTxt { get; set; }

        public string? IbMatAcoTxt { get; set; }

        public string? IbMatEtiTxt { get; set; }

        public int? IbMatProcTim { get; set; }

        public int? IbMatEntTim { get; set; }

        public int? IbMatEstTimTot { get; set; }

        public int? IbMatProc1Id { get; set; }
        public string? IbMatProc1Den { get; set; }

        public int? IbMatProc2Id { get; set; }
        public string? IbMatProc2Den { get; set; }

        public bool IbPmaSel { get; set; }
        public bool IbMstSel { get; set; }
        public bool IbMcoSel { get; set; }

        public string? IbMatTxt1 { get; set; }
        public string? IbMatTxt2 { get; set; }

        public int? IbMatNum1 { get; set; }
        public int? IbMatNum2 { get; set; }

        public DateTime? IbMatDat1 { get; set; }

        public string? IbMatMem1 { get; set; }

        public string? IbMatPcLog { get; set; }
        public string? IbMatPcUsr { get; set; }

        // 🔥 CAMPOS IMPORTANTES PARA TU LISTA
        public int? IbMatEstIngId { get; set; }
        public string? IbMatEstIngDen { get; set; }

        // Para mostrar algo combinado
        public string DescripcionCompleta => $"{IbMatDen} ({IbMatMarDen})";
    }
}
