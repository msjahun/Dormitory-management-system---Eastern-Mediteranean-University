using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.Configuration
{
    public class EmailAccountAdd
    {
        [Display(Name = "EmailAddress",
        Description = "This is the from address for all outgoing emails from your store e.g. 'sales@yourstore.com'."), DataType(DataType.Text), MaxLength(256)]
        public string EmailAddress { get; set; }


        [Display(Name = "EmailDisplayName",
        Description = "This is the friendly display name for outgoing emails from your store e.g. 'Your Store Sales Department'."), DataType(DataType.Text), MaxLength(256)]
        public string EmailDisplayName { get; set; }


        [Display(Name = "Host",
        Description = "This is the host name or IP address of your mail server.You can normally find this out from your ISP or web host."), DataType(DataType.Text), MaxLength(256)]
        public string Host { get; set; }


        [Display(Name = "Port",
        Description = "This is the SMTP port of your mail server.This is usually port 25."), MaxLength(256)]
        public int Port { get; set; }


        [Display(Name = "User",
        Description = "This is the username you use to authenticate to your mail server."), DataType(DataType.Text), MaxLength(256)]
        public string User { get; set; }


        [Display(Name = "Password",
        Description = "This is the password you use to authenticate to your mail server."), DataType(DataType.Text), MaxLength(256)]
        public string Password { get; set; }


        [Display(Name = "SSL",
        Description = "Check to use Secure Sockets Layer(SSL) to encrypt the SMTP connection.")]
        public bool SSL { get; set; }


        [Display(Name = "UseDefaultCredentials",
        Description = "Check to use default credentials for the connection.")]
        public bool UseDefaultCredentials { get; set; }

    }

    public class EmailAccountEdit
    {
        [Display(Name = "EmailAddress",
        Description = "This is the from address for all outgoing emails from your store e.g. 'sales@yourstore.com'."), DataType(DataType.Text), MaxLength(256)]
        public string EmailAddress { get; set; }


        [Display(Name = "EmailDisplayName",
        Description = "This is the friendly display name for outgoing emails from your store e.g. 'Your Store Sales Department'."), DataType(DataType.Text), MaxLength(256)]
        public string EmailDisplayName { get; set; }

        [Display(Name = "Host",
        Description = "This is the host name or IP address of your mail server.You can normally find this out from your ISP or web host."), DataType(DataType.Text), MaxLength(256)]
        public string Host { get; set; }

        [Display(Name = "Port",
        Description = "This is the SMTP port of your mail server.This is usually port 25."), MaxLength(256)]
        public int Port { get; set; }

        [Display(Name = "User",
        Description = "This is the username you use to authenticate to your mail server."), DataType(DataType.Text), MaxLength(256)]
        public string User { get; set; }

        [Display(Name = "Password",
        Description = "This is the password you use to authenticate to your mail server."), DataType(DataType.Text), MaxLength(256)]
        public string Password { get; set; }

        [Display(Name = "SSL",
        Description = "Check to use Secure Sockets Layer(SSL) to encrypt the SMTP connection.")]
        public bool SSL { get; set; }

        [Display(Name = "UserDEfaultCredentials",
        Description = "Check to use default credentials for the connection.")]
        public bool UseDefaultCredentials { get; set; }

        [Display(Name = "SendEmailTo",
        Description = "Send test email to ensure that everything is properly configured."), DataType(DataType.Text), MaxLength(256)]
        public string SendEmailTo { get; set; }

    }
}
