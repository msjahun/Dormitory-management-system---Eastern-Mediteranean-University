using Dau.Core.Domain.System;
using Dau.Core.Event;
using Dau.Data;
using Dau.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Dau.Services.Email
{
  public  class EmailService : IEmailService
    {
        private readonly IServiceProvider _provider;

        public EmailService(IServiceProvider serviceProvider)
        {
            _provider = serviceProvider;

        }

        public void SendTestEmail()
        {
            var ClientEmail = "msjahun@live.com";
            var ClientPassword = "abmubasa1994";
            var ClientPort = 587;
            var UseDefaultCredentials = false;
            var EnableSSl = true;
            var SmtpServer = "smtp-mail.outlook.com";

          
            

            SmtpClient client = new SmtpClient(SmtpServer);
            client.UseDefaultCredentials = UseDefaultCredentials;
            client.EnableSsl = EnableSSl;
            client.Port = ClientPort;

            client.Credentials = new NetworkCredential(ClientEmail, ClientPassword);


            using (IServiceScope scope = _provider.CreateScope())
            {
                var _dbContext = scope.ServiceProvider.GetRequiredService<Fees_and_facilitiesContext>();
               
         


            var messagesToSend = from message in _dbContext.MessageQueue.ToList()
                                 where !message.IsSent && message.SendAttempts < message.MaximumSentAttempts
                                 orderby message.MessagePriority ascending
                                 select message;





            foreach (var message in messagesToSend.ToList().Take(20))
            {
                var updateinfo = _dbContext.MessageQueue.Where(c=>c.Id==message.Id).FirstOrDefault();
                updateinfo.SendAttempts = updateinfo.SendAttempts + 1;
                updateinfo.FromAddress = ClientEmail;
                updateinfo.ToName = message.ToName;
                updateinfo.ReplyTo = ClientEmail;
                updateinfo.ReplyToName = ClientEmail;// consider updating these
                try { 
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(ClientEmail);
                mailMessage.To.Add(message.ToAddress);
                    mailMessage.Body = message.Body;
                mailMessage.Subject = message.Subject;

                client.Send(mailMessage);
                    updateinfo.IsSent = true;
                    updateinfo.ToAddress = (message.ToAddress);
                    updateinfo.SentOn = DateTime.Now;
                    updateinfo.FromAddress = (ClientEmail);
                        _dbContext.SaveChanges();

                        LogEvent(new EventLogger
                        {
                            EventName = "sent Email",
                            EventDescription = "Sent email to " + updateinfo.ToAddress,
                            EventParameters = "Subject :" + message.Subject + " Body:" + message.Body
                        });

                    }
                catch
                {
                    updateinfo.IsSent = false;
                    updateinfo.ToAddress = (message.ToAddress);
                    updateinfo.FromAddress = (ClientEmail);
                     


                _dbContext.SaveChanges();

                        LogEvent(new EventLogger
                        {
                            EventName = "Failed to send Email",
                            EventDescription = "Sent email to " + updateinfo.ToAddress,
                            EventParameters = "Subject :" + message.Subject + " Body:" + message.Body
                        });

                    }

                }
            }

        }


        private void LogEvent(EventLogger logger)
        {
            if (logger != null)
            {
                logger.CreatedOn = DateTime.Now;
                using (IServiceScope scope = _provider.CreateScope())
                {
                    var _dbContext = scope.ServiceProvider.GetRequiredService<Fees_and_facilitiesContext>();
                    _dbContext.EventLogger.Add(logger);
                    _dbContext.SaveChanges();
                }
                   
                
            }
        }

    }
}
