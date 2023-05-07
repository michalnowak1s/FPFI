using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPFI.Models
{
    public class Meal
    {
        public int MealID { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public string Nutriscore { get; set; }
        public string Difficulty { get; set; }
        public string TimeConsumption { get; set; }
        public string Type { get; set; }

    }
}