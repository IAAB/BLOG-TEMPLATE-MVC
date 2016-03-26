using BlogTemplateMvc.Context;
using BlogTemplateMvc.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogTemplateMvc.Controllers
{
    public class HomeController : Controller
    {
        private const int postsPerPage = 3;
        BlogMVCDbContext db = new BlogMVCDbContext();

        public ActionResult Index()
        {
            var post = db.Posts.OrderByDescending(p => p.PostedOn).FirstOrDefault();
            return View(post);
        }

        public ActionResult ViewAllPosts()
        {
            ViewBag.CurrentPage = 1;
            ViewBag.LastPage = Math.Ceiling((double)(db.Posts.Count()) / postsPerPage);
            var posts = db.Posts.OrderByDescending(p => p.PostedOn).Take(postsPerPage);
            return View(posts);
        }

        [HttpPost]
        public ActionResult ViewAllPosts(int CurrentPage, int LastPage)
        {
            ViewBag.CurrentPage = CurrentPage;
            ViewBag.LastPage = LastPage;
            var posts = db.Posts.OrderByDescending(p => p.PostedOn).Skip((CurrentPage - 1) * postsPerPage).Take(postsPerPage);
            return View(posts);
        }

        public ActionResult SeePost(int id)
        {
            Post post = db.Posts.Where(p => p.Id == id).FirstOrDefault();
            return View(post);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Contact(Message message)
        {
            try
            {
                message.SentOn = DateTime.Now;
                db.Messages.Add(message);
                db.SaveChanges();

                this.TempData["SuccesfulMessage"] = "Thank you for your message! I will contact you as soon as I can.";
                return View();
            }
            catch (Exception)
            {
                this.TempData["UnsuccesullMessage"] = "Problem occured with your message, please try again later.";
                return View(message);
            }
        }
    }
}