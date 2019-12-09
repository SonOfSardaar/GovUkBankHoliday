using System;
using System.Net.Http;
using System.Threading.Tasks;
using Gov.UK.BankHolidayProvider.Beans;
using Gov.UK.BankHolidayProvider.Models;

namespace Gov.UK.BankHolidayProvider.Services
{
    public sealed class GovDotUkBankHolidayService : IGovDotUkBankHolidayService
    {
        private const string DefaultBaseUrl = "https://www.gov.uk";

        private readonly HttpClient _httpClient;

        public GovDotUkBankHolidayService()
        {
            _httpClient=new HttpClient{BaseAddress=new Uri(DefaultBaseUrl)};
        }

        public GovDotUkBankHolidayService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            
            if (_httpClient.BaseAddress != null) return; 

            _httpClient.BaseAddress=new Uri(DefaultBaseUrl);
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
