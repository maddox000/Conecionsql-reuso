using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.IO;
using System.Threading.Tasks;

namespace ConexionSql.Utilidades
{
    public static class ControllerRenderExtensions
    {
        public static async Task<string> RenderViewToStringAsync<TModel>(this Controller controller, string viewName, TModel model, bool partial = false)
        {
            controller.ViewData.Model = model;

            using var writer = new StringWriter();
            var viewEngine = controller.HttpContext.RequestServices.GetService(typeof(ICompositeViewEngine)) as ICompositeViewEngine;

            string finalViewName = viewName.EndsWith(".cshtml") ? viewName : $"{viewName}.cshtml";

            // ✅ Permite rutas absolutas (~) o rutas automáticas por controlador
            string viewPath = viewName.StartsWith("~")
                ? viewName
                : $"/Views/{controller.RouteData.Values["controller"]}/{finalViewName}";

            var viewResult = partial
                ? viewEngine.GetView(null, viewPath, false)
                : viewEngine.FindView(controller.ControllerContext, viewPath, true);

            if (!viewResult.Success)
                throw new FileNotFoundException($"No se encontró la vista '{viewPath}'.");

            var viewContext = new ViewContext(
                controller.ControllerContext,
                viewResult.View,
                controller.ViewData,
                controller.TempData,
                writer,
                new HtmlHelperOptions()
            );

            await viewResult.View.RenderAsync(viewContext);
            return writer.GetStringBuilder().ToString();
        }
    }
}
