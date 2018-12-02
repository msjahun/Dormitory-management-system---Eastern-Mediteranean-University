using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.MobileAppManager
{
    public class PushNotification : BaseEntity
    {
        
        public string AllowedTokens { get; set; }

        public string Name { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public DateTime PlannedDateOfSending { get; set; }

        public int LimitedToCustomerRole { get; set; }




        public int NotificationAccount { get; set; } //the account that sends the message, it may be an admin user or automatically, the person
        //who sends the notification should be tracked

  //      public string SendTestNotificationTo { get; set; }
  //we should leave this in the service or and also have a seperate table for tracking notificationAccounts

        //maybe we should track the user who sent the notification, if it's not automatic



    }
}
