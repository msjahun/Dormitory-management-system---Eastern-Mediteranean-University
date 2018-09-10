using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.System
{
    public class MessageQueuesVm
    {

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


        [EmailAddress,
            Display(Name = "From address",
        Description = "From email address."),
        DataType(DataType.EmailAddress),
        MaxLength(256)]
        public string FromAddress { get; set; }

        [EmailAddress,
            Display(Name = "To address",
        Description = "To email address."),
        DataType(DataType.EmailAddress),
        MaxLength(256)]
        public string ToAddress { get; set; }

        [Display(Name = "Load not sent emails only",
        Description = "Only lodad emails into queue that have not been sent yet.")]
        public bool LoadNotSentEmailsOnly { get; set; }


        [Display(Name = "Maximum sent attempts",
        Description = "The maximum number of attempts to send a message."),
        MaxLength(256)]
        public int MaximumSentAttempts { get; set; }

        [Display(Name = "Go directly to email",
        Description = "Go directly to email #."),
        MaxLength(256)]
        public int GoDirectlyToEmail { get; set; }



    }
}
