using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Promotions
{
    class DiscountUsageHistory
    {
        public bool Used { get; set; }
        public string OrderNumber { get; set; }
        public double OrderTotal { get; set; }
    }
}
