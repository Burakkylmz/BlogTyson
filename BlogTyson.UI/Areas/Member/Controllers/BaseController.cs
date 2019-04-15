using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogTyson.UI.Areas.Member.Controllers
{
    public class BaseController : Controller
    {
        // GET: Member/Base
        public ActionResult Index()
        {
            return View();
        }
    }
}