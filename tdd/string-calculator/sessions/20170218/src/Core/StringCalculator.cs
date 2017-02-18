using System;
using System.Linq;

namespace GusztavVargadDr.Katas.Tdd
{
    public class StringCalculator
    {
        private const int DefaultSum = 0;

        private const string CustomNumberDelimiterMark = "//";
        private const char CustomNumberDelimiterDelimiter = '\n';

        private const string NegativesNotAllowedMessage = "negatives not allowed";
        private const string NegativeItemDelimiter = ", ";

        private static readonly char[] DefaultNumberDelimiters = {',', '\n'};

        public StringCalculator()
        {
            NumberDelimiters = DefaultNumberDelimiters;
        }

        private char[] NumberDelimiters { get; set; }

        public int Add(string numbers)
        {
            if (numbers == string.Empty)
                return DefaultSum;

            if (numbers.StartsWith(CustomNumberDelimiterMark) && numbers[3] == CustomNumberDelimiterDelimiter)
            {
                NumberDelimiters = new[] {numbers[2]};
                numbers = numbers.Substring(4);
            }

            var items = numbers.Split(NumberDelimiters).Select(int.Parse).ToList();
            var negativeItems = items.Where(item => item < 0).ToList();
            if (negativeItems.Any())
                throw new ArgumentOutOfRangeException(nameof(numbers),
                    $"{NegativesNotAllowedMessage}: {string.Join(NegativeItemDelimiter, negativeItems)}");

            return items.Sum();
        }
    }
}