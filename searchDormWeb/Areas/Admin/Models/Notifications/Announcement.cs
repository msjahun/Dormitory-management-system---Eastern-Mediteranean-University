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
    public class AnnouncementAdd
    {
        [Display(Name = "Title",
        Description = "Title of the announcement."), DataType(DataType.Text), MaxLength(256)]
        public string Title { get; set; }

        [Display(Name = "Message",
        Description = "Message of the announcement."), DataType(DataType.Text), MaxLength(256)]
        public string Message { get; set; }

        [Display(Name = "StartDate",
        Description = "The start date/time the announcement will be displayed.")]
        public DateTime StartDate { get; set; }

        [Display(Name = "EndDate",
        Description = "The end date/time the announcement will be displayed.")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Priority",
        Description = "The priority of the announcement."), MaxLength(256)]
        public int Priority { get; set; }

        [Display(Name = "Published",
        Description = "Check published to display annoucement to the dashboard.")]
        public bool Published { get; set; }

    }

    public class AnnouncementEdit
    {
        [Display(Name = "Title",
        Description = "Title of the announcement."), DataType(DataType.Text), MaxLength(256)]
        public string Title { get; set; }

        [Display(Name = "Message",
        Description = "Message of the announcement."), DataType(DataType.Text), MaxLength(256)]
        public string Message { get; set; }

        [Display(Name = "StartDate",
        Description = "The start date/time the announcement will be displayed.")]
        public DateTime StartDate { get; set; }

        [Display(Name = "EndDate",
        Description = "The end date/time the announcement will be displayed.")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Priority",
        Description = "The priority of the announcement."), MaxLength(256)]
        public int Priority { get; set; }

        [Display(Name = "Published",
        Description = "Check published to display annoucement to the dashboard.")]
        public bool Published { get; set; }

    }

}
