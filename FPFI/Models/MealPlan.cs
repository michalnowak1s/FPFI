using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPFI.Models
{
    public class MealPlan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MealPlansID { get; set; }
        [Required]
        public int MealID { get; set; }
        [Required]
        public DateTime StartData { get; set; }
        [Required]
        public DateTime EndData { get; set; }
        public  string Title { get; set; }
        public string Description { get; set; }

        public virtual Meal Meals { get; set; }

    }
}