﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.Promotions
{
    public class DiscountsVm
    {

        public string DiscountName { get; set; }
        public string CouponCode { get; set; }
        public int DiscountType { get; set; }

    }
}