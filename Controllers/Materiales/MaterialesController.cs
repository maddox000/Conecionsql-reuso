using ConexionSql.Data;
using ConexionSql.Models.Materiales;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConexionSql.Controllers.Materiales
{
    public class MaterialesController : Controller
    {
        private readonly ConexionSqlContext _context;

        public MaterialesController(ConexionSqlContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ListaMateriales()
        {
            var lista = await _context.IbMat
                .OrderBy(x => x.IB_MAT_ID)
                .Select(x => new IbMatDto
                {
                    // Código sistema
                    IbMatId = x.IB_MAT_ID,

                    // Código producto
                    IbMatPr = x.IB_MAT_PR,

                    // Denominación
                    IbMatDen = x.IB_MAT_DEN,

                    // Tipo de material
                    IbMatMtiDen = x.IB_MAT_MTI_DEN,

                    // Ubicación física
                    IbMatEstIngDen = x.IB_MAT_EST_ING_DEN,

                    // Contenido
                    IbMatConUnid = x.IB_MAT_CON_UNID,

                    // Controlado
                    IbMatConAct = x.IB_MAT_CON_ACT,

                    // Inhabilitado
                    IbMatOcu = x.IB_MAT_OCU
                })
                .ToListAsync();

            return View("~/Views/Materiales/ListaMateriales.cshtml", lista);
        }

        [HttpGet]
        public async Task<IActionResult> Imagen(int id)
        {
            // 1) Leer ruta base desde A_PAN_OPC
            var rutaImagenes = await _context.APanOpc
                .Where(x => x.IdDenominacion == "A_PAN_RUTA_IMG_MAT")
                .Select(x => x.ValorTxt)
                .FirstOrDefaultAsync();

            if (string.IsNullOrWhiteSpace(rutaImagenes))
                return NotFound();

            // 2) Buscar campos de imágenes del material
            var material = await _context.IbMat
                .Where(x => x.IB_MAT_ID == id)
                .Select(x => new
                {
                    // Campos donde Access guarda los nombres de imágenes
                    x.IB_MAT_IMG_1,
                    x.IB_MAT_IMG_2,
                    x.IB_MAT_IMG_3,
                    x.IB_MAT_IMG_4,
                    x.IB_MAT_IMG_5
                })
                .FirstOrDefaultAsync();

            if (material == null)
                return NotFound();

            // 3) Tomar la primera imagen válida
            var imagenes = new[]
            {
        material.IB_MAT_IMG_1,
        material.IB_MAT_IMG_2,
        material.IB_MAT_IMG_3,
        material.IB_MAT_IMG_4,
        material.IB_MAT_IMG_5
    };

            var nombreImagen = imagenes
                .FirstOrDefault(x =>
                    !string.IsNullOrWhiteSpace(x));

            if (string.IsNullOrWhiteSpace(nombreImagen))
                return NotFound();

            nombreImagen = Path.GetFileName(nombreImagen.Trim());

            // 4) Buscar archivo real.
            // Si en DB viene "ALICATE.jpg", lo usa directo.
            // Si en DB viene "ALICATE", prueba extensiones comunes.
            string? rutaArchivo = null;

            if (Path.HasExtension(nombreImagen))
            {
                var rutaDirecta = Path.Combine(rutaImagenes, nombreImagen);

                if (System.IO.File.Exists(rutaDirecta))
                    rutaArchivo = rutaDirecta;
            }
            else
            {
                var extensiones = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" };

                foreach (var ext in extensiones)
                {
                    var rutaTemp = Path.Combine(rutaImagenes, nombreImagen + ext);

                    if (System.IO.File.Exists(rutaTemp))
                    {
                        rutaArchivo = rutaTemp;
                        break;
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(rutaArchivo))
                return NotFound();

            // 5) Devolver imagen al navegador
            var extension = Path.GetExtension(rutaArchivo).ToLower();

            var contentType = extension switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                ".webp" => "image/webp",
                _ => "application/octet-stream"
            };

            var bytes = await System.IO.File.ReadAllBytesAsync(rutaArchivo);

            return File(bytes, contentType);
        }
    }
}