using CurrencyQuotesCore.Entites;
using System.Collections.Generic;

namespace CurrencyQuotesCore
{
    public interface IExchangeRatesRepository {
        ExchangeRates ExchangeRates { get; set; }
        void Update();
        IEnumerable<Currency> WithFilter( string filter );
    }
}