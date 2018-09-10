using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.Notifications
{
    public class AnnoucementsVm
    {
        [Display(Name = "Created on",
        Description = "Filters announcements created on selected date"),
        DataType(DataType.Date),
        MaxLength(256)]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Priority",
        Description = "Priority of announcement e.g. Urgent"),
        MaxLength(256)]
        public int Priority { get; set; }

        [Display(Name = "Start date",
        Description = "The start date of the search."),
        DataType(DataType.Date),
        MaxLength(256)]
        public DateTime StartDate { get; set; }

        [Display(Name = "Active",
        Description = "Search by a specific status e.g. Active."),
        MaxLength(256)]
        public int Active { get; set; }

    }
}
