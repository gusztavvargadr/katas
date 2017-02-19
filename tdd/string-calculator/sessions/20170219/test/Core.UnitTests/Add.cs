using GusztavVargadDr.Katas.Tdd;
using Xunit;

static internal class Add
{
    private static void AssertResultEquals(string numbers, int expectedResult)
    {
        var stringCalculator = new StringCalculator();

        var actualResult = stringCalculator.Add(numbers);

        Assert.Equal(expectedResult, actualResult);
    }
}