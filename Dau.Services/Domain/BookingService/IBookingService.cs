namespace Dau.Services.Domain.BookingService
{
    public interface IBookingService
    {
        BookingCartViewModel GetCheckoutCartService();
        BookingCheckoutCustomerInfoViewModel GetCheckoutCustomerService();
        BookingCheckoutCustomerInfoViewModel GetCheckoutPaymentService();
        bool DeleteItemFromCart();
        bool AddToCart(long RoomId);
    }
}