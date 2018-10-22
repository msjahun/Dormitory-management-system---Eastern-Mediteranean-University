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


    public class MessageQueueEdit
    {
        [Display(Name = "MessagePriority",
        Description = "Message priority."), DataType(DataType.Text), MaxLength(256)]
        public string MessagePriority { get; set; }

        [Display(Name = "From",
        Description = "From address."), DataType(DataType.Text), MaxLength(256)]
        public string From { get; set; }

        [Display(Name = "FromName",
        Description = "From name."), DataType(DataType.Text), MaxLength(256)]
        public string FromName { get; set; }

        [Display(Name = "To",
        Description = "To address."), DataType(DataType.Text), MaxLength(256)]
        public string To { get; set; }

        [Display(Name = "ToName",
        Description = "To name."), DataType(DataType.Text), MaxLength(256)]
        public string ToName { get; set; }

        [Display(Name = "ReplyTo",
        Description = "Reply to address"), DataType(DataType.Text), MaxLength(256)]
        public string ReplyTo { get; set; }

        [Display(Name = "ReplyToName",
        Description = "Reply to name."), DataType(DataType.Text), MaxLength(256)]
        public string ReplyToName { get; set; }

        [Display(Name = "CC",
        Description = "Cc address"), DataType(DataType.Text), MaxLength(256)]
        public string CC { get; set; }

        [Display(Name = "BCC",
        Description = "BCC address"), DataType(DataType.Text), MaxLength(256)]
        public string BCC { get; set; }

        [Display(Name = "Subject",
        Description = "Message subject"), DataType(DataType.Text), MaxLength(256)]
        public string Subject { get; set; }

        [Display(Name = "Body",
        Description = "Message body"), DataType(DataType.Text), MaxLength(256)]
        public string Body { get; set; }

        [Display(Name = "CreatedOn",
        Description = "Date/Time message added to queue"), DataType(DataType.Text), MaxLength(256)]
        public string CreatedOn { get; set; }

        [Display(Name = "SendImmediately",
        Description = "Send message immediately")]
        public bool SendImmediately { get; set; }

        [Display(Name = "SendAttempts",
        Description = "The number of times to attempt to send this message."), MaxLength(256)]
        public int SendAttempts { get; set; }

        [Display(Name = "SentOn",
        Description = "The date/time message was sent."), DataType(DataType.Text), MaxLength(256)]
        public string SentOn { get; set; }

        [Display(Name = "EmailAccount",
        Description = "The email account that will be used to send email."), DataType(DataType.Text), MaxLength(256)]
        public string EmailAccount { get; set; }

    }
}
