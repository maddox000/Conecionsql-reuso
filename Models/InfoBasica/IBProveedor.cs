using System.ComponentModel.DataAnnotations;

namespace ConexionSql.InfoBasica.Models
{
    public class IBProveedor
    {
        [Key]
        public int IB_ORT_ID { get; set; }

        public string IB_ORT_DEN { get; set; } = string.Empty;

        public bool IB_ORT_OCU { get; set; }
    }
}
