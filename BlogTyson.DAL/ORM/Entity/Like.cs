using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTyson.DAL.ORM.Entity
{
    public class Like : BaseEntity
    {
        public Guid AppUserID { get; set; }
        public virtual AppUser AppUser { get; set; }

        public Guid ArticleID { get; set; }
        public virtual Article Article { get; set; }
    }
}
