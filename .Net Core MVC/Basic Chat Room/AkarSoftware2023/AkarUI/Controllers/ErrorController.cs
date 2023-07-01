using Microsoft.AspNetCore.Mvc;

namespace AkarUI.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Üzgünüz, istediğiniz sayfa bulunamadı.";
                    break;
                case 403:
                    ViewBag.ErrorMessage = "İstediğiniz gruba erişim için yetkiniz bulunamamktadır. lütfen grup adminler ile iletişime geçerek yetkilendirme alınız.";
                    break;
            }
            return View("Error");
        }
    }
}
