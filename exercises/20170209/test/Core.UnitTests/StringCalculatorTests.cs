using System;
using Xunit;

namespace TddKata.UnitTests
{
    public class StringCalculatorTests
    {
        public class Add : StringCalculatorTests
        {
            // ReSharper disable once UnusedParameter.Local
            private static void AssertResultEquals(string numbers, int expectedResult)
            {
                var stringCalculator = new StringCalculator();

                var result = stringCalculator.Add(numbers);

                Assert.Equal(expectedResult, result);
            }

            public class EmptyString : Add
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
                public void ReturnsSingleNumber(string numbers, int expectedResult)
                {
                    AssertResultEquals(numbers, expectedResult);
                }
            }

            public class TwoNumbers : Add
            {
                [Theory]
                [InlineData("0,1", 1)]
                [InlineData("1,2", 3)]
                [InlineData("2,3", 5)]
                public void ReturnsSum(string numbers, int expectedResult)
                {
                    AssertResultEquals(numbers, expectedResult);
                }
            }

            public class AnyNumbers : Add
            {
                [Theory]
                [InlineData("0,1,2", 3)]
                [InlineData("1,2,3,4", 10)]
                [InlineData("2,3,4,5,6", 20)]
                public void ReturnsSum(string numbers, int expectedResult)
                {
                    AssertResultEquals(numbers, expectedResult);
                }
            }

            public class NewLineDelimiter : Add
            {
                [Theory]
                [InlineData("1\n2,3", 6)]
                [InlineData("1,2\n3", 6)]
                [InlineData("1\n2\n3", 6)]
                public void ReturnsSum(string numbers, int expectedResult)
                {
                    AssertResultEquals(numbers, expectedResult);
                }
            }

            public class CustomDelimiter : Add
            {
                [Theory]
                [InlineData("//;\n0;1", 1)]
                [InlineData("//:\n1:2:3", 6)]
                [InlineData("//a\n2a3a4", 9)]
                public void ReturnsSum(string numbers, int expectedResult)
                {
                    AssertResultEquals(numbers, expectedResult);
                }
            }

            public class NegativeNumbers : Add
            {
                [Theory]
                [InlineData("-1")]
                [InlineData("1,-2")]
                [InlineData("-1,-2")]
                public void Throws(string numbers)
                {
                    var stringCalculator = new StringCalculator();

                    Assert.Throws<ArgumentOutOfRangeException>(() => stringCalculator.Add(numbers));
                }

                [Theory]
                [InlineData("-1")]
                [InlineData("1,-2")]
                [InlineData("-1,-2")]
                public void ExceptionMessageContainsDescription(string numbers)
                {
                    try
                    {
                        var stringCalculator = new StringCalculator();

                        stringCalculator.Add(numbers);

                        Assert.True(false);
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        Assert.Contains("negatives not allowed", ex.Message);
                    }
                }

                [Theory]
                [InlineData("-1", new[] {-1})]
                [InlineData("1,-2", new[] {-2})]
                [InlineData("-1,-2", new[] {-1, -2})]
                public void ExceptionMessageContainsNegativesNumbers(string numbers, int[] negativeNumbers)
                {
                    try
                    {
                        var stringCalculator = new StringCalculator();

                        stringCalculator.Add(numbers);

                        Assert.True(false);
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        Assert.All(negativeNumbers, item => Assert.Contains(item.ToString(), ex.Message));
                    }
                }
            }
        }
    }
}