using LastMVCTraining.Models;
using Microsoft.AspNetCore.Mvc;

namespace LastMVCTraining
{
    public class AkarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var car = new Car { Id = 1966, Plaka = "Tofask 10 AR 2255" };
            return View("carpartial",car);
        }
    }
}
