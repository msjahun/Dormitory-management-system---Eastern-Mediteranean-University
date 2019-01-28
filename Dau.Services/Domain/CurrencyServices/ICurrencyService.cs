using System.Collections.Generic;

namespace Dau.Services.Domain.CurrencyServices
{
    public interface ICurrencyService
    {
        long AddCurrency(CurrencyCrud vm);
        bool DeleteCurrency(long Id);
        CurrencyCrud GetCurrencyById(long Id);
        bool MarkAsPrimaryExchangeRateCurrency(long Id);
        bool UpdateCurrency(CurrencyCrud vm);
         List<CurrenciesTable> GetCurrenciesTablesList();
        object GetDormitoryCurrencyCode(long id);
        string CurrencyFormatterByRoomId(long Id, double Amount);
        string CurrencyFormatterByRoomId(long Id, string Amount);
        string CurrencyFormatterByDormitoryId(long Id, double Amount);


    }
}