using BudgetBuddy.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BudgetBuddy.Controllers
{
    public class WishListController : Controller
    {
        ApplicationDbContext context;

        public WishListController()
        {
            context = new ApplicationDbContext();
        }
        // GET: WishList
        public ActionResult Index()
        {
            return View(context.WishLists.ToList());
        }

        // GET: WishLists/Details/5
        public ActionResult Details(int id)
        {
            WishList wishList = context.WishLists.Where(w => w.wishListId == id).FirstOrDefault();
            return View(wishList);
        }

        // GET: WishLists/Create
        public ActionResult Create()
        {
            WishList wishList = new WishList();
            return View();
        }

        // POST: WishLists/Create
        [HttpPost]
        public ActionResult Create(WishList wishList)
        {
            try
            {
                // TODO: Add insert logic here
                context.WishLists.Add(wishList);
                context.SaveChanges();

                string id = User.Identity.GetUserId();
                var user = context.Users.Where(u => u.ApplicationId == id).FirstOrDefault();
                wishList.Id = user.Id;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: WishLists/Edit/5
        public ActionResult Edit(int id)
        {
            WishList wishList = context.WishLists.Where(w => w.wishListId == id).FirstOrDefault();
            return View(wishList);
        }

        // POST: WishLists/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, WishList wishList)
        {
            try
            {
                // TODO: Add update logic here
                WishList editWishList = context.WishLists.Where(w => w.wishListId == id).FirstOrDefault();
                editWishList.wishListName = wishList.wishListName;
                editWishList.wishListPrice = wishList.wishListPrice;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: WishLists/Delete/5
        public ActionResult Delete(int id)
        {
            WishList wishList = context.WishLists.Where(w => w.wishListId == id).FirstOrDefault();
            return View(wishList);
        }

        // POST: WishLists/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, WishList wishList)
        {
            try
            {
                // TODO: Add delete logic here
                WishList deleteWishList = context.WishLists.Where(w => w.wishListId == id).FirstOrDefault();
                context.WishLists.Remove(deleteWishList);
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
