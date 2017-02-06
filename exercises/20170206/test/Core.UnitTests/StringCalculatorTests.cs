using Xunit;

namespace TddKata.UnitTests
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
        }
    }
}