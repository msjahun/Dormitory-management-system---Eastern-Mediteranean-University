using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Promotions
{
    public class DiscountUsage
    {
        public int Id { get; set; }
        public bool Used { get; set; }
        public string BookingNumber { get; set; }
        public double BookingTotal { get; set; }


        public Discount Discount{ get; set; }
    }
}
