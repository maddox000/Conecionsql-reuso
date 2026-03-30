using ConexionSql.Models.Estados;
using ConexionSql.Models.IbPer;
using ConexionSql.Models.Materiales;
using System.Collections.Generic;

namespace ConexionSql.Models.Recepciones
{
    public class TbRecDetFormDto
    {
        // Objeto que se envía al backend al guardar
        public TbRecDetDto Detalle { get; set; } = new TbRecDetDto();

        // Lista de materiales para el combobox
        public List<IbMatDto> Materiales { get; set; } = new List<IbMatDto>();

        // Lista de estados para el combobox
        public List<IbEstDto> Estados { get; set; } = new List<IbEstDto>();

        // Lista de revision para el combobox
        public List<IbMatRevDto> Revisiones { get; set; } = new List<IbMatRevDto>();

        // Default de estado desde configuración
        public int? EstadoDefaultId { get; set; }

    }
}
