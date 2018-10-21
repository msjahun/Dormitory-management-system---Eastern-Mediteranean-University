using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.Reservation
{
    public class CancelReservationRequestEdit
    {
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
