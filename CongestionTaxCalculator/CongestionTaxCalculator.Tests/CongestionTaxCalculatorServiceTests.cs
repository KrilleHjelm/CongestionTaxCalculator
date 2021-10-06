using CongestionTaxCalculator.API;
using Moq.AutoMock;
using System;
using Xunit;

namespace CongestionTaxCalculator.Tests
{
    public class CongestionTaxCalculatorServiceTests
    {
        readonly AutoMocker _mocker;
        readonly CongestionTaxCalculatorService _service;
        public CongestionTaxCalculatorServiceTests()
        {
            _mocker = new AutoMocker();
            _service = _mocker.CreateInstance<CongestionTaxCalculatorService>();
        }

        [Theory]
        [InlineData("2021-01-01", true)]
        [InlineData("2021-01-05", true)]
        [InlineData("2021-01-06", true)]
        [InlineData("2021-04-01", true)]
        [InlineData("2021-04-02", true)]
        [InlineData("2021-04-03", true)]
        [InlineData("2021-04-05", true)]
        [InlineData("2021-04-30", true)]
        [InlineData("2021-05-13", true)]
        [InlineData("2021-05-01", true)]
        [InlineData("2021-05-22", true)]
        [InlineData("2021-05-23", true)]
        [InlineData("2021-06-06", true)]
        [InlineData("2021-06-25", true)]
        [InlineData("2021-06-26", true)]
        [InlineData("2021-11-05", true)]
        [InlineData("2021-11-06", true)]
        [InlineData("2021-12-24", true)]
        [InlineData("2021-12-25", true)]
        [InlineData("2021-12-26", true)]
        [InlineData("2021-12-31", true)]
        [InlineData("2021-01-04", false)]
        [InlineData("2021-05-26", false)]
        [InlineData("2021-06-01", false)]
        public void IsTollFreeDate_Returns_Correct(string date, bool expectedValue)
        {
            var tollDate = DateTime.Parse(date);

            var result = _service.IsTollFreeDate(tollDate);

            Assert.Equal(expectedValue, result);
        }
    }
}
