using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.System
{
    public class MaintenanceVm
    {

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool OnlyWithoutWishList { get; set; }
        public DateTime CreatedBefore { get; set; }

    }
}
