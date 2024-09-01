using Microsoft.AspNetCore.Mvc;

namespace ProjARVenture.Controllers
{
    public class LaunchARFashionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult LaunchARFashion()
        {
            return View();
        }
    }
}
