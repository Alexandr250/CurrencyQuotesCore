using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CurrencyQuotesCore.Entites;
using Newtonsoft.Json;

namespace CurrencyQuotesCore {
    public class ExchangeRatesRepository : IExchangeRatesRepository {
        private ExchangeRates _exchangeRates;
        private string _exchangeRatesUrl;

        public ExchangeRates ExchangeRates {
            get {
                if ( _exchangeRates == null )
                    Update();

                return _exchangeRates;
            }
            set => _exchangeRates = value;
        }

        public ExchangeRatesRepository( string ratesUrl ) => _exchangeRatesUrl = ratesUrl;

        public void Update() {
            if ( _exchangeRatesUrl != null ) {
                WebClient webClient = new WebClient() {
                    Encoding = Encoding.UTF8
                };

                _exchangeRates = JsonConvert.DeserializeObject<ExchangeRates>( webClient.DownloadString( _exchangeRatesUrl ) );
            }
        }

        public IEnumerable<Currency> WithFilter( string filter ) {
            return string.IsNullOrEmpty( filter ) ? ExchangeRates.Currencies.Select( c => c.Value ).Where( c => c.Designation.Contains( filter ) || c.Name.Contains( filter ) ) : ExchangeRates.Currencies.Select( c => c.Value ) ;
        }
    }
}
