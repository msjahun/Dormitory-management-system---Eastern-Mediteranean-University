namespace Dau.Services.Domain.PriceCalculationService
{
    public interface IPriceCalculationService
    {
        double CalculateBookingTotal(bool IsPricePerYear, long SemesterPeriodId, double Price);
    }
}