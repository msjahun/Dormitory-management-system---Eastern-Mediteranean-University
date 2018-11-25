using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Promotions
{
    class Affiliate
    {
      public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FriendlyURLName { get; set; }


       public bool LoadOnlyWithOrders { get; set; }


       public bool Active { get; set; }

 

      public string Email { get; set; }

       public string Company { get; set; }

        public int Country { get; set; }

       public int StateProvince { get; set; }

       public string City { get; set; }

       public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string ZipPostalCode { get; set; }

        public string PhoneNumber { get; set; }

        public string FaxNumber { get; set; }

       public string AdminComment { get; set; }

       public string FriendlyUrlName { get; set; }

        public string AffiliateURL { get; set; }
      

        //public AffiliatedBookingsTab AffiliatedBookingsTab { get; set; } create a table for AffiliatedBookings, or add a field for affiliate in the booking table
        //I added a field
    }
}
