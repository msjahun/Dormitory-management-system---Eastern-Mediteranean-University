using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.Notifications
{
    public class AnnoucementsVm
    {

        public DateTime   CreatedOn { get; set; }
        public int Priority { get; set; }
        public DateTime StartDate { get; set; }
        public int Active { get; set; }

    }
}
