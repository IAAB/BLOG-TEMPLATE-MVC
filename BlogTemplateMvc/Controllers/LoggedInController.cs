using BlogTemplateMvc.Context;
using BlogTemplateMvc.Data.Models;
using BlogTemplateMvc.HelpMethods;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogTemplateMvc.Controllers
{
    public class LoggedInController : Controller
    {
        private const int postsPerPage = 20;
        BlogMVCDbContext db = new BlogMVCDbContext();
       
        public ActionResult Index()
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Post post,HttpPostedFileBase img)
        {
            
            try
            {
                if (img != null)
                {
                    var arr = new ConvertToByteArr();
                    var convertedImg = arr.ConvertToArr(img);
                    post.Image = convertedImg;
                }
                post.PostedOn = DateTime.Now;
                db.Posts.Add(post);
                db.SaveChanges();

                this.TempData["SuccesfulPost"] = "You succesfully made a post!";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                this.TempData["UnsuccesullPost"] = "Problem occured, couldn't make the post!";
                return View(post);
            }
        }

        public ActionResult ViewMessages()
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.CurrentPage = 1;
            ViewBag.LastPage = Math.Ceiling((double)(db.Messages.Count()) / postsPerPage);
            var messages = db.Messages.OrderBy(m => m.SentOn).Take(postsPerPage);
            return View(messages);
        }

        [HttpPost]
        public ActionResult ViewMessages(int CurrentPage, int LastPage)
        {
            ViewBag.CurrentPage = CurrentPage;
            ViewBag.LastPage = LastPage;
            var messages = db.Messages.OrderByDescending(m => m.SentOn).Skip((CurrentPage - 1) * postsPerPage).Take(postsPerPage);
            return View(messages);
        }

        public ActionResult SeeMessage(int id)
        {
            Message message = db.Messages.Where(m => m.Id == id).FirstOrDefault();
            return View(message);
        }
    }
}