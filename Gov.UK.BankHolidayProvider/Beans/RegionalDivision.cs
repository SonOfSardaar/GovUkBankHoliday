using Newtonsoft.Json;

namespace Gov.UK.BankHolidayProvider.Beans
{
    public enum RegionalDivision
    {
        [JsonProperty("england-and-wales")]
        EnglandAndWales,

        [JsonProperty("scotland")]
        Scotland,

        [JsonProperty("northern-ireland")]
        NorthernIreland
    }
}