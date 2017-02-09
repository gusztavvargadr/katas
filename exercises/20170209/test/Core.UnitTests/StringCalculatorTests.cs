﻿using Xunit;

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
        }
    }
}