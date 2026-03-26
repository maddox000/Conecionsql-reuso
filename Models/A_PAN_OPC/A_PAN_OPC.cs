using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexionSql.Models.A_PAN_OPC
{
    [Table("A_PAN_OPC")]
    public class APanOpc
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("ID_DENOMINACION")]
        public string? IdDenominacion { get; set; }

        [Column("COMENTARIO")]
        public string? Comentario { get; set; }

        [Column("VALOR")]
        public bool Valor { get; set; }
    }
}