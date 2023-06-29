using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPFI.Models
{
    public class MealIngredient
    {

        [Key]
        [Column(Order = 1)]
        public int MealID { get; set; }

        [Key]
        [Column(Order = 2)]
        public int IngredientID { get; set; }
        public int Quantity { get; set; }

        public virtual Meal Meal { get; set; }
        public virtual Ingredient Ingredient { get; set; }

    }
}