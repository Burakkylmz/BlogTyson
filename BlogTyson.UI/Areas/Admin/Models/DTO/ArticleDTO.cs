using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogTyson.UI.Areas.Admin.Models.DTO
{
    public class ArticleDTO : BaseDTO
    {
        public string Header { get; set; }
        public string Content { get; set; }
    }
}