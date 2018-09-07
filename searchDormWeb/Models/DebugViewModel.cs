using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Models
{
    public class DebugViewModel
    {

        [Required, EmailAddress, MaxLength(256), Display(Name = "Email Address", Description = "Field for valid email addresses")]
        public string Email { get; set; }

        [MinLength(6), MaxLength(50), DataType(DataType.Password), Display(Name = "Password", Description ="Password field")]
        
        public string Password { get; set; }

       [Required, Display(Description ="Read only text")]
        public string TextReadOnly { get; set; }


        [Required, Display(Description = "Read only text")]
        public string TextReadOnlyNotRequired { get; }

        [Display(Name = "Gender", Description = "Gender ")]
        public string Gender { get; }

           [Display(Name = "Gender", Description = "Gender readonly")]
        public string GenderReadOnly { get; }

        [Display(Name = "Gender Multi-select", Description = "Gender multiselect")]
        public string GenderMultiSelect { get; set; }

        public List<SelectListItem> Genders { get; } = new List<SelectListItem>
        {

            new SelectListItem { Value = "M", Text = "Male" },
            new SelectListItem { Value = "F", Text = "Female" },
            new SelectListItem { Value = "F", Text = "Female" },
            new SelectListItem { Value = "F", Text = "Female" },
            new SelectListItem {Disabled= true, Value = "F", Text = "Female" },
            new SelectListItem { Value = "F", Text = "Female" },
            new SelectListItem {Disabled= true, Value = "F", Text = "Female" },
            new SelectListItem { Value = "F", Text = "Female" }
        };

        [Required, EmailAddress, MaxLength(256), Display(Name = "Text area", Description = "Field fortext area addresses")]
        public string TextArea { get; set; }

        [Required, EmailAddress, MaxLength(256), Display(Name = "Textarea Editor", Description = "Field fortext area addresses")]
        public string TextAreaEditor { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }

    }
}
