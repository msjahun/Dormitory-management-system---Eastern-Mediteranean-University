using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.User
{
   public class OnlineUsers : BaseEntity
    {
       
        public string UserInfo { get; set; }
        public string IpAddress { get; set; }
        public string Location { get; set;  }
        public string LastActivity { get; set; }

        public string LastVisitedPage { get; set; }
        public DateTime LastActivityTime { get; set; }
    }
}
