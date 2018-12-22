using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Bookings
{
  public  class CancelBookingRequests : BaseEntity
    {

      

        public long BookingId { get; set; }
       
        public string CustomerId { get; set; }
        public int ReturnRequestStatus { get; set; }
        public string ReasonForCancellation { get; set; }
        public string RequestedAction { get; set; }
        public string CustomerComment { get; set; }
        public string StaffNotes { get; set; }
        public DateTime CreatedOn{ get; set; }
        public int CancellationStatus { get; set; }


        //this definitely has some sort of relationship with booking/reservation table, is bookingNumber enough
    }
}
