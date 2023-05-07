using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FPFI.Models
{
    public class MealsIngredients
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MealsIngredientsID { get; set; }
        public int IngredientID { get; set; }
        public int MealID { get; set; }
        public int Quantity { get; set; }

        public virtual Ingredients Ingredients { get; set; }
        public virtual Meals Meals { get; set; }

    }
}