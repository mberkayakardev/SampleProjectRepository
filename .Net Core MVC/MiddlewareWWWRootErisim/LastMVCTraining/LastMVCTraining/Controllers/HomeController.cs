using Microsoft.AspNetCore.Mvc;

namespace LastMVCTraining.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
    }
}
