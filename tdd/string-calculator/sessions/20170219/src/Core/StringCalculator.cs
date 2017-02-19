using System.Linq;

namespace GusztavVargadDr.Katas.Tdd
{
    public class StringCalculator
    {
        private const int DefaultResult = 0;

        private const string CustomDelimiterMark = "//";
        private const char CustomDelimiterDelimiter = '\n';

        private static readonly char[] DefaultDelimiters = {',', '\n'};

        public StringCalculator()
        {
            Delimiters = DefaultDelimiters;
        }

        private char[] Delimiters { get; set; }

        public int Add(string numbers)
        {
            if (numbers == string.Empty)
                return DefaultResult;

            if (numbers.StartsWith(CustomDelimiterMark) && numbers[3] == CustomDelimiterDelimiter)
            {
                Delimiters = new[] {numbers[2]};
                numbers = numbers.Substring(4);
            }

            return numbers.Split(Delimiters).Sum(int.Parse);
        }
    }
}