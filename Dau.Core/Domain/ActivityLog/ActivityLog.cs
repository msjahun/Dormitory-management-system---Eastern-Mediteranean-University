using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.ActivityLog
{
    class ActivityLog
    {
    
        public DateTime CreatedFrom { get; set; }

       
        public DateTime CreatedTo { get; set; }

       
        public string IpAddress { get; set; }


  
        public int ActivityLogType { get; set; }
    }
}
