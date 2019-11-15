using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BudgetBuddy.Models
{
    public class WishList
    {
        [Key]
        public int wishListId { get; set; }

        [Required]
        [Display(Name = "Wish List Item")]
        public string wishListName { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Wish List Price")]
        public decimal wishListPrice { get; set; }

        [ForeignKey("User")]
        public int? Id { get; set; }
        public User User { get; set; }
    }
}