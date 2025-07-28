using ConexionSql.Models.Lavado;

namespace ConexionSql.Models.Lavado
{
    /// <summary>
    /// ViewModel que combina la cabecera del lavado y el DTO para cargar detalles
    /// </summary>
    public class TbProLavDetFormDto
    {
        public TbProLav Cabecera { get; set; }                   // Cabecera del proceso de lavado
        public TbProLavDetDto Detalle { get; set; }              // Objeto para insertar detalle
        public List<TbProLavDetDto> Detalles { get; set; }       // Lista de detalles cargados
    }
}
