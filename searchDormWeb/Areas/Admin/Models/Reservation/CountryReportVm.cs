using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.Reservation
{
    public class CountryReportVm
    {

        [Display(Name = "Start date",
        Description = "The start date of the search."),
        DataType(DataType.Date),
        MaxLength(256)]
        public DateTime StartDate { get; set; }

       
        [Required,
        Display(Name = "End date",
        Description = "The end date of the search."),
        DataType(DataType.Date),
        MaxLength(256)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Booking status",
        Description = "Search by a specific booking status e.g. Complete."),
        MaxLength(256)]
        public int BookingStatus { get; set; }


        [Display(Name = "Payment status",
        Description = "Search by a specific payment status e.g. Paid."),
        MaxLength(256)]
        public int PaymentStatus { get; set; }


    }
}
