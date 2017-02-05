using System;
using Xunit;

namespace TddKata.UnitTests
{
    public class StringCalculatorTests
    {
        public class Add : StringCalculatorTests
        {
            // ReSharper disable once UnusedParameter.Local
            private static void AssertResultEquals(string numbers, int sum)
            {
                var stringCalculator = new StringCalculator();

                var result = stringCalculator.Add(numbers);

                Assert.Equal(sum, result);
            }

            public class EmtpyString : Add
            {
                [Fact]
                public void ReturnsZero()
                {
                    AssertResultEquals(string.Empty, 0);
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
                    AssertResultEquals(numbers, number);
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
                    AssertResultEquals(numbers, sum);
                }
            }

            public class AnyNumbers : Add
            {
                [Theory]
                [InlineData("0,1,2", 3)]
                [InlineData("1,2,3", 6)]
                [InlineData("2,3,4", 9)]
                [InlineData("0,1,2,3", 6)]
                [InlineData("1,2,3,4", 10)]
                [InlineData("2,3,4,5", 14)]
                public void ReturnsSum(string numbers, int sum)
                {
                    AssertResultEquals(numbers, sum);
                }
            }

            public class NewLineDelimiter : Add
            {
                [Theory]
                [InlineData("0\n1,2", 3)]
                [InlineData("1,2\n3", 6)]
                [InlineData("2\n3\n4", 9)]
                public void ReturnsSum(string numbers, int sum)
                {
                    AssertResultEquals(numbers, sum);
                }

                [Theory]
                [InlineData("1,\n")]
                public void ThrowsForMultipleDelimiters(string numbers)
                {
                    var stringCalculator = new StringCalculator();

                    Assert.ThrowsAny<Exception>(() => stringCalculator.Add(numbers));
                }
            }

            public class CustomDelimiter : Add
            {
                [Theory]
                [InlineData("//;\n0;1", 1)]
                [InlineData("//:\n1:2", 3)]
                [InlineData("//a\n2a3", 5)]
                public void ReturnsSum(string numbers, int sum)
                {
                    AssertResultEquals(numbers, sum);
                }
            }
        }
    }
}