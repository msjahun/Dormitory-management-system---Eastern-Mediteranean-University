using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.ContentManagement
{
    public class PollAnswers
    {
        public string Name { get; set; }
        public string NumberOfVotes { get; set; }
        public string DisplayOrder { get; set; }

        //needs some work
        public Poll Poll { get; set; }
    }
}
