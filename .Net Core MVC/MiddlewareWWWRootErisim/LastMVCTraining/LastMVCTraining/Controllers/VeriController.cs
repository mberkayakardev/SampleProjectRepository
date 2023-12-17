using LastMVCTraining.Models;
using Microsoft.AspNetCore.Mvc;

namespace LastMVCTraining.Controllers
{
    public class VeriController : Controller
    {
        public IActionResult Index()
        {
            // Viewbag , ViewData, Tempdate, Model 
            // @model ile bunu karşılamamız gerekmekteidr. 
            // 

            var product = new Product() { Id = 1, Name = "Berkay" };
            TempData["Berkay"] = "Berkay";

            return View(product);

        }
        public IActionResult Category()
        {
            var resut = TempData["Berkay"];
            //TempData.Keep();

            Product p = new Product() { Id = 1, Name = "Telefon" };
            return View(p);
        }

        public IActionResult Car()
        {
            var resut = TempData["Berkay"];

            var model = new Car { Id = 1999, Plaka = "Tofaş 34 AR 2255" };
            return View("carpartial",model);
        }



    }


}




//public IActionResult Index()
//{
//    /// 3 Tipte veri taşımamız mümkündür ViewBag, ViewData, TempData, Model 

//    /// ViewBag dynamic bir değişkendir 
//    ViewBag.Name = "Berkay";

//    /// ViewData 
//    ViewData["Surname"] = "Akar";

//    /// TempData 
//    TempData["Message"] = "Selamlar "; 

//    Product p = new Product() { Id = 1, Name = "Telefon" };
//    return View(p);
//}