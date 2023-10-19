using EntityFrameworkPractice.Data.Entities;
using EntityFrameworkPractice.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkPractice.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            //var user = _userManager.Users.Where(x => x.Id == 2).FirstOrDefault();
            //user.Email = "Ahmet@gmail.com";
            //await _userManager.UpdateNormalizedEmailAsync(user);

            var user = User.Identity.Name;
            return View();
        }

        #region KAyıt olma sayfası

        /// ilk olarak bir get li method yazılacak amaç view i gösterebilemk 
        ///
        /// sonrasında bir dto yazılacak kullanıcıdan alınan bilgiler şeysiiçin
        /// 
        /// View oluştur içerisinde form yaz 
        /// 
        /// Post lu yaz ve create action ini çalıştır 
        /// Create te iki methodumuz var 
        /// bi tanesi direk kaydeder 2. si ise passwordu hashler sen heslemiceksen identity e de password u yapılandırabilrisin.
        public IActionResult Create()
        {
            return View(new UserCreateDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateDto dto)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName = dto.UserNAme,
                    Email = dto.Email,
                    BerkayProp6 = "asd",
                };

                var result = await _userManager.CreateAsync(user, dto.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }

                    return View(dto);
                }
            }


            return View(dto);

        }

        #endregion

        #region Login işlemleri
        /// Create ile aynı mantık bi nebze 
        /// Get ile view açacak bir method
        /// Bir Dto
        /// Bir view sayfası (içerisinde form olan )
        /// bir de Post lu method  <summary>
        /// Create ile aynı mantık bi nebze 
        /// bu etapta bizler sing in manager i kullanacaz 
        /// İçerisinde birçok method var bizler password sing in i kullancvaz 
        /// 
        /// 2 overload var birinde appğuser istiyo birinde usernmae istiyo sadece 
        /// neticesinde 2 parametre daga var birisi beni hatırla diğeri ise hatalı giriş sonrasında locout olsunmu olmasındmıu durumu 
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginDto());
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(dto.UserName, dto.Password, dto.Rememberme, true);
                var resultUser = User;

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                if (result.IsLockedOut)
                {
                    TempData["Message"] = result.ToString();
                    return View();

                }
            }
            return View(dto);
        }

        #endregion

        #region Logout

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

        #endregion

        [Authorize]
        [HttpGet]
        public IActionResult Hosgeldin()
        {
            var result = User;
            return View();
        }

        // giriş yapmış olması yetmez roles bilgiside olması gerekir 
        [Authorize(Roles = "ahmet")]
        [HttpGet]
        public IActionResult Hosgeldin2()
        {
            return View();
        }


        // giriş yapmış olması yetmez virgülle ayrılmış rollerden en az birisi olması gerekir 
        [Authorize(Roles = "ahmet,mehmet")]
        [HttpGet]
        public IActionResult Hosgeldin3()
        {
            return View();
        }

        public IActionResult YetkisizErisim()
        {
            return View();
        }
    }
}
