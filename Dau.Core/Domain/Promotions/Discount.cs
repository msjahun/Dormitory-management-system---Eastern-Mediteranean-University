using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Promotions
{
    class Discount
    {
        public string DiscountName { get; set; }

      public string CouponCode { get; set; }

        public int DiscountType { get; set; }


        public string Name { get; set; }

     
       public bool UsePercentage { get; set; }

       public int DiscountAmount { get; set; }

       public bool RequiresCouponCode { get; set; }

       public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

      public bool CumulativeWithOtherDiscounts { get; set; }

       public int DiscountLimitation { get; set; }




        //requirement tab // should have a dropdown list
       public int DiscountRequirementType { get; set; }


        //usage history create a table for usage history
    }
}
