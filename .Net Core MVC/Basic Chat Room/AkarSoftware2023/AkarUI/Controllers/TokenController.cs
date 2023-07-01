using AkarBusiness.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AkarUI.Controllers
{
    public class TokenController : Controller
    {
        private readonly ITokenService _Tokenservice;
        private readonly IGroupService groupService;
        private readonly IUserService userService;

        public TokenController(ITokenService tokenservice, IGroupService groupService, IUserService userService)
        {
            _Tokenservice = tokenservice;
            this.groupService = groupService;
            this.userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string Token)
        {
            var token = _Tokenservice.Get(x => x.OneTimeUsableToken == Token, new System.Linq.Expressions.Expression<System.Func<AkarEntities.Entities.Token, object>>[] { x => x.Person, x => x.Gruoup });
            if (token == null)
            {
                return NotFound("Geçersiz Token");
            }
            var username = HttpContext.User.Claims.FirstOrDefault().Value;
            if (token.Person.UserName != username)
            {
                return NotFound("Token Kullanıcı Eşleşmesi Hatalı.");
            }
            if (token.IsUsed == true)
            {
                return NotFound("Token Kullanıldı.");
            }
            var grup = groupService.Get(x => x.Id == token.Gruoup.Id, new System.Linq.Expressions.Expression<System.Func<AkarEntities.Entities.Group, object>>[] { x => x.MembersList });
            var person = userService.Get(x => x.UserName == username);
            grup.MembersList.Add(person);
            groupService.Update(grup);
            token.IsUsed = true;
            token.GecerliFlg = false;
            _Tokenservice.Update(token);

            return RedirectToAction("Detail", "Group", new { id = token.Gruoup.Id });
        }
    }
}
