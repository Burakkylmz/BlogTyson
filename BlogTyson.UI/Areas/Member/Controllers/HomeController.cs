using BlogTyson.UI.Areas.Member.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogTyson.UI.Areas.Member.Controllers
{
    public class HomeController : BaseController
    {

        public ActionResult MemberHomeIndex()
        {

            var model = service.ArticleService.GetActive().OrderByDescending(x => x.AddDate).Take(5);

            return View(model);
        }
    }
}