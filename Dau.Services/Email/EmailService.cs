using Dau.Core.Domain.System;
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

            var ToEmail = "msjahun@live.com";
            var FromEmail = "msjahun@live.com";
            

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
                updateinfo.FromAddress = FromEmail;
                updateinfo.ToName = ToEmail;
                updateinfo.ReplyTo = FromEmail;
                updateinfo.ReplyToName = FromEmail;// consider updating these
                try { 
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(FromEmail);
                mailMessage.To.Add(ToEmail);
                    mailMessage.Body = message.Body;
                mailMessage.Subject = message.Subject;

                client.Send(mailMessage);
                    updateinfo.IsSent = true;
                    updateinfo.ToAddress = (ToEmail);
                    updateinfo.SentOn = DateTime.Now;
                    updateinfo.FromAddress = (FromEmail);
                    
                }
                catch
                {
                    updateinfo.IsSent = false;
                    updateinfo.ToAddress = (ToEmail);
                    updateinfo.FromAddress = (FromEmail);
                }
                _dbContext.SaveChanges();
             
            }
            }

        }
    }
}
