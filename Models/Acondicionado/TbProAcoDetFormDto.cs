using System.Collections.Generic;
using ConexionSql.Models.Acondicionado;
using ConexionSql.Models.Procesos;
using ConexionSql.Models.Recepciones;

namespace ConexionSql.Models.Acondicionado
{
    public class TbProAcoDetFormDto
    {
        // 📝 Objeto que se envía al backend para guardar el detalle
        public TbProAcoDetDto Detalle { get; set; } = new TbProAcoDetDto();

        // 📋 Lista de etiquetas (detalles de recepción disponibles para procesar)
        public List<TbRecDetDto> Etiquetas { get; set; } = new List<TbRecDetDto>();

        // 🧾 Cabecera del proceso de acondicionado
        public TbProAco? Cabecera { get; set; }

        // 📄 Lista de detalles cargados hasta el momento (para mostrar la tabla)
        public List<TbProAcoDetDto> Detalles { get; set; } = new List<TbProAcoDetDto>();
    }
}
