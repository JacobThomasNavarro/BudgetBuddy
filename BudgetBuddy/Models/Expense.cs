using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;



namespace BudgetBuddy.Models
{
    public class Expense
    {
        [Key]
        public int expenseId { get; set; }

        [Required]
        [Display(Name = "Bill Name")]
        public string billName { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Bill Price")]
        public decimal billPrice { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Purchased")]
        public DateTime purchaseDate { get; set; }

        [Display(Name = "Recurring Expense")]
        public bool recurringExpense { get; set; }

        [ForeignKey("User")]
        public int? Id { get; set; }
        public User User { get; set; }
    }


}