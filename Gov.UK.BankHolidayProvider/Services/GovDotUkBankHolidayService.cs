using System;
using System.Net.Http;
using System.Threading.Tasks;
using Gov.UK.BankHolidayProvider.Beans;
using Gov.UK.BankHolidayProvider.Models;

namespace Gov.UK.BankHolidayProvider.Services
{
    public sealed class GovDotUkBankHolidayService : IBankHolidayService
    {
        private readonly HttpClient _httpClient;

        public GovDotUkBankHolidayService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            if(_httpClient.BaseAddress==null) _httpClient.BaseAddress=new Uri("https://www.gov.uk");
        }

        public async Task<GovDotUkBankHolidaysResponse> GetBankHolidaysAsync()
        {
            var response = await _httpClient.GetAsync("bank-holidays.json");

            if (!response.IsSuccessStatusCode) 
                throw new GovDotUkBankHolidayServiceException($"could not obtain good response from {response.RequestMessage.RequestUri}", null);

            var bankHolidays = await response.Content.ReadAsAsync<GovDotUkBankHolidaysResponse>();
            return bankHolidays;
        }
    }
}
