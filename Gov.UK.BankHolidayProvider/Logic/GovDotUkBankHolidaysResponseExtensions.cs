using System;
using System.Linq;
using Gov.UK.BankHolidayProvider.Beans;

namespace Gov.UK.BankHolidayProvider.Logic
{
    public static class GovDotUkBankHolidaysResponseExtensions
    {
        public static bool IsBankHoliday(this GovDotUkBankHolidaysResponse bankHolidaysResponse, RegionalDivision division, DateTime? dateTime)
        {
            var fallsOnBankHoliday = bankHolidaysResponse.AllDivisionEvents.Any(x =>
            {
                return  x?.Division == division && x.Events.Any(e => e.Date == dateTime);
            });
            
            return fallsOnBankHoliday;
        }
    }
}