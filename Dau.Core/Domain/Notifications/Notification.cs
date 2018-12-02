using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Notifications
{
   public class Notification : BaseEntity
    {//need to determined  what notifiction to save
        
        public DateTime CreatedOn { get; set; }
        //the notifications that administrators and users use
    }
}
