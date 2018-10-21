using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.Promotions
{
    public class AffiliatesVm
    {

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

        [Display(Name = "Friendly Url name",
        Description = "Search by a friendly url name."),
        DataType(DataType.Text),
        MaxLength(256)]
        public string FriendlyURLName { get; set; }


        [Display(Name = "Load only with orders",
        Description = "Check to load affiliates only with orders placed (by affiliated customers).")]
        public bool LoadOnlyWithOrders { get; set; }


    }

    public class AffiliateAdd
    {
       

    }

    public class AffiliateEdit
    {


    }
}
