using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Models
{
    public class DebugViewModel
    {

        [Required, EmailAddress, MaxLength(256), Display(Name = "Email Address", Description = "Field for valid email addresses")]
        public string Email { get; set; }

        [Required, MinLength(6), MaxLength(50), DataType(DataType.Password), Display(Name = "Password", Description ="Password field")]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }

    }
}
