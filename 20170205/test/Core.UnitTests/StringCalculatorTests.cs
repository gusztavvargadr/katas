using Xunit;

namespace TddKata.UnitTests
{
    public class StringCalculatorTests
    {
        public class Add
        {
            public class EmtpyString
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