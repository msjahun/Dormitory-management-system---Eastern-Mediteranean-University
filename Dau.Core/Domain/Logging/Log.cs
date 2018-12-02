using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Logging
{
   public class Log : BaseEntity
    {
       
        public int EventId { get; set; }
      
        public string LogLevel { get; set; }
        public string Message { get; set; }
        public string Ipaddress { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
