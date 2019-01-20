using System.Collections.Generic;
using static Dau.Services.Email.MessageQueueService;

namespace Dau.Services.Email
{
    public interface IMessageQueueService
    {
        void QueueVerificationEmail(string verificationToken, string UserFullName, string ToAddress);
        List<MessageQueueTable> messageQueueListTable();
        MessageQueueEdit GetMessageQueueById(long Id);
        bool UpdateMessageQueue(MessageQueueEdit vm);
        bool DeleteMessageFromQueue(MessageQueueEdit vm);
        bool RequeueMessage(MessageQueueEdit vm);
        string SendTestEmail(EmailAccountCrud vm);
    }
}