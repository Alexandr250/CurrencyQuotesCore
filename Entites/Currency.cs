using Newtonsoft.Json;
using System.Diagnostics;

namespace CurrencyQuotesCore.Entites {
    [DebuggerDisplay( "{Designation} : {Name}" )]
    public class Currency {
        [JsonProperty( "ID" )]
        public string Id { get; set; }

        [JsonProperty( "NumCode" )]
        public string Code { get; set; }

        [JsonProperty( "CharCode" )]
        public string Designation { get; set; }

        [JsonProperty( "Nominal" )]
        public int Nominal { get; set; }

        [JsonProperty( "Name" )]
        public string Name { get; set; }

        [JsonProperty( "Value" )]
        public double Value { get; set; }

        [JsonProperty( "Previous" )]
        public double PreviousValue { get; set; }
    }
}
