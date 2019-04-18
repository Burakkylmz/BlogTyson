using BlogTyson.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogTyson.UI.Areas.Member.Models.VM
{
    public class ArticleCommentVM
    {

        public ArticleCommentVM()
        {
            Comments = new List<Comment>();
            Articles = new List<Article>();
            AppUsers = new List<AppUser>();

        }

        public IEnumerable<AppUser> AppUsers { get; set; }
        public IEnumerable<Article> Articles { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public int Likes { get; set; }

    }
}