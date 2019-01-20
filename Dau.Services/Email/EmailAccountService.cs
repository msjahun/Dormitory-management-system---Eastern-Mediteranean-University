using Dau.Core.Domain.EmailAccountInformation;
using Dau.Data.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Dau.Services.Email
{
    public class EmailAccountService : IEmailAccountService
    {
        private readonly IRepository<EmailAccount> _emailAccountRepo;

        public EmailAccountService(IRepository<EmailAccount> emailAccountRepo)
        {
            _emailAccountRepo = emailAccountRepo;
        }


        public long AddNewEmail(EmailAccountCrud vm)
        {
            try {

                var emailAccount = new EmailAccount
                {
                  EmailAddress =vm.EmailAddress,
                  EmailDisplayName =vm.EmailDisplayName,
                  Host=vm.Host,
                  Port=vm.Port,
                  UserName= vm.EmailAccoutUser,
                  Password =vm.EmailAccoutPassword,
                  SSL =vm.SSL,
                  UseDefaultCredentials = vm.UseDefaultCredentials
                };

           var newEmailId=     _emailAccountRepo.Insert(emailAccount);

                return newEmailId;

            }
            catch {

                return 0;
            }
        }

        public bool UpdateEmailAccount(EmailAccountCrud vm)
        {
            try
            {

                var emailAccount = _emailAccountRepo.GetById(vm.Id);
                if (emailAccount == null) return false;

                emailAccount.EmailAddress = vm.EmailAddress;
                emailAccount.EmailDisplayName = vm.EmailDisplayName;
                emailAccount.Host = vm.Host;
                emailAccount.Port = vm.Port;
                emailAccount.UserName = vm.EmailAccoutUser;
                emailAccount.SSL = vm.SSL;
                emailAccount.UseDefaultCredentials = vm.UseDefaultCredentials;
             

                _emailAccountRepo.Update(emailAccount);

                return true;

            }
            catch
            {

                return false;
            }
        }

        public bool SetEmailAccountToDefault(long EmailAccountId)
        {
            try
            {

                var emailAccount = _emailAccountRepo.GetById(EmailAccountId);
                if (emailAccount == null) return false;


                var AllEmailAccounts = _emailAccountRepo.List().ToList();


                //clears email accounts
                foreach(var emailAcct in AllEmailAccounts)
                {
                    emailAcct.IsDefault = false;
                    _emailAccountRepo.Update(emailAcct);
                }

                emailAccount.IsDefault = true;

                _emailAccountRepo.Update(emailAccount);

                return true;

            }
            catch
            {

                return false;
            }
        }

        public EmailAccountCrud GetEmailAccountById(long EmailAccountId)
        {
            try
            {

                var emailAccount = _emailAccountRepo.GetById(EmailAccountId);
                if (emailAccount == null) return null;
                var EmailAccountCrud = new EmailAccountCrud
                {
                EmailAddress = emailAccount.EmailAddress,
                EmailDisplayName = emailAccount.EmailDisplayName,
                Host = emailAccount.Host,
                Port = emailAccount.Port,
                    EmailAccoutUser = emailAccount.UserName,
                SSL = emailAccount.SSL,
                UseDefaultCredentials = emailAccount.UseDefaultCredentials,
                Id= emailAccount.Id,
                IsDefault= emailAccount.IsDefault
            };


                return EmailAccountCrud;

            }
            catch
            {

                return null;
            }
        }

        public bool UpdateEmailAccountPassword(EmailAccountCrud vm)
        {
            try
            {

                var emailAccount = _emailAccountRepo.GetById(vm.Id);
                if (emailAccount == null) return false;

                emailAccount.Password = vm.EmailAccoutPassword;

                _emailAccountRepo.Update(emailAccount);

                return true;

            }
            catch
            {

                return false;
            }
        }

        public bool DeleteEmailAccount(EmailAccountCrud vm)
        {
            try
            {

                var emailAccount = _emailAccountRepo.GetById(vm.Id);

                _emailAccountRepo.Delete(emailAccount);

                return true;

            }
            catch
            {

                return false;
            }
        }

        public List<EmailAccountsTable> GetEmailAccountsTableList()
        {
            var EmailAccounts = from emailAcct in _emailAccountRepo.List().ToList()
                                select new EmailAccountsTable
                                {
                                    Id = emailAcct.Id,
                                    EmailAddress = emailAcct.EmailAddress,
                                    IsDefaultEmailAccount = emailAcct.IsDefault,
                                    EmailDisplayName=emailAcct.EmailDisplayName

                                };

            return EmailAccounts.ToList();

        }



        
    }



    public class EmailAccountsTable
    {
        public long Id { get; set; }
        public string EmailAddress { get; set; }
        public string EmailDisplayName { get; set; }
        public bool IsDefaultEmailAccount { get; set; }
        
    }
    public class EmailAccountCrud
    {
        public long Id { get; set; }
        [Required]
        [Display(Name = "Email Address",
       Description = "This is the from address for all outgoing emails from your site e.g. 'noreply@emu.edu.tr'."), DataType(DataType.Text), MaxLength(256)]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Email Display Name",
        Description = "This is the friendly display name for outgoing emails from this site e.g. 'Booking handling Department'."), DataType(DataType.Text), MaxLength(256)]
        public string EmailDisplayName { get; set; }

        [Required]
        [Display(Name = "Host",
        Description = "This is the host name or IP address of your mail server.You can normally find this out from your ISP or web host."), DataType(DataType.Text), MaxLength(256)]
        public string Host { get; set; }

        [Required]
        [Display(Name = "Port",
        Description = "This is the SMTP port of your mail server.This is usually port 25.")]
        public int Port { get; set; }

        [Required]
        [Display(Name = "User",
        Description = "This is the username you use to authenticate to your mail server."), DataType(DataType.Text), MaxLength(256)]
        public string EmailAccoutUser { get; set; }


        [Display(Name = "Password",
        Description = "This is the password you use to authenticate to your mail server."), DataType(DataType.Password), MaxLength(256)]
        public string EmailAccoutPassword { get; set; }


        [Display(Name = "SSL",
        Description = "Check to use Secure Sockets Layer(SSL) to encrypt the SMTP connection.")]
        public bool SSL { get; set; }


        [Display(Name = "Use Default Credentials",
        Description = "Check to use default credentials for the connection.")]
        public bool UseDefaultCredentials { get; set; }


        [Display(Name = "Send Email To",
        Description = "Send test email to ensure that everything is properly configured."), DataType(DataType.EmailAddress)]
        public string SendEmailTo { get; set; }
        public bool IsDefault { get; internal set; }
    }
}
