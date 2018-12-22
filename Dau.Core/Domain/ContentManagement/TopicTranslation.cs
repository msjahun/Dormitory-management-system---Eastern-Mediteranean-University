//using Dau.Core.Domain.Language;
using Dau.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.ContentManagement
{
   public class TopicTranslation : BaseLanguage


    {
      
        public long TopicNonTransId { get; set; }
        public string Title { get; set; }

        public string Body { get; set; }


        public Topic TopicNonTrans{ get; set; }
    }
}
