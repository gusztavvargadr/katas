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
                public void ReturnsValue(string numbers, int expectedResult)
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
                public void ReturnsSum(string numbers, int expexctedResult)
                {
                    AssertResultEquals(numbers, expexctedResult);
                }
            }

            public class AnyNumbers : Add
            {
                [Theory]
                [InlineData("0,1,2", 3)]
                [InlineData("1,2,3", 6)]
                [InlineData("2,3,4", 9)]
                public void ReturnsSum(string numbers, int expexctedResult)
                {
                    AssertResultEquals(numbers, expexctedResult);
                }
            }

            public class NewLineSeparator : Add
            {
                [Theory]
                [InlineData("0,1\n2", 3)]
                [InlineData("1\n2,3", 6)]
                [InlineData("2\n3\n4", 9)]
                public void ReturnsSum(string numbers, int expexctedResult)
                {
                    AssertResultEquals(numbers, expexctedResult);
                }
            }


            public class CustomSeparator : Add
            {
                [Theory]
                [InlineData("//;\n0;1", 1)]
                [InlineData("//:\n1:2", 3)]
                [InlineData("//a\n2a3", 5)]
                public void ReturnsSum(string numbers, int expexctedResult)
                {
                    AssertResultEquals(numbers, expexctedResult);
                }
            }

            public class NegativeNumbers : Add
            {
                [Theory]
                [InlineData("-1")]
                [InlineData("1,-2")]
                [InlineData("1,-2,-3")]
                public void Throws(string numbers)
                {
                    var stringCalculator = new StringCalculator();

                    Assert.Throws<ArgumentOutOfRangeException>(() => stringCalculator.Add(numbers));
                }

                [Theory]
                [InlineData("-1")]
                [InlineData("1,-2")]
                [InlineData("1,-2,-3")]
                public void ExceptionMessageContainsError(string numbers)
                {
                    var stringCalculator = new StringCalculator();

                    var exception = Assert.Throws<ArgumentOutOfRangeException>(() => stringCalculator.Add(numbers));

                    Assert.Contains("negatives not allowed", exception.Message);
                }

                [Theory]
                [InlineData("-1", new[] {-1})]
                [InlineData("1,-2", new[] {-2})]
                [InlineData("1,-2,-3", new[] {-2, -3})]
                public void ExceptionMessageContainsNegativeNumbers(string numbers, int[] negativeNumbers)
                {
                    var stringCalculator = new StringCalculator();

                    var exception = Assert.Throws<ArgumentOutOfRangeException>(() => stringCalculator.Add(numbers));

                    Assert.All(negativeNumbers, item => Assert.Contains(item.ToString(), exception.Message));
                }
            }
        }
    }
}