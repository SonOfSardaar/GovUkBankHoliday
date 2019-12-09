using System;
using System.Threading.Tasks;
using FluentAssertions;
using Gov.UK.BankHolidayProvider.Beans;
using Gov.UK.BankHolidayProvider.Logic;
using Gov.UK.BankHolidayProvider.Services;
using NUnit.Framework;

namespace GovUkBankHolidayTests
{
    public sealed class GovDotUkBankHolidayResponseExtensionsShould
    {
        private readonly GovDotUkBankHolidayService _service;

        public GovDotUkBankHolidayResponseExtensionsShould()
        {
            _service=new GovDotUkBankHolidayService();
        }

        [TestCase("25 Dec", true)]
        [TestCase("01 Jan", true)]
        [TestCase("15 Jan", false)]
        public async Task ReturnTrueOrFalseBaseOnWhenGivenDateIsBankHolidayOrNotAsync(string testDateWithoutYear, bool isExpectedBankHoliday)
        {
            var testDate = DateTime.Parse($"{testDateWithoutYear} {DateTime.Now.Year}");
            var response = await _service.GetBankHolidaysAsync();
            var isBankHoliday = response.IsBankHoliday(GovDotUkBankHolidayDivision.EnglandAndWales, testDate);
            isBankHoliday.Should().Be(isExpectedBankHoliday);
        }
    }
}