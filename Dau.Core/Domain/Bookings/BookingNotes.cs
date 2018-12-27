using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Bookings
{
   public class BookingNotes : BaseEntity

    {
       
        public string Note { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool ShowToCustomer { get; set; }

        public Booking Booking { get; set; }
        public long BookingId { get; set; }
        //where are the fields
    }
}
