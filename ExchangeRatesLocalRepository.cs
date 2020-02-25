using CurrencyQuotesCore.Entites;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyQuotesCore {
    public class ExchangeRatesLocalRepository : IExchangeRatesRepository {
        private ExchangeRates _exchangeRates;

        public ExchangeRates ExchangeRates {
            get {
                if ( _exchangeRates == null )
                    Update();

                return _exchangeRates;
            }
            set => _exchangeRates = value;
        }
        public FileInfo SourceFileInfo { get; set; }

        public ExchangeRatesLocalRepository( FileInfo sourceFileInfo ) => SourceFileInfo = sourceFileInfo;

        public async void Update() {
            if ( SourceFileInfo != null && SourceFileInfo.Exists ) {
                string json = await File.OpenText(SourceFileInfo.FullName).ReadToEndAsync();
                _exchangeRates = JsonConvert.DeserializeObject<ExchangeRates>( json );
            }
        }

        public IEnumerable<Currency> WithFilter( string filter ) {
            if (ExchangeRates == null)
                return null;

            if ( !string.IsNullOrEmpty( filter ) )
                return ExchangeRates.Currencies.Select( c => c.Value ).Where( c => c.Designation.ToLower().Contains( filter.ToLower() ) || c.Name.ToLower().Contains( filter.ToLower() ) );

            return ExchangeRates.Currencies.Select( c => c.Value );
        }
    }
}
