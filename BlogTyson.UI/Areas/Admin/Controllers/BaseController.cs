using BlogTyson.BLL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogTyson.UI.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected EntityService service;

        public BaseController()
        {
            service = new EntityService();
        }
    }
}