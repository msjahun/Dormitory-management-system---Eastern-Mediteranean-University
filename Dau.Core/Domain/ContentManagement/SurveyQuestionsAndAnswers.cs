using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.ContentManagement
{
   public class SurveyQuestionsAndAnswers
    {
        public string Name { get; set; }
        public string NumberOfParticipants { get; set; }
        public string DisplayOrder { get; set; }

        //needs some work
        public Survey Survey{ get; set; }
    }
}
