using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetBuddy.Models
{
    public class UserExpenseViewModel
    {
       
        public decimal TotalExpenses { get; set; }
        public decimal? TotalSavings { get; set; }

        public decimal WishlistItemPrice { get; set; }

        public List<decimal> Progress { get; set; }

        public List<Expense> Expenses { get; set; }
        public List<WishList> WishlistItems { get; set; }


    }
}