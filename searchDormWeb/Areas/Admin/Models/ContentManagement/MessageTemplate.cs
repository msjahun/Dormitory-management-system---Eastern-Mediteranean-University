using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.ContentManagement
{
    public class MessageTemplateEdit
    {


        public LocalizedMessageTemplateContent[] localizedMessageTemplateContents { get; set; }

        [Display(Name = "AllowedTokens",
      Description = "Allowed Tokens you can use to be replaced with custoper/user data"), DataType(DataType.Text), MaxLength(256)]
        public string AllowedTokens { get; set; }

        [Display(Name = "Name",
      Description = "The name of the message template"), DataType(DataType.Text), MaxLength(256)]
        public string Name { get; set; }


        [Display(Name = "isActive",
        Description = "Indicating whether the message template is active.")]
        public bool isActive { get; set; }

        [Display(Name = "SendImmediately",
        Description = "Send message immediately.")]
        public bool SendImmediately { get; set; }

        [Display(Name = "AttachedStaticFile",
        Description = "Upload a static file you want to attach to each sent email.")]
        public bool AttachedStaticFile { get; set; }

        [Display(Name = "LimitedToStores",
        Description = "Option to limit this template to a certain dormitory.If you have multiple dormitories, choose one or several from the list.If you don't use this option just leave this field empty.")]
        public IEnumerable<int> LimitedToDormitories { get; set; }

    }


public class LocalizedMessageTemplateContent
    {
        [Display(Name = "Subject",
       Description = "The subject of the message(email). TIP - You can include tokens in your subject."), DataType(DataType.Text), MaxLength(256)]
        public string Subject { get; set; }

        [Display(Name = "Body",
        Description = "The body of your message."), DataType(DataType.Text), MaxLength(256)]
        public string Body { get; set; }

        [Display(Name = "BCC",
        Description = "The blind carbon copy(BCC) recipients for this e-mail message."), DataType(DataType.Text), MaxLength(256)]
        public string BCC { get; set; }


        [Display(Name = "EmailAccount",
        Description = "The email account that will be used to send this message template."), MaxLength(256)]
        public int EmailAccount { get; set; }
    }

}
