using System.Collections.Generic;
using ConexionSql.Models.Estados;
using ConexionSql.Models.Materiales;

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

    }
}
