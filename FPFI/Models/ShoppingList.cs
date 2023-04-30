using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPFI.Models
{
    public class ShoppingList
    {
        public int ShoppingListID { get; set; }
        public int MealPlansID { get; set; }

        public virtual MealPlans MealPlans { get; set; }

    }
}