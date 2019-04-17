using BlogTyson.DAL.ORM.Entity;
using BlogTyson.UI.Areas.Admin.Controllers;
using BlogTyson.UI.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BlogTyson.UI.Controllers
{
    public class AccountController : BaseController
    {

        public ActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                AppUser user = service.AppUserService.FindByuserName(User.Identity.Name);

                if (user.Role == DAL.ORM.Enum.Role.Admin)
                {
                    return RedirectToAction("AdminHomeIndex", "Home");
                }
                else if (user.Role == DAL.ORM.Enum.Role.Member)
                {
                    return RedirectToAction("MemberHomeIndex", "Home");
                }

            }
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(LoginVM credentials)
        {
            if (ModelState.IsValid)
            {
                if (service.AppUserService.CheckCredentials(credentials.UserName, credentials.Password))
                {
                    AppUser user = service.AppUserService.FindByuserName(credentials.UserName);

                    string cookie = user.UserName;
                    FormsAuthentication.SetAuthCookie(cookie, true);

                    if (user.Role==DAL.ORM.Enum.Role.Admin)
                    {
                        return Redirect("/Admin/Home/AdminHomeIndex");
                    }
                    else if (user.Role == DAL.ORM.Enum.Role.Member)
                    {
                        return Redirect("/Member/Home/MemberHomeIndex");
                    }
                    
                }
                else
                {
                    ViewData["error"] = "Kullanıcı Adı veya Şifre Hatalı";
                    return View();
                }
            }
            
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Account/Login");
        }


    }
}