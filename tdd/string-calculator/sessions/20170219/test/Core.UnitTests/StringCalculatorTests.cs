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

            private static void AssertThrows<T>(string numbers, Action<T> exceptionHandler = null) where T : Exception
            {
                var stringCalculator = new StringCalculator();

                var ex = Assert.ThrowsAny<T>(() => stringCalculator.Add(numbers));

                exceptionHandler?.Invoke(ex);
            }

            public class EmptyString : Add
            {
                [Fact]
                public void RetunsZero()
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

            public class MultipleNumbers : Add
            {
                [Theory]
                [InlineData("0,1,2", 3)]
                [InlineData("1,2,3,4", 10)]
                [InlineData("2,3,4,5,6", 20)]
                public void ReturnsSum(string numbers, int sum)
                {
                    AssertResultEquals(numbers, sum);
                }
            }

            public class NewLineDelimiter : Add
            {
                [Theory]
                [InlineData("0,1\n2", 3)]
                [InlineData("1\n2,3", 6)]
                [InlineData("2\n3\n4", 9)]
                public void ReturnsSum(string numbers, int sum)
                {
                    AssertResultEquals(numbers, sum);
                }
            }

            public class CustomDelimiter : Add
            {
                [Theory]
                [InlineData("//:\n0:1", 1)]
                [InlineData("//;\n1;2", 3)]
                [InlineData("///\n2/3", 5)]
                public void ReturnsSum(string numbers, int sum)
                {
                    AssertResultEquals(numbers, sum);
                }
            }

            public class NegativeNumbers : Add
            {
                [Theory]
                [InlineData("-1")]
                [InlineData("1,-2")]
                [InlineData("-2,-3")]
                public void ThrowsArgumentOutOfRange(string numbers)
                {
                    AssertThrows<ArgumentOutOfRangeException>(numbers);
                }

                [Theory]
                [InlineData("-1")]
                [InlineData("1,-2")]
                [InlineData("-2,-3")]
                public void ThrowsAndMessageContainsNegativesNotAllowedMessage(string numbers)
                {
                    AssertThrows<Exception>(numbers, ex => Assert.Contains("negatives not allowed", ex.Message));
                }

                [Theory]
                [InlineData("-1", new[] {-1})]
                [InlineData("1,-2", new[] {-2})]
                [InlineData("-2,-3", new[] {-2, -3})]
                public void ThrowsAndMessageContainsNegativeNumbers(string numbers, int[] negativeNumbers)
                {
                    AssertThrows<Exception>(numbers,
                        ex => Assert.All(negativeNumbers, item => Assert.Contains(item.ToString(), ex.Message)));
                }
            }

            public class NumbersBiggerThanThousand : Add
            {
                [Theory]
                [InlineData("1,1000", 1001)]
                [InlineData("2,1001", 2)]
                [InlineData("1001,1002", 0)]
                public void ReturnsSum(string numbers, int sum)
                {
                    AssertResultEquals(numbers, sum);
                }
            }
        }
    }
}