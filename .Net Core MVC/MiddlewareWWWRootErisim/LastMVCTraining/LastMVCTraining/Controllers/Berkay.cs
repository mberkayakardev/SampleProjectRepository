using LastMVCTraining.Models;
using Microsoft.AspNetCore.Mvc;

namespace LastMVCTraining.Controllers
{
    public class Berkay : Controller
    {
        public IActionResult Index()
        {
            
            return View(new Product() { Id = 1966, Name = "Balıkesir" });
        }
    }
}
