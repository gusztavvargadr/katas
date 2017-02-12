using System;
using Xunit;

namespace GusztavVargadDr.Katas.Tdd.UnitTests
{
    public class StringCalculatorTests
    {
        public class Add : StringCalculatorTests
        {
            // ReSharper disable once UnusedParameter.Local
            private static void AssertResultEquals(string numbers, int expectedResult)
            {
                var stringCalculator = new StringCalculator();

                var actualResult = stringCalculator.Add(numbers);

                Assert.Equal(expectedResult, actualResult);
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
                [InlineData("0,1\n2", 3)]
                [InlineData("1\n2,3", 6)]
                [InlineData("2\n3\n4", 9)]
                public void ReturnsSum(string numbers, int expectedResult)
                {
                    AssertResultEquals(numbers, expectedResult);
                }
            }

            public class CustomDelimiter : Add
            {
                [Theory]
                [InlineData("//:\n0:1", 1)]
                [InlineData("//;\n1;2;3", 6)]
                [InlineData("//a\n2a3a4a5", 14)]
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
                public void ThrowsArgumentOutOfRangeException(string numbers)
                {
                    var stringCalculator = new StringCalculator();

                    Assert.Throws<ArgumentOutOfRangeException>(() => stringCalculator.Add(numbers));
                }

                [Theory]
                [InlineData("-1")]
                [InlineData("1,-2")]
                [InlineData("-1,-2")]
                public void ExceptionMessageContainsNegativesNotAllowed(string numbers)
                {
                    var stringCalculator = new StringCalculator();

                    var ex = Assert.ThrowsAny<Exception>(() => stringCalculator.Add(numbers));

                    Assert.Contains("negatives not allowed", ex.Message);
                }

                [Theory]
                [InlineData("-1", new[] {-1})]
                [InlineData("1,-2", new[] {-2})]
                [InlineData("-1,-2", new[] {-1, -2})]
                public void ExceptionMessageContainsNegativesNumbers(string numbers, int[] negativeNumbers)
                {
                    var stringCalculator = new StringCalculator();

                    var ex = Assert.ThrowsAny<Exception>(() => stringCalculator.Add(numbers));

                    Assert.All(negativeNumbers, item => Assert.Contains(item.ToString(), ex.Message));
                }
            }
        }
    }
}