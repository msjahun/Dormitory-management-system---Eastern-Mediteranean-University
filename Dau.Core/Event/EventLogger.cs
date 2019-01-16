using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Event
{
    public class EventLogger:BaseEntity
    {
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public string EventParameters { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
