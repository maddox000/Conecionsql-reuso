using ConexionSql.Models.Procesos;

namespace ConexionSql.Models.Procesos
{
    /// <summary>
    /// ViewModel que combina la cabecera del proceso y el DTO para cargar detalles
    /// </summary>
    public class TbProDetFormDto
    {
        public TbPro Cabecera { get; set; }                 // Cabecera del proceso
        public TbProDetDto Detalle { get; set; }            // Objeto para insertar
        public List<TbProDetDto> Detalles { get; set; }     // Lista de detalles cargados

    }
}


