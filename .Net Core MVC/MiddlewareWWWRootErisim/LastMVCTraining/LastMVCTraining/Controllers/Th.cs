using Microsoft.AspNetCore.Mvc;

namespace LastMVCTraining.Controllers
{
    public class Th : Controller
    {
        public IActionResult Index()
        {
            return View();
             
        }
    }
}
