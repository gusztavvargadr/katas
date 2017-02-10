using Xunit;

namespace GusztavVargadDr.Tdd.Katas.UnitTests
{
    public class StringCalculatorTests
    {
        public class Add : StringCalculatorTests
        {
            public class EmptyString : Add
            {
                [Fact]
                public void ReturnsZero()
                {
                    var stringCalculator = new StringCalculator();

                    var result = stringCalculator.Add(string.Empty);

                    Assert.Equal(0, result);
                }
            }

            public class SingleNumber : Add
            {
                [Theory]
                [InlineData("0", 0)]
                [InlineData("1", 1)]
                [InlineData("2", 2)]
                public void ReturnsSingleNumber(string numbers, int expectedResult)
                {
                    var stringCalculator = new StringCalculator();

                    var result = stringCalculator.Add(numbers);

                    Assert.Equal(expectedResult, result);
                }
            }
        }
    }
}