using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.Reservation
{
    public class ReservationsVm
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

        [Display(Name = "Room",
        Description = "Search by a specific room."),
        DataType(DataType.Text),
        MaxLength(256)]
        public string Room { get; set; }

        [Display(Name = "Booking status",
        Description = "Search by a specific booking status e.g. Pending.")]
        public IEnumerable<int> BookingStatus { get; set; }

        [Display(Name = "Payment status",
        Description = "Search by a specific payment status e.g. Paid.")]
        public IEnumerable<int> PaymentStatus { get; set; }


        [EmailAddress,
            Display(Name = "Billing email address",
        Description = "Filter by customer biling email address."),
        DataType(DataType.EmailAddress),
        MaxLength(256)]
        public string BillingEmailAddress { get; set; }

        [Display(Name = "Billing last name",
        Description = "Filter by customer billing last name."),
        DataType(DataType.Text),
        MaxLength(256)]
        public string BillingLastName { get; set; }

        [Display(Name = "Billing country",
        Description = "Filter by booking biling country."),
        MaxLength(256)]
        public int BillingCountry { get; set; }

        [Display(Name = "Payment method",
        Description = "Search by a specific payment method."),
        MaxLength(256)]
        public int PaymentMethod { get; set; }

        [Display(Name = "Booking notes",
        Description = "Search in order notes. Leave empty to load all bookings."),
        DataType(DataType.Text),
        MaxLength(256)]
        public string BookingNotes { get; set; }

        [Display(Name = "Go directly to booking #",
        Description = "Go directly to booking number #."),
        MaxLength(256)]
        public int GoDirectlyToBookingNumber { get; set; }

    }

    public class ReservationEdit
    {
    }
}
