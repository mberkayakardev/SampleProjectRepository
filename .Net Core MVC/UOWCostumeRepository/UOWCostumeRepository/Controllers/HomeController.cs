using DataAccess;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace UOWCostumeRepository.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUOW _uow;
        public HomeController(IUOW uow)
        {
            _uow = uow;
        }
        public IActionResult Index()
        {
            _uow.GetRepository<Product, IProductRepository>().AddBerkayinMethodu();
            return View();
        }
    }
}
