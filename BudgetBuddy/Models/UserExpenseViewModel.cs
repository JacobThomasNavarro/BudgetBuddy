using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetBuddy.Models
{
    public class UserExpenseViewModel
    {
       
        public decimal TotalExpenses { get; set; }

        public List<Expense> Expenses { get; set; }

        
    }
}