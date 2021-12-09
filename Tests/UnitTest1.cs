using System;
using WebApplication1;
using Xunit;

namespace Tests
{
    public class EasterDateTests
    {
        [Theory]
        [InlineData(2021, "02.05.2021")]
        [InlineData(2020, "19.04.2020")]
        [InlineData(2022, "24.04.2022")]
        [InlineData(2008, "27.04.2008")]
        [InlineData(532,  "24.04.0532")]
        [InlineData(2027, "02.05.2027")]
        [InlineData(2024, "05.05.2024")]
        public void TestEasterDate(int year, string response)
        {
            EasterDateCalculator dateCalculator = new EasterDateCalculator();

            Assert.Equal(response, dateCalculator.CalculateEasterDate(year).ToString("d"));
        }
    }
}
