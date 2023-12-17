using LastMVCTraining.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Cryptography.X509Certificates;

namespace LastMVCTraining.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var list = new List<Product>() {

                new Product() { Id = 1, Name = "Iphone 14", Price = 65000 },
                new Product() { Id = 2, Name = "Iphone 15", Price = 75000 },
                new Product() { Id = 3, Name = "Samsung Galaxy S22 ", Price = 40000},
            };
            return View(list);
        }

        #region Create 
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult CreateWithForm()
        //{
        //    var Productname = HttpContext.Request.Form["Name"].ToString();
        //    var Price = HttpContext.Request.Form["Price"].ToString();
        //    var product = new Product
        //    {
        //        Name = Productname,
        //        Price = Convert.ToDecimal(
        //        Price)
        //    };

        //    // Veri tabanı işlemleri 

        //    TempData["Message"] = "İlgili kayıt başarı ile gerçekleşti";

        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public IActionResult CreateWithForm(Product product)
        {
            if (ModelState.IsValid)
            {
                TempData["Message"] = "İlgili kayıt başarı ile gerçekleşti";
                return RedirectToAction("Index");
            }
            return View("create");

        }
        #endregion

        #region Delete 

        public IActionResult Delete()
        {
            int id = Convert.ToInt32(RouteData.Values["id"]);
            return RedirectToAction("Index");
        }


        #endregion




















        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View();
        }


        #region Deneme 
        [HttpGet]
        public IActionResult Update(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Update(Product product)
        {
            return View();
        }
        #endregion

    }
}
