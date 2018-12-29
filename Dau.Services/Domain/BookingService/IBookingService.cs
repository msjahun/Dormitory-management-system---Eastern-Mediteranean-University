using System.Collections.Generic;

namespace Dau.Services.Domain.BookingService
{
    public interface IBookingService
    {
        BookingCartViewModel GetCheckoutCartService();
        BookingCheckoutCustomerInfoViewModel GetCheckoutCustomerService();
        BookingCheckoutCustomerInfoViewModel GetCheckoutPaymentService();
        bool DeleteItemFromCart();
        bool AddToCart(long RoomId);
        int GetTotalNumberOfBookings();
        int GetTotalNumberOfCancelRequests();
        List<ReservationListTable> GetBookingTableList();
        List<LatestBookingsTable> GetLatestBookingsDashboardList();
        bool AddBooking();
    }
}