using BlogTyson.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTyson.BLL.Repository
{
    public class AppUserRepository : BaseRepository<AppUser>
    {
        public bool CheckCredentials(string userName, string Password)
        {
            return table.Any(x => x.UserName == userName && x.Password == Password);
        }
        public AppUser FindByuserName(string userName)
        {
            return table.FirstOrDefault(x => x.UserName == userName);
        }
    }
}
