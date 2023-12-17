using Microsoft.AspNetCore.Mvc;

namespace LastMVCTraining.Controllers
{
    public class Mcv : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Ahmet()
        {
            var a = RouteData.Values[""];
            return View();
        }
        public IActionResult Mehmet()
        {
            return View();

            //return View();
        }
        public IActionResult Mehmet2()
        {
            return View("Mehmet");
        }
        //public IActionResult Mehmet3()
        //{
        //}
    }
}
