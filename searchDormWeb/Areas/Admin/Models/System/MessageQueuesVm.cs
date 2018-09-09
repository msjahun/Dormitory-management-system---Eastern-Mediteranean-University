using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.System
{
    public class MessageQueuesVm
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public bool LoadNotSentEmailsOnly { get; set; }
        public int MaximumSentAttempts { get; set; }
        public int GoDirectlyToEmail { get; set; }



    }
}
