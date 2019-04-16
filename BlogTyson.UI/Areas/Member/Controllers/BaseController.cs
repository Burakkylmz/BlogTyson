using BlogTyson.BLL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogTyson.UI.Areas.Member.Controllers
{
    public class BaseController : Controller
    {
        protected EntityService service = new EntityService();
    }
}