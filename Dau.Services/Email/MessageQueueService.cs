using Dau.Core.Domain.EmailAccountInformation;
using Dau.Core.Domain.System;
using Dau.Data.Repository;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Dau.Services.Email
{
   public class MessageQueueService : IMessageQueueService
    {
        private readonly IStringLocalizer _localizer;
        private IRepository<MessageQueue> _messageQueueRepo;
        private IRepository<EmailAccount> _emailAccountRepo;

        public MessageQueueService(IRepository<MessageQueue> messageQueueRepo,
            IRepository<EmailAccount> emailAccountRepo, IStringLocalizer stringLocalizer)
        {
            _localizer = stringLocalizer;
            _messageQueueRepo = messageQueueRepo;
            _emailAccountRepo = emailAccountRepo;
        }


        public string SendTestEmail(EmailAccountCrud vm)
        {
            try
            {
                var message =
           new MessageQueue
           {
               ToAddress = vm.SendEmailTo,
               IsSent = true,
               MaximumSentAttempts = 5,
               MessagePriority = 2,
               FromAddress= vm.EmailAddress,
               FromName=vm.EmailDisplayName,
               Subject = "Test Email",
               Body = "Test email sent successfully, email configuration is correct",
               CreatedOn = DateTime.Now,
               SendImmediately = false,
               SendAttempts = 1
           };
                var emailAccount = _emailAccountRepo.GetById(vm.Id);
                var password = emailAccount.Password;

                var ClientEmail = vm.EmailAccoutUser;
                var ClientPassword = password;
                var ClientPort = vm.Port;
                var UseDefaultCredentials = vm.UseDefaultCredentials;
                var EnableSSl = vm.SSL;
                var SmtpServer = vm.Host;

                SmtpClient client = new SmtpClient(SmtpServer);
                client.UseDefaultCredentials = UseDefaultCredentials;
                client.EnableSsl = EnableSSl;
                client.Port = ClientPort;

                client.Credentials = new NetworkCredential(ClientEmail, ClientPassword);


                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(ClientEmail);
                mailMessage.To.Add(message.ToAddress);
                mailMessage.Body = message.Body;
                mailMessage.IsBodyHtml = true;
                mailMessage.Subject = message.Subject;

             client.Send(mailMessage);
                message.SentOn = DateTime.Now;
                _messageQueueRepo.Insert(message);
                return "Email sent successfully";
            }
            catch(Exception e)
            {
                return "Wrong Email configuration, please check it and try again";
            }
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
                  Body = "Your account has been created successfully, please very your account using this link <br><br>  <a href=\"" + verificationToken+"\">Verification token</a> <br> <br> Thank you <br> <br> Sent to "+UserFullName,
                  CreatedOn = DateTime.Now,
                  SendImmediately = false,
                  SendAttempts = 0
              };

            _messageQueueRepo.Insert(message);
        }

        public List<MessageQueueTable> messageQueueListTable()
        {

            var messageQueue = from msgQueue in _messageQueueRepo.List().ToList()
                               orderby msgQueue.CreatedOn descending
                               select new MessageQueueTable
                               {
                                   Id = msgQueue.Id,
                                   Subject = msgQueue.Subject,
                                   From = msgQueue.FromAddress,
                                   To = msgQueue.ToAddress,
                                   CreatedOn = msgQueue.CreatedOn.ToString(),
                                   IsSent= (msgQueue.SentOn == DateTime.MinValue) ? false : true,
                                   SentOn = (msgQueue.SentOn == DateTime.MinValue)?_localizer["Not sent"]: msgQueue.SentOn.ToString(),
                                   MessagePriority = msgQueue.MessagePriority.ToString(),


                               };

            return messageQueue.ToList();

        }


        public MessageQueueEdit GetMessageQueueById (long Id)
        {
            var MessageQueue = _messageQueueRepo.GetById(Id);
            if (MessageQueue == null) return null;

            var model = new MessageQueueEdit
            {
           MessagePriority =MessageQueue.MessagePriority,
           From =MessageQueue.FromAddress,
           FromName =MessageQueue.FromName,
           To =MessageQueue.ToAddress,
           ToName =MessageQueue.ToName,
           ReplyTo =MessageQueue.ReplyTo,
           ReplyToName =MessageQueue.ReplyTo,
           CC =MessageQueue.CC,
           BCC =MessageQueue.BCC,
           Body =MessageQueue.Body,
           CreatedOn =MessageQueue.CreatedOn.ToString(),
           SendAttempts=MessageQueue.SendAttempts,
           SentOn = (MessageQueue.SentOn == DateTime.MinValue) ? _localizer["Not sent"] : MessageQueue.SentOn.ToString(),
                EmailAccount =MessageQueue.FromAddress,
           Id= MessageQueue .Id,
           Subject= MessageQueue.Subject
    };

            return model;
        }

        public bool UpdateMessageQueue(MessageQueueEdit vm)
        {

            try
            {
                var MessageQueue = _messageQueueRepo.GetById(vm.Id);
                if (MessageQueue == null) return false;
                MessageQueue.Subject = vm.Subject;
                MessageQueue.Body = vm.Body;
                _messageQueueRepo.Update(MessageQueue);

                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool DeleteMessageFromQueue(MessageQueueEdit vm)
        {
            try
            {
                var MessageQueue = _messageQueueRepo.GetById(vm.Id);
                if (MessageQueue == null) return false;
                _messageQueueRepo.Delete(MessageQueue);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool RequeueMessage(MessageQueueEdit vm)
        {

            try
            {
                var MessageQueue = _messageQueueRepo.GetById(vm.Id);
                if (MessageQueue == null) return false;
                MessageQueue.IsSent = false;
                MessageQueue.Subject = vm.Subject;
                MessageQueue.Body = vm.Body;

                MessageQueue.SendAttempts = --MessageQueue.SendAttempts;
                _messageQueueRepo.Update(MessageQueue);

                return true;
            }
            catch
            {
                return false;
            }


        }

        public class MessageQueueEdit
        {

            public long Id { get; set; }
            [Display(Name = "Message Priority",
            Description = "Message priority.")]
            public int MessagePriority { get; set; }

            [Display(Name = "From",
            Description = "From address."), DataType(DataType.Text), MaxLength(256)]
            public string From { get; set; }

            [Display(Name = "From Name",
            Description = "From name."), DataType(DataType.Text), MaxLength(256)]
            public string FromName { get; set; }

            [Display(Name = "To",
            Description = "To address."), DataType(DataType.Text), MaxLength(256)]
            public string To { get; set; }

            [Display(Name = "To Name",
            Description = "To name."), DataType(DataType.Text), MaxLength(256)]
            public string ToName { get; set; }

            [Display(Name = "Reply To",
            Description = "Reply to address"), DataType(DataType.Text), MaxLength(256)]
            public string ReplyTo { get; set; }

            [Display(Name = "Reply To Name",
            Description = "Reply to name."), DataType(DataType.Text), MaxLength(256)]
            public string ReplyToName { get; set; }

            [Display(Name = "CC",
            Description = "Cc address"), DataType(DataType.Text), MaxLength(256)]
            public string CC { get; set; }

            [Display(Name = "BCC",
            Description = "BCC address"), DataType(DataType.Text), MaxLength(256)]
            public string BCC { get; set; }

            [Display(Name = "Subject",
            Description = "Message subject")]
            public string Subject { get; set; }

            [Display(Name = "Body",
            Description = "Message body")]
            public string Body { get; set; }

            [Display(Name = "Created On",
            Description = "Date/Time message added to queue")]
            public string CreatedOn { get; set; }

            [Display(Name = "Send Immediately",
            Description = "Send message immediately")]
            public bool SendImmediately { get; set; }

            [Display(Name = "Send Attempts",
            Description = "The number of times to attempt to send this message.")]
            public int SendAttempts { get; set; }

            [Display(Name = "Sent On",
            Description = "The date/time message was sent.")]
            public string SentOn { get; set; }

            [Display(Name = "Email Account",
            Description = "The email account that will be used to send email.")]
            public string EmailAccount { get; set; }

        }


        public class MessageQueueTable
        {
            public long Id { get; set; }
            public string Subject { get; set; }
            public string From { get; set; }
            public string To { get; set; }
            public string CreatedOn { get; set; }
            public string PlannedDateOfSending { get; set; }
            public bool IsSent { get; set; }
            public string SentOn { get; set; }
            public string MessagePriority { get; set; }
            public string Edit { get; set; }
        }
    }
}
