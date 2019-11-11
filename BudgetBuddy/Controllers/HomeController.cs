using BudgetBuddy.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BudgetBuddy.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext context;
        public HomeController()
        {
            context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            if (User.Identity.GetUserId() == null)
            {
                return View();
            }
            else
            {
                string userId = User.Identity.GetUserId();
                var user = context.Users.Where(u => u.ApplicationId == userId).FirstOrDefault();
                return RedirectToAction("Details", "Users", user);
            }
            
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}