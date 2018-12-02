using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Promotions
{
    public class DiscountUsage : BaseEntity
    {
      
        public bool Used { get; set; }
        public string BookingNumber { get; set; }
        public double BookingTotal { get; set; }


        public Discount Discount{ get; set; }
    }
}
