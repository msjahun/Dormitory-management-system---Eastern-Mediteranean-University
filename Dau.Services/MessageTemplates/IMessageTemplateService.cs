using System.Collections.Generic;
using static Dau.Services.MessageTemplates.MessageTemplateService;

namespace Dau.Services.MessageTemplates
{
    public interface IMessageTemplateService
    {
        List<MessageTemplateService.MessageTemplatesTable> GetMessageTemplatesList();
        MessageTemplateService.MessageTemplateEdit GetTemplateById(long id);
        bool UpdateMessageTemplate(MessageTemplateService.MessageTemplateEdit vm);
        string Tokenizer(string template, List<Tokens> tokens);
        MessageTemplateData PrepareMessageTemplateForSending(string MessageTemplateName, long LanguageId);
    }
}