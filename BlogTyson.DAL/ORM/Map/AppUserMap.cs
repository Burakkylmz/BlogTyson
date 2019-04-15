using BlogTyson.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTyson.DAL.ORM.Map
{
    public class AppUserMap : CoreMap<AppUser>
    {
        public AppUserMap()
        {
            ToTable("dbo.Users");
            Property(x => x.UserName).IsOptional();
            Property(x => x.Password).IsOptional();
            Property(x => x.Email).IsOptional();
            Property(x => x.Status).IsOptional();
            Property(x => x.Role).IsOptional();
            Property(x => x.LastName).IsOptional();
            Property(x => x.FirstName).IsOptional();

            HasMany(x => x.Articles)
                .WithRequired(x => x.AppUser)
                .HasForeignKey(x => x.AppUserID)
                .WillCascadeOnDelete(false);

            HasMany(x => x.Comments)
                .WithRequired(x => x.AppUser)
                .HasForeignKey(x => x.AppUserID)
                .WillCascadeOnDelete(false);

            HasMany(x => x.Likes)
                .WithRequired(x => x.AppUser)
                .HasForeignKey(x => x.AppUserID)
                .WillCascadeOnDelete(false);
        }
    }
}
