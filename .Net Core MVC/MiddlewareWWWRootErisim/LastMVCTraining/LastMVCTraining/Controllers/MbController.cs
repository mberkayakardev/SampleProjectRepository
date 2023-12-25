using LastMVCTraining.Models;
using Microsoft.AspNetCore.Mvc;

namespace LastMVCTraining.Controllers
{
    public class MbController : Controller
    {
        #region Alternative 1 

        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Index(Product p,Car c)
        //{
        //    return RedirectToAction("Index");
        //}


        #endregion

        [HttpGet]
        public IActionResult Index()
        {
            var MODEL = new ProductCarWM();
            MODEL.c = new Car();
            MODEL.p = new Product();
            return View(MODEL);
        }
        [HttpPost]
        public IActionResult Index(ProductCarWM A )
        {

            return RedirectToAction("Index");
        }



    }
}
