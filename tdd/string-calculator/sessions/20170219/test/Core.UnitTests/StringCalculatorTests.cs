using Xunit;

namespace GusztavVargadDr.Katas.Tdd.UnitTests
{
    public class StringCalculatorTests
    {
        public class Add : StringCalculatorTests
        {
            public class EmptyString : Add
            {
                [Fact]
                public void RetunsZero()
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
                public void ReturnsNumber(string numbers, int number)
                {
                    var stringCalculator = new StringCalculator();

                    var result = stringCalculator.Add(numbers);

                    Assert.Equal(number, result);
                }
            }

            public class TwoNumbers : Add
            {
                [Theory]
                [InlineData("0,1", 1)]
                [InlineData("1,2", 3)]
                [InlineData("2,3", 5)]
                public void ReturnsSum(string numbers, int sum)
                {
                    var stringCalculator = new StringCalculator();

                    var result = stringCalculator.Add(numbers);

                    Assert.Equal(sum, result);
                }
            }
        }
    }
}