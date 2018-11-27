using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.ContentManagement
{
    class MessageTemplateTranslation
    {

      public string Subject { get; set; }

       public string Body { get; set; }

       public string BCC { get; set; }


        public int EmailAccount { get; set; }


        public MessageTemplate MessageTemplateNonTrans{ get; set; }
    }
}
