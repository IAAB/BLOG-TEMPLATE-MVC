using BlogTemplateMvc.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogTemplateMvc.Controllers
{
    public class AdminLogInController : Controller
    {
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(Admin user)
        {
            //Add your Admin user and password here
            if (user.Password == "123" && user.Username == "admin")
            {
                Session["Admin"] = "true";
                return RedirectToAction("Index","LoggedIn",new { area=""});
            }
            else
            {
                ModelState.AddModelError("", "Incorrect username or password.");
                return View();
            }
        }

        public ActionResult LoggedIn()
        {
            if (Session["Admin"] !=null)
            {
                return RedirectToAction("Index", "Room", new { area = "" });
            }
            else
            {
                return RedirectToAction("LogIn");
            }
        }
    }
}