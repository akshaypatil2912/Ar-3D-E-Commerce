using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjARVenture.Controllers
{
    public class LaunchARFurnitureController : Controller
    {

        public ActionResult LaunchARFurniture()
        {
            return View();
        }

    

        // GET: LaunchARFurnitureController
        public ActionResult Index()
        {
            return View();
        }

        // GET: LaunchARFurnitureController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LaunchARFurnitureController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LaunchARFurnitureController/Create
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

        // GET: LaunchARFurnitureController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LaunchARFurnitureController/Edit/5
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

        // GET: LaunchARFurnitureController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LaunchARFurnitureController/Delete/5
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
