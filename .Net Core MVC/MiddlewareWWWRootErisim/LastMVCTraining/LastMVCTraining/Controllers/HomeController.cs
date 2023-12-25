using Microsoft.AspNetCore.Mvc;

namespace LastMVCTraining.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index(int? id)
        {
            var deg1 = RouteData.Values["Controller"].ToString();
            var deg2 = RouteData.Values["Action"].ToString();
            var deg3 = RouteData.Values["id"].ToString();

            return View();
        }

        [HttpPost]
        public IActionResult Index()
        {
            var deg1 = RouteData.Values["Controller"].ToString();
            var deg2 = RouteData.Values["Action"].ToString();
            var deg3 = RouteData.Values["id"].ToString();
            var UrunAdi = HttpContext.Request.Form["Name"].ToString();
            var Fiyati = HttpContext.Request.Form["Price"].ToString();


            return View();
        }


    }
}
