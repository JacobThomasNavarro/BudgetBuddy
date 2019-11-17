using BudgetBuddy.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BudgetBuddy.Controllers
{
    public class WishListController : Controller
    {
        ApplicationDbContext context;
        SMSController sendText;

        public WishListController()
        {
            context = new ApplicationDbContext();
            sendText = new SMSController();
        }
        // GET: WishList
        public ActionResult Index()
        {
            return View(context.WishLists.ToList());
        }
        public ActionResult GetUserWishlist()
        {
            decimal temporaryProgress = 0;
            
            UserExpenseViewModel userExpenses = new UserExpenseViewModel() { TotalExpenses = 0, TotalSavings = 0, WishlistItemPrice = 0};
            string id = User.Identity.GetUserId();
            var user = context.Users.Where(u => u.ApplicationId == id).FirstOrDefault();
            userExpenses.Expenses = context.Expenses.Where(e => e.Id == user.Id).ToList();
            userExpenses.WishlistItems = context.WishLists.Where(e => e.Id == user.Id).ToList();
            foreach (Expense item in userExpenses.Expenses)
            {
                if (item.savingPercentage != null)
                {
                    userExpenses.TotalSavings += (item.savingPercentage / 100) * item.billPrice;
                }
            }
            userExpenses.TotalSavings = Decimal.Round(userExpenses.TotalSavings.Value, 2);
            userExpenses.Progress = new List<decimal>();
            foreach (WishList item in userExpenses.WishlistItems)
            {
                
                temporaryProgress = (userExpenses.TotalSavings.Value / item.wishListPrice) * 100;
                if (temporaryProgress >= item.wishListPrice)
                {
                    //sendText.SendSMS(user);    
                }
                if(temporaryProgress >= 100)
                {
                    temporaryProgress = 100;
                }
                temporaryProgress = decimal.Round(temporaryProgress, 0);
                userExpenses.Progress.Add(temporaryProgress);
                
            }
            
            return View(userExpenses);
        }
        // GET: WishLists/Details/5
        public ActionResult Details(int id)
        {
            WishList wishList = context.WishLists.Where(w => w.wishListId == id).FirstOrDefault();
            return View(wishList);
        }


        // GET: WishLists/Create
        public ActionResult Search()
        {
            WishList wishList = new WishList();
            return View();
        }
        // POST: WishLists/Create
        [HttpPost]
        public async Task<ActionResult> Search(WishList wishList)
        {
           
            string id = User.Identity.GetUserId();
            var user = context.Users.Where(u => u.ApplicationId == id).FirstOrDefault();
            string url = $"https://google-shopping.p.rapidapi.com/search?language=EN&keywords={wishList.wishListName}&country=US";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "8fa913baffmshf6dc5b1fa40cc1fp1fdf06jsn365e4c5f0d7f");
            HttpResponseMessage response = await client.GetAsync(url);
            string data = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                Class1[] googleWishListItems = JsonConvert.DeserializeObject<Class1[]>(data);


                
                

                return View("SearchResults", googleWishListItems);

            }
            return View("SearchResults","WishList");
        }
        public ActionResult SearchResults(Class1[] googleWishListItem)
        {
            
            return View(googleWishListItem);
        }
        public ActionResult UpdateWishlistItem(string name, float price)
        {
            string id = User.Identity.GetUserId();
            var user = context.Users.Where(u => u.ApplicationId == id).FirstOrDefault();
            WishList wishList = new WishList();
            wishList.wishListName = name;
            wishList.wishListPrice = (decimal)price;
            wishList.Id = user.Id;
            context.WishLists.Add(wishList);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");

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
                return RedirectToAction("Index","Users");
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
                return RedirectToAction("Index", "Users");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Purchase(int id)
        {
            WishList wishList = context.WishLists.Where(w => w.wishListId == id).FirstOrDefault();
            return View(wishList);
        }

        // POST: WishLists/Delete/5
        [HttpPost]
        public ActionResult Purchase(int id, WishList wishList)
        {
            try
            {
                // TODO: Add delete logic here
                WishList deleteWishList = context.WishLists.Where(w => w.wishListId == id).FirstOrDefault();
                context.WishLists.Remove(deleteWishList);
                context.SaveChanges();
                return RedirectToAction("Index", "Users");
            }
            catch
            {
                return View();
            }
        }
    }
}
