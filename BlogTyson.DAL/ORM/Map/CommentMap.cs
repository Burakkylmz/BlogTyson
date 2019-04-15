using BlogTyson.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTyson.DAL.ORM.Map
{
    public class CommentMap : CoreMap<Comment>
    {
        public CommentMap()
        {
            ToTable("dbo.Comments");
            Property(x => x.Content).IsOptional();

            HasKey(c => new { c.AppUserID, c.ArticleID });

        }
    }
}
