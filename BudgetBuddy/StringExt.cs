using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetBuddy
{
    public static class StringExt
    {
        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) { return value; }
            if(value.Length > maxLength)
            {
                List<char> holder = new List<char>();
                for (int i = 0; i < value.Length - 2; i++)
                {
                    holder.Add(value[i]);

                }
                var result = holder.ToString();
                value = result;
            }
            return value;
        }
    }
}