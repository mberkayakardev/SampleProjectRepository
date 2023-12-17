using LastMVCTraining.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LastMVCTraining.Controllers
{
    public class RazorController : Controller
    {
        public IActionResult Index()
        {
            return View(new Product() { });
            
        }
    }
}
