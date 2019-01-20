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
     
            using (IServiceScope scope = _provider.CreateScope())
            {
                var _dbContext = scope.ServiceProvider.GetRequiredService<Fees_and_facilitiesContext>();



                var DefaultEmail = (from EmailAccount in _dbContext.EmailAccount.ToList()
                                   where EmailAccount.IsDefault == true
                                   select EmailAccount).FirstOrDefault();
                if (DefaultEmail == null) {
                    LogEvent(new EventLogger
                    {
                        EventName = "No Default email in database",
                        EventDescription = "No default email in database, email will not be sent",
                        EventParameters = ""
                    });
                    return;
                } ;



                var ClientEmail = DefaultEmail.EmailAddress;
                var ClientPassword = DefaultEmail.Password;
                var ClientPort = DefaultEmail.Port;
                var UseDefaultCredentials = DefaultEmail.UseDefaultCredentials;
                var EnableSSl = DefaultEmail.SSL;
                var SmtpServer = DefaultEmail.Host;




                SmtpClient client = new SmtpClient(SmtpServer);
                client.UseDefaultCredentials = UseDefaultCredentials;
                client.EnableSsl = EnableSSl;
                client.Port = ClientPort;

                client.Credentials = new NetworkCredential(ClientEmail, ClientPassword);

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
                        mailMessage.IsBodyHtml = true;
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
