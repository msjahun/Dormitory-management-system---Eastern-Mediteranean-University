using Dau.Core.Domain.Bookings;
using Dau.Core.Domain.Catalog;
using Dau.Core.Domain.System;
using Dau.Core.Domain.Users;
using Dau.Core.Event;
using Dau.Data.Repository;
using Dau.Services.MessageTemplates;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;

using static Dau.Services.MessageTemplates.MessageTemplateService;

namespace Dau.Services.Event
{
    public class EventService : IEventService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRepository<Booking> _bookingRepository;
        private readonly IRepository<CancelBookingRequests> _cancelBookingRequests;
        private readonly UserManager<User> _userManager;
        private readonly IRepository<BookingStatus> _bookingStatusRepo;
        private readonly IRepository<BookingStatusTranslation> _bookingStatusTransRepo;
        private readonly IRepository<PaymentStatus> _paymentStatusRepo;
        private readonly IRepository<PaymentStatusTranslation> _paymentStatusTransRepo;
        private IRepository<EventLogger> _eventLoggerRepo;
        private readonly IRepository<MessageQueue> _messageQueueRepo;
        private readonly IMessageTemplateService _messageTemplateService;
        private readonly IRepository<Review> _reviewRepo;
        private readonly IRepository<Room> _roomRepository;
        private readonly IRepository<RoomTranslation> _roomTransRepository;
        private readonly IRepository<Dormitory> _dormitoryRepository;

        private readonly IRepository<DormitoryTranslation> _dormitoryTranslationRepository;

        public EventService(IRepository<EventLogger> eventLoggerRepo,
            IRepository<MessageQueue> messageQueueRepo,
               IHttpContextAccessor httpContextAccessor,
            IMessageTemplateService messageTemplateService,
             IRepository<Booking> bookingRepository,
            IRepository<BookingStatus> bookingStatusRepository,
            IRepository<BookingStatusTranslation> bookingStatusTransRepository,
            IRepository<PaymentStatus> paymentStatusRepository,
            IRepository<PaymentStatusTranslation> paymentStatusTransRepository,
            IRepository<Room> RoomRepository,
            IRepository<RoomTranslation> RoomTransRepository,
            IRepository<Dormitory> DormitoryRepository,
            IRepository<DormitoryTranslation> DormitoryTranslationRepository,
             UserManager<User> userManager,
             IRepository<Review> reviewRepo
            )
        {
            _eventLoggerRepo = eventLoggerRepo;
            _messageQueueRepo = messageQueueRepo;
            _messageTemplateService = messageTemplateService;
            _reviewRepo = reviewRepo;

            _httpContextAccessor = httpContextAccessor;

            _roomRepository = RoomRepository;
            _roomTransRepository = RoomTransRepository;
            _dormitoryRepository = DormitoryRepository;
            _dormitoryTranslationRepository = DormitoryTranslationRepository;
     
            _bookingRepository = bookingRepository;
          
            _userManager = userManager;
         


            _bookingStatusRepo = bookingStatusRepository;
            _bookingStatusTransRepo = bookingStatusTransRepository;
            _paymentStatusRepo = paymentStatusRepository;
            _paymentStatusTransRepo = paymentStatusTransRepository;
        }

    



        public  const string Student_BackInStockRoomEmail = "Student.BackInStockRoomEmail";
        public  const string Student_EmailValidation = "Student.EmailValidation";
        public  const string Student_WelcomeMessage  = "Student.WelcomeMessage";
        public  const string Student_BookingCancellation = "Student.BookingCancellation";
        public  const string Student_BookingCompleted  = "Student.BookingCompleted";
        public  const string Student_BookingPaid  = "Student.BookingPaid";
        public  const string DormitoryManager_BookingPaid = "DormitoryManager.BookingPaid";
        public  const string DormitoryManager_NewBookingAlert = "DormitoryManager.NewBookingAlert";
        public  const string Student_BookingPlacedSuccessfully = "Student.BookingPlacedSuccessfully";
        public  const string DormitoryManager_NewReviewInDormitory = "DormitoryManager.NewReviewInDormitory";
        public  const string DormitoryManager_LowQuotaRoomAlert = "DormitoryManager.LowQuotaRoomAlert";
        public  const string Administrator_DormitoryInformationChangedAlert = "Administrator.DormitoryInformationChangedAlert";
        public  const string Administrator_NewRegistration = "Administrator.NewRegistration";


     

        public void TriggerTestEvent()
        {
            string UserFullName = "Musa Jahun";
            string ToAddress = "mjahun@gmail.com";

            var SendLanguageId = 1;
            var MessageTemplateName = Student_EmailValidation;
            var EmailTokens = new List<Tokens>
                          {
                                new Tokens {TokenName="%User.Firstname%", TokenValue="" },
                                new Tokens {TokenName="%User.LastName%", TokenValue=""},
                                new Tokens {TokenName="%User.Verificationlink%", TokenValue=""}
                          };
            var MessageTemplate = _messageTemplateService.PrepareMessageTemplateForSending(MessageTemplateName, SendLanguageId);
            var message =
           new MessageQueue
           {
               ToAddress = ToAddress,
               ToName = UserFullName,
               IsSent = false,
               MaximumSentAttempts = 5,
               MessagePriority = 2,
               Subject = MessageTemplate.Subject,
               Body = MessageTemplate.Body,
               CreatedOn = DateTime.Now,
               SendImmediately = false,
               SendAttempts = 0
           };

            message.Body = _messageTemplateService.Tokenizer(message.Body, EmailTokens);
            message.Subject = _messageTemplateService.Tokenizer(message.Subject, EmailTokens);
            _messageQueueRepo.Insert(message);


            LogEvent(new EventLogger
            {EventName="Added testing event",
            EventDescription="Added some cool testing event",
            EventParameters="Json of some parameter or something"
            });
        }


        public void Trigger_Student_BackInStock_Event(long RoomId)
        {//List of tokens

            //RoomId and Dormitory Id and we'll use it to get other information
            //for user information you'll need to check subsribed list
            //for now let's say my email is subsribed
            var CurrentSystemUrl = (_httpContextAccessor.HttpContext.Request.IsHttps) ? "https://" : "http://" + _httpContextAccessor.HttpContext.Request.Host.Value.ToString();

            var SendLanguageId = 1;
            var Room = _roomRepository.GetById(RoomId);
            if (Room == null) return;
            string DormitoryName = _dormitoryTranslationRepository.List().ToList().Where(c => c.LanguageId == SendLanguageId && c.DormitoryNonTransId == _roomRepository.GetById(Room.Id).DormitoryId).FirstOrDefault().DormitoryName;
            string RoomName = _roomTransRepository.List().ToList().Where(c => c.LanguageId == SendLanguageId && c.RoomNonTransId == Room.Id).FirstOrDefault().RoomName;
            string DormitoryUrl = CurrentSystemUrl + "/Dormitories";
           
            
            //user subscribed to backInStock Room
            string UserFullName = "Musa Jahun";
            string UserFirstName = "Musa";
            string UserLastName = "Jahun";
            string ToAddress = "mjahun@gmail.com";


            var MessageTemplateName = Student_BackInStockRoomEmail;
            var EmailTokens = new List<Tokens>
                            {
                                new Tokens{ TokenName="%Dormitory.Url%"  , TokenValue =DormitoryUrl},
                                new Tokens{ TokenName="%Room.Name%"  , TokenValue =RoomName},
                                new Tokens{ TokenName="%User.Firstname%"  , TokenValue =UserFirstName},
                                new Tokens{ TokenName="%User.LastName%"  , TokenValue =UserLastName},
                                new Tokens{ TokenName="%Dormitory.Name%"  , TokenValue =DormitoryName},
                            };
           
            var MessageTemplate = _messageTemplateService.PrepareMessageTemplateForSending(MessageTemplateName, SendLanguageId);
            var message =
           new MessageQueue
           {
               ToAddress = ToAddress,
               ToName = UserFullName,
               IsSent = false,
               MaximumSentAttempts = 5,
               MessagePriority = 2,
               Subject = MessageTemplate.Subject,
               Body = MessageTemplate.Body,
               CreatedOn = DateTime.Now,
               SendImmediately = false,
               SendAttempts = 0
           };
            message.Body = _messageTemplateService.Tokenizer(message.Body, EmailTokens);
            message.Subject = _messageTemplateService.Tokenizer(message.Subject, EmailTokens);
            _messageQueueRepo.Insert(message);



            LogEvent(new EventLogger
            {EventName="Student RoomBackInStock event",
            EventDescription= "Student.BackInStock Room back in stock % Dormitory.Name % //quota added",
            EventParameters=""
            });
        }
        
        public void Trigger_Student_EmailValidationMessage_Event(
            string UserEmail,string UserFirstName, string UserLastName, string UserVerificationLink)
        {
            string UserFullName = UserLastName;
            string ToAddress = UserEmail;
          
            var SendLanguageId = 1;
            var MessageTemplateName = Student_EmailValidation;
            var EmailTokens = new List<Tokens>
                          {
                                new Tokens {TokenName="%User.Firstname%", TokenValue=UserFirstName},
                                new Tokens {TokenName="%User.LastName%", TokenValue=UserLastName},
                                new Tokens {TokenName="%User.Verificationlink%", TokenValue=UserVerificationLink}
                          };
            var MessageTemplate = _messageTemplateService.PrepareMessageTemplateForSending(MessageTemplateName, SendLanguageId);
            var message =
           new MessageQueue
           {
               ToAddress = ToAddress,
               ToName = UserFullName,
               IsSent = false,
               MaximumSentAttempts = 5,
               MessagePriority = 2,
               Subject = MessageTemplate.Subject,
               Body = MessageTemplate.Body,
               CreatedOn = DateTime.Now,
               SendImmediately = false,
               SendAttempts = 0
           };

            message.Body = _messageTemplateService.Tokenizer(message.Body, EmailTokens);
            message.Subject = _messageTemplateService.Tokenizer(message.Subject, EmailTokens);
            _messageQueueRepo.Insert(message);





            LogEvent(new EventLogger
            {EventName="Student emailValidationMessage event",
            EventDescription= "Student.EmailValidationMessage % Dormitory.Name % Email Activation",
            EventParameters=""
            });
        }
        
        public void Trigger_Student_WelcomeMessage_Event(
            string UserEmail, string UserFirstName, string UserLastName)
        {


            string UserFullName = UserFirstName+ " "+ UserLastName;
            string ToAddress = UserEmail;
         
            var SendLanguageId = 1;
            var MessageTemplateName = Student_WelcomeMessage;
            var EmailTokens = new List<Tokens>
                            {
                                new Tokens {TokenName ="%User.Firstname%", TokenValue=UserFirstName},
                                new Tokens {TokenName ="%User.LastName%", TokenValue=UserLastName}


                            };
            var MessageTemplate = _messageTemplateService.PrepareMessageTemplateForSending(MessageTemplateName, SendLanguageId);
            var message =
           new MessageQueue
           {
               ToAddress = ToAddress,
               ToName = UserFullName,
               IsSent = false,
               MaximumSentAttempts = 5,
               MessagePriority = 2,
               Subject = MessageTemplate.Subject,
               Body = MessageTemplate.Body,
               CreatedOn = DateTime.Now,
               SendImmediately = false,
               SendAttempts = 0
           };

            message.Body = _messageTemplateService.Tokenizer(message.Body, EmailTokens);
            message.Subject = _messageTemplateService.Tokenizer(message.Subject, EmailTokens);
            _messageQueueRepo.Insert(message);




            LogEvent(new EventLogger
            {EventName="Welcome messsage event(new student created)",
            EventDescription= "Student.WelcomeMessage Welcome to emu Booking system",
            EventParameters=""
            });
        }
        
        public void Trigger_BookingCancelled_StudentNotification_Event(long BookingId )
        {
            var SendLanguageId = 1;
            var booking = _bookingRepository.GetById(BookingId);
            if (booking == null) return;
            string UserEmail = _userManager.Users.ToList().Where(c => c.Id == booking.UserId).FirstOrDefault().Email;
            string BookingNo = booking.Id.ToString();
            string DormitoryName = _dormitoryTranslationRepository.List().ToList().Where(c => c.LanguageId == SendLanguageId && c.DormitoryNonTransId == _roomRepository.GetById(booking.RoomId).DormitoryId).FirstOrDefault().DormitoryName;
            string RoomName = _roomTransRepository.List().ToList().Where(c => c.LanguageId == SendLanguageId && c.RoomNonTransId == booking.RoomId).FirstOrDefault().RoomName;
            string BookingCreateDate = booking.CreatedOn.ToString();
            string UserFirstName= _userManager.Users.ToList().Where(c=> c.Id==booking.UserId).FirstOrDefault().FirstName;
            string UserLastName = _userManager.Users.ToList().Where(c => c.Id == booking.UserId).FirstOrDefault().LastName;


            string UserFullName = UserFirstName +" "+ UserLastName;
            string ToAddress = UserEmail;
      
          
            var MessageTemplateName = Student_BookingCancellation;
            var EmailTokens = new List<Tokens>
                             {
                                  new Tokens {TokenName="%Booking.No%", TokenValue = BookingNo},
                                  new Tokens {TokenName="%Dormitory.Name%", TokenValue = DormitoryName},
                                  new Tokens {TokenName="%Room.Name%", TokenValue =RoomName},
                                  new Tokens {TokenName="%Booking.CreateDate%", TokenValue =BookingCreateDate},
                                  new Tokens {TokenName="%User.Firstname%", TokenValue =UserFirstName},
                                  new Tokens {TokenName="%User.LastName%", TokenValue =UserLastName}
                             };

            var MessageTemplate = _messageTemplateService.PrepareMessageTemplateForSending(MessageTemplateName, SendLanguageId);
            var message =
           new MessageQueue
           {
               ToAddress = ToAddress,
               ToName = UserFullName,
               IsSent = false,
               MaximumSentAttempts = 5,
               MessagePriority = 2,
               Subject = MessageTemplate.Subject,
               Body = MessageTemplate.Body,
               CreatedOn = DateTime.Now,
               SendImmediately = false,
               SendAttempts = 0
           };

            message.Body = _messageTemplateService.Tokenizer(message.Body, EmailTokens);
            message.Subject = _messageTemplateService.Tokenizer(message.Subject, EmailTokens);
            _messageQueueRepo.Insert(message);





            LogEvent(new EventLogger
            {EventName="Booking Cancelled event",
            EventDescription= "BookingCancelled.StudentNotification % Dormitory.Name %.Your Booking cancelled",
            EventParameters=""
            });
        }
        
        public void Trigger_BookingCompleted_StudentNotification_Event(long BookingId)
        {
            var SendLanguageId = 1;
            var booking = _bookingRepository.GetById(BookingId);
            if (booking == null) return;
            string UserEmail = _userManager.Users.ToList().Where(c => c.Id == booking.UserId).FirstOrDefault().Email;
            string BookingNo = booking.Id.ToString();
            string DormitoryName = _dormitoryTranslationRepository.List().ToList().Where(c => c.LanguageId == SendLanguageId && c.DormitoryNonTransId == _roomRepository.GetById(booking.RoomId).DormitoryId).FirstOrDefault().DormitoryName;
            string RoomName = _roomTransRepository.List().ToList().Where(c => c.LanguageId == SendLanguageId && c.RoomNonTransId == booking.RoomId).FirstOrDefault().RoomName;
            string BookingCreateDate = booking.CreatedOn.ToString();
            string UserFirstName = _userManager.Users.ToList().Where(c => c.Id == booking.UserId).FirstOrDefault().FirstName;
            string UserLastName = _userManager.Users.ToList().Where(c => c.Id == booking.UserId).FirstOrDefault().LastName;

            //need to create these in the database
            string DormitoryManagerName = "Musa Jahun";
            string DormitoryPhoneNumber = "+905338264432";
            string DormitoryEmail = "msjahun@live.com";
            

            string UserFullName = UserFirstName + " " + UserLastName;
            string ToAddress = UserEmail;
       
           
            var MessageTemplateName = Student_BookingCompleted;
            var EmailTokens = new List<Tokens>
                            {
                                new Tokens{TokenName="%Booking.No%", TokenValue =BookingNo },
                                new Tokens{TokenName="%Dormitory.Name%", TokenValue =DormitoryName},
                                new Tokens{TokenName="%Room.Name%", TokenValue =RoomName},
                                new Tokens{TokenName="%Booking.Date%", TokenValue =BookingCreateDate},
                                new Tokens{TokenName="%Dormitory.Managername%", TokenValue =DormitoryManagerName},
                                new Tokens{TokenName="%Dormitory.Name%", TokenValue =DormitoryName},
                                new Tokens{TokenName="%Dormitory.PhoneNumber%", TokenValue =DormitoryPhoneNumber},
                                new Tokens{TokenName="%Dormitory.Email%", TokenValue =DormitoryEmail},
                                new Tokens{TokenName="%User.Firstname%", TokenValue =UserFirstName},
                                new Tokens{TokenName="%User.LastName%", TokenValue =UserLastName}
                            };
            var MessageTemplate = _messageTemplateService.PrepareMessageTemplateForSending(MessageTemplateName, SendLanguageId);
            var message =
           new MessageQueue
           {
               ToAddress = ToAddress,
               ToName = UserFullName,
               IsSent = false,
               MaximumSentAttempts = 5,
               MessagePriority = 2,
               Subject = MessageTemplate.Subject,
               Body = MessageTemplate.Body,
               CreatedOn = DateTime.Now,
               SendImmediately = false,
               SendAttempts = 0
           };

            message.Body = _messageTemplateService.Tokenizer(message.Body, EmailTokens);
            message.Subject = _messageTemplateService.Tokenizer(message.Subject, EmailTokens);
            _messageQueueRepo.Insert(message);






            LogEvent(new EventLogger
            {EventName="Booking completed status change event",
            EventDescription= "BookingCompleted.StudentNotification % Dormitory.Name %.Your Booking completed",
            EventParameters=""
            });
        }
        
        public void Trigger_BookingPaid_StudentNotification_Event(long BookingId)
        {
            var SendLanguageId = 1;
            var booking = _bookingRepository.GetById(BookingId);
            if (booking == null) return;
            string UserEmail = _userManager.Users.ToList().Where(c => c.Id == booking.UserId).FirstOrDefault().Email;
            string BookingNo = booking.Id.ToString();
            string DormitoryName = _dormitoryTranslationRepository.List().ToList().Where(c => c.LanguageId == SendLanguageId && c.DormitoryNonTransId == _roomRepository.GetById(booking.RoomId).DormitoryId).FirstOrDefault().DormitoryName;
            string RoomName = _roomTransRepository.List().ToList().Where(c => c.LanguageId == SendLanguageId && c.RoomNonTransId == booking.RoomId).FirstOrDefault().RoomName;
            string BookingCreateDate = booking.CreatedOn.ToString();
            string UserFirstName = _userManager.Users.ToList().Where(c => c.Id == booking.UserId).FirstOrDefault().FirstName;
            string UserLastName = _userManager.Users.ToList().Where(c => c.Id == booking.UserId).FirstOrDefault().LastName;

            //need to create these in the database
            string DormitoryManagerName = "Musa Jahun";
            string DormitoryPhoneNumber = "+905338264432";
            string DormitoryEmail = "msjahun@live.com";



            string UserFullName = UserFirstName + " " + UserLastName;
            string ToAddress = UserEmail;

            var MessageTemplateName = Student_BookingPaid;
            var EmailTokens = new List<Tokens>
                            {
                            new Tokens {TokenName="%Booking.No%", TokenValue =BookingNo },
                            new Tokens {TokenName="%Dormitory.Name%", TokenValue =DormitoryName},
                            new Tokens {TokenName="%Room.Name%", TokenValue =RoomName},
                            new Tokens {TokenName="%Booking.ReceiptUploadStatus%", TokenValue =(string.IsNullOrEmpty(booking.ReceiptUrl)?"Not uploded": "Uploaded")},
                            new Tokens {TokenName="%Booking.DateOfBooking%", TokenValue =BookingCreateDate},
                            new Tokens {TokenName="%Dormitory.Managername%", TokenValue =DormitoryManagerName},
                            new Tokens {TokenName="%Dormitory.Name%", TokenValue =DormitoryName},
                            new Tokens {TokenName="%Dormitory.PhoneNumber%", TokenValue =DormitoryPhoneNumber},
                            new Tokens {TokenName="%Dormitory.Email%", TokenValue =DormitoryEmail},
                            new Tokens {TokenName="%User.Firstname%", TokenValue =UserFirstName},
                            new Tokens {TokenName="%User.LastName%", TokenValue =UserLastName}
                            };

            var MessageTemplate = _messageTemplateService.PrepareMessageTemplateForSending(MessageTemplateName, SendLanguageId);
            var message =
           new MessageQueue
           {
               ToAddress = ToAddress,
               ToName = UserFullName,
               IsSent = false,
               MaximumSentAttempts = 5,
               MessagePriority = 2,
               Subject = MessageTemplate.Subject,
               Body = MessageTemplate.Body,
               CreatedOn = DateTime.Now,
               SendImmediately = false,
               SendAttempts = 0
           };

            message.Body = _messageTemplateService.Tokenizer(message.Body, EmailTokens);
            message.Subject = _messageTemplateService.Tokenizer(message.Subject, EmailTokens);
            _messageQueueRepo.Insert(message);





            LogEvent(new EventLogger
            {EventName="Booking paid event student notification",
            EventDescription= "BookingPaid.StudentNotification % Dormitory.Name %.Booking #%Booking.BookingNumber% paid",
            EventParameters=""
            });
        }
        
        public void Trigger_BookingPaid_DormitoryNotification_Event(long BookingId)
        {
            var SendLanguageId = 1;
            var booking = _bookingRepository.GetById(BookingId);
            if (booking == null) return;
            string UserEmail = _userManager.Users.ToList().Where(c => c.Id == booking.UserId).FirstOrDefault().Email;
            string BookingNo = booking.Id.ToString();
            string DormitoryName = _dormitoryTranslationRepository.List().ToList().Where(c => c.LanguageId == SendLanguageId && c.DormitoryNonTransId == _roomRepository.GetById(booking.RoomId).DormitoryId).FirstOrDefault().DormitoryName;
            string RoomName = _roomTransRepository.List().ToList().Where(c => c.LanguageId == SendLanguageId && c.RoomNonTransId == booking.RoomId).FirstOrDefault().RoomName;
            string BookingCreateDate = booking.CreatedOn.ToString();
            string UserFirstName = _userManager.Users.ToList().Where(c => c.Id == booking.UserId).FirstOrDefault().FirstName;
            string UserLastName = _userManager.Users.ToList().Where(c => c.Id == booking.UserId).FirstOrDefault().LastName;
            string BookingStatus = _bookingStatusTransRepo.List().ToList().Where(c => c.LanguageId == SendLanguageId && c.BookingStatusNonTransId == booking.BookingStatusId).FirstOrDefault().BookingStatus;
            string PaymentStatus = _paymentStatusTransRepo.List().ToList().Where(c => c.LanguageId == SendLanguageId && c.PaymentStatusNonTransId == booking.PaymentStatusId).FirstOrDefault().PaymentStatus;


            //need to create these in the database
            string DormitoryManagerName = "Musa Jahun";
            string DormitoryPhoneNumber = "+905338264432";
            string DormitoryEmail = "msjahun@live.com";



            string UserFullName = DormitoryManagerName;
            string ToAddress = DormitoryEmail;
            var MessageTemplateName = DormitoryManager_BookingPaid;
            var EmailTokens = new List<Tokens>
                            {
                            new Tokens {TokenName ="%Booking.No%", TokenValue = BookingNo},
                            new Tokens {TokenName ="%Dormitory.Name%", TokenValue =DormitoryName},
                            new Tokens {TokenName ="%Room.Name%", TokenValue =RoomName},
                            new Tokens {TokenName ="%Booking.ReceiptUploadStatus%", TokenValue =(string.IsNullOrEmpty(booking.ReceiptUrl)?"Not uploded": "Uploaded")},
                            new Tokens {TokenName ="%Booking.DateOfBooking%", TokenValue =BookingCreateDate},
                            new Tokens {TokenName ="%Booking.BookingStatus%", TokenValue =BookingStatus},
                            new Tokens {TokenName ="%Booking.PaymentStatus%", TokenValue =PaymentStatus},
                            new Tokens {TokenName ="%User.Firstname%", TokenValue =UserFirstName},
                            new Tokens {TokenName ="%User.LastName%", TokenValue =UserLastName}
                            };
            var MessageTemplate = _messageTemplateService.PrepareMessageTemplateForSending(MessageTemplateName, SendLanguageId);
            var message =
           new MessageQueue
           {
               ToAddress = ToAddress,
               ToName = UserFullName,
               IsSent = false,
               MaximumSentAttempts = 5,
               MessagePriority = 2,
               Subject = MessageTemplate.Subject,
               Body = MessageTemplate.Body,
               CreatedOn = DateTime.Now,
               SendImmediately = false,
               SendAttempts = 0
           };

            message.Body = _messageTemplateService.Tokenizer(message.Body, EmailTokens);
            message.Subject = _messageTemplateService.Tokenizer(message.Subject, EmailTokens);
            _messageQueueRepo.Insert(message);





            LogEvent(new EventLogger
            {EventName="BookingPaid event DormitoryNotification",
            EventDescription= "BookingPaid.DormitoryNotification % Dormitory.Name %.Booking #%Booking.BookingNumber% paid",
            EventParameters= ""
            });
        }
        
        public void Trigger_BookingPlaced_StudentNotification_Event(long BookingId)
        {
            var SendLanguageId = 1;
            var booking = _bookingRepository.GetById(BookingId);
            if (booking == null) return;
            string UserEmail = _userManager.Users.ToList().Where(c => c.Id == booking.UserId).FirstOrDefault().Email;
            string UserStudentNumber = _userManager.Users.ToList().Where(c => c.Id == booking.UserId).FirstOrDefault().StudentNumber;
            string BookingNo = booking.Id.ToString();
            string DormitoryName = _dormitoryTranslationRepository.List().ToList().Where(c => c.LanguageId == SendLanguageId && c.DormitoryNonTransId == _roomRepository.GetById(booking.RoomId).DormitoryId).FirstOrDefault().DormitoryName;
            string RoomName = _roomTransRepository.List().ToList().Where(c => c.LanguageId == SendLanguageId && c.RoomNonTransId == booking.RoomId).FirstOrDefault().RoomName;
            string BookingCreateDate = booking.CreatedOn.ToString();
            string UserFirstName = _userManager.Users.ToList().Where(c => c.Id == booking.UserId).FirstOrDefault().FirstName;
            string UserLastName = _userManager.Users.ToList().Where(c => c.Id == booking.UserId).FirstOrDefault().LastName;
            string BookingStatus = _bookingStatusTransRepo.List().ToList().Where(c => c.LanguageId == SendLanguageId && c.BookingStatusNonTransId == booking.BookingStatusId).FirstOrDefault().BookingStatus;
            string PaymentStatus = _paymentStatusTransRepo.List().ToList().Where(c => c.LanguageId == SendLanguageId && c.PaymentStatusNonTransId == booking.PaymentStatusId).FirstOrDefault().PaymentStatus;
            var Dormitory = _dormitoryRepository.GetById(_roomRepository.GetById(booking.RoomId).DormitoryId);
            string BookingCancellationDate = DateTime.Now.AddDays(Dormitory.CancelWaitDays).ToString();
            //need to create these in the database
            string DormitoryManagerName = "Musa Jahun";
            string DormitoryPhoneNumber = "+905338264432";
            string DormitoryEmail = "msjahun@live.com";


            string UserFullName = UserFirstName + " " + UserLastName;
            string ToAddress = UserEmail;
            var MessageTemplateName = Student_BookingPlacedSuccessfully;
            var EmailTokens = new List<Tokens>
                           {
                                new Tokens {TokenName="%Booking.WaitDaysBeforeCancellation%", TokenValue=Dormitory.CancelWaitDays.ToString() },
                                new Tokens {TokenName="%Booking.No%", TokenValue=BookingNo},
                                new Tokens {TokenName="%Booking.CancellationDate%.", TokenValue=BookingCancellationDate},
                                new Tokens {TokenName="%Dormitory.Name%", TokenValue=DormitoryName},
                                new Tokens {TokenName="%Room.Name%", TokenValue=RoomName},
                                new Tokens {TokenName="%Booking.ReceiptUploadStatus%", TokenValue=(string.IsNullOrEmpty(booking.ReceiptUrl)?"Not uploded": "Uploaded")},
                                new Tokens {TokenName="%Booking.DateOfBooking%", TokenValue=BookingCreateDate},
                                new Tokens {TokenName="%Dormitory.Managername%", TokenValue=DormitoryManagerName},
                                new Tokens {TokenName="%Dormitory.PhoneNumber%", TokenValue=DormitoryPhoneNumber},
                                new Tokens {TokenName="%Dormitory.Email%", TokenValue=DormitoryEmail},
                                new Tokens {TokenName="%User.Firstname%", TokenValue=UserFirstName},
                                new Tokens {TokenName="%User.LastName%", TokenValue=UserLastName}
                           };
            var MessageTemplate = _messageTemplateService.PrepareMessageTemplateForSending(MessageTemplateName, SendLanguageId);
            var message =
           new MessageQueue
           {
               ToAddress = ToAddress,
               ToName = UserFullName,
               IsSent = false,
               MaximumSentAttempts = 5,
               MessagePriority = 2,
               Subject = MessageTemplate.Subject,
               Body = MessageTemplate.Body,
               CreatedOn = DateTime.Now,
               SendImmediately = false,
               SendAttempts = 0
           };

            message.Body = _messageTemplateService.Tokenizer(message.Body, EmailTokens);
            message.Subject = _messageTemplateService.Tokenizer(message.Subject, EmailTokens);
            _messageQueueRepo.Insert(message);




            LogEvent(new EventLogger
            {EventName="Booking Placed student notification",
            EventDescription= "BookingPlaced.StudentNotification Booking receipt from % Dormitory.Name %.",
            EventParameters=""
            });
        }
        
        public void Trigger_BookingPlaced_DormitoryNotification_Event(long BookingId)
        {

            var SendLanguageId = 1;
            var booking = _bookingRepository.GetById(BookingId);
            if (booking == null) return;
            string UserEmail = _userManager.Users.ToList().Where(c => c.Id == booking.UserId).FirstOrDefault().Email;
            string UserStudentNumber = _userManager.Users.ToList().Where(c => c.Id == booking.UserId).FirstOrDefault().StudentNumber;
            string BookingNo = booking.Id.ToString();
            string DormitoryName = _dormitoryTranslationRepository.List().ToList().Where(c => c.LanguageId == SendLanguageId && c.DormitoryNonTransId == _roomRepository.GetById(booking.RoomId).DormitoryId).FirstOrDefault().DormitoryName;
            string RoomName = _roomTransRepository.List().ToList().Where(c => c.LanguageId == SendLanguageId && c.RoomNonTransId == booking.RoomId).FirstOrDefault().RoomName;
            string BookingCreateDate = booking.CreatedOn.ToString();
            string UserFirstName = _userManager.Users.ToList().Where(c => c.Id == booking.UserId).FirstOrDefault().FirstName;
            string UserLastName = _userManager.Users.ToList().Where(c => c.Id == booking.UserId).FirstOrDefault().LastName;
            string BookingStatus = _bookingStatusTransRepo.List().ToList().Where(c => c.LanguageId == SendLanguageId && c.BookingStatusNonTransId == booking.BookingStatusId).FirstOrDefault().BookingStatus;
            string PaymentStatus = _paymentStatusTransRepo.List().ToList().Where(c => c.LanguageId == SendLanguageId && c.PaymentStatusNonTransId == booking.PaymentStatusId).FirstOrDefault().PaymentStatus;


            //need to create these in the database
            string DormitoryManagerName = "Musa Jahun";
            string DormitoryPhoneNumber = "+905338264432";
            string DormitoryEmail = "msjahun@live.com";



            string UserFullName = DormitoryManagerName;
            string ToAddress = DormitoryEmail;
            var MessageTemplateName = DormitoryManager_NewBookingAlert;
            var EmailTokens = new List<Tokens>
                            {
                                new Tokens {TokenName ="%Booking.No%", TokenValue =BookingNo},
                                new Tokens {TokenName ="%Dormitory.Name%", TokenValue =DormitoryName},
                                new Tokens {TokenName ="%Room.Name%", TokenValue =RoomName},
                                new Tokens {TokenName ="%Booking.ReceiptUploadStatus%", TokenValue =(string.IsNullOrEmpty(booking.ReceiptUrl)?"Not uploded": "Uploaded")},
                                new Tokens {TokenName ="%Booking.BookingDate%", TokenValue =BookingCreateDate},
                                new Tokens {TokenName ="%User.FirstName%", TokenValue =UserFirstName},
                                new Tokens {TokenName ="%User.LastName%", TokenValue =UserLastName},
                                new Tokens {TokenName ="%User.StudentNumber%", TokenValue =UserStudentNumber},
                                new Tokens {TokenName ="%Dormitory.Managername%", TokenValue =DormitoryManagerName},
                                new Tokens {TokenName ="%Dormitory.PhoneNumber%", TokenValue =DormitoryPhoneNumber},
                                new Tokens {TokenName ="%Dormitory.Email%", TokenValue =DormitoryEmail},
                            };
            var MessageTemplate = _messageTemplateService.PrepareMessageTemplateForSending(MessageTemplateName, SendLanguageId);
            var message =
           new MessageQueue
           {
               ToAddress = ToAddress,
               ToName = UserFullName,
               IsSent = false,
               MaximumSentAttempts = 5,
               MessagePriority = 2,
               Subject = MessageTemplate.Subject,
               Body = MessageTemplate.Body,
               CreatedOn = DateTime.Now,
               SendImmediately = false,
               SendAttempts = 0
           };

            message.Body = _messageTemplateService.Tokenizer(message.Body, EmailTokens);
            message.Subject = _messageTemplateService.Tokenizer(message.Subject, EmailTokens);
            _messageQueueRepo.Insert(message);







            LogEvent(new EventLogger
            {EventName="Bookingplaced dormitory notification",
            EventDescription= "BookingPlaced.DormitoryNotification % Dormitory.Name %.Booking placed",
            EventParameters=""
            });
        }
        
        public void Trigger_Room_RoomReview_Event(long ReviewId)
        {
            var SendLanguageId = 1;
            var Review = _reviewRepo.GetById(ReviewId);
            if (Review == null) return;

            string ReviewNo = Review.Id.ToString();
            string ReviewCreateDate = Review.CreatedOn.ToString();
            string ReviewText = Review.Message;
            string ReviewRatingNo = Review.Rating.ToString("N1");
           
         
            string UserEmail = _userManager.Users.ToList().Where(c => c.Id == Review.UserId).FirstOrDefault().Email;
            string UserStudentNumber = _userManager.Users.ToList().Where(c => c.Id == Review.UserId).FirstOrDefault().StudentNumber;
           
            string DormitoryName = _dormitoryTranslationRepository.List().ToList().Where(c => c.LanguageId == SendLanguageId && c.DormitoryNonTransId == Review.DormitoryId).FirstOrDefault().DormitoryName;
            
            string UserFirstName = _userManager.Users.ToList().Where(c => c.Id == Review.UserId).FirstOrDefault().FirstName;
            string UserLastName = _userManager.Users.ToList().Where(c => c.Id == Review.UserId).FirstOrDefault().LastName;
          

            //need to create these in the database
            string DormitoryManagerName = "Musa Jahun";
            string DormitoryPhoneNumber = "+905338264432";
            string DormitoryEmail = "msjahun@live.com";



            string UserFullName = DormitoryManagerName;
            string ToAddress = DormitoryEmail;

         
            var MessageTemplateName = DormitoryManager_NewReviewInDormitory;
            var EmailTokens = new List<Tokens>
                            {
                                new Tokens {TokenName ="%Dormitory.Name%", TokenValue =DormitoryName},
                                new Tokens {TokenName ="%Review.No%", TokenValue =ReviewNo},
                                new Tokens {TokenName ="%Review.RatingNo%", TokenValue =ReviewRatingNo},
                                new Tokens {TokenName ="%Review.CreatedDate%", TokenValue =ReviewCreateDate},
                                new Tokens {TokenName ="%User.StudentNo%", TokenValue =UserStudentNumber},
                                new Tokens {TokenName ="%User.Firstname%", TokenValue =UserFirstName},
                                new Tokens {TokenName ="%User.LastName%", TokenValue =UserLastName},
                                new Tokens {TokenName ="%User.Email%", TokenValue =UserEmail},
                                new Tokens {TokenName ="%Review.Text%", TokenValue =ReviewText},
                                new Tokens {TokenName ="%Dormitory.Email%", TokenValue =DormitoryEmail},
                            };
            var MessageTemplate = _messageTemplateService.PrepareMessageTemplateForSending(MessageTemplateName, SendLanguageId);
            var message =
           new MessageQueue
           {
               ToAddress = ToAddress,
               ToName = UserFullName,
               IsSent = false,
               MaximumSentAttempts = 5,
               MessagePriority = 2,
               Subject = MessageTemplate.Subject,
               Body = MessageTemplate.Body,
               CreatedOn = DateTime.Now,
               SendImmediately = false,
               SendAttempts = 0
           };

            message.Body = _messageTemplateService.Tokenizer(message.Body, EmailTokens);
            message.Subject = _messageTemplateService.Tokenizer(message.Subject, EmailTokens);
            _messageQueueRepo.Insert(message);




            LogEvent(new EventLogger
            {EventName="Room. review added Dormitory notification",
            EventDescription= "Room.RoomReview % Dormitory.Name %.New Room review. //only if you complete the review functionality	",
            EventParameters=""
            });
        }
        
        public void Trigger_RoomQuotaBelow_DormitoryManagerNotification_Event(long RoomId)
        {
            var SendLanguageId = 1;
            var Room = _roomRepository.GetById(RoomId);
            if (Room == null) return;
            string DormitoryName = _dormitoryTranslationRepository.List().ToList().Where(c => c.LanguageId == SendLanguageId && c.DormitoryNonTransId == _roomRepository.GetById(Room.Id).DormitoryId).FirstOrDefault().DormitoryName;
            string RoomName = _roomTransRepository.List().ToList().Where(c => c.LanguageId == SendLanguageId && c.RoomNonTransId == Room.Id).FirstOrDefault().RoomName;
          

            //need to create these in the database
            string DormitoryManagerName = "Musa Jahun";
            string DormitoryPhoneNumber = "+905338264432";
            string DormitoryEmail = "msjahun@live.com";



            string UserFullName = DormitoryManagerName;
            string ToAddress = DormitoryEmail;


            var MessageTemplateName = DormitoryManager_LowQuotaRoomAlert;
            var EmailTokens = new List<Tokens>
                             {
                                new Tokens {TokenName ="%Room.Name%", TokenValue =RoomName },
                                new Tokens {TokenName ="%Room.RemainingQuota%", TokenValue =Room.NoRoomQuota.ToString()},
                                new Tokens {TokenName ="%Dormitory.Name%", TokenValue =DormitoryName},
                                new Tokens {TokenName ="%Room.No%", TokenValue =Room.Id.ToString()},
                                new Tokens {TokenName ="%Dormitory.Email%", TokenValue =DormitoryEmail},
                                new Tokens {TokenName ="%Dormitory.Name%", TokenValue =DormitoryName}
                             };
            var MessageTemplate = _messageTemplateService.PrepareMessageTemplateForSending(MessageTemplateName, SendLanguageId);
            var message =
           new MessageQueue
           {
               ToAddress = ToAddress,
               ToName = UserFullName,
               IsSent = false,
               MaximumSentAttempts = 5,
               MessagePriority = 2,
               Subject = MessageTemplate.Subject,
               Body = MessageTemplate.Body,
               CreatedOn = DateTime.Now,
               SendImmediately = false,
               SendAttempts = 0
           };

            message.Body = _messageTemplateService.Tokenizer(message.Body, EmailTokens);
            message.Subject = _messageTemplateService.Tokenizer(message.Subject, EmailTokens);
            _messageQueueRepo.Insert(message);



            LogEvent(new EventLogger
            {EventName="Room Quota low dormitory notification",
            EventDescription= "//RoomQuotaBelow.DormitoryManagerNotification % Dormitory.Name %.Quota Quantity below notification. % Room.Name %",
            EventParameters=""
            });
        }
        
        public void Trigger_DormitoryInformationChange_DormitoryManagerNotification_Event(long DormitoryId)
        {
            var SendLanguageId = 1;
            var Dormitory = _dormitoryRepository.GetById(DormitoryId);
            if (Dormitory == null) return;
           string DormitoryName = _dormitoryTranslationRepository.List().ToList().Where(c => c.LanguageId == SendLanguageId && c.DormitoryNonTransId == DormitoryId).FirstOrDefault().DormitoryName;
            

          

            string AdministratorEmail = "mjahun@gmail.com";
            string AdministratorName = "Musa Jahun";
            string AdministratorLastName = "Jahun";
            string AdministratorFirstName = "Musa";
            string UserFullName = AdministratorName;
            string ToAddress = AdministratorEmail;

            var MessageTemplateName = Administrator_DormitoryInformationChangedAlert;
            var EmailTokens = new List<Tokens>
                            {
                                new Tokens {TokenName ="%Dormitory.Name%", TokenValue =DormitoryName },
                                new Tokens {TokenName ="%DormitoryId%", TokenValue =Dormitory.Id.ToString()},
                             
                                new Tokens {TokenName ="%Dormitory.UpdatedDate%", TokenValue =Dormitory.UpdatedOn.ToString()},
                                new Tokens {TokenName ="%User.Firstname%", TokenValue =AdministratorFirstName},
                                new Tokens {TokenName ="%User.LastName%", TokenValue =AdministratorLastName},
                                new Tokens {TokenName ="%Administrator.Email%", TokenValue =AdministratorEmail}
                            };
            var MessageTemplate = _messageTemplateService.PrepareMessageTemplateForSending(MessageTemplateName, SendLanguageId);
            var message =
           new MessageQueue
           {
               ToAddress = ToAddress,
               ToName = UserFullName,
               IsSent = false,
               MaximumSentAttempts = 5,
               MessagePriority = 2,
               Subject = MessageTemplate.Subject,
               Body = MessageTemplate.Body,
               CreatedOn = DateTime.Now,
               SendImmediately = false,
               SendAttempts = 0
           };

            message.Body = _messageTemplateService.Tokenizer(message.Body, EmailTokens);
            message.Subject = _messageTemplateService.Tokenizer(message.Subject, EmailTokens);
            _messageQueueRepo.Insert(message);





            LogEvent(new EventLogger
            {EventName="Dormitory information change notification",
            EventDescription= "DormitoryInformationChange.DormitoryManagerNotification % Dormitory.Name %.Dormitory information change.",
            EventParameters=""
            });
        }
        
        public void Trigger_NewStudent_Notification_Event(
            string UserId, 
            string UserStudentNumber,
            string UserFirstName,
            string UserLastName,
            string UserEmail,
            string UserAddress
            
            )
        {
            string AdministratorEmail = "mjahun@gmail.com";
            string AdministratorName = "Musa Jahun";
            string UserFullName = AdministratorName;
            string ToAddress = AdministratorEmail;
            var SendLanguageId = 1;
            var MessageTemplateName = Administrator_NewRegistration;
            var EmailTokens = new List<Tokens>
                             {
                                new Tokens {TokenName = "%User.Id%", TokenValue =UserId },
                                new Tokens {TokenName = "%User.StudentNumber%", TokenValue =UserStudentNumber},
                                new Tokens {TokenName = "%User.FirstName%", TokenValue =UserFirstName},
                                new Tokens {TokenName = "%User.LastName%", TokenValue =UserLastName},
                                new Tokens {TokenName = "%User.Email%", TokenValue =UserEmail},
                                new Tokens {TokenName = "%User.Address%", TokenValue =UserAddress},
                                new Tokens {TokenName = "%Admnistrator.Email%", TokenValue =AdministratorEmail}
                             };
            var MessageTemplate = _messageTemplateService.PrepareMessageTemplateForSending(MessageTemplateName, SendLanguageId);
            var message =
           new MessageQueue
           {
               ToAddress = ToAddress,
               ToName = UserFullName,
               IsSent = false,
               MaximumSentAttempts = 5,
               MessagePriority = 2,
               Subject = MessageTemplate.Subject,
               Body = MessageTemplate.Body,
               CreatedOn = DateTime.Now,
               SendImmediately = false,
               SendAttempts = 0
           };

            message.Body = _messageTemplateService.Tokenizer(message.Body, EmailTokens);
            message.Subject = _messageTemplateService.Tokenizer(message.Subject, EmailTokens);
            _messageQueueRepo.Insert(message);




            LogEvent(new EventLogger
            {EventName="New user registration notification",
            EventDescription= "NewStudent.Notification % Dormitory.Name %.New Student registration",
            EventParameters=""
            });
        }

        public void LogEvent(EventLogger logger)
        {
            if (logger != null)
            {
                logger.CreatedOn = DateTime.Now;
                _eventLoggerRepo.Insert(logger);
            }
        }

        public bool DeleteEvent (long Id)
        {
            try { 
            var _event = _eventLoggerRepo.GetById(Id);
            if (_event != null)
                _eventLoggerRepo.Delete(_event);
                LogEvent(new EventLogger
                {
                    EventName = "Delete event",
                    EventDescription = "Deleted an event",
                    EventParameters = ""
                });
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteAllEvents()
        {
            try
            {
                var _events = _eventLoggerRepo.List().ToList();
                if (_events != null) {
                    foreach(var evnt in _events)
                    {
                        _eventLoggerRepo.Delete(evnt);
                    }

                    LogEvent(new EventLogger
                    {
                        EventName = "Deleted all events",
                        EventDescription = "Deleted all  events",
                        EventParameters = ""
                    });

                }

                return true;
            }
            catch
            {
                return false;
            }

        }

        public List<EventLogger> GetAllEvents()
        {
            var events = from e in _eventLoggerRepo.List().ToList()
                         orderby e.CreatedOn descending
                         select e;
                return events.ToList();
        }


        

    }

}
