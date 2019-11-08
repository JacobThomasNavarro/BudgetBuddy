using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BudgetBuddy.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string firstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        public string emailAddress { get; set; }

        [Required]
        [Display(Name = "Street Address")]
        public string streetAddress { get; set; }
        [Required]
        [Display(Name = "City")]
        public string city { get; set; }
        [Required]
        [Display(Name = "State Code")]
        public string stateCode { get; set; }
        [Required]
        [Display(Name = "ZIP Code")]
        public int zipcode { get; set; }



        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}