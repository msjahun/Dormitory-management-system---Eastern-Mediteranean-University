using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Reservations
{
  public  class CancelReservationRequests
    {

        public string Id { get; set; }

        public string BookingNumber { get; set; }

        public string Customer { get; set; }

        public string Room { get; set; }

        public int ReturnRequestStatus { get; set; }

        public string ReasonForCancellation { get; set; }

        public string RequestedAction { get; set; }

        public string CustomerComment { get; set; }

        public string StaffNotes { get; set; }

        public string Date { get; set; }




        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }


        public int CancellationStatus { get; set; }


        //this definitely has some sort of relationship with booking/reservation table, is bookingNumber enough
    }
}
