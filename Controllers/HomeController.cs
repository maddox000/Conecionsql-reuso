using System.Diagnostics;
using Conecionsql.Models;
using Microsoft.AspNetCore.Mvc;
using ConexionSql.Utilidades;

namespace Conecionsql.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

  

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult PruebaMenu()
        {
            return View();
        }

        public IActionResult TestLayout()
        {
            return View();
        }

        //metodo para la impresion
        [HttpPost]
        public IActionResult ImprimirEtiqueta()
        {
            string zpl = "^XA" +
               "^PW480" +                      // Ancho de 6 cm convertido a 480 puntos
               "^LL360" +                      // Largo de 4.5 cm convertido a 360 puntos
               "^CF0,60" +                     // Fuente grande (60 puntos) para BAXEN
               "^FO0,30^FB480,1,0,C^FDBAXEN^FS" +    // BAXEN centrado, 30px desde arriba
               "^CF0,30" +                     // Fuente más chica (30 puntos) para las otras dos líneas
               "^FO0,150^FB480,1,0,C^FDImpresora Zebra^FS" + // Segunda línea centrada
               "^FO0,220^FB480,1,0,C^FDse logro la impresion^FS" + // Tercera línea centrada
               "^XZ";



            string impresora = "ZDesigner GK420t"; // <-- Acá poné el nombre real de tu impresora

            try
            {
                ImpresionZebra.EnviarAImpresora(impresora, zpl);
                return Content("Etiqueta enviada a la impresora.");
            }
            catch (Exception ex)
            {
                return Content($"Error al imprimir: {ex.Message}");
            }
        }

    }
}
