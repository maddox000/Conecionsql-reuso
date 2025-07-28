using ConexionSql.Data;
using ConexionSql.Utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConexionSql.Controllers.Impresiones
{
    // Controlador dedicado a manejar todo lo relacionado con impresión de etiquetas
    public class ImpresionController : Controller
    {
        private readonly ConexionSqlContext _context;

        // Constructor que recibe el contexto de base de datos
        public ImpresionController(ConexionSqlContext context)
        {
            _context = context;
        }

        // Acción que recibe un ID de persona y genera/imprime una etiqueta
        [HttpPost]
        public async Task<IActionResult> ImprimirPersonal(int id)
        {
            // Busca la persona en la base de datos
            var persona = await _context.IbPers.FirstOrDefaultAsync(x => x.IbPerId == id);
            if (persona == null)
                return NotFound(); // Si no la encuentra, devuelve 404

            // Genera el contenido ZPL para imprimir
            //string zpl = Etiquetas.Personal(persona);
            string zpl = Etiquetas.Personal(persona);

            // Nombre exacto de la impresora configurada en Windows
            string impresora = "ZDesigner GK420t";

            // Opcional: Muestra en consola el contenido que se está enviando
            Console.WriteLine("Etiqueta a enviar:");
            Console.WriteLine(zpl);
            Console.WriteLine("Impresora: " + impresora);

            // Envía la etiqueta a la impresora
            bool enviado = ImpresionZebra.EnviarAImpresora(impresora, zpl);

            // Si no se pudo enviar, avisa en la respuesta
            if (!enviado)
                return Content("Error al enviar a la impresora.");

            // Si todo salió bien, devuelve un mensaje de éxito
            return Content($"Etiqueta enviada para {persona.IbPerNom} {persona.IbPerApe}");
        }
    }
}
