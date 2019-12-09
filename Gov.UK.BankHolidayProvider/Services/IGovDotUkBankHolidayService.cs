using System;
using System.Threading.Tasks;
using Gov.UK.BankHolidayProvider.Beans;

namespace Gov.UK.BankHolidayProvider.Services
{
    public interface IGovDotUkBankHolidayService
    {
        Task<GovDotUkBankHolidaysResponse> GetBankHolidaysAsync();
    }
}