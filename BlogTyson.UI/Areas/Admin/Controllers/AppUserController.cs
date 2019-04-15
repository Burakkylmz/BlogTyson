using BlogTyson.DAL.ORM.Entity;
using BlogTyson.UI.Areas.Admin.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogTyson.UI.Areas.Admin.Controllers
{
    public class AppUserController : BaseController
    {
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(AppUser data)
        {
            service.AppUserService.Add(data);
            return Redirect("/Admin/AppUser/List");
        }

        public ActionResult List()
        {
            List<AppUser> model = service.AppUserService.GetActive();
            return View(model);
        }

        public ActionResult Update(Guid id)
        {
            AppUser user = service.AppUserService.GetById(id);
            AppUserDTO model = new AppUserDTO();
            model.ID = user.ID;
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.Email = user.Email;
            model.Password = user.Password;
            model.UserName = user.UserName;
            model.Role = user.Role;

            return View(model);
        }

        [HttpPost]
        public ActionResult Update(AppUserDTO data)
        {
            AppUser user = service.AppUserService.GetById(data.ID);
            user.FirstName = data.FirstName;
            user.LastName = data.LastName;
            user.UserName = data.UserName;
            user.Email = data.Email;
            user.Password = data.Password;
            user.Role = data.Role;

            service.AppUserService.Update(user);
            TempData["Successful"] = "Transaction is successful.";
            return Redirect("/Admin/AppUser/List");
        }

        public ActionResult Delete(Guid id)
        {
            service.AppUserService.Remove(id);
            TempData["Successful"] = "Transaction is successful.";
            return Redirect("/Admin/AppUser/List");
        }
    }
}