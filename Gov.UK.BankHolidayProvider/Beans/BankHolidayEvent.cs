using System;

namespace Gov.UK.BankHolidayProvider.Beans
{
    public sealed class BankHolidayEvent
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
    }
}