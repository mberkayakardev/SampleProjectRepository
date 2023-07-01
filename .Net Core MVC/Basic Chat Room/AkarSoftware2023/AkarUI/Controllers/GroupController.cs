using AkarBusiness.Abstract;
using AkarEntities.Dtos;
using AkarEntities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AkarUI.Controllers
{
    public class GroupController : Controller
    {
        private readonly IGroupService _groupService;
        private readonly IUserService _userservice;
        private readonly ITokenService _tokenService;

        public GroupController(IGroupService groupService, IUserService userservice, ITokenService tokenService)
        {
            _groupService = groupService;
            _userservice = userservice;
            _tokenService = tokenService;
        }

        public IActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated == true)
            {
                // Sistemde bir user var 
                var model = _groupService.GroupList(x => x.GecerliFlg == true, include: new System.Linq.Expressions.Expression<System.Func<Group, object>>[] { x => x.MembersList });
                var username = HttpContext.User.Claims.FirstOrDefault().Value;
                var model2 = new List<ListGroupDto>();
                foreach (var item in model)
                {

                    var isthere = item.MembersList.FirstOrDefault(x => x.UserName == username);
                    if (isthere == null && item.IsPublicOrPrivate == false)
                    {
                        continue;
                    }
                    else
                    {
                        foreach (var item2 in item.MembersList)
                        {

                            if (item2.UserName == username || item.IsPublicOrPrivate == false)
                            {
                                item.KatilimSaglanabilirmi = false;
                            }
                            else
                            {
                                item.KatilimSaglanabilirmi = true;
                            }

                        }
                        model2.Add(item);

                    }

                }

                return View(model2);
            }
            else
            {
                // Sistemde bir user yok ziyaretçi modu 
                var model = _groupService.GroupList(x => x.GecerliFlg == true && x.IsPublicOrPrivate == true, include: new System.Linq.Expressions.Expression<System.Func<Group, object>>[] { x => x.MembersList });
                return View(model);
            }
        }
        [HttpPost]
        public IActionResult CreateGroup(CreateGroupDto dto)
        {
            var username = HttpContext.User.Claims.FirstOrDefault().Value;
            var user = _userservice.Get(x => x.UserName == username);
            if (user != null)
            {
                Group grup = new Group
                {
                    MembersList = new List<User> { user },
                    GroupName = dto.GroupName,
                    IsPublicOrPrivate = (dto.IsPublicOrPrivate == "on") ? true : false,
                };

                _groupService.Add(grup);
                return RedirectToAction("Index", "Group");
            }
            else
            {
                return NotFound();
            }

        }
        public IActionResult Detail(int id)
        {
            if (id == null || id == 0)
            {
                throw new ArgumentException("Geçerli Grup Bulunamadı. Böyle Bir grup mevcut değil");
            }
            var model = _groupService.Get(x => x.Id == id, new System.Linq.Expressions.Expression<Func<Group, object>>[] { x => x.MembersList });
            var person = model.MembersList.FirstOrDefault(x => x.UserName == HttpContext.User.Claims.FirstOrDefault().Value);
            if (person == null)
            {
                return new JsonResult("Gecersizkullanici 403");
            }
            return View(model);
        }
        public IActionResult JoinTheGroup(int id)
        {
            if (HttpContext.User.Identity.IsAuthenticated == true)
            {
                var model = _groupService.Get(x => x.Id == id, new System.Linq.Expressions.Expression<Func<Group, object>>[] { x => x.MembersList });
                var username = HttpContext.User.Claims.FirstOrDefault().Value;
                var user = _userservice.Get(x => x.UserName == username);
                if (model.MembersList.Contains(user))
                {
                    return RedirectToAction("Detail", "Group", new { id = id });
                }
                else
                {
                    model.MembersList.Add(user);
                    _groupService.Update(model);
                    return RedirectToAction("Detail", "Group", new { id = id });
                }

            }
            else
            {
                ViewBag.Mesaj = "Katılım İşlemleri için lütfen Login olun ";
                return RedirectToAction("Index", "Group");
            }
            return View();
        }

        [HttpPost]
        public IActionResult TokenOlustur(string UserName, int GroupId)
        {
            var model = _userservice.Get(x => x.UserName == UserName, new System.Linq.Expressions.Expression<Func<User, object>>[] { x => x.Groups });
            if (model == null)
            {
                return new JsonResult("İlgili Kullanıcı Sistemde Mevcut Değil");
            }
            else
            {
                var model2 = model.Groups.FirstOrDefault(x => x.Id == GroupId);
                if (model2 != null)
                {
                    return new JsonResult("İlgili Kullanıcı Zaten Grupta Mevcut");
                }
                else
                {
                    var model3 = _groupService.Get(x => x.Id == GroupId);
                    Token t = new Token { Person = model, Gruoup = model3 };
                    _tokenService.Add(t);
                    return new JsonResult(t);
                }

            }
        }

    }
}


