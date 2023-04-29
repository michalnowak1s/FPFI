using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace FPFI.ViewModel
{
    public class CalendarUserViewModel
    {
        [Display(Name = "Login")]
        public string Login { get; set; }
        [Display(Name = "Hasło")]
        public string Password { get; set; }
    }
}


