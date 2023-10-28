using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Razordeneme()
        {
            return View();
        }
    }
}
