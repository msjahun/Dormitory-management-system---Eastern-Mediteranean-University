using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.MobileAppManager
{
    public class PushNotificationAdd
    {
        [Display(Name = "AllowedTokens",
 Description = "Allowed Tokens you can use to be replaced with custoper/user data"), DataType(DataType.Text), MaxLength(256)]
        public string AllowedTokens { get; set; }

        [Display(Name = "Name",
        Description = "The name of the push notification being sent"), DataType(DataType.Text), MaxLength(256)]
        public string Name { get; set; }

        [Display(Name = "Subject",
        Description = "Subject of the push notification being sent"), DataType(DataType.Text), MaxLength(256)]
        public string Subject { get; set; }

        [Display(Name = "Body",
        Description = "The body of the notification message"), DataType(DataType.Text), MaxLength(256)]
        public string Body { get; set; }

        [Display(Name = "PlannedDateOfSending",
        Description = "Planned date of sending the notifcation")]
        public DateTime PlannedDateOfSending { get; set; }

        [Display(Name = "LimitedToCustomerRole",
        Description = "Limit notification to only selected customer roles"), MaxLength(256)]
        public int LimitedToCustomerRole { get; set; }

    }

    public class PushNotificationEdit
    {
        [Display(Name = "AllowedTokens",
Description = "Allowed Tokens you can use to be replaced with custoper/user data"), DataType(DataType.Text), MaxLength(256)]
        public string AllowedTokens { get; set; }

        [Display(Name = "NotificationAccount",
        Description = "Notification account used for sending notification"), MaxLength(256)]
        public int NotificationAccount { get; set; }

        [Display(Name = "SendTestNotificationTo",
        Description = "notification address of a device/user"), DataType(DataType.Text), MaxLength(256)]
        public string SendTestNotificationTo { get; set; }


        [Display(Name = "Name",
        Description = "The name of the push notification being sent"), DataType(DataType.Text), MaxLength(256)]
        public string Name { get; set; }

        [Display(Name = "Subject",
        Description = "Subject of the push notification being sent"), DataType(DataType.Text), MaxLength(256)]
        public string Subject { get; set; }

        [Display(Name = "Body",
        Description = "The body of the notification message"), DataType(DataType.Text), MaxLength(256)]
        public string Body { get; set; }

        [Display(Name = "PlannedDateOfSending",
        Description = "Planned date of sending the notifcation")]
        public DateTime PlannedDateOfSending { get; set; }

        [Display(Name = "LimitedToCustomerRole",
        Description = "Limit notification to only selected customer roles"), MaxLength(256)]
        public int LimitedToCustomerRole { get; set; }

    }
}
