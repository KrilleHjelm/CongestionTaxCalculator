using CongestionTaxCalculator.API;
using CongestionTaxCalculator.API.Utilities;
using Moq.AutoMock;
using System;
using Xunit;

namespace CongestionTaxCalculator.Tests
{
    public class DateCalculatorTests
    {
        [Fact]
        public void GetFirstSundayOfNextMonth_Returns_CorrectDate()
        {
            var dateMiddleOfWeek = new DateTime(2021, 10, 5);
            var expectedDate = new DateTime(2021, 11, 7);

            var result = DateCalculator.GetFirstSundayOfNextMonth(dateMiddleOfWeek);

            Assert.Equal(expectedDate, result);
        }
        [Fact]
        public void GetAscensionDayDate_Returns_CorrectDate()
        {
            var monthBeforeEaster = new DateTime(2021, 03, 15);
            var easterDate = DateCalculator.GetFirstSundayOfNextMonth(monthBeforeEaster);
            var expectedDate = new DateTime(2021, 05, 13);

            var result = DateCalculator.GetAscensionDayDate(easterDate);

            Assert.Equal(expectedDate, result);
        }
        [Fact]
        public void GetPentecostDayDate_Returns_CorrectDate()
        {
            var monthBeforeEaster = new DateTime(2021, 03, 15);
            var easterDate = DateCalculator.GetFirstSundayOfNextMonth(monthBeforeEaster);
            var expectedDate = new DateTime(2021, 05, 23);

            var result = DateCalculator.GetPentecostDayDate(easterDate);

            Assert.Equal(expectedDate, result);
        }
        [Fact]
        public void GetMidsummerDate_Returns_CorrectDate()
        {
            var expectedDate = new DateTime(2021, 06, 26);

            var result = DateCalculator.GetMidsummerDate(new DateTime(2021, 04, 03));

            Assert.Equal(expectedDate, result);
        }
        [Fact]
        public void GetAllSaintsDayDate_Returns_CorrectDate()
        {
            var expectedDate = new DateTime(2021, 11, 6);

            var result = DateCalculator.GetAllSaintsDayDate(new DateTime(2021, 04, 03));

            Assert.Equal(expectedDate, result);
        }
    }
}
