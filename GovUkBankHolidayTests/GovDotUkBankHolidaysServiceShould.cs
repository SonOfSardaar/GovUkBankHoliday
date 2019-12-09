using System;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Gov.UK.BankHolidayProvider.Services;
using NUnit.Framework;

namespace GovUkBankHolidayTests
{
    public sealed class GovDotUkBankHolidaysServiceShould
    {
        [Test]
        public async Task GetListOfBankHolidaysWhenNoHttpClientIsSuppliedAsync()
        {
            var service=new GovDotUkBankHolidayService();
            var result = await service.GetBankHolidaysAsync();
            result.Should().NotBeNull();
            result.EnglandAndWales.Should().NotBeNull();
            result.EnglandAndWales.Events.Should().NotBeEmpty();
        }

        [Test]
        public async Task GetListOfBankHolidaysWhenHttpClientIsSuppliedAsync()
        {
            var service=new GovDotUkBankHolidayService(new HttpClient());
            var result = await service.GetBankHolidaysAsync();
            result.Should().NotBeNull();
            result.EnglandAndWales.Should().NotBeNull();
            result.EnglandAndWales.Events.Should().NotBeEmpty();
        }

        [Test]
        public async Task GetListOfBankHolidaysWhenHttpClientIsSuppliedWithUrlAsync()
        {
            var service=new GovDotUkBankHolidayService(new HttpClient{BaseAddress=new Uri("https://www.gov.uk")});
            var result = await service.GetBankHolidaysAsync();
            result.Should().NotBeNull();
            result.EnglandAndWales.Should().NotBeNull();
            result.EnglandAndWales.Events.Should().NotBeEmpty();
        }
    }
}