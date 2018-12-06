using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Reservations
{
  public  class CancelReservationRequests : BaseEntity
    {

      

        public long BookingNumber { get; set; }

        public string CustomerId { get; set; }

    

        public int ReturnRequestStatus { get; set; }

        public string ReasonForCancellation { get; set; }

        public string RequestedAction { get; set; }

        public string CustomerComment { get; set; }

        public string StaffNotes { get; set; }

        public DateTime CreatedOn{ get; set; }




       // public DateTime StartDate { get; set; }

      //  public DateTime EndDate { get; set; }


        public int CancellationStatus { get; set; }


        //this definitely has some sort of relationship with booking/reservation table, is bookingNumber enough
    }
}
