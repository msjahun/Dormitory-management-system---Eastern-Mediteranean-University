using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Reservations
{
    class Reservation
    {

        public DateTime StartDate { get; set; }

 public DateTime EndDate { get; set; }

       public string Room { get; set; }

        public IEnumerable<int> BookingStatus { get; set; }

        public IEnumerable<int> PaymentStatus { get; set; }


      public string BillingEmailAddress { get; set; }

        public string BillingLastName { get; set; }

       public int BillingCountry { get; set; }

        public int PaymentMethod { get; set; }

      public string BookingNotes { get; set; }

      public int GoDirectlyToBookingNumber { get; set; }

    

       public string BookingOrderNumber { get; set; }

      public string Dormitory { get; set; }



       public string Customer { get; set; }

        public string CustomerIpAddress { get; set; }

        public string BookingOrderSubtotal { get; set; }

       public string BookingFee { get; set; }

       public string OrderTotal { get; set; }

        public string Profit { get; set; }



        public string CreatedOn { get; set; }


       public string BillingAddress { get; set; }

        //put a field for CancelReservations
        public bool IsCancelled { get; set; }

        public bool IsDeleted { get; set; }


        //two field to track affiliate accounts
        public bool IsAffiliateBooking { get; set; }
        public bool AffiliateId { get; set; }

        //     public OrderNotesTab orderNotesTab { get; set; } create a table for ordernotes
    }
}
