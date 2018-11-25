using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.ContentManagement
{
    class Poll
    {
       public int Language { get; set; }

       public string Name { get; set; }

        public string SystemKeyword { get; set; }

       public bool Published { get; set; }

        public bool ShowOnHomePage { get; set; }

       public bool AllowGuestsToVote { get; set; }

        public int DisplayOrder { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

     
    }
}
