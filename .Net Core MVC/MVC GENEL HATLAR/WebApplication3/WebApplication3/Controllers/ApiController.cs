using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    public class ApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
