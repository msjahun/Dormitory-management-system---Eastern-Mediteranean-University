using Dau.Core.Domain.System;
using Dau.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Services.Email
{
   public class MessageQueueService : IMessageQueueService
    {
        private IRepository<MessageQueue> _messageQueueRepo;

        public MessageQueueService(IRepository<MessageQueue> messageQueueRepo)
        {
            _messageQueueRepo = messageQueueRepo;
        }

        public void QueueVerificationEmail(string verificationToken, string UserFullName, string ToAddress)
        {
            var message =
              new MessageQueue
              {
                  ToAddress = ToAddress,
                  ToName = UserFullName,
                  IsSent = false,
                  MaximumSentAttempts = 5,
                  MessagePriority = 2,

                  Subject = "Verification token ", 
                  Body = "Your account has been created successfully, please very your account using this link <br><br>  " + verificationToken+" <br> <br> Thank you <br> <br> Sent to "+UserFullName,
                  CreatedOn = DateTime.Now,
                  SendImmediately = false,
                  SendAttempts = 0
              };

            _messageQueueRepo.Insert(message);
        }
    }
}
