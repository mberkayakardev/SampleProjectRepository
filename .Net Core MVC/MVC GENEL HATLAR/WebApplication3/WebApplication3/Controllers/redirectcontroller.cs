using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    public class redirectcontroller : Controller
    {
        public IActionResult Index()
        {
            return View(); // içerisinde buludğu action methodunun ismi ile aynı isimdeki view i getirir
        }
        public IActionResult Index999()
        {
            return View(); // içerisinde buludğu action methodunun ismi ile aynı isimdeki view i getirir
        }

        public IActionResult Index2()
        {
            return View(); // içerisinde yazılan isimdeki view i getirir
        }

        public IActionResult Index3()
        {
            TempData["Message"] = "Redirect ile gelindi";
            return RedirectToAction("Index"); // index sayfasını controller i çalıştırarak getirebilir 
        }

        public ActionResult Deneme()
        {
            return Ok();
        }

    }

}
