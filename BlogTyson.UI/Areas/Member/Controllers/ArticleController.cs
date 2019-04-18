using BlogTyson.DAL.ORM.Entity;
using BlogTyson.UI.Areas.Member.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogTyson.UI.Areas.Member.Controllers
{
    public class ArticleController : BaseController
    {

        private object comment;

        public ActionResult Show(Guid id)
        {
            ArticleCommentVM model = new ArticleCommentVM() {

                Articles = service.ArticleService.GetActive(),

                AppUsers = service.AppUserService.GetActive(),

                Comments = service.CommentService.GetDefault(x => x.ArticleID == id).OrderByDescending(x => x.AddDate).Take(10),

                Likes = service.LikeService.GetDefault(x => x.ArticleID == id).Count(),

            };
            return View(model);
        }

        public ActionResult AddComment(CommentVM data)
        {
            Comment comment = new Comment();
            comment.AppUserID = service.AppUserService.FindByuserName(HttpContext.User.Identity.Name).ID;
            comment.ArticleID = data.ID;
            comment.Content = data.Content;
            comment.AddDate = DateTime.Now;
            service.CommentService.Add(comment);
            return Redirect("/Article/Show/" + data.ID);
        }

        public JsonResult AddLike(Guid id)
        {
            JsonLikeVM jr = new JsonLikeVM();
            Guid appuserID = service.AppUserService.FindByuserName(HttpContext.User.Identity.Name).ID;

            if (!(service.LikeService.Any(x => x.AppUserID == appuserID && x.ArticleID == id)))
            {
                Like like = new Like();
                like.ArticleID = id;
                like.AppUserID = appuserID;
                service.LikeService.Add(like);

                //Kullanıcıya gönderilecek mesaj oluşturulur.

                jr.Likes = service.LikeService.GetDefault(x => x.ArticleID == id).Count();
                jr.userMessage = "";
                jr.isSuccess = true;
                return Json(jr, JsonRequestBehavior.AllowGet);
            }

            jr.isSuccess = false;
            jr.userMessage = "Bu yazıyı daha önce beğendiniz!";
            jr.Likes = service.LikeService.GetDefault(x => x.ArticleID == id).Count();
            return Json(jr, JsonRequestBehavior.AllowGet);

        }
    }
}