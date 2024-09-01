using Microsoft.AspNetCore.Mvc;

namespace ProjARVenture.Controllers
{
    public class MyHomePageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyHomePage()
        {
            return View();
        }
    }
}
