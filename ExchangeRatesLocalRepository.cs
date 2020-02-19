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

        public void Update() {
            if ( SourceFileInfo != null && SourceFileInfo.Exists ) {
                _exchangeRates = JsonConvert.DeserializeObject<ExchangeRates>( File.ReadAllText( SourceFileInfo.FullName, Encoding.UTF8 ) );
            }
        }

        public IEnumerable<Currency> WithFilter( string filter ) {            
            if ( !string.IsNullOrEmpty( filter ) && ExchangeRates != null )
                return ExchangeRates.Currencies.Select( c => c.Value ).Where( c => c.Designation.ToLower().Contains( filter.ToLower() ) || c.Name.ToLower().Contains( filter.ToLower() ) );

            return ExchangeRates.Currencies.Select( c => c.Value );
        }
    }
}
