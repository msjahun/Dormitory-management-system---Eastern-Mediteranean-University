using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.Reservation
{
    public class BestSellerRoomsVm
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IEnumerable<int> BookingStatus { get; set; }
        public IEnumerable<int> PaymentStatus { get; set; }
        public int DormitoryBlock { get; set; }
        public int BillingCountry { get; set; }
        public int Dormitory { get; set; }


    }
}
