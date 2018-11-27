using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.Addresses;

namespace Dau.Core.Domain.Reservations
{
    public class Reservation
    {
        public Reservation()
        {
            OrderNotes = new HashSet<OrderNotes>();
        }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Room { get; set; }

        public IEnumerable<int> BookingStatus { get; set; }

        public IEnumerable<int> PaymentStatus { get; set; }


        public string BillingEmail { get; set; }

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

        //there will be two kinds of address, booking address and billing address
        //and its one to  one relationship
        public Address BillingAddress { get; set; }

        //put a field for CancelReservations
        public bool IsCancelled { get; set; }

        public bool IsDeleted { get; set; }


        //two field to track affiliate accounts
        public bool IsAffiliateBooking { get; set; }
        public bool AffiliateId { get; set; }

        //     public OrderNotesTab orderNotesTab { get; set; } create a table for ordernotes
        public ICollection<OrderNotes> OrderNotes{ get; set; }

        //since you can only reserve one room at a time, I can just add a room identifier in the reservation entity
        public int RoomId { get; set; }
    }
}
