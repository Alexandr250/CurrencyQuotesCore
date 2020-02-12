using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyQuotesCore.Entites {
    public class ExchangeRates {
        [JsonProperty( "Date" )]
        public DateTime CurrentDate { get; set; }

        [JsonProperty( "PreviousDate" )]
        public DateTime PreviousDate { get; set; }

        [JsonProperty( "PreviousURL" )]
        public string PreviousUrl { get; set; }

        [JsonProperty( "Timestamp" )]
        public DateTime Timestamp { get; set; }

        [JsonProperty( "Valute" )]
        public Dictionary<string, Currency> Currencies { get; set; }
    }
}
