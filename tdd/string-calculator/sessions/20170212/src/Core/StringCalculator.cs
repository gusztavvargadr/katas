using System.Linq;

namespace GusztavVargadDr.Katas.Tdd
{
    public class StringCalculator
    {
        private const int DefaultResult = 0;
        private const string CustomNumberDelimiterMark = "//";
        private const char CustomnumberDelimiterDelimiter = '\n';
        private static readonly char[] DefaultNumberDelimiters = {',', '\n'};

        public StringCalculator()
        {
            NumberDelimiters = DefaultNumberDelimiters;
        }

        private char[] NumberDelimiters { get; set; }

        public int Add(string numbers)
        {
            if (numbers == string.Empty)
                return DefaultResult;

            if (numbers.StartsWith(CustomNumberDelimiterMark) && numbers[3] == CustomnumberDelimiterDelimiter)
            {
                NumberDelimiters = new[] {numbers[2]};
                numbers = numbers.Substring(4);
            }

            return numbers.Split(NumberDelimiters).Sum(int.Parse);
        }
    }
}