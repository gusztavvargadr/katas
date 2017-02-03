using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddKata;
using Xunit;

namespace TddKata.UnitTests
{
    public class StringCalculatorTests
    {
        public class Add
        {
            [Theory]
            [InlineData(null, 0)]
            [InlineData("", 0)]
            public void ReturnsSum(string numbers, int sum)
            {
                var stringCalculator = new StringCalculator();

                var result = stringCalculator.Add(numbers);

                Assert.Equal(sum, result);
            }
        }
    }
}
