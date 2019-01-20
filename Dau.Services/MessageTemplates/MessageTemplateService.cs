using Dau.Core.Domain.ContentManagement;
using Dau.Data.Repository;
using Dau.Services.Event;
using Dau.Services.Languages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Dau.Services.MessageTemplates
{
    public class MessageTemplateService : IMessageTemplateService
    {
      
        private readonly IRepository<MessageTemplate> _messageTemplateRepo;
        private readonly IRepository<MessageTemplateTranslation> _messageTemplateTransRepo;
        private readonly ILanguageService _languageService;

        public MessageTemplateService(IRepository<MessageTemplate> messageTempleteRepo,
            IRepository<MessageTemplateTranslation> messageTemplateTransRepo,
          
             ILanguageService languageService)
        {
           
            _messageTemplateRepo = messageTempleteRepo;
            _messageTemplateTransRepo = messageTemplateTransRepo;
            _languageService = languageService;

        }
        public const string Student_BackInStockRoomEmail = "Student.BackInStockRoomEmail";
        public const string Student_EmailValidation = "Student.EmailValidation";
        public const string Student_WelcomeMessage = "Student.WelcomeMessage";
        public const string Student_BookingCancellation = "Student.BookingCancellation";
        public const string Student_BookingCompleted = "Student.BookingCompleted";
        public const string Student_BookingPaid = "Student.BookingPaid";
        public const string DormitoryManager_BookingPaid = "DormitoryManager.BookingPaid";
        public const string DormitoryManager_NewBookingAlert = "DormitoryManager.NewBookingAlert";
        public const string Student_BookingPlacedSuccessfully = "Student.BookingPlacedSuccessfully";
        public const string DormitoryManager_NewReviewInDormitory = "DormitoryManager.NewReviewInDormitory";
        public const string DormitoryManager_LowQuotaRoomAlert = "DormitoryManager.LowQuotaRoomAlert";
        public const string Administrator_DormitoryInformationChangedAlert = "Administrator.DormitoryInformationChangedAlert";
        public const string Administrator_NewRegistration = "Administrator.NewRegistration";
        public List<MessageTemplatesTable> GetMessageTemplatesList()
        {
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();
            var MessageTemplates = from msgTemplate in _messageTemplateRepo.List().ToList()
                                   join msgTemplateTrans in _messageTemplateTransRepo.List().ToList() on msgTemplate.Id equals msgTemplateTrans.MessageTemplateNonTransId
                                   where msgTemplateTrans.LanguageId == CurrentLanguageId
                                   select new MessageTemplatesTable
                                   {
                                       Id = msgTemplate.Id,
                                       Name = msgTemplate.Name,
                                       Subject = msgTemplateTrans.Subject,
                                       IsActive = msgTemplate.IsActive

                                   };

            return MessageTemplates.ToList();


        }


        private List<Tokens> ResolveMessageTemplateTokens (string MessageTemplateName)
        {
            switch (MessageTemplateName)
            {
                case Student_BackInStockRoomEmail:
                    {

                        return
                            new List<Tokens>
                            {
                                new Tokens{ TokenName="%Dormitory.Url%"  , TokenValue ="" },
                                new Tokens{ TokenName="%Room.Name%"  , TokenValue =""},
                                new Tokens{ TokenName="%User.Firstname%"  , TokenValue =""},
                                new Tokens{ TokenName="%User.LastName%"  , TokenValue =""},
                                new Tokens{ TokenName="%Dormitory.Name%"  , TokenValue =""},
                                new Tokens{ TokenName="%Room.Name%"  , TokenValue =""},
                                new Tokens{ TokenName="%Dormitory.Name%"  , TokenValue =""},
                                new Tokens{ TokenName="%Room.Name%"  , TokenValue =""}
                            };

                    }
                case Student_EmailValidation:
                    {
                        return
                          new List<Tokens>
                          {
                                new Tokens {TokenName="%User.Firstname%", TokenValue="" },
                                new Tokens {TokenName="%User.LastName%", TokenValue=""},
                                new Tokens {TokenName="%User.Verificationlink%", TokenValue=""}
                          };

                    }
                case Student_WelcomeMessage:
                    {

                        return
                            new List<Tokens>
                            {
                                new Tokens {TokenName ="%User.Firstname%", TokenValue="" },
                                new Tokens {TokenName ="%User.LastName%", TokenValue=""}


                            };

                    }
                case Student_BookingCancellation:
                    {

                        return
                             new List<Tokens>
                             {
                                  new Tokens {TokenName="%Booking.No%", TokenValue ="" },
                                  new Tokens {TokenName="%Booking.No%", TokenValue =""},
                                  new Tokens {TokenName="%Booking.No%", TokenValue =""},
                                  new Tokens {TokenName="%Dormitory.Name%", TokenValue =""},
                                  new Tokens {TokenName="%Room.Name%", TokenValue =""},
                                  new Tokens {TokenName="%Booking.CreateDate%", TokenValue =""},
                                  new Tokens {TokenName="%User.Firstname%", TokenValue =""},
                                  new Tokens {TokenName="%User.LastName%", TokenValue =""}
                             };

                    }
                case Student_BookingCompleted:
                    {

                        return
                            new List<Tokens>
                            {
                                new Tokens{TokenName="%Booking.No%", TokenValue ="" },
                                new Tokens{TokenName="%Dormitory.Name%", TokenValue =""},
                                new Tokens{TokenName="%Room.Name%", TokenValue =""},
                                new Tokens{TokenName="%Booking.Date%", TokenValue =""},
                                new Tokens{TokenName="%Dormitory.Managername%", TokenValue =""},
                                new Tokens{TokenName="%Dormitory.Name%", TokenValue =""},
                                new Tokens{TokenName="%Dormitory.PhoneNumber%", TokenValue =""},
                                new Tokens{TokenName="%Dormitory.Email%", TokenValue =""},
                                new Tokens{TokenName="%User.Firstname%", TokenValue =""},
                                new Tokens{TokenName="%User.LastName%", TokenValue =""}
                            };

                    }
                case Student_BookingPaid:
                    {

                        return
                            new List<Tokens>
                            {
                            new Tokens {TokenName="%Booking.No%", TokenValue ="" },
                            new Tokens {TokenName="%Dormitory.Name%", TokenValue =""},
                            new Tokens {TokenName="%Booking.No%", TokenValue =""},
                            new Tokens {TokenName="%Dormitory.Name%", TokenValue =""},
                            new Tokens {TokenName="%Room.Name%", TokenValue =""},
                            new Tokens {TokenName="%Booking.ReceiptUploadStatus%", TokenValue =""},
                            new Tokens {TokenName="%Booking.DateOfBooking%", TokenValue =""},
                            new Tokens {TokenName="%Dormitory.Managername%", TokenValue =""},
                            new Tokens {TokenName="%Dormitory.Name%", TokenValue =""},
                            new Tokens {TokenName="%Dormitory.PhoneNumber%", TokenValue =""},
                            new Tokens {TokenName="%Dormitory.Email%", TokenValue =""},
                            new Tokens {TokenName="%User.Firstname%", TokenValue =""},
                            new Tokens {TokenName="%User.LastName%", TokenValue =""}
                            };

                    }
                case DormitoryManager_BookingPaid:
                    {

                        return
                            new List<Tokens>
                            {
                            new Tokens {TokenName ="%Booking.No%", TokenValue ="" },
                            new Tokens {TokenName ="%Booking.No%", TokenValue =""},
                            new Tokens {TokenName ="%Dormitory.Name%", TokenValue =""},
                            new Tokens {TokenName ="%Room.Name%", TokenValue =""},
                            new Tokens {TokenName ="%Booking.ReceiptUploadStatus%", TokenValue =""},
                            new Tokens {TokenName ="%Booking.DateOfBooking%", TokenValue =""},
                            new Tokens {TokenName ="%Booking.BookingStatus%", TokenValue =""},
                            new Tokens {TokenName ="%Booking.PaymentStatus%", TokenValue =""},
                            new Tokens {TokenName ="%User.Firstname%", TokenValue =""},
                            new Tokens {TokenName ="%User.LastName%", TokenValue =""}
                            };

                    }
                case DormitoryManager_NewBookingAlert:
                    {

                        return
                            new List<Tokens>
                            {
                                new Tokens {TokenName ="%Dormitory.Name%", TokenValue ="" },
                                new Tokens {TokenName ="%Booking.No%", TokenValue =""},
                                new Tokens {TokenName ="%Dormitory.Name%", TokenValue =""},
                                new Tokens {TokenName ="%Room.Name%", TokenValue =""},
                                new Tokens {TokenName ="%Booking.ReceiptUploadStatus%", TokenValue =""},
                                new Tokens {TokenName ="%Booking.BookingDate%", TokenValue =""},
                                new Tokens {TokenName ="%User.FirstName%", TokenValue =""},
                                new Tokens {TokenName ="%User.LastName%", TokenValue =""},
                                new Tokens {TokenName ="%User.StudentNumber%", TokenValue =""},
                                new Tokens {TokenName ="%Dormitory.Managername%", TokenValue =""},
                                new Tokens {TokenName ="%Dormitory.Name%", TokenValue =""},
                                new Tokens {TokenName ="%Dormitory.PhoneNumber%", TokenValue =""},
                                new Tokens {TokenName ="%Dormitory.Email%", TokenValue =""},
                                new Tokens {TokenName ="%Dormitory.Email%", TokenValue =""},
                                new Tokens {TokenName ="%Dormitory.Name%", TokenValue =""},
                                new Tokens {TokenName ="%Dormitory.Name%", TokenValue =""}
                            };

                    }
                case Student_BookingPlacedSuccessfully:
                    {

                        return
                           new List<Tokens>
                           {
                                new Tokens {TokenName="%Booking.WaitDaysBeforeCancellation%", TokenValue="" },
                                new Tokens {TokenName="%Booking.No%", TokenValue=""},
                                new Tokens {TokenName="%Booking.CancellationDate%.", TokenValue=""},
                                new Tokens {TokenName="%Booking.No%", TokenValue=""},
                                new Tokens {TokenName="%Dormitory.Name%", TokenValue=""},
                                new Tokens {TokenName="%Room.Name%", TokenValue=""},
                                new Tokens {TokenName="%Booking.ReceiptUploadStatus%", TokenValue=""},
                                new Tokens {TokenName="%Booking.DateOfBooking%", TokenValue=""},
                                new Tokens {TokenName="%Dormitory.Managername%", TokenValue=""},
                                new Tokens {TokenName="%Dormitory.Name%", TokenValue=""},
                                new Tokens {TokenName="%Dormitory.PhoneNumber%", TokenValue=""},
                                new Tokens {TokenName="%Dormitory.Email%", TokenValue=""},
                                new Tokens {TokenName="%User.Firstname%", TokenValue=""},
                                new Tokens {TokenName="%User.LastName%", TokenValue=""}
                           };

                    }
                case DormitoryManager_NewReviewInDormitory:
                    {

                        return
                            new List<Tokens>
                            {
                                new Tokens {TokenName ="%Dormitory.Name%", TokenValue ="" },
                                new Tokens {TokenName ="%Dormitory.Name%", TokenValue =""},
                                new Tokens {TokenName ="%Review.No%", TokenValue =""},
                                new Tokens {TokenName ="%Dormitory.Name%", TokenValue =""},
                                new Tokens {TokenName ="%Review.RatingNo%", TokenValue =""},
                                new Tokens {TokenName ="%Review.CreatedDate%", TokenValue =""},
                                new Tokens {TokenName ="%User.StudentNo%", TokenValue =""},
                                new Tokens {TokenName ="%User.Firstname%", TokenValue =""},
                                new Tokens {TokenName ="%User.LastName%", TokenValue =""},
                                new Tokens {TokenName ="%User.Email%", TokenValue =""},
                                new Tokens {TokenName ="%Review.Text%", TokenValue =""},
                                new Tokens {TokenName ="%Dormitory.Email%", TokenValue =""},
                                new Tokens {TokenName ="%Dormitory.Name%", TokenValue =""}
                            };

                    }
                case DormitoryManager_LowQuotaRoomAlert:
                    {

                        return
                             new List<Tokens>
                             {
                                new Tokens {TokenName ="%Room.Name%", TokenValue ="" },
                                new Tokens {TokenName ="%Room.RemainingQuota%", TokenValue =""},
                                new Tokens {TokenName ="%Dormitory.Name%", TokenValue =""},
                                new Tokens {TokenName ="%Room.RemainingQuota%", TokenValue =""},
                                new Tokens {TokenName ="%Room.No%", TokenValue =""},
                                new Tokens {TokenName ="%Room.RemainingQuota%", TokenValue =""},
                                new Tokens {TokenName ="%Dormitory.Email%", TokenValue =""},
                                new Tokens {TokenName ="%Dormitory.Name%", TokenValue =""}
                             };

                    }
                case Administrator_DormitoryInformationChangedAlert:
                    {

                        return
                            new List<Tokens>
                            {
                                new Tokens {TokenName ="%Dormitory.Name%", TokenValue ="" },
                                new Tokens {TokenName ="%DormitoryId%", TokenValue =""},
                                new Tokens {TokenName ="%Dormitory.Name%", TokenValue =""},
                                new Tokens {TokenName ="%Dormitory.UpdatedDate%", TokenValue =""},
                                new Tokens {TokenName ="%User.Firstname%", TokenValue =""},
                                new Tokens {TokenName ="%User.LastName%", TokenValue =""},
                                new Tokens {TokenName ="%Administrator.Email%", TokenValue =""}
                            };

                    }
                case Administrator_NewRegistration:
                    {

                        return
                             new List<Tokens>
                             {
                                new Tokens {TokenName = "%User.Id%", TokenValue ="" },
                                new Tokens {TokenName = "%User.StudentNumber%", TokenValue =""},
                                new Tokens {TokenName = "%User.FirstName%", TokenValue =""},
                                new Tokens {TokenName = "%User.LastName%", TokenValue =""},
                                new Tokens {TokenName = "%User.Email%", TokenValue =""},
                                new Tokens {TokenName = "%User.Address%", TokenValue =""},
                                new Tokens {TokenName = "%Admnistrator.Email%", TokenValue =""}
                             };

                    }
                default: return null;
            }

        }


        public MessageTemplateEdit GetTemplateById(long id)
        {

          
            var messageTemplate = _messageTemplateRepo.GetById(id);
            if (messageTemplate == null) return null;


            var messageTemplateTrans = from msgTTrans in _messageTemplateTransRepo.List().ToList()
                                       where msgTTrans.MessageTemplateNonTransId == messageTemplate.Id
                                       select msgTTrans;

            var englishMsgTemplate = messageTemplateTrans.Where(c => c.LanguageId == 1).FirstOrDefault();
            var turkishMsgTemplate = messageTemplateTrans.Where(c => c.LanguageId == 2).FirstOrDefault();


            var EmailTokens = ResolveMessageTemplateTokens(messageTemplate.Name);
            var model = new MessageTemplateEdit
            {
                AllowedTokens = StringToKens(EmailTokens),
                isActive = messageTemplate.IsActive,
                Id = messageTemplate.Id,
                Name= messageTemplate.Name,

                localizedContent = new List<LocalizedContent>
                                        { new LocalizedContent
                                            {
                                              Body= englishMsgTemplate.Body,
                                              Subject= englishMsgTemplate.Subject,
                                              BCC= englishMsgTemplate.BCC
                                                //english
                                            },
                                            new LocalizedContent
                                            {
                                               Body= turkishMsgTemplate.Body,
                                               Subject= turkishMsgTemplate.Subject,
                                               BCC= turkishMsgTemplate.BCC
                                                //turkish
                                            }
            }




            };
            return model;
        }




        public string Tokenizer(string template, List<Tokens> tokens)
        {
            if (template == null || string.IsNullOrWhiteSpace(template))

                return null;


            foreach (var token in tokens)
            {
                if (token.TokenName == null || token.TokenValue == null)
                {//if no value is provided should replace it with space
                    template = Regex.Replace(template, token.TokenName, " ");
                }
                else
                {
                    template = Regex.Replace(template, token.TokenName, token.TokenValue);
                }
                
               // template.Replace(token.TokenName, token.TokenValue);
            }
            return template;
        }

        public class Tokens
        {
            public string TokenName { get; set; }
            public string TokenValue { get; set; }
        }

        public string StringToKens(List<Tokens> tokens)
        {
            string token = " ";

            foreach(var tokenString in tokens)
            {
                token += tokenString.TokenName + ", ";
            }

            return token;
        }


       public MessageTemplateData PrepareMessageTemplateForSending(string MessageTemplateName, long LanguageId)
        {
            var MessageTemplateFound = _messageTemplateRepo.List().ToList().Where(c => c.Name == MessageTemplateName).FirstOrDefault();
            if (MessageTemplateFound == null) return null;

            var messageTemplate = _messageTemplateRepo.GetById(MessageTemplateFound.Id);
            var messageTemplateTrans = from msgTTrans in _messageTemplateTransRepo.List().ToList()
                                       where msgTTrans.MessageTemplateNonTransId == messageTemplate.Id
                                       select msgTTrans;
            var MsgTemplateTrans = messageTemplateTrans.Where(c => c.LanguageId == LanguageId).FirstOrDefault();


            return new MessageTemplateData
            {
                Body = MsgTemplateTrans.Body,
                Subject= MsgTemplateTrans.Subject
            };

        }


        public class MessageTemplateData
        {
            public string Body { get; set; }
            public string Subject { get; set; }
        }


        public bool UpdateMessageTemplate(MessageTemplateEdit vm)
        {
            try
            {
                var messageTemplate = _messageTemplateRepo.GetById(vm.Id);
                if (messageTemplate == null) return false;
                var messageTemplateTrans = from msgTTrans in _messageTemplateTransRepo.List().ToList()
                                           where msgTTrans.MessageTemplateNonTransId == messageTemplate.Id
                                           select msgTTrans;

                var englishMsgTemplate = messageTemplateTrans.Where(c => c.LanguageId == 1).FirstOrDefault();
                var turkishMsgTemplate = messageTemplateTrans.Where(c => c.LanguageId == 2).FirstOrDefault();



                messageTemplate.IsActive = vm.isActive;
                englishMsgTemplate.Subject = vm.localizedContent[0].Subject;
                englishMsgTemplate.Body = vm.localizedContent[0].Body;
                englishMsgTemplate.BCC = vm.localizedContent[0].BCC;



                turkishMsgTemplate.Subject = vm.localizedContent[1].Subject;
                turkishMsgTemplate.Body = vm.localizedContent[1].Body;
                turkishMsgTemplate.BCC = vm.localizedContent[1].BCC;

                _messageTemplateTransRepo.Update(englishMsgTemplate);
                _messageTemplateTransRepo.Update(turkishMsgTemplate);
                _messageTemplateRepo.Update(messageTemplate);






                return true;
            }
            catch
            {
                return false;
            }
        }

        public class MessageTemplatesTable
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public string Subject { get; set; }
            public bool IsActive { get; set; }
            public string LimitedToDormitory { get; set; }
            public string Edit { get; set; }
        }


        public class MessageTemplateEdit
        {
            public bool SavedSuccessful { get; set; }
            public long Id { get; set; }
            public List<LocalizedContent> localizedContent { get; set; }

            [Display(Name = "Allowed Tokens",
          Description = "Allowed Tokens you can use to be replaced with custoper/user data")]
            public string AllowedTokens { get; set; }

            [Display(Name = "Name",
          Description = "The name of the message template"), DataType(DataType.Text)]
            public string Name { get; set; }


            [Display(Name = "Is Active",
            Description = "Indicating whether the message template is active.")]
            public bool isActive { get; set; }

            [Display(Name = "Send Immediately",
            Description = "Send message immediately.")]
            public bool SendImmediately { get; set; }

            [Display(Name = "Attached Static File",
            Description = "Upload a static file you want to attach to each sent email.")]
            public bool AttachedStaticFile { get; set; }

            [Display(Name = "Limited To Dormitory",
            Description = "Option to limit this template to a certain dormitory.If you have multiple dormitories, choose one or several from the list.If you don't use this option just leave this field empty.")]
            public IEnumerable<int> LimitedToDormitories { get; set; }

        }


        public class LocalizedContent
        {
            [Display(Name = "Subject",
           Description = "The subject of the message(email). TIP - You can include tokens in your subject."), DataType(DataType.Text), MaxLength(256)]
            public string Subject { get; set; }

            [Display(Name = "Body",
            Description = "The body of your message."), DataType(DataType.Text)]
            public string Body { get; set; }

            [Display(Name = "BCC",
            Description = "The blind carbon copy(BCC) recipients for this e-mail message."), DataType(DataType.Text), MaxLength(256)]
            public string BCC { get; set; }


            [Display(Name = "Email Account",
            Description = "The email account that will be used to send this message template.")]
            public int EmailAccount { get; set; }
        }
    }
}
