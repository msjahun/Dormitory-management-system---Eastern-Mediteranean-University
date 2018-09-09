using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.User
{
    public class UsersReportVm
    {
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        public int[] BookingStatus { get; set; }
        public int[] PaymentStatus { get; set; }


    }
}
