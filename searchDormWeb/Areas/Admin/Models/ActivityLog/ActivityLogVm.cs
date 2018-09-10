using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.ActivityLog
{
    public class ActivityLogVm
    {
        [Display(Name = "Created from",
        Description = "The creation from the date of the search."),
        DataType(DataType.Date)]
        public DateTime CreatedFrom { get; set; }

        [Required]
        [Display(Name = "Created to",
        Description = "The creation date of the search."),
        DataType(DataType.Date),
        MaxLength(256)]
        public DateTime CreatedTo { get; set; }

        [Display(Name = "Ip address",
        Description = "The ip address of the search."),
        MaxLength(256)]
        public string IpAddress { get; set; }


        [Display(Name = "Activity log type",
        Description = "The activity log type."),
        MaxLength(256)]
        public int ActivityLogType { get; set; }


    }
}
