using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.Addresses;
using Dau.Core.Domain.Catalog;
using Dau.Core.Domain.Users;

namespace Dau.Core.Domain.Bookings
{
    public class Booking : BaseEntity
    {
        public Booking()
        {
            BookingNotes = new HashSet<BookingNotes>();
        }

       
       

        public long BookingStatusId { get; set; }
        public BookingStatus BookingStatus { get; set; }

        public long PaymentStatusId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }


 
     

        public string UserId { get; set; }
        public User User { get; set;  }

        public string CustomerIpAddress { get; set; }
        public double BookingOrderSubtotal { get; set; }
        public double BookingFee { get; set; }
        public double BookingTotal { get; set; }
        public DateTime CreatedOn { get; set; }
        public Address BillingAddress { get; set; }
        public bool IsCancelled { get; set; }
        public bool IsDeleted { get; set; }
        public bool AffiliateId { get; set; }
        public ICollection<BookingNotes> BookingNotes { get; set; }

        public long RoomId { get; set; }
        public Room Room { get; set; }
    }
}
