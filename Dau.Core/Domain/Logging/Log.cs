using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Logging
{
    class Log
    {
        public DateTime CreatedFrom { get; set; }


       public DateTime CreatedTo { get; set; }

       public string Message { get; set; }

        public int LogLevel { get; set; }

       




        public string ShortMessage { get; set; }



        public string FullMessage { get; set; }



       public string IpAddress { get; set; }



       public string Customer { get; set; }


 public string PageUrl { get; set; }


      public string ReferrerUrl { get; set; }


        public string CreatedOn { get; set; }
    }
}
