using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPFI.Models
{
    public class Ingredients
    {
        public int IngredientID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Nutriscore { get; set; }
        public string Endurance { get; set; }
        public string Allergen { get; set; }
        public string Unit { get; set; }
    }
}