using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPFI.Models
{
    public class MealPlans
    {
        public int MealPlansID { get; set; }
        public int AccountID { get; set; }
        public int MealID { get; set; }
        public DateTime MeakDay { get; set; }
        public int Section { get; set; }


    }
}