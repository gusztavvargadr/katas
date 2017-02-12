using System;
using System.Linq;

namespace GusztavVargadDr.Katas.Tdd
{
    public class StringCalculator
    {
        private const int DefaultResult = 0;

        private const string CustomNumberDelimiterMark = "//";
        private const char CustomnumberDelimiterDelimiter = '\n';

        private const string NegativesNotAllowedMessage = "negatives not allowed";
        private const string NegativeNumberSeparator = ", ";

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

            var items = numbers.Split(NumberDelimiters).Select(int.Parse).ToList();
            var negativeItems = items.Where(item => item < 0).ToList();
            if (negativeItems.Any())
                throw new ArgumentOutOfRangeException(nameof(numbers),
                    $"{NegativesNotAllowedMessage}: {string.Join(NegativeNumberSeparator, negativeItems)}");

            return items.Sum();
        }
    }
}