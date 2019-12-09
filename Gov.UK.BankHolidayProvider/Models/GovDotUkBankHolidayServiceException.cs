using System;

namespace Gov.UK.BankHolidayProvider.Models
{
    public sealed class GovDotUkBankHolidayServiceException : Exception
    {
        public GovDotUkBankHolidayServiceException(string message, Exception innerException):base(message, innerException){}
    }
}