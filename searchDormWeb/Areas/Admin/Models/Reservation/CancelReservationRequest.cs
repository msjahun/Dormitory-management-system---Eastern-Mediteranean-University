using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.Reservation
{
    public class CancelReservationRequestEdit
    {
        [Display(Name = "Id",
        Description = "Cancel Booking request Id"), DataType(DataType.Text), MaxLength(256)]
        public string Id { get; set; }

        [Display(Name = "Booking Number",
        Description = "The unique number of this booking order."), DataType(DataType.Text), MaxLength(256)]
        public string BookingNumber { get; set; }

        [Display(Name = "Customer",
        Description = "The customer who placed this booking order."), DataType(DataType.Text), MaxLength(256)]
        public string Customer { get; set; }

        [Display(Name = "Room",
        Description = "The room name that reservation was cancelled for."), DataType(DataType.Text), MaxLength(256)]
        public string Room { get; set; }

        [Display(Name = "Return Request Status",
        Description = "The status of the return request"), MaxLength(256)]
        public int ReturnRequestStatus { get; set; }

        [Display(Name = "Reason For Cancellation",
        Description = "The reason for reservation request cancellation provided by the customer."), DataType(DataType.Text), MaxLength(256)]
        public string ReasonForCancellation { get; set; }

        [Display(Name = "Requested Action",
        Description = "What action the customer requests from the administrator"), DataType(DataType.Text), MaxLength(256)]
        public string RequestedAction { get; set; }

        [Display(Name = "Customer Comment",
        Description = "The comment by the customer"), DataType(DataType.Text), MaxLength(256)]
        public string CustomerComment { get; set; }

        [Display(Name = "Staff Notes",
        Description = "Comment made by Staff/Administrator"), DataType(DataType.Text), MaxLength(256)]
        public string StaffNotes { get; set; }

        [Display(Name = "Date",
        Description = "Date the reservation cancellation request was created"), DataType(DataType.Text), MaxLength(256)]
        public string Date { get; set; }

    }

    public class CancelReservationsRequestsVm
    {
        [Display(Name = "ID",
        Description = "Search by a specific cancel request identifier."),
        MaxLength(256)]
        public int ID { get; set; }

        [Display(Name = "Booking id",
        Description = "Search by a specific booking number."),
        MaxLength(256)]
        public int BookingId { get; set; }


        [Display(Name = "Start date",
        Description = "The start date of the search."),
        DataType(DataType.Date),
        MaxLength(256)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End date",
        Description = "The end date of the search."),
        DataType(DataType.Date),
        MaxLength(256)]
        public DateTime EndDate { get; set; }


        [Display(Name = "Cancellation status",
        Description = "Serach by a specific cancel request status e.g. Processing."),
        MaxLength(256)]
        public int CancellationStatus { get; set; }

    }

}
