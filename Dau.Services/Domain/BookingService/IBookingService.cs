using System;
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
        int BusinessDaysUntil(DateTime firstDay, DateTime lastDay, params DateTime[] Holidays);
        ReservationEdit GetBookingById(long BookingId);
        bool ChangeBookingStatus(long bookingId, long newBookingStatusId);
        bool ChangePaymentStatus(long bookingId, long newpaymentStatusId);
        Charts GetBookingsChartById(long id);
        List<BookingAccountVM> GetUserBookings(string userId);
        bool UpdateSemesterPeriod(long id);
    }
}