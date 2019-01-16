using Dau.Core.Domain.System;
using Dau.Core.Event;
using Dau.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dau.Services.Event
{
    public class EventService : IEventService
    {
        private IRepository<EventLogger> _eventLoggerRepo;
        private readonly IRepository<MessageQueue> _messageQueueRepo;

        public EventService(IRepository<EventLogger> eventLoggerRepo,
            IRepository<MessageQueue> messageQueueRepo
            )
        {
            _eventLoggerRepo = eventLoggerRepo;
            _messageQueueRepo = messageQueueRepo;
        }

        public void TriggerTestEvent()
        {
            string UserFullName = "Musa Jahun";
            string ToAddress = "mjahun@gmail.com";
            var message =
           new MessageQueue
           {
               ToAddress = ToAddress,
               ToName = UserFullName,
               IsSent = false,
               MaximumSentAttempts = 5,
               MessagePriority = 2,

               Subject = "Verification token ",
               Body = "<h3>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <ins>&nbsp;</ins><strong><ins>Room Is now available&nbsp;</ins>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</strong></h3>" +
                        "<p><strong>Alfam dormitory</strong>&#39;s <strong>Single Room</strong> is now back in stock more quota has been added to the room.</p>" +
                        "<p>You will now be able to book for the Dormitory.</p>" +
                        "<p>Thank you</p>" +
                        "<p><br />" +
                        "Kind Regards,<br />" +
                        "<strong>Dormitory Booking Team</strong></p>" +
                        "<p>Sent to Musa Jahun</p>",
               CreatedOn = DateTime.Now,
               SendImmediately = false,
               SendAttempts = 0
           };

            _messageQueueRepo.Insert(message);


            LogEvent(new EventLogger
            {EventName="Added testing event",
            EventDescription="Added some cool testing event",
            EventParameters="Json of some parameter or something"
            });
        }


        public void Trigger_Student_BackInStock_Event()
        {


            string UserFullName = "Musa Jahun";
            string ToAddress = "mjahun@gmail.com";
            var message =
           new MessageQueue
           {
               ToAddress = ToAddress,
               ToName = UserFullName,
               IsSent = false,
               MaximumSentAttempts = 5,
               MessagePriority = 2,

               Subject = "Verification token ",
               Body = "<h3>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <ins>&nbsp;</ins><strong><ins>Room Is now available&nbsp;</ins>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</strong></h3>" +
                        "<p><strong>Alfam dormitory</strong>&#39;s <strong>Single Room</strong> is now back in stock more quota has been added to the room.</p>" +
                        "<p>You will now be able to book for the Dormitory.</p>" +
                        "<p>Thank you</p>" +
                        "<p><br />" +
                        "Kind Regards,<br />" +
                        "<strong>Dormitory Booking Team</strong></p>" +
                        "<p>Sent to Musa Jahun</p>",
               CreatedOn = DateTime.Now,
               SendImmediately = false,
               SendAttempts = 0
           };

            _messageQueueRepo.Insert(message);


            LogEvent(new EventLogger
            {EventName="Student RoomBackInStock event",
            EventDescription= "Student.BackInStock Room back in stock % Dormitory.Name % //quota added",
            EventParameters=""
            });
        }
        
        public void Trigger_Student_EmailValidationMessage_Event()
        {
            string UserFullName = "Musa Jahun";
            string ToAddress = "mjahun@gmail.com";
            var message =
           new MessageQueue
           {
               ToAddress = ToAddress,
               ToName = UserFullName,
               IsSent = false,
               MaximumSentAttempts = 5,
               MessagePriority = 2,

               Subject = "Verification token ",
               Body =
               "<h2><img src=\"https://dormitories.emu.edu.tr/_layouts/emu/images/logo/emu-logo-horizontalblue-en.png?ver=1\" />&nbsp; &nbsp; &nbsp; &nbsp; <strong>&nbsp;Email Activation<strong>&nbsp; </strong> </strong></h2>" +
                 "<p>Thank you for registering an account with EMU Dormitory Booking System</p>" +
                "<p>Please use this link to verify your email address.</p>" +
                "<p><a href=\"#\">Verification link</a></p>" +
                "<p>Thank you</p>" +
                "<p><br />" +
                "Kind Regards,<br />" +
                "<strong>Dormitory Booking Team</strong></p>" +
                "<p>Sent to Musa Jahun</p>",
               CreatedOn = DateTime.Now,
               SendImmediately = false,
               SendAttempts = 0
           };

            _messageQueueRepo.Insert(message);





            LogEvent(new EventLogger
            {EventName="Student emailValidationMessage event",
            EventDescription= "Student.EmailValidationMessage % Dormitory.Name % Email Activation",
            EventParameters=""
            });
        }
        
        public void Trigger_Student_WelcomeMessage_Event()
        {


            string UserFullName = "Musa Jahun";
            string ToAddress = "mjahun@gmail.com";
            var message =
           new MessageQueue
           {
               ToAddress = ToAddress,
               ToName = UserFullName,
               IsSent = false,
               MaximumSentAttempts = 5,
               MessagePriority = 2,

               Subject = "Verification token ",
               Body = "<h2><img src=\"https://dormitories.emu.edu.tr/_layouts/emu/images/logo/emu-logo-horizontalblue-en.png?ver=1\" />&nbsp; &nbsp; &nbsp; &nbsp; <strong>&nbsp; <ins>Welcome To EMU Dormitory Booking System</ins><strong>&nbsp;&nbsp;</strong> </strong></h2>"+
"<h3>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<strong>&nbsp;Welcome to EMU Dormitory Booking System<strong>&nbsp;&nbsp;</strong>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</strong></h3>"+
"<p>Thank you for registering an account with EMU Dormitory Booking System</p>"+
"<p>Now that your registered these are the things you&#39;ll be able to do on the system</p>"+
"<ul><li>Book for dormitories</li>"+
"	<li>Manage previous bookings</li>"+
"	<li>Get tons of discounts and deals and so much more</li>"+
"</ul>"+
"<p>Thank you</p>"+
"<p><br />"+
"Kind Regards,<br />"+
"<strong>Dormitory Booking Team</strong></p>"+
"<p>Sent to Musa Jahun</p>",
               CreatedOn = DateTime.Now,
               SendImmediately = false,
               SendAttempts = 0
           };

            _messageQueueRepo.Insert(message);







            LogEvent(new EventLogger
            {EventName="Welcome messsage event(new student created)",
            EventDescription= "Student.WelcomeMessage Welcome to emu Booking system",
            EventParameters=""
            });
        }
        
        public void Trigger_BookingCancelled_StudentNotification_Event()
        {

            string UserFullName = "Musa Jahun";
            string ToAddress = "mjahun@gmail.com";
            var message =
           new MessageQueue
           {
               ToAddress = ToAddress,
               ToName = UserFullName,
               IsSent = false,
               MaximumSentAttempts = 5,
               MessagePriority = 2,

               Subject = "Verification token ",
               Body = "<h3>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <ins>&nbsp;</ins><strong><ins>Room Is now available&nbsp;</ins>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</strong></h3>" +
                        "<p><strong>Alfam dormitory</strong>&#39;s <strong>Single Room</strong> is now back in stock more quota has been added to the room.</p>" +
                        "<p>You will now be able to book for the Dormitory.</p>" +
                        "<p>Thank you</p>" +
                        "<p><br />" +
                        "Kind Regards,<br />" +
                        "<strong>Dormitory Booking Team</strong></p>" +
                        "<p>Sent to Musa Jahun</p>",
               CreatedOn = DateTime.Now,
               SendImmediately = false,
               SendAttempts = 0
           };

            _messageQueueRepo.Insert(message);





            LogEvent(new EventLogger
            {EventName="Booking Cancelled event",
            EventDescription= "BookingCancelled.StudentNotification % Dormitory.Name %.Your Booking cancelled",
            EventParameters=""
            });
        }
        
        public void Trigger_BookingCompleted_StudentNotification_Event()
        {



            string UserFullName = "Musa Jahun";
            string ToAddress = "mjahun@gmail.com";
            var message =
           new MessageQueue
           {
               ToAddress = ToAddress,
               ToName = UserFullName,
               IsSent = false,
               MaximumSentAttempts = 5,
               MessagePriority = 2,

               Subject = "Verification token ",
               Body = "<h3>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <ins>&nbsp;</ins><strong><ins>Room Is now available&nbsp;</ins>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</strong></h3>" +
                        "<p><strong>Alfam dormitory</strong>&#39;s <strong>Single Room</strong> is now back in stock more quota has been added to the room.</p>" +
                        "<p>You will now be able to book for the Dormitory.</p>" +
                        "<p>Thank you</p>" +
                        "<p><br />" +
                        "Kind Regards,<br />" +
                        "<strong>Dormitory Booking Team</strong></p>" +
                        "<p>Sent to Musa Jahun</p>",
               CreatedOn = DateTime.Now,
               SendImmediately = false,
               SendAttempts = 0
           };

            _messageQueueRepo.Insert(message);





            LogEvent(new EventLogger
            {EventName="Booking completed status change event",
            EventDescription= "BookingCompleted.StudentNotification % Dormitory.Name %.Your Booking completed",
            EventParameters=""
            });
        }
        
        public void Trigger_BookingPaid_StudentNotification_Event()
        {


            string UserFullName = "Musa Jahun";
            string ToAddress = "mjahun@gmail.com";
            var message =
           new MessageQueue
           {
               ToAddress = ToAddress,
               ToName = UserFullName,
               IsSent = false,
               MaximumSentAttempts = 5,
               MessagePriority = 2,

               Subject = "Verification token ",
               Body = "<h3>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <ins>&nbsp;</ins><strong><ins>Room Is now available&nbsp;</ins>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</strong></h3>" +
                        "<p><strong>Alfam dormitory</strong>&#39;s <strong>Single Room</strong> is now back in stock more quota has been added to the room.</p>" +
                        "<p>You will now be able to book for the Dormitory.</p>" +
                        "<p>Thank you</p>" +
                        "<p><br />" +
                        "Kind Regards,<br />" +
                        "<strong>Dormitory Booking Team</strong></p>" +
                        "<p>Sent to Musa Jahun</p>",
               CreatedOn = DateTime.Now,
               SendImmediately = false,
               SendAttempts = 0
           };

            _messageQueueRepo.Insert(message);



            LogEvent(new EventLogger
            {EventName="Booking paid event student notification",
            EventDescription= "BookingPaid.StudentNotification % Dormitory.Name %.Booking #%Booking.BookingNumber% paid",
            EventParameters=""
            });
        }
        
        public void Trigger_BookingPaid_DormitoryNotification_Event()
        {

           string UserFullName = "Musa Jahun";
            string ToAddress = "mjahun@gmail.com";
            var message =
           new MessageQueue
           {
               ToAddress = ToAddress,
               ToName = UserFullName,
               IsSent = false,
               MaximumSentAttempts = 5,
               MessagePriority = 2,

               Subject = "Verification token ",
               Body = "<h3>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <ins>&nbsp;</ins><strong><ins>Room Is now available&nbsp;</ins>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</strong></h3>" +
                        "<p><strong>Alfam dormitory</strong>&#39;s <strong>Single Room</strong> is now back in stock more quota has been added to the room.</p>" +
                        "<p>You will now be able to book for the Dormitory.</p>" +
                        "<p>Thank you</p>" +
                        "<p><br />" +
                        "Kind Regards,<br />" +
                        "<strong>Dormitory Booking Team</strong></p>" +
                        "<p>Sent to Musa Jahun</p>",
               CreatedOn = DateTime.Now,
               SendImmediately = false,
               SendAttempts = 0
           };

            _messageQueueRepo.Insert(message);




            LogEvent(new EventLogger
            {EventName="BookingPaid event DormitoryNotification",
            EventDescription= "BookingPaid.DormitoryNotification % Dormitory.Name %.Booking #%Booking.BookingNumber% paid",
            EventParameters= ""
            });
        }
        
        public void Trigger_BookingPlaced_StudentNotification_Event()
        {

            //
            string UserFullName = "Musa Jahun";
            string ToAddress = "mjahun@gmail.com";
            var message =
           new MessageQueue
           {
               ToAddress = ToAddress,
               ToName = UserFullName,
               IsSent = false,
               MaximumSentAttempts = 5,
               MessagePriority = 2,

               Subject = "Verification token ",
               Body = "<h3>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <ins>&nbsp;</ins><strong><ins>Room Is now available&nbsp;</ins>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</strong></h3>" +
                        "<p><strong>Alfam dormitory</strong>&#39;s <strong>Single Room</strong> is now back in stock more quota has been added to the room.</p>" +
                        "<p>You will now be able to book for the Dormitory.</p>" +
                        "<p>Thank you</p>" +
                        "<p><br />" +
                        "Kind Regards,<br />" +
                        "<strong>Dormitory Booking Team</strong></p>" +
                        "<p>Sent to Musa Jahun</p>",
               CreatedOn = DateTime.Now,
               SendImmediately = false,
               SendAttempts = 0
           };

            _messageQueueRepo.Insert(message);



            LogEvent(new EventLogger
            {EventName="Booking Placed student notification",
            EventDescription= "BookingPlaced.StudentNotification Booking receipt from % Dormitory.Name %.",
            EventParameters=""
            });
        }
        
        public void Trigger_BookingPlaced_DormitoryManagerNotification_Event()
        {


            string UserFullName = "Musa Jahun";
            string ToAddress = "mjahun@gmail.com";
            var message =
           new MessageQueue
           {
               ToAddress = ToAddress,
               ToName = UserFullName,
               IsSent = false,
               MaximumSentAttempts = 5,
               MessagePriority = 2,

               Subject = "Verification token ",
               Body = "<h3>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <ins>&nbsp;</ins><strong><ins>Room Is now available&nbsp;</ins>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</strong></h3>" +
                        "<p><strong>Alfam dormitory</strong>&#39;s <strong>Single Room</strong> is now back in stock more quota has been added to the room.</p>" +
                        "<p>You will now be able to book for the Dormitory.</p>" +
                        "<p>Thank you</p>" +
                        "<p><br />" +
                        "Kind Regards,<br />" +
                        "<strong>Dormitory Booking Team</strong></p>" +
                        "<p>Sent to Musa Jahun</p>",
               CreatedOn = DateTime.Now,
               SendImmediately = false,
               SendAttempts = 0
           };

            _messageQueueRepo.Insert(message);





            LogEvent(new EventLogger
            {EventName="Booking placed dormitory manager notification",
            EventDescription= "BookingPlaced.DormitoryManagerNotification % Dormitory.Name %.Purchase Receipt for Booking #%Booking.BookingNumber%	",
            EventParameters=""
            });
        }
        
        public void Trigger_BookingPlaced_DormitoryNotification_Event()
        {



            string UserFullName = "Musa Jahun";
            string ToAddress = "mjahun@gmail.com";
            var message =
           new MessageQueue
           {
               ToAddress = ToAddress,
               ToName = UserFullName,
               IsSent = false,
               MaximumSentAttempts = 5,
               MessagePriority = 2,

               Subject = "Verification token ",
               Body = "<h3>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <ins>&nbsp;</ins><strong><ins>Room Is now available&nbsp;</ins>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</strong></h3>" +
                        "<p><strong>Alfam dormitory</strong>&#39;s <strong>Single Room</strong> is now back in stock more quota has been added to the room.</p>" +
                        "<p>You will now be able to book for the Dormitory.</p>" +
                        "<p>Thank you</p>" +
                        "<p><br />" +
                        "Kind Regards,<br />" +
                        "<strong>Dormitory Booking Team</strong></p>" +
                        "<p>Sent to Musa Jahun</p>",
               CreatedOn = DateTime.Now,
               SendImmediately = false,
               SendAttempts = 0
           };

            _messageQueueRepo.Insert(message);





            LogEvent(new EventLogger
            {EventName="Bookingplaced dormitory notification",
            EventDescription= "BookingPlaced.DormitoryNotification % Dormitory.Name %.Booking placed",
            EventParameters=""
            });
        }
        
        public void Trigger_Room_RoomReview_Event()
        {


            string UserFullName = "Musa Jahun";
            string ToAddress = "mjahun@gmail.com";
            var message =
           new MessageQueue
           {
               ToAddress = ToAddress,
               ToName = UserFullName,
               IsSent = false,
               MaximumSentAttempts = 5,
               MessagePriority = 2,

               Subject = "Verification token ",
               Body = "<h3>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <ins>&nbsp;</ins><strong><ins>Room Is now available&nbsp;</ins>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</strong></h3>" +
                        "<p><strong>Alfam dormitory</strong>&#39;s <strong>Single Room</strong> is now back in stock more quota has been added to the room.</p>" +
                        "<p>You will now be able to book for the Dormitory.</p>" +
                        "<p>Thank you</p>" +
                        "<p><br />" +
                        "Kind Regards,<br />" +
                        "<strong>Dormitory Booking Team</strong></p>" +
                        "<p>Sent to Musa Jahun</p>",
               CreatedOn = DateTime.Now,
               SendImmediately = false,
               SendAttempts = 0
           };

            _messageQueueRepo.Insert(message);




            LogEvent(new EventLogger
            {EventName="Room. review added Dormitory notification",
            EventDescription= "Room.RoomReview % Dormitory.Name %.New Room review. //only if you complete the review functionality	",
            EventParameters=""
            });
        }
        
        public void Trigger_RoomQuotaBelow_DormitoryManagerNotification_Event()
        {



            string UserFullName = "Musa Jahun";
            string ToAddress = "mjahun@gmail.com";
            var message =
           new MessageQueue
           {
               ToAddress = ToAddress,
               ToName = UserFullName,
               IsSent = false,
               MaximumSentAttempts = 5,
               MessagePriority = 2,

               Subject = "Verification token ",
               Body = "<h3>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <ins>&nbsp;</ins><strong><ins>Room Is now available&nbsp;</ins>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</strong></h3>" +
                        "<p><strong>Alfam dormitory</strong>&#39;s <strong>Single Room</strong> is now back in stock more quota has been added to the room.</p>" +
                        "<p>You will now be able to book for the Dormitory.</p>" +
                        "<p>Thank you</p>" +
                        "<p><br />" +
                        "Kind Regards,<br />" +
                        "<strong>Dormitory Booking Team</strong></p>" +
                        "<p>Sent to Musa Jahun</p>",
               CreatedOn = DateTime.Now,
               SendImmediately = false,
               SendAttempts = 0
           };

            _messageQueueRepo.Insert(message);



            LogEvent(new EventLogger
            {EventName="Room Quota low dormitory notification",
            EventDescription= "//RoomQuotaBelow.DormitoryManagerNotification % Dormitory.Name %.Quota Quantity below notification. % Room.Name %",
            EventParameters=""
            });
        }
        
        public void Trigger_DormitoryInformationChange_DormitoryManagerNotification_Event()
        {

            string UserFullName = "Musa Jahun";
            string ToAddress = "mjahun@gmail.com";
            var message =
           new MessageQueue
           {
               ToAddress = ToAddress,
               ToName = UserFullName,
               IsSent = false,
               MaximumSentAttempts = 5,
               MessagePriority = 2,

               Subject = "Verification token ",
               Body = "<h3>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <ins>&nbsp;</ins><strong><ins>Room Is now available&nbsp;</ins>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</strong></h3>" +
                        "<p><strong>Alfam dormitory</strong>&#39;s <strong>Single Room</strong> is now back in stock more quota has been added to the room.</p>" +
                        "<p>You will now be able to book for the Dormitory.</p>" +
                        "<p>Thank you</p>" +
                        "<p><br />" +
                        "Kind Regards,<br />" +
                        "<strong>Dormitory Booking Team</strong></p>" +
                        "<p>Sent to Musa Jahun</p>",
               CreatedOn = DateTime.Now,
               SendImmediately = false,
               SendAttempts = 0
           };

            _messageQueueRepo.Insert(message);



            LogEvent(new EventLogger
            {EventName="Dormitory information change notification",
            EventDescription= "DormitoryInformationChange.DormitoryManagerNotification % Dormitory.Name %.Dormitory information change.",
            EventParameters=""
            });
        }
        
        public void Trigger_NewStudent_Notification_Event()
        {

            string UserFullName = "Musa Jahun";
            string ToAddress = "mjahun@gmail.com";
            var message =
           new MessageQueue
           {
               ToAddress = ToAddress,
               ToName = UserFullName,
               IsSent = false,
               MaximumSentAttempts = 5,
               MessagePriority = 2,

               Subject = "Verification token ",
               Body = "<h3>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <ins>&nbsp;</ins><strong><ins>Room Is now available&nbsp;</ins>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</strong></h3>" +
                        "<p><strong>Alfam dormitory</strong>&#39;s <strong>Single Room</strong> is now back in stock more quota has been added to the room.</p>" +
                        "<p>You will now be able to book for the Dormitory.</p>" +
                        "<p>Thank you</p>" +
                        "<p><br />" +
                        "Kind Regards,<br />" +
                        "<strong>Dormitory Booking Team</strong></p>" +
                        "<p>Sent to Musa Jahun</p>",
               CreatedOn = DateTime.Now,
               SendImmediately = false,
               SendAttempts = 0
           };

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
