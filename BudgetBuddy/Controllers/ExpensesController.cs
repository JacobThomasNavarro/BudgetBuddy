using BudgetBuddy.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BudgetBuddy.Controllers
{
    public class ExpensesController : Controller
    {
        ApplicationDbContext context;

        public ExpensesController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Expenses
        public ActionResult Index()
        {
            return View(context.Expenses.ToList());
        }
        public ActionResult GetUserExpenses()
        {
            string id = User.Identity.GetUserId();
            var user = context.Users.Where(u => u.ApplicationId == id).FirstOrDefault();
            var expenses = context.Expenses.Where(e => e.Id == user.Id).ToList();
            
            
            return View(expenses);
        }
        // GET: Expenses/Details/5
        public ActionResult Details(int id)
        {
            Expense expense = context.Expenses.Where(e => e.expenseId == id).FirstOrDefault();
            return View(expense);
        }

        // GET: Expenses/Create
        public ActionResult Create()
        {
            Expense expense = new Expense();
            return View();
        }

        // POST: Expenses/Create
        [HttpPost]
        public ActionResult Create(Expense expense)
        {
            try
            {
                // TODO: Add insert logic here
                context.Expenses.Add(expense);
                context.SaveChanges();

                string id = User.Identity.GetUserId();
                var user = context.Users.Where(u => u.ApplicationId == id).FirstOrDefault();
                expense.Id = user.Id;
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Expenses/Edit/5
        public ActionResult Edit(int id)
        {
            Expense expense = context.Expenses.Where(e => e.expenseId == id).FirstOrDefault();
            return View(expense);
        }

        // POST: Expenses/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Expense expense)
        {
            try
            {
                // TODO: Add update logic here
                Expense expenseToEdit = context.Expenses.Where(e => e.expenseId == id).FirstOrDefault();
                expenseToEdit.billName = expense.billName;
                expenseToEdit.billPrice = expense.billPrice;
                expenseToEdit.purchaseDate = expense.purchaseDate;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Expenses/Delete/5
        public ActionResult Delete(int id)
        {
            Expense expense = context.Expenses.Where(e => e.expenseId == id).FirstOrDefault();
            return View(expense);
        }

        // POST: Expenses/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Expense expense)
        {
            try
            {
                // TODO: Add delete logic here
                Expense expenseToDelete = context.Expenses.Where(e => e.expenseId == id).FirstOrDefault();
                context.Expenses.Remove(expenseToDelete);
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
