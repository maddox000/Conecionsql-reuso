using System.Collections.Generic;
using ConexionSql.Models.Entrega;
using ConexionSql.Models.Estados;
using ConexionSql.Models.Materiales;
using ConexionSql.Models.Sectores;

namespace ConexionSql.Models.Entrega
{
    public class TbEntDetFormDto
    {
        // 📝 Objeto que se envía al backend para guardar el detalle
        public TbEntDetDto Detalle { get; set; } = new TbEntDetDto();

        // 📋 Lista de materiales disponibles (si usás combobox en lugar de etiqueta)
        public List<IbMatDto> Materiales { get; set; } = new List<IbMatDto>();

        // 📋 Lista de estados (si el subformulario los requiere)
        public List<IbEstDto> Estados { get; set; } = new List<IbEstDto>();

        // 📋 Lista de sectores (si aplica para validación o visualización)
        public List<IbSec> Sectores { get; set; } = new List<IbSec>();

        // 🧾 Cabecera de la entrega (necesaria si se muestra info arriba del subform)
        public TbEnt? Cabecera { get; set; }

        // 📄 Lista de detalles cargados hasta el momento (para mostrar la tabla)
        public List<TbEntDetDto> Detalles { get; set; } = new List<TbEntDetDto>();
    }
}
