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
    public class DiscountAdd
    {
        [Display(Name = "Name",
        Description = "The name of the discount"), DataType(DataType.Text), MaxLength(256)]
        public string Name { get; set; }

        [Display(Name = "DiscountType",
        Description = "The type of the discont"), MaxLength(256)]
        public int DiscountType { get; set; }

        [Display(Name = "UsePercentage",
        Description = "Determines whether to apply a percentage discount to the order/SKUs.If not enabled, a set value is discounted.")]
        public bool UsePercentage { get; set; }

        [Display(Name = "DiscountAmount",
        Description = "The discount amount to apply to the booking"), MaxLength(256)]
        public int DiscountAmount { get; set; }

        [Display(Name = "RequiresCouponCode",
        Description = "If checked, a customer must supply a valid coupon code for the discount to be applied.")]
        public bool RequiresCouponCode { get; set; }

        [Display(Name = "StartDate",
        Description = "The start of the discount period in Coordinated Universal Time(UTC).")]
        public DateTime StartDate { get; set; }

        [Display(Name = "EndDate",
        Description = "The end of the discount period in Coordinated Universal Time(UTC).")]
        public DateTime EndDate { get; set; }

        [Display(Name = "CumulativeWithOtherDiscounts",
        Description = "Cumulative with other discounts")]
        public bool CumulativeWithOtherDiscounts { get; set; }

        [Display(Name = "DiscountLimitation",
        Description = "Choose the limitation of discount."), MaxLength(256)]
        public int DiscountLimitation { get; set; }

    }

    public class DiscountEdit
    {

        [Display(Name = "Name",
        Description = "The name of the discount"), DataType(DataType.Text), MaxLength(256)]
        public string Name { get; set; }

        [Display(Name = "DiscountType",
        Description = "The type of the discont"), MaxLength(256)]
        public int DiscountType { get; set; }

        [Display(Name = "UsePercentage",
        Description = "Determines whether to apply a percentage discount to the order/SKUs.If not enabled, a set value is discounted.")]
        public bool UsePercentage { get; set; }

        [Display(Name = "DiscountAmount",
        Description = "The discount amount to apply to the booking"), MaxLength(256)]
        public int DiscountAmount { get; set; }

        [Display(Name = "RequiresCouponCode",
        Description = "If checked, a customer must supply a valid coupon code for the discount to be applied.")]
        public bool RequiresCouponCode { get; set; }

        [Display(Name = "StartDate",
        Description = "The start of the discount period in Coordinated Universal Time(UTC).")]
        public DateTime StartDate { get; set; }

        [Display(Name = "EndDate",
        Description = "The end of the discount period in Coordinated Universal Time(UTC).")]
        public DateTime EndDate { get; set; }

        [Display(Name = "CumulativeWithOtherDiscounts",
        Description = "Cumulative with other discounts")]
        public bool CumulativeWithOtherDiscounts { get; set; }

        [Display(Name = "DiscountLimitation",
        Description = "Choose the limitation of discount."), MaxLength(256)]
        public int DiscountLimitation { get; set; }

    }

    
    //tab
    public class Requirement
    {
        [Display(Name = "DiscountRequirementType",
        Description = "You can choose one of the following requirement types, or add a requirement group to use several requirement types simultaneously."), MaxLength(256)]
        public int DiscountRequirementType { get; set; }
    }

    //tab table

    public class UsageHistory
    {

        public bool Used { get; set; }
        public string OrderNumber { get; set; }
        public double OrderTotal { get; set; }


    }

}
