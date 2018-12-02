using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.ContentManagement
{
    public class PollAnswers : BaseEntity
    {
  
        public string Name { get; set; }
        public int NumberOfVotes { get; set; }
        public int DisplayOrder { get; set; }

        //needs some work
        public Poll Poll { get; set; }
    }
}
