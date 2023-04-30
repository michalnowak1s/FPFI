using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPFI.Models
{
    public class MealsIngredients
    {
        public int MealsIngredientsID { get; set; }
        public int IngredientID { get; set; }
        public int MealID { get; set; }
        public int Quantity { get; set; }

        public virtual Ingredients Ingredients { get; set; }
        public virtual Meals Meals { get; set; }

    }
}