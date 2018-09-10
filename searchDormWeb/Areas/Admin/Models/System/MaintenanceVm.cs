using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.System
{
    public class MaintenanceVm
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


        [Display(Name = "Only without wishlist",
        Description = "A value indicating whether we need to find customers without shopping carts/wishlists. If unchecked, then all customers will be found.")]
        public bool OnlyWithoutWishList { get; set; }


        [Display(Name = "Created before",
        Description = "Delete shopping cart items created before the secified date."),
        DataType(DataType.Date),
        MaxLength(256)]
        public DateTime CreatedBefore { get; set; }

    }
}
