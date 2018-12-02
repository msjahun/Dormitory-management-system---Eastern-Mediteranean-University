using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.ContentManagement
{
   public class SurveyQuestionsAndAnswers : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfParticipants { get; set; }
        public int DisplayOrder { get; set; }

        //needs some work
        public Survey Survey{ get; set; }
    }
}
