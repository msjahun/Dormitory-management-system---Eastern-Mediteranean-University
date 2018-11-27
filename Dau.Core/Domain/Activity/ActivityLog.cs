using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Activity
{
  public  class ActivityLog
    {
    
        public DateTime CreatedFrom { get; set; }

       
        public DateTime CreatedTo { get; set; }

       
        public string IpAddress { get; set; }


  
        public int ActivityLogType { get; set; }
        //ActivityLogType table


        public string UserGUid { get; set; }
        //link to userTable, to keep track of the user that made changes, or just a username that lets us know who changed what
        // just add a field for use id


        //we'll probably need to add things link
        //activity performed
        //activity category / activityType
        //date/time activity was performed and by
        //who the activity was performed by
    }
}
