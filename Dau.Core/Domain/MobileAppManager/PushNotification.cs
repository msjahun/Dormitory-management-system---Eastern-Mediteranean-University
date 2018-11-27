using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.MobileAppManager
{
    class PushNotification
    {
        public string AllowedTokens { get; set; }

        public string Name { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public DateTime PlannedDateOfSending { get; set; }

        public int LimitedToCustomerRole { get; set; }




        public int NotificationAccount { get; set; }

        public string SendTestNotificationTo { get; set; }

        //maybe we should track the user who sent the notification, if it's not automatic



    }
}
