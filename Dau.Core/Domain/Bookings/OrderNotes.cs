using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Bookings
{
   public class OrderNotes : BaseEntity

    {
       
        public string Note { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool ShowToCustomer { get; set; }

        public Booking Booking { get; set; }
        //where are the fields
    }
}
