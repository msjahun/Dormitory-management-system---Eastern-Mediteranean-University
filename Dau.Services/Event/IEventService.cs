using System.Collections.Generic;
using Dau.Core.Event;

namespace Dau.Services.Event
{
    public interface IEventService
    {
        bool DeleteAllEvents();
        bool DeleteEvent(long Id);
        List<EventLogger> GetAllEvents();
        void LogEvent(EventLogger logger);
        void TriggerTestEvent();
        void Trigger_BookingCancelled_StudentNotification_Event();
        void Trigger_BookingCompleted_StudentNotification_Event();
        void Trigger_BookingPaid_DormitoryNotification_Event();
        void Trigger_BookingPaid_StudentNotification_Event();
        void Trigger_BookingPlaced_DormitoryManagerNotification_Event();
        void Trigger_BookingPlaced_DormitoryNotification_Event();
        void Trigger_BookingPlaced_StudentNotification_Event();
        void Trigger_DormitoryInformationChange_DormitoryManagerNotification_Event();
        void Trigger_NewStudent_Notification_Event();
        void Trigger_RoomQuotaBelow_DormitoryManagerNotification_Event();
        void Trigger_Room_RoomReview_Event();
        void Trigger_Student_BackInStock_Event();
        void Trigger_Student_EmailValidationMessage_Event();
        void Trigger_Student_WelcomeMessage_Event();
    }
}