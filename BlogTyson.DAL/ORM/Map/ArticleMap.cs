using BlogTyson.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTyson.DAL.ORM.Map
{
    public class ArticleMap : CoreMap<Article>
    {
        public ArticleMap()
        {
            ToTable("dbo.Articles");
            Property(x => x.Content).IsOptional();
            Property(x => x.Header).IsOptional();

            HasRequired(x => x.Category)
                .WithMany(x => x.Articles)
                .HasForeignKey(x => x.CategoryID)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.AppUser)
                .WithMany(x => x.Articles)
                .HasForeignKey(x => x.AppUserID)
                .WillCascadeOnDelete(false);

            HasMany(x => x.Comments)
                .WithRequired(x => x.Article)
                .HasForeignKey(x => x.ArticleID)
                .WillCascadeOnDelete(false);

            HasMany(x => x.Likes)
               .WithRequired(x => x.Article)
               .HasForeignKey(x => x.ArticleID)
               .WillCascadeOnDelete(false);
        }
    }
}
