using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPFI.Models
{
    public class MealIngredient
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MealIngredientID { get; set; }
        public int IngredientID { get; set; }
        public int MealID { get; set; }
        public int Quantity { get; set; }

        public virtual Meal Meal { get; set; }
        public virtual Ingredient Ingredient { get; set; }

    }
}