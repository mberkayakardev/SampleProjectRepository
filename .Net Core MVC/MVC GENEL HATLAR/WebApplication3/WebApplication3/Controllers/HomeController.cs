using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int id)
        {
            // index viewini getirir.

            var controllername = RouteData.Values["controller"];
            var ActionName = RouteData.Values["action"];
            var Id = RouteData.Values["id"];


            return View();
        }

        public IActionResult Razordeneme()
        {
            return View();
        }

        public IActionResult Ahmet()
        {
            // Ahmet view ini getirir
            return View();
        }

        public IActionResult Mehmet()
        {
            // Ahmet view ini getirir
            return View("Hasan");
        }
    }
}
