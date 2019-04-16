using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogTyson.UI.Models.VM
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Kullanıcı Adı Hatası!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifre Hatası!")]
        public string Password { get; set; }

    }
}