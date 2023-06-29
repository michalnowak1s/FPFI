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
        public int AccountID { get; set; }
        public int MealID { get; set; }
        public DateTime MeakDay { get; set; }
        public int Section { get; set; }

        public virtual MealPlan MealPlans { get; set; }
        public virtual Account Account { get; set; }

    }
}