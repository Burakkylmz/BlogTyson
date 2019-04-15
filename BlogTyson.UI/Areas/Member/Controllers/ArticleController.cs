using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogTyson.UI.Areas.Member.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Member/Article
        public ActionResult Index()
        {
            return View();
        }
    }
}