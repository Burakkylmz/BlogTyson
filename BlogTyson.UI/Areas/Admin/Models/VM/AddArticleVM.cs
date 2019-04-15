using BlogTyson.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogTyson.UI.Areas.Admin.Models.VM
{
    public class AddArticleVM
    {
        public AddArticleVM()
        {
            AppUsers = new List<AppUser>();
            Categories = new List<Category>();
        }

        public List<AppUser> AppUsers { get; set; }
        public List<Category> Categories { get; set; }
    }
}