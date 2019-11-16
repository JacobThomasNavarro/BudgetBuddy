using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BudgetBuddy.Models
{
    
    

        public class GoogleWishListItem
        {
            public Class1[] Property1 { get; set; }
        }

        public class Class1
        {
            [Display(Name = "Name")]
            public string title { get; set; }
            public string currency { get; set; }
            [Display(Name = "Price")]
            public float price { get; set; }
            public string google_shopping_id { get; set; }
        }



    
}