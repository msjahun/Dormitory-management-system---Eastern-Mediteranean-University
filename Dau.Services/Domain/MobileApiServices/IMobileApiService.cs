using Dau.Core.Domain.API;
using System.Threading.Tasks;

namespace Dau.Services.Domain.MobileApiServices
{
    public interface IMobileApiService
    {
        RootObjectBookingByBookingId BookingByBookingIdService(long id);
        RootObjectFacilitiesFilter FacilitiesFilterService();
        RootObjectGetBooking GetBookingService(long id);
        RootObjectGetBookingsByCustomerId GetBookingsByCustomerIdService(string id);
        RootObjectGetDormitories GetDormitoriesService();
        RootObjectGetDormitoryDetailById GetDormitoryDetailByIdService(long id);
        RootObjectGetHighlyRatedDormitories GetHighlyRatedDormitoriesService();
        RootObjectGetMostPopularDormitories GetMostPopularDormitoriesService();
        RootObjectGetRoomByDormitoryId GetRoomByDormitoryIdService(long id);
        RootObjectGetRoomById GetRoomByIdService(long id);
        Task<RootObjectAuthentication> AuthenticationAsync();
        Task<RootObjectAuthentication> CreateUserAsync();
        //need to work on the following apis
        void CancelBookingService();
        void CreateBookingService();
        void EditBookingService();
        void GetCurrencyService();
        void GetSearchDormitoriesByFilterService();
        void GiveAppFeedBackService();
        void PaymentConfirmationService();
        void RateYourStayService();
        
    }
}