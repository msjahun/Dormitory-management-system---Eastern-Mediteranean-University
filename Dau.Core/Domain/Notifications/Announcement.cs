using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Notifications
{
   public class Announcement : BaseEntity
    {
       
        public DateTime CreatedOn { get; set; }

        public int Priority { get; set; }

        public DateTime StartDate { get; set; }

        public int Active { get; set; }


        public string Title { get; set; }

        public string Message { get; set; }



        public DateTime EndDate { get; set; }



        public bool Published { get; set; }


    }
}
