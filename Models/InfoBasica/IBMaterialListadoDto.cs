using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConexionSql.Models.InfoBasica
{
    public class IBMaterialListadoDto : Controller
    {
        // GET: IBMaterialListadoDto
        public ActionResult Index()
        {
            return View();
        }

        // GET: IBMaterialListadoDto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: IBMaterialListadoDto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IBMaterialListadoDto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IBMaterialListadoDto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: IBMaterialListadoDto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IBMaterialListadoDto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: IBMaterialListadoDto/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
