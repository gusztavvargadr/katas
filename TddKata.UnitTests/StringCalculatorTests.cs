﻿using Xunit;

namespace TddKata.UnitTests
{
    public class StringCalculatorTests
    {
        public class Add
        {
            // ReSharper disable once UnusedParameter.Local
            private static void AssertAdd(string numbers, int expectedSum)
            {
                var stringCalculator = new StringCalculator();

                var actualSum = stringCalculator.Add(numbers);

                Assert.Equal(expectedSum, actualSum);
            }

            public class EmptyString : Add
            {
                [Fact]
                public void ReturnsZero()
                {
                    AssertAdd(string.Empty, 0);
                }
            }

            public class SingleNumber : Add
            {
                [Theory]
                [InlineData("0", 0)]
                [InlineData("1", 1)]
                [InlineData("2", 2)]
                public void ReturnsSingleNumber(string numbers, int expectedSum)
                {
                    AssertAdd(numbers, expectedSum);
                }
            }

            public class TwoNumbers : Add
            {
                [Theory]
                [InlineData("0,1", 1)]
                [InlineData("1,2", 3)]
                [InlineData("2,3", 5)]
                public void ReturnsSum(string numbers, int expectedSum)
                {
                    AssertAdd(numbers, expectedSum);
                }
            }
        }
    }
}