using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.ContentManagement
{
    class MessageTemplate
    {
        public MessageTemplate()
        {
            MessageTemplateTranslations = new HashSet<MessageTemplateTranslation>();
        }


        // public LocalizedMessageTemplateContent[] localizedMessageTemplateContents { get; set; }
        //MessageTemplateTranslation


        public string AllowedTokens { get; set; }

      public string Name { get; set; }


       public bool isActive { get; set; }

      public bool SendImmediately { get; set; }

       public bool AttachedStaticFile { get; set; }

        public IEnumerable<int> LimitedToDormitories { get; set; }

        public ICollection<MessageTemplateTranslation> MessageTemplateTranslations{ get; set; }
        
    }
}
