using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.ContentManagement
{
    public class MessageTemplate :BaseEntity
    {
        public MessageTemplate()
        {
            MessageTemplateTranslations = new HashSet<MessageTemplateTranslation>();
        }

        public int Id { get; set; }
        public string AllowedTokens { get; set; }
        //I'll create allowedTokens service but I don't know how it will turn up, I'll leave this here for now

        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool SendImmediately { get; set; }
        public bool AttachedStaticFile { get; set; }
        public string StaticFileUrl { get; set; }

       // public IEnumerable<int> LimitedToDormitories { get; set; }
       //ICollectionized this



  // public LocalizedMessageTemplateContent[] localizedMessageTemplateContents { get; set; }
        //MessageTemplateTranslation

        public ICollection<MessageTemplateTranslation> MessageTemplateTranslations{ get; set; }
        
    }
}
