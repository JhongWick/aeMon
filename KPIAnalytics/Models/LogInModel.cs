using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KPIAnalytics.Models
{
    public class LogInModel
    {


        // public string UserName { get; set; }

        //public string Password { get; set; }

        // public string Roles { get; set; }


        //Edit  
        [Required(ErrorMessage = "Username is required")]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Roles { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }

    }
}