
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.User
{
    public class UserAddViewModel
    {
      

     


        [Required, EmailAddress, MaxLength(256), Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required, MinLength(6), MaxLength(60), DataType(DataType.Password), Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Customer roles")]
        public IEnumerable<string> CustomerRole { get; set; }
       
        public List<SelectListItem> CustomerRoles { get; set; }

        [Display(Name = "Manager of dormitory")]
        public List<long> ManagerOfDormitory { get; set; }

        public List<SelectListItem> Dormitories { get; set; }


        [Display(Name = "Gender")]
        public string Gender { get; set; }

        public List<SelectListItem> Genders { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "", Text = "" },
            new SelectListItem { Value = "M", Text = "Male" },
            new SelectListItem { Value = "F", Text = "Female" }
        };


        [Display(Name = "First name")]
        [StringLength(40)]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Last name")]
        [StringLength(40)]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; } = DateTime.Now;

        [Display(Name = "City")]
        public string City { get; set; }

        public List<SelectListItem> Cities { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "", Text = "" }
          
        };


        [Display(Name = "Country")]
        public string Country { get; set; }

        public List<SelectListItem> Countries { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "", Text = "" },
            new SelectListItem { Value = "TR", Text = "Turkey" },
            new SelectListItem { Value = "CY", Text = "Cyprus"  },
        };


        [Display(Name = "Admin Comment")]
        [MaxLength(1024)]
        public string AdminComment { get; set; }

        [Display(Name = "News Letter")]
        public bool NewsletterSubscription { get; set; }

        [Display(Name = "Active")]
        public bool Active { get; set; }





    }

    
}
