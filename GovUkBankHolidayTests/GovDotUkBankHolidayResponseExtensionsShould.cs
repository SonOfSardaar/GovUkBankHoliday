using System;
using System.Threading.Tasks;
using FluentAssertions;
using Gov.UK.BankHolidayProvider.Beans;
using Gov.UK.BankHolidayProvider.Logic;
using Gov.UK.BankHolidayProvider.Services;
using NSubstitute;
using NUnit.Framework;

namespace GovUkBankHolidayTests
{
    public sealed class GovDotUkBankHolidayResponseExtensionsShould
    {
        private readonly IGovDotUkBankHolidayService _service;

        public GovDotUkBankHolidayResponseExtensionsShould()
        {
            _service=Substitute.For<IGovDotUkBankHolidayService>();
        }

        [TestCase("26 Dec", true)]
        [TestCase("15 Jan", false)]
        public async Task ReturnTrueOrFalseBaseOnWhenGivenDateIsBankHolidayOrNotAsync(string testDateWithoutYear, bool isExpectedBankHoliday)
        {
            var testDate = DateTime.Parse($"{testDateWithoutYear} {2022}");
            var expectedResponse = new GovDotUkBankHolidaysResponse
            {
                EnglandAndWales = new DivisionEvents
                {
                    Division = GovDotUkBankHolidayDivision.EnglandAndWales,
                    Events = new[] { new BankHolidayEvent { Date= testDate,Title = "NA" } } 
                }
            };

            if(isExpectedBankHoliday)  _service.GetBankHolidaysAsync().Returns(expectedResponse);

            var response = await _service.GetBankHolidaysAsync();
            var isBankHoliday = response.IsBankHoliday(GovDotUkBankHolidayDivision.EnglandAndWales, testDate);
            isBankHoliday.Should().Be(isExpectedBankHoliday);
        }
    }
}