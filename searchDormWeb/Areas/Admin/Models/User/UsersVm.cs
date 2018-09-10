using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.User
{
    public class UsersVm
    {
        [EmailAddress,
         Display(Name = "Email",
         Description = "Search by a specific email."),
         DataType(DataType.EmailAddress),
         MaxLength(256)]

        public string Email { get; set; }

        [Display(Name = "First name",
        Description = "Search by a first name."),
        DataType(DataType.Text),
        MaxLength(256)]
        public string FirstName { get; set; }

        [Display(Name = "Last name",
        Description = "Search by a last name."),
        DataType(DataType.Text),
        MaxLength(256)]
        public string LastName { get; set; }

        [Display(Name = "Date of birth",
        Description = "Filter by date of birth, don't select any value to load all records."),
        DataType(DataType.Date),
        MaxLength(256)]
        public DateTime DateOfBirth { get; set; }


        [Display(Name = "Phone",
        Description = "Search by a phone number."),
        DataType(DataType.PhoneNumber),
        MaxLength(256)]
        public string Phone { get; set; }

        [Display(Name = "Ip address",
        Description = "Search by Ip address."),
        DataType(DataType.Text),
        MaxLength(256)]
        public string IpAddress { get; set; }


        [Display(Name = "Customer role",
        Description = "Filter by customer role."),
        MaxLength(256)]
        public int CustomerRole { get; set; }

    }
}
