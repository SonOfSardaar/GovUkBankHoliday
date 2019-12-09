using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Gov.UK.BankHolidayProvider.Beans
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GovDotUkBankHolidayDivision
    {
        [EnumMember(Value="england-and-wales")]
        EnglandAndWales,

        [EnumMember(Value = "scotland")]
        Scotland,

        [EnumMember(Value="northern-ireland")]
        NorthernIreland
    }
}