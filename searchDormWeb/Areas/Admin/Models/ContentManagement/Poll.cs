using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.ContentManagement
{
    public class PollAdd
    {
        [Display(Name = "Language",
        Description = "Language the poll is in."), MaxLength(256)]
        public int Language { get; set; }

        [Display(Name = "Name",
        Description = "Name of the poll"), DataType(DataType.Text), MaxLength(256)]
        public string Name { get; set; }

        [Display(Name = "System keyword",
        Description = "Name used by the system to identify this poll"), DataType(DataType.Text), MaxLength(256)]
        public string Systemkeyword { get; set; }

        [Display(Name = "Published",
        Description = "Determines whether this topic is published(visible) in the website.")]
        public bool Published { get; set; }

        [Display(Name = "Show On HomePage",
        Description = "Check to display this poll on your home page.Recommended for your most popular poll.")]
        public bool ShowOnHomePage { get; set; }

        [Display(Name = "Allow Guests To Vote",
        Description = "Check this to allow unregistered users (Guest) to vote on this poll.")]
        public bool AllowGuestsToVote { get; set; }

        [Display(Name = "Display Order",
        Description = "The poll display order. 1 represents the first item in the list. "), MaxLength(256)]
        public int DisplayOrder { get; set; }

        [Display(Name = "Start Date",
        Description = "The date/time the poll will start running.")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date",
        Description = "The date/time the poll will end.")]
        public DateTime EndDate { get; set; }
    }

    public class PollEdit
    {
        [Display(Name = "Language",
        Description = "Language the poll is in."), MaxLength(256)]
        public int Language { get; set; }

        [Display(Name = "Name",
        Description = "Name of the poll"), DataType(DataType.Text), MaxLength(256)]
        public string Name { get; set; }

        [Display(Name = "System Keyword",
        Description = "Name used by the system to identify this poll"), DataType(DataType.Text), MaxLength(256)]
        public string SystemKeyword { get; set; }

        [Display(Name = "Published",
        Description = "Determines whether this poll is published(visible) in the website.")]
        public bool Published { get; set; }

        [Display(Name = "Show On HomePge",
        Description = "Check to display this poll on your home page.Recommended for your most popular poll.")]
        public bool ShowOnHomePage { get; set; }

        [Display(Name = "Allow Guests To Vote",
        Description = "Check this to allow unregistered users (Guest) to vote on this poll.")]
        public bool AllowGuestsToVote { get; set; }

        [Display(Name = "Display Order",
        Description = "The poll display order. 1 represents the first item in the list. "), MaxLength(256)]
        public int DisplayOrder { get; set; }

        [Display(Name = "Start Date",
        Description = "The date/time the poll will start running.")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date",
        Description = "The date/time the poll will end.")]
        public DateTime EndDate { get; set; }
    }

    public class PollAnswersTable
    {
        public string Name { get; set; }
        public string NumberOfVotes {get; set;}
        public string DisplayOrder {get; set;}

    }

}
