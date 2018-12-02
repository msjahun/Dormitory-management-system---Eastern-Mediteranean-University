using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.System
{
    public class MessageQueue : BaseEntity


    {
       
      //  public DateTime StartDate { get; set; }

       // public DateTime EndDate { get; set; }

        public string FromAddress { get; set; }

        public string ToAddress { get; set; }

        public bool LoadNotSentEmailsOnly { get; set; }


        public int MaximumSentAttempts { get; set; }

       // public int GoDirectlyToEmail { get; set; } //why is this here though, don't remember why we need this


        public int MessagePriority { get; set; }


        public string FromName { get; set; }

        public string ToName { get; set; }

        public string ReplyTo { get; set; }

        public string ReplyToName { get; set; }

        public string CC { get; set; }

        public string BCC { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }
        public DateTime CreatedOn { get; set; }

        public bool SendImmediately { get; set; }

        public int SendAttempts { get; set; }

        public DateTime SentOn { get; set; }

        public int EmailAccount { get; set; }
        //id of the emailAccount that sends the email
    }
}
