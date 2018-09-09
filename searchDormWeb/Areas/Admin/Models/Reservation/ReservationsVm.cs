using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.Reservation
{
    public class ReservationsVm
    {

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Room { get; set; }
        public int[] BookingStatus { get; set; }
        public int[] PaymentStatus { get; set; }
        public string BillingEmailAddress { get; set; }
        public string BillingLastName { get; set; }
        public int BillingCountry { get; set; }
        public int PaymentMethod { get; set; }
        public string BookingNotes { get; set; }
        public int GoDirectlyToBookingNumber { get; set; }

    }
}
