using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Promotions
{
    public class DiscountUsage
    {
        public bool Used { get; set; }
        public string OrderNumber { get; set; }
        public double OrderTotal { get; set; }


        public Discount Discount{ get; set; }
    }
}
