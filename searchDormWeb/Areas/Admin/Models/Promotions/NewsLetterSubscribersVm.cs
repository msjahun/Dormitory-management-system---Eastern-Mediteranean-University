using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.Promotions
{
    public class NewsLetterSubscribersVm
    {
        [Display(Name = "Start date",
        Description = "The start date of the search."),
        DataType(DataType.Date),
        MaxLength(256)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End date",
        Description = "The end date of the search."),
        DataType(DataType.Date),
        MaxLength(256)]
        public DateTime EndDate { get; set; }

        [EmailAddress,
            Display(Name = "Email",
        Description = "Search by a specific email."),
        DataType(DataType.EmailAddress),
        MaxLength(256)]
        public string Email { get; set; }

        [Display(Name = "Active",
        Description = "Search by a specific status e.g. Active."),
        MaxLength(256)]
        public int Active { get; set;  }

        [Display(Name = "Customer roles",
        Description = "Search by a specific customer role."),
        MaxLength(256)]
        public int CustomerRoles { get; set; }


    }
}
