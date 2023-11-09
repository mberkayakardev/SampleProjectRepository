using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow.ValueContentAnalysis;
using WebApplication3.Models;
using WebApplication3.StaticDatas;

namespace WebApplication3.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var model = Context.Products;
            return View(model);
        }

        #region Ekleme operasyonu
        /// Eklemenin 3 aşaması 

        
        
        /// 1 Ekme yapabilmeniz için HTTPGET method açacaksınız. Ana amacı ekleme yapacğaınız formun olduğu view i çevirmek
        /// Bu view açıldığında bir form oluşyurayım ve bu form ile eklemeyi gerçekleştrielim

        
        
        /// 2 Eklemek için bir form sayfası yazınız Form olacak formnda nveriler name propertysi üzerinden bind olacak 
        /// Create view imizi yaz 
        /// Formunu oluştuır action ile ilgili endpointe yönlendir methodu post yap 
        /// inputların name i arkada eşleceşek name alanları ile erişeceğiz name propertyleri html tarafında önemli 
        /// Button koy type i submit olsun tılkalyınca tetiklensin.

        
        /// 3 Formdan verileri post ile bir post methoda yollayacaksınız 
        /// Methodların hepsinin önünde httpget var attribute vermediysek
        /// httppost içerisinde bir adet create methodu oluşturabilieiz.
        /// işlem gerçekleştiknten sonra redirect etsin
        /// Form içerisindeki alanlara HTTPCONTEXT nesnesi şeklinde request içerisinde form içerisine erişebilirsin
        /// form içersinden input a erişmek istiyorsam o input un name 
        /// view den bir post istegi gönderdiğim için request i seçiyorum
        /// formdan input a erişmek istiyorsam input un name özelliğinin içerisindeki değeri yazmam gerekmektedir. 
        /// request ve response a ben httpcontext üzerinden erişebiliyorum  

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateWithForm()
        {
            var model = new Product();
            model.ProductId = Context.Products.Max(x => x.ProductId);
            model.ProductName = HttpContext.Request.Form["ProductName"].ToString();
            model.UnitStock = Convert.ToInt32(HttpContext.Request.Form["UnitStock"]);
            
            await Task.Run(() =>
            {
                Context.Products.Add(model);
            });

            return RedirectToAction("Index");
        }

        #endregion

        #region Silme Senaryosu
        /// silme işlemi için sadece 1 adet controller yeterlidir. Silme işlemleri
        /// silme işlemi için sadece 1 adet controller yeterlidir. Silme işlemleri 
        /// MVC tarafında Get isteği ile birlikte gerçekleşmektedir. 

        [HttpGet]
        public async Task<IActionResult> Remove()
        {
            var removeid = Convert.ToInt32(RouteData.Values["Id"]);
            var costumermodel = (new Product());
            
            await Task.Run(() =>
            {
                costumermodel = Context.Products.FirstOrDefault(x => x.ProductId == removeid);
                Context.Products.Remove(costumermodel);
            });
            return RedirectToAction("Index");
        }



        #endregion

        #region Güncelleme Senaryosu 

        /// Ekleme senaryosundan aşina olacağımız üzere bizler 3 işlem gerçekleştireceğiz 


        /// Get li bir methodf : Create işleminde oldugu gibi bir view açılacaktır. içerisine de veritabanından çektiğimiz datayı yazacağız içerisine 

        /// view (içerisnde form barındıracak alınan veriler arka tarafta map edilecektir. )

        /// ilgili değişikliklerin veritabnaına yansıması için bir adet post methodu burada da güncelleme operasyonları yazılacaktır. 
        
        [HttpGet]        
        public async Task<IActionResult> Update()
        {
            var id = int.Parse(RouteData.Values["Id"].ToString());
            var product = new Product();
            await Task.Run(() =>
            {

                product = Context.Products.FirstOrDefault(x => x.ProductId == id);
            });

            return View(product);
            
        }


        [HttpPost]
        public async Task<IActionResult> UpdateWithForm()
        {
            return RedirectToAction("Index");
        } 








        #endregion

    }
}
