using System;
using System.Collections.Generic;
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
            public string title { get; set; }
            public string currency { get; set; }
            public float price { get; set; }
            public string google_shopping_id { get; set; }
        }



    
}