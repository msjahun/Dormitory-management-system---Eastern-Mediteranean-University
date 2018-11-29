using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.EmailAccountInformation
{
   public class EmailAccount
    {
        public int Id { get; set; }

        public string EmailAddress { get; set; }

        public string EmailDisplayName { get; set; }


        public string Host { get; set; }


        public int Port { get; set; }


        public string UserName { get; set; }


        public string Password { get; set; }


        public bool SSL { get; set; }


        public bool UseDefaultCredentials { get; set; }




        //public string SendEmailTo { get; set; }
       //we only needs this in the sevice I think
    }
}
