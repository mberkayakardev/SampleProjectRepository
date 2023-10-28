using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class DataTransfer : Controller
    {
        /// <summary>
        /// sizler controller dan view e veri gönderebilmek için 4 yöntemi kullanabilirsinniz
        /// 
        /// Viewbag : Dinamik bir veri tipidir viewbag. diyerek verdiğimniz isim ile veri aktaraımı yapabilmeniz söz konusudur ayriyetten gidipte 
        /// views içerisinde veri göndermeniz gerek yoktur 
        /// 
        /// 
        /// ViewData : sözlük tipidir viewbag ile aynı yere tekabül eder. viewbag. diyerek ulaşabilirken viewdata["degisken"] diyerek ulaşabilirsin
        /// 
        /// TempData : viewbag ile viewdata dan farkı bulunmaktadır. tempdata Lifecycle i itibari ile methodlar arası veri aktarımını sağlayabilirsiniz 
        /// view e de veri gönderebilirsiniz sözlük gibidir tempdate["degisken"] = "deger";
        /// 
        /// Models : komplex veri tiplerini view e yollamanızı sağlar. Tip güvenli iş yapabilmeniz bu sayede mümkündür. 
        ///  return view içerisine ilgili model verilir. diğerlerinde buna ihtiyaç yok 
        ///  view içerisinde de modeli karşılaman gerekir 
        ///  
        /// küçük model @model ile veriyi karşılarsın büyük model ile de propertylerine erişirisen @Model.ID gibi 
        /// 
        /// </summary>
        public IActionResult Index()
        {
            ViewBag.Name = "Berkay";
            //Tempdata["name"] = "akar" dersem viewbag içerisidneki name de akara döner birbirleri ile aynı tiplte olup ezebviliriler
            ViewData["Surname"] = "Akar";
            TempData["Message"] = "Selamlama mesajı iletilmiştir";
            return View(new ModelsDeneme { Id = 123, ProductName = "İphone 14 "});

        }

        public IActionResult Ahmet()
        {
            return View(); 
        }

        public IActionResult Orhan()
        {
            return View("Resul");
        }

    }
}
