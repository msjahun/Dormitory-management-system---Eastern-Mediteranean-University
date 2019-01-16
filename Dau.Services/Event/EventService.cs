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

        public EventService(IRepository<EventLogger> eventLoggerRepo)
        {
            _eventLoggerRepo = eventLoggerRepo;
        }

        public void TriggerTestEvent()
        {

            LogEvent(new EventLogger
            {EventName="Added testing event",
            EventDescription="Added some cool testing event",
            EventParameters="Json of some parameter or something"
            });
        }


        public void Trigger_Student_BackInStock_Event()
        {
               
             



            LogEvent(new EventLogger
            {EventName="Student RoomBackInStock event",
            EventDescription= "Student.BackInStock Room back in stock % Dormitory.Name % //quota added",
            EventParameters=""
            });
        }
        
        public void Trigger_Student_EmailValidationMessage_Event()
        {
             		
                
                
              


            LogEvent(new EventLogger
            {EventName="Student emailValidationMessage event",
            EventDescription= "Student.EmailValidationMessage % Dormitory.Name % Email Activation",
            EventParameters=""
            });
        }
        
        public void Trigger_Student_WelcomeMessage_Event()
        {
                
                
                
                
                
                




            LogEvent(new EventLogger
            {EventName="Welcome messsage event(new student created)",
            EventDescription= "Student.WelcomeMessage Welcome to emu Booking system",
            EventParameters=""
            });
        }
        
        public void Trigger_BookingCancelled_StudentNotification_Event()
        {
                
                
                
                
               


            LogEvent(new EventLogger
            {EventName="Booking Cancelled event",
            EventDescription= "BookingCancelled.StudentNotification % Dormitory.Name %.Your Booking cancelled",
            EventParameters=""
            });
        }
        
        public void Trigger_BookingCompleted_StudentNotification_Event()
        {
                
                
                
              
                
                



            LogEvent(new EventLogger
            {EventName="Booking completed status change event",
            EventDescription= "BookingCompleted.StudentNotification % Dormitory.Name %.Your Booking completed",
            EventParameters=""
            });
        }
        
        public void Trigger_BookingPaid_StudentNotification_Event()
        {
                
                		
                



            LogEvent(new EventLogger
            {EventName="Booking paid event student notification",
            EventDescription= "BookingPaid.StudentNotification % Dormitory.Name %.Booking #%Booking.BookingNumber% paid",
            EventParameters=""
            });
        }
        
        public void Trigger_BookingPaid_DormitoryNotification_Event()
        {
                
                //	
               



            LogEvent(new EventLogger
            {EventName="BookingPaid event DormitoryNotification",
            EventDescription= "BookingPaid.DormitoryNotification % Dormitory.Name %.Booking #%Booking.BookingNumber% paid",
            EventParameters= ""
            });
        }
        
        public void Trigger_BookingPlaced_StudentNotification_Event()
        {
               
                //
                



            LogEvent(new EventLogger
            {EventName="Booking Placed student notification",
            EventDescription= "BookingPlaced.StudentNotification Booking receipt from % Dormitory.Name %.",
            EventParameters=""
            });
        }
        
        public void Trigger_BookingPlaced_DormitoryManagerNotification_Event()
        {
                
                	
               
              




            LogEvent(new EventLogger
            {EventName="Booking placed dormitory manager notification",
            EventDescription= "BookingPlaced.DormitoryManagerNotification % Dormitory.Name %.Purchase Receipt for Booking #%Booking.BookingNumber%	",
            EventParameters=""
            });
        }
        
        public void Trigger_BookingPlaced_DormitoryNotification_Event()
        {
               
                
                
                
                




            LogEvent(new EventLogger
            {EventName="Bookingplaced dormitory notification",
            EventDescription= "BookingPlaced.DormitoryNotification % Dormitory.Name %.Booking placed",
            EventParameters=""
            });
        }
        
        public void Trigger_Room_RoomReview_Event()
        {
               
                
                
        



            LogEvent(new EventLogger
            {EventName="Room. review added Dormitory notification",
            EventDescription= "Room.RoomReview % Dormitory.Name %.New Room review. //only if you complete the review functionality	",
            EventParameters=""
            });
        }
        
        public void Trigger_RoomQuotaBelow_DormitoryManagerNotification_Event()
        {
                
                
                




            LogEvent(new EventLogger
            {EventName="Room Quota low dormitory notification",
            EventDescription= "//RoomQuotaBelow.DormitoryManagerNotification % Dormitory.Name %.Quota Quantity below notification. % Room.Name %",
            EventParameters=""
            });
        }
        
        public void Trigger_DormitoryInformationChange_DormitoryManagerNotification_Event()
        { 
               




            LogEvent(new EventLogger
            {EventName="Dormitory information change notification",
            EventDescription= "DormitoryInformationChange.DormitoryManagerNotification % Dormitory.Name %.Dormitory information change.",
            EventParameters=""
            });
        }
        
        public void Trigger_NewStudent_Notification_Event()
        {
                
                




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
