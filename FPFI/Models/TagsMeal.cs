using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPFI.Models
{
    public class TagsMeal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TagsMealID { get; set; }
        [Required]
        public int TagID { get; set; }
        [Required]
        public int MealID { get; set; }


        public virtual Tag  Tag { get; set; }
        public virtual Meal Meal { get; set; }

    }
}