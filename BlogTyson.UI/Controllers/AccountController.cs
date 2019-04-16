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
                return RedirectToAction("index", "home");
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
                    return RedirectToAction("index", "home");
                }
                else
                {
                    ViewData["error"] = "Kullanıcı Adı veya Şifre Hatalı";
                    return View();
                }
            }
            TempData["class"] = "custom-show";
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/home/index");
        }


    }
}