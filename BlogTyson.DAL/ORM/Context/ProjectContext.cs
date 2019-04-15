using BlogTyson.DAL.ORM.Entity;
using BlogTyson.DAL.ORM.Map;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTyson.DAL.ORM.Context
{
    public class ProjectContext : DbContext
    {
        public ProjectContext()
        {
            Database.Connection.ConnectionString = "Server=.;Database=TysonBlog;uid=burak;pwd=112358";
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AppUserMap());
            modelBuilder.Configurations.Add(new ArticleMap());
            modelBuilder.Configurations.Add(new CommentMap());
            modelBuilder.Configurations.Add(new LikeMap());
            modelBuilder.Configurations.Add(new CategoryMap());

            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));

            base.OnModelCreating(modelBuilder);
        }
    }
}

