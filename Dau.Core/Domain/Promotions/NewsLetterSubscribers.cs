using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Promotions
{
   public class NewsLetterSubscribers : BaseEntity
    {
       // public DateTime StartDate { get; set; }

       // public  EndDate { get; set; }

          
       public string Email { get; set; }

        public bool Active { get; set; }

        public int CustomerRoles { get; set; }
        //what's with this customerRoles, is there a need

        public DateTime SubscribedDate { get; set; }
    }
}
