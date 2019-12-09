using System.Collections.Generic;
using Newtonsoft.Json;

namespace Gov.UK.BankHolidayProvider.Beans
{
    public class DivisionEvents
    {
        [JsonProperty("division")]
        public GovDotUkBankHolidayDivision Division { get; set; }

        [JsonProperty("events")]
        public IEnumerable<BankHolidayEvent> Events { get; set; }
    }
}