using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.ContentManagement
{
    public class SurveyAdd
    {
        [Display(Name = "Language",
        Description = "Language the survey is in."), MaxLength(256)]
        public int Language { get; set; }

        [Display(Name = "Name",
        Description = "Name of the survey"), DataType(DataType.Text), MaxLength(256)]
        public string Name { get; set; }

        [Display(Name = "System Keyword",
        Description = "Name used by the system to identify this survey"), DataType(DataType.Text), MaxLength(256)]
        public string SystemKeyword { get; set; }

        [Display(Name = "Published",
        Description = "Determines whether this survey is published(visible) in the website.")]
        public bool Published { get; set; }

        [Display(Name = "Show On HomePage",
        Description = "Check to display this survey on your home page.Recommended for your most popular survey.")]
        public bool ShowOnHomePage { get; set; }

        [Display(Name = "Allow Guests To Vote",
        Description = "Check this to allow unregistered users (Guest) to participate in survey.")]
        public bool AllowGuestsToVote { get; set; }

        [Display(Name = "Display Order",
        Description = "The survey display order. 1 represents the first item in the list. "), MaxLength(256)]
        public int DisplayOrder { get; set; }

        [Display(Name = "Start Date",
        Description = "The date/time the survey will start running.")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date",
        Description = "The date/time the survey will end.")]
        public DateTime EndDate { get; set; }
    }

    public class SurveyEdit
    {
        [Display(Name = "Language",
        Description = "Language the survey is in."), MaxLength(256)]
        public int Language { get; set; }

        [Display(Name = "Name",
        Description = "Name of the survey"), DataType(DataType.Text), MaxLength(256)]
        public string Name { get; set; }

        [Display(Name = "System Keyword",
        Description = "Name used by the system to identify this survey"), DataType(DataType.Text), MaxLength(256)]
        public string SystemKeyword { get; set; }

        [Display(Name = "Published",
        Description = "Determines whether this survey is published(visible) in the website.")]
        public bool Published { get; set; }

        [Display(Name = "Show On HomePage",
        Description = "Check to display this survey on your home page.Recommended for your most popular survey.")]
        public bool ShowOnHomePage { get; set; }

        [Display(Name = "Allow Guests To Vote",
        Description = "Check this to allow unregistered users (Guest) to participate in survey.")]
        public bool AllowGuestsToVote { get; set; }

        [Display(Name = "Display Order",
        Description = "The survey display order. 1 represents the first item in the list. "), MaxLength(256)]
        public int DisplayOrder { get; set; }

        [Display(Name = "Start Date",
        Description = "The date/time the survey will start running.")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date",
        Description = "The date/time the survey will end.")]
        public DateTime EndDate { get; set; }
    }

    public class SurveyQuestionsAndAnswersTable
    {
        public string Name {get; set;}
        public string NumberOfParticipants {get; set;}
        public string DisplayOrder { get; set; }

    }

}
