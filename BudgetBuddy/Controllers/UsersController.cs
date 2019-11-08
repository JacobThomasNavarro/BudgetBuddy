using BudgetBuddy.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BudgetBuddy.Controllers
{
    public class UsersController : Controller
    {
        

        ApplicationDbContext context;
        public UsersController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Users
        public ActionResult Index()
        {
            return View(context.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            User user = context.Users.Where(u => u.Id == id).FirstOrDefault();
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            User users = new User();
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                string id = User.Identity.GetUserId();
                user.ApplicationId = id;
                // TODO: Add insert logic here
                context.Users.Add(user);
                
                context.SaveChanges();
                return RedirectToAction("Details", "Users", user);
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            User user = context.Users.Where(u => u.Id == id).FirstOrDefault();
            return View(user);
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            try
            {
                // TODO: Add update logic here
                User editedUser = context.Users.Where(c => c.Id == id).FirstOrDefault();
                editedUser.firstName = user.firstName;
                editedUser.lastName = user.lastName;
                editedUser.emailAddress = user.emailAddress;
                editedUser.streetAddress = user.streetAddress;
                editedUser.city = user.city;
                editedUser.stateCode = user.stateCode;
                editedUser.zipcode = user.zipcode;
               
                context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            User user = context.Users.Where(u => u.Id == id).FirstOrDefault();
            return View();
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, User user)
        {
            try
            {
                // TODO: Add delete logic here
                User userToDelete = context.Users.Where(u => u.Id == id).FirstOrDefault();
                context.Users.Remove(userToDelete);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
