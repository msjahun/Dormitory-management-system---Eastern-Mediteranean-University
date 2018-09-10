using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.Reservation
{
    public class BestSellerRoomsVm
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


        [Display(Name = "Booking status",
        Description = "Search by a specific booking status e.g. Complete.")]
        public IEnumerable<int> BookingStatus { get; set; }


        [Display(Name = "Payment status",
        Description = "Serach by a specific payment status e.g Paid.")]
        public IEnumerable<int> PaymentStatus { get; set; }


        [Display(Name = "Dormitory block",
        Description = "Search in a specific dormitory block."),
        MaxLength(256)]
        public int DormitoryBlock { get; set; }


        [Display(Name = "Billing country",
        Description = "Filter by booking biling country."),
        MaxLength(256)]
        public int BillingCountry { get; set; }


        [Display(Name = "Dormitory",
        Description = "Search by a specific dormitory."),
        MaxLength(256)]
        public int Dormitory { get; set; }


    }
}
