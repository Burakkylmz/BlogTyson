using BlogTyson.DAL.ORM.Entity;
using BlogTyson.UI.Areas.Admin.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogTyson.UI.Areas.Admin.Models.VM
{
    public class UpdateArticleVM:BaseVM
    {
        public UpdateArticleVM()
        {
            AppUsers = new List<AppUser>();
            Categories = new List<Category>();
            Article = new ArticleDTO();
        }

        public List<Category> Categories { get; set; }
        public List<AppUser> AppUsers { get; set; }
        public ArticleDTO Article { get; set; }
    }
}