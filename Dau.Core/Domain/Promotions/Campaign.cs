using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Promotions
{
  public  class Campaign
    {
        public int Id { get; set; }
        public string AllowedTokens { get; set; }

        public string Name { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public DateTime PlannedDateOfSending { get; set; }

        public int LimitedToCustomerRole { get; set; }



        public int EmailAccount { get; set; }

        public string SendTestEmailTo { get; set; }


    }
}
