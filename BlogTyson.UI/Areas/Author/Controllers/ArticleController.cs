using BlogTyson.DAL.ORM.Entity;
using BlogTyson.DAL.ORM.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogTyson.UI.Areas.Author.Controllers
{
    public class ArticleController : BaseController
    {
        public ActionResult Add()
        {
            return View(service.CategoryService.GetActive());
        }

        public ActionResult Add(Article data)
        {
            AppUser user = service.AppUserService.GetByDefault(x => x.UserName == User.Identity.Name);
            data.AppUserID = user.ID;
            service.ArticleService.Add(data);
            return Redirect("/Author/Article/List");
        }

        public ActionResult List()
        {
            Guid userid = service.AppUserService.FindByuserName(User.Identity.Name).ID;
            List<Article> model = service.ArticleService.GetDefault(x => x.AppUserID == userid && (x.Status == Status.Active || x.Status == Status.Modified));
            return View(model);
        }
    }
}