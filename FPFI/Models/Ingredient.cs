using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FPFI.Models
{
    public class Ingredient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IngredientID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Nutriscore { get; set; }
        public string Endurance { get; set; }
        public string Allergen { get; set; }
        public int UnitID { get; set; }


        public virtual Unit Unit { get; set; }
    }
}