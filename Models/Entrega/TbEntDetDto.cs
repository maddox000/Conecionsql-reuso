using System;

namespace ConexionSql.Models.Entrega
{
    public class TbEntDetDto
    {
        public int? TbEntId { get; set; }
        public int? TB_ENT_ID { get; set; }

        public int TbEntDetId { get; set; }
        public int TB_ENT_DET_ID { get; set; }

        public string? TbEntDetPcLog { get; set; }
        public string? TbEntDetPcUsr { get; set; }

        public int? TbEntDetRecDetId { get; set; }
        public int? TB_ENT_DET_REC_DET_ID { get; set; }

        public int? TbEntDetRecDetMatId { get; set; }
        public int? IB_MAT_ID { get; set; }

        public string? TbEntDetRecDetMatDen { get; set; }

        public int? TbEntDetRecDetMatTipId { get; set; }
        public string? TbEntDetRecDetMatTipDen { get; set; }

        public int? TbEntDetRecDetCant { get; set; }
        public int? Recibidos { get; set; }

        public int? TbEntDetRecDetEntStock { get; set; }
        public int? Pendientes { get; set; }

        public int? TbEntDetRecDetEntCant { get; set; }

        public int? TbEntDetRecDetEntTot { get; set; }
        public int? Entregados { get; set; }

        public int? TbEntDetRecId { get; set; }

        public string? TbEntDetRecDetReuId { get; set; }
        public string? CodigoReuso { get; set; }

        public int? TbEntDetCant { get; set; }
        public int? TB_ENT_DET_CANT { get; set; }

        public string? TbEntDetRecDetPac { get; set; }

        public int? TbRecDetProId { get; set; }
        public string? TbRecDetProNom { get; set; }
        public string? TbRecDetProApe { get; set; }

        public string? TbRecDetRem { get; set; }

        public int? TbEntSecId { get; set; }
        public string? TbEntSecDen { get; set; }

        public DateTime? TbEntFec { get; set; }

        public int? TbEntDetNum1 { get; set; }
        public int? TbEntDetNum2 { get; set; }
        public int? TbEntDetNum3 { get; set; }

        public string? TbEntDetTxt1 { get; set; }
        public string? TbEntDetTxt2 { get; set; }
        public string? TbEntDetTxt3 { get; set; }

        public DateTime? TbEntDetDti1 { get; set; }
        public DateTime? TbEntDetDti2 { get; set; }
        public DateTime? TbEntDetDti3 { get; set; }

        public string? TbEntDetMem1 { get; set; }
        public string? TbEntDetMem2 { get; set; }
        public string? TbEntDetMem3 { get; set; }

        public bool? TbEntDetCkl1 { get; set; }
        public bool? TbEntDetCkl2 { get; set; }
        public bool? TbEntDetCkl3 { get; set; }
        public bool? TbEntDetCkl4 { get; set; }
        public bool? TbEntDetCkl5 { get; set; }
        public bool? TbEntDetCkl6 { get; set; }

        public bool? TbEntDetBit1 { get; set; }
        public bool? TbEntDetBit2 { get; set; }
        public bool? TbEntDetBit3 { get; set; }

        public int? TbEntDetCantMult { get; set; }
        public int? TbEntDetCantElim { get; set; }

        public string? TbEntDetDat { get; set; }

        public int? TbEntDetMatEtiId { get; set; }
        public string? TbEntDetMatEtiDen { get; set; }

        public int? TbEntDetProPtiId { get; set; }
        public string? TbEntDetProPtiDen { get; set; }

        public int? TbEntDetTranspOpcId { get; set; }
        public string? TbEntDetTranspOpcDen { get; set; }
        public int? TB_ENT_DET_CANT_ELIM { get; set; }
        public string? TB_ENT_DET_DAT { get; set; }
    }
}