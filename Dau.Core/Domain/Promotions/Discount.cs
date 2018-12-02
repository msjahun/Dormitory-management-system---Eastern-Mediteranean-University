using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Promotions
{
  public  class Discount : BaseEntity
    {
        public Discount()
        {
            DiscountUsages = new HashSet<DiscountUsage>();
        }

        
        public string DiscountName { get; set; }

        public string CouponCode { get; set; }

        public int DiscountType { get; set; }


       // public string Name { get; set; } ..we already have discountName


        public double UsePercentage { get; set; } //percentage 5% discount

        public double DiscountAmount { get; set; }

        public bool RequiresCouponCode { get; set; }

        //public DateTime StartDate { get; set; }

       // public DateTime EndDate { get; set; }

            public DateTime UsedDate { get; set; }

        public bool CumulativeWithOtherDiscounts { get; set; }

        public int DiscountLimitation { get; set; }




        //requirement tab // should have a dropdown list
        public int DiscountRequirementType { get; set; }


        //usage history create a table for usage history
        //one to many with usage history

        public ICollection<DiscountUsage> DiscountUsages{ get; set; }

    }
}
