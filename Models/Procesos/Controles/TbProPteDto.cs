namespace ConexionSql.Models.Procesos.Controles
{
    public class TbProPteDto
    {
        // IB_PTE_ID
        public int IB_PTE_ID { get; set; }

        // IB_PTE_DEN
        public string? IB_PTE_DEN { get; set; }

        // IB_PTE_PTI_ID
        public int? IB_PTE_PTI_ID { get; set; }

        // IB_PTE_PTI_DEN
        public string? IB_PTE_PTI_DEN { get; set; }

        // IB_PTE_PTI_OCU
        public bool IB_PTE_PTI_OCU { get; set; }
    }
}