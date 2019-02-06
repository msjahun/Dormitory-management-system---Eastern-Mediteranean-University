using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dau.Services.Domain.BookingService
{
    public class BestSellerRoomsTable
    {
        public long RoomId { get; set; }
        public string RoomName { get; set; }
        public string DormitoryName { get; set; }
        public string DormitoryBlock { get; set; }
        public double TotalQuantity { get; set; }
        public string TotalAmount { get; set; }
        //public string View { get; set; }
    }
    public class RoomsNeverBookedTable
    {
        public long RoomId { get; set; }
        public string RoomName { get; set; }
        public string DormitoryBlock { get; set; }
        public string DormitoryName { get; set; }
        //public string View { get; set; }
    }

    public class CurrentBookingWishListTable
    {
        public string UserId { get; set; }
        public string User { get; set; }
        public long DormitoryId { get; set; }
        public long RoomId { get; set; }
        public string DormitoryBlock { get; set; }
        public string DormitoryName { get; set; }
        public string RoomName { get; set; }
        public string Semester { get; set; }
        public string CartTotalAmount { get; set; }
        public string CartSubTotal { get; set; }
        public string DateCreated { get; set; }
    }
    public class BookingAccountVM
    {
        public string BookingId { get; set; }
        public long PaymentStatusId { get; set; }
        public string Paymentstatus { get; set; }
        public long BookingStatusId { get; set; }
        public string BookingStatus { get; set; }
        public string BookingDate { get; set; }
        public string DormitoryName { get; set; }
        public string RoomName { get; set; }
        public string Price { get; set; }
        public string ReceiptImageUrl { get; set; }
    }
    public class ReservationEdit
    {
        //student information
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string StudentPhoneNumber { get; set; }
        public string StudentAddress1 { get; set; }
        public string StudentAddress2 { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string ZipCode { get; set; }


        public string ReceiptUrl { get; set; }
        [Display(Name = "Booking Status",
        Description = "The status of the booking"), DataType(DataType.Text), MaxLength(256)]
        public string BookingStatus { get; set; }

        [Display(Name = "Booking Order Number",
        Description = "The unique number of this booking order."), DataType(DataType.Text), MaxLength(256)]
        public string BookingOrderNumber { get; set; }

        [Display(Name = "Dormitory",
        Description = "A dormitory name in which this booking order was placed."), DataType(DataType.Text), MaxLength(256)]
        public string Dormitory { get; set; }

        public long RoomId { get; set; }

        [Display(Name = "Student",
        Description = "The customer who placed this booking order."), DataType(DataType.Text), MaxLength(256)]
        public string Student { get; set; }

        [Display(Name = "Student Ip Address",
        Description = "Student IP address"), DataType(DataType.Text), MaxLength(256)]
        public string StudentIpAddress { get; set; }

        [Display(Name = "Booking Order Subtotal",
        Description = "The subtotal of this booking order."), DataType(DataType.Text), MaxLength(256)]
        public string BookingOrderSubtotal { get; set; }

        [Display(Name = "Booking Fee",
        Description = "The total shipping cost for this booking order."), DataType(DataType.Text), MaxLength(256)]
        public string BookingFee { get; set; }

        [Display(Name = "Booking Total",
        Description = "The total cost of this booking order(includes discounts, booking fee & tax)."), DataType(DataType.Text), MaxLength(256)]
        public string BookingTotal { get; set; }

        [Display(Name = "Profit",
        Description = "Profit of this order."), DataType(DataType.Text), MaxLength(256)]
        public string Profit { get; set; }

        [Display(Name = "Payment receipt",
        Description = "The payment receipt used for this transaction."), DataType(DataType.Text), MaxLength(256)]
        public string PaymentMethod { get; set; }


        [Display(Name = "Payment Status",
        Description = "The status of the payment."), DataType(DataType.Text), MaxLength(256)]
        public string PaymentStatus { get; set; }

        [Display(Name = "Created On",
        Description = "The date/time the booking order was placed/created."), DataType(DataType.Text), MaxLength(256)]
        public string CreatedOn { get; set; }


        [Display(Name = "Student information",
    Description = "The Student information"), DataType(DataType.Text), MaxLength(256)]
        public string StudentInformation { get; set; }


        public OrderNotesTab orderNotesTab { get; set; }
    }

    public class BillingAddressTable
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string ZipPostalCode { get; set; }
        public string Country { get; set; }

    }

    public class RoomResevationTable
    {
        public string Picture { get; set; }
        public string RoomName { get; set; }
        public string Price { get; set; }
        public string Quantity { get; set; }
        public string Discount { get; set; }
        public string Total { get; set; }
        public string Edit { get; set; }

    }

    public class OrderNotesTable
    {
        public string CreatedOn { get; set; }
        public string Note { get; set; }
        public string AttachedFile { get; set; }
        public string DisplayToStudent { get; set; }
        public string Delete { get; set; }

    }


    public class OrderNotesTab
    {
        [Display(Name = "Note",
        Description = "A note about booking."), DataType(DataType.Text), MaxLength(256)]
        public string Note { get; set; }

        [Display(Name = "Attached file",
      Description = "Attached file to this to the order note, e.g booking receipt an so on.")]
        public bool AttachedFile { get; set; }


        [Display(Name = "Display to customer",
      Description = "Check this option to display this booking note to customer")]
        public bool DisplayToStudent { get; set; }

    }

    public class LatestBookingsTable
    {
        public long DormitoryId { get; set; }
        public string OrderNo { get; set; }
        public long BookingStatusId { get; set; }
        public string OrderStatus { get; set; }
        public string Customer { get; set; }
        public string CreatedOn { get; set; }
        //public button View { get; set; }


    }

    public class BookingCartViewModel
    {
        public long RoomId { get; set; }

        public List<SelectListItem> SemestersList { get; set; }
        public string DormitoryName { get; set; }
        public string DormitoryLogoUrl { get; set; }
        public string RoomName { get; set; }
        public string RoomBlock { get; set; }
        public string RoomSize { get; set; }
        public string AmountTotal { get; set; }
        public string StayDuration { get; set; }
        public string RoomPricePerSemester { get; set; }
        public bool IsPricePerYear { get; set; }
        public long CartId { get; set; }
        public string SubtotalAmount { get; set; }
        public string BookingFee { get; set; }
        public string TaxAmount { get; set; }
        public long SemesterPeriodId { get; set; }
        public double PriceRaw { get; set; }
        public double TaxAmountRaw { get; internal set; }
        public double BookingFeeRaw { get; internal set; }
        public int CancelWaitDays { get; internal set; }
    }

    public class SemPeriod
    {
        public bool IsSelected { get; set; }
        public string Value { get; set; }
        public string Text { get; set; }
    }
    public class BookingCheckoutCustomerInfoViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StudentNumber { get; set; }
        public string ParmanentAddress { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string DateBookingExpiresWithoutConfirmation { get; set; }
        public int NumberOfWorkingDaysBeforeBookingExpires { get; set; }
        public BookingCartViewModel BookingDetails { get; set; }
        //summary

    }



    public class ReservationListTable
    {
        public long DormitoryId { get; set; }
        public long PaymentStatusId { get; set; }
        public long BookingStatusId
        { get; set; }
        public string BookingNo { get; set; }
        public string BookingStatus { get; set; }
        public string PaymentStatus { get; set; }
        public string cancellationDate { get; set; }
        public double cancellationDays { get; set; }
        public string User { get; set; }
        public string CreatedOn { get; set; }
        public string BookingTotal { get; set; }
        public string View { get; set; }
    }
}
