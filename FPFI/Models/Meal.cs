using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FPFI.Models
{
    public class Meal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MealID { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public string Nutriscore { get; set; }
        public string Difficulty { get; set; }
        public string TimeConsumption { get; set; }
        public string Type { get; set; }

    }
}