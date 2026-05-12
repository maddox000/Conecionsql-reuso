// Models/Procesos/TbProNcoDto.cs

namespace ConexionSql.Models.Procesos
{
    public class TbProNcoDto
    {
        // TB_PRO_NCO_ID
        public int TB_PRO_NCO_ID { get; set; }

        // TB_PRO_NCO_DEN
        public string? TB_PRO_NCO_DEN { get; set; }

        // TB_PRO_NCO_OCU
        public bool TB_PRO_NCO_OCU { get; set; }

        // TB_PRO_NCO_EST_ID
        public int? TB_PRO_NCO_EST_ID { get; set; }
    }
}