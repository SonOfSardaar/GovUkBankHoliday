using System.Collections.Generic;
using Newtonsoft.Json;

namespace Gov.UK.BankHolidayProvider.Beans
{
    public class GovDotUkBankHolidaysResponse
    {
        [JsonProperty("england-and-wales")]
        public DivisionEvents EnglandAndWales { get; set; }

        [JsonProperty("scotland")]
        public DivisionEvents Scotland { get; set; }

        [JsonProperty("northern-ireland")]
        public DivisionEvents NorthernIreland { get; set; }

        [JsonIgnore]
        public IEnumerable<DivisionEvents> AllDivisionEvents => new[] { EnglandAndWales, Scotland, NorthernIreland };
    }
}
