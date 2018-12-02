using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Reservations
{
   public class OrderNotes : BaseEntity

    {
       
        public string Note { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool ShowToCustomer { get; set; }

        public Reservation Reservation { get; set; }
        //where are the fields
    }
}
