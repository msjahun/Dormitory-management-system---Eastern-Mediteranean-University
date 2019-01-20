using System.Collections.Generic;
using Dau.Core.Event;

namespace Dau.Services.Event
{
    public interface IEventService
    {
        bool DeleteAllEvents();
        bool DeleteEvent(long Id);
        List<EventLogTable> GetAllEvents();
        void LogEvent(EventLogger logger);
        void TriggerTestEvent();
        void Trigger_BookingCancelled_StudentNotification_Event(long BookingId);
        void Trigger_BookingCompleted_StudentNotification_Event(long BookingId);
        void Trigger_BookingPaid_DormitoryNotification_Event(long BookingId);
        void Trigger_BookingPaid_StudentNotification_Event(long BookingId);
      //  void Trigger_BookingPlaced_DormitoryManagerNotification_Event();
        void Trigger_BookingPlaced_DormitoryNotification_Event(long BookingId);
        void Trigger_BookingPlaced_StudentNotification_Event(long BookingId);
        void Trigger_DormitoryInformationChange_DormitoryManagerNotification_Event(long DormitoryId);
        void Trigger_NewStudent_Notification_Event(
                  string UserId,
                  string UserStudentNumber,
                  string UserFirstName,
                  string UserLastName,
                  string UserEmail,
                  string UserAddress

                  );
        void Trigger_RoomQuotaBelow_DormitoryManagerNotification_Event(long RoomId);
        void Trigger_Room_RoomReview_Event(long ReviewId);
        void Trigger_Student_BackInStock_Event(long RoomId);
         void Trigger_Student_EmailValidationMessage_Event(
            string UserEmail, string UserFirstName, string UserLastName, string UserVerificationLink);

        void Trigger_Student_WelcomeMessage_Event(
            string UserEmail, string UserFirstName, string UserLastName);
       


    }
}