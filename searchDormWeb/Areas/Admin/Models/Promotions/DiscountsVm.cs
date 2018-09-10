using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.Promotions
{
    public class DiscountsVm
    {
        [Display(Name = "Discount name",
        Description = "Search by discount name."),
        DataType(DataType.Text),
        MaxLength(256)]
        public string DiscountName { get; set; }

        [Display(Name = "Coupon code",
        Description = "Search by discount coupon code."),
        DataType(DataType.Text),
        MaxLength(256)]
        public string CouponCode { get; set; }

        [Display(Name = "Discount type",
        Description = "Search by discount type."),
        MaxLength(256)]
        public int DiscountType { get; set; }

    }
}
