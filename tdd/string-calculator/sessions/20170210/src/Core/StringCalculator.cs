using System;
using System.Linq;

namespace GusztavVargadDr.Tdd.Katas
{
    public class StringCalculator
    {
        private const int DefaultSum = 0;
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
                return DefaultSum;

            if (numbers.StartsWith(CustomDelimiterMark) && numbers[3] == CustomDelimiterDelimiter)
            {
                Delimiters = new[] {numbers[2]};
                numbers = numbers.Substring(4);
            }

            var items = numbers.Split(Delimiters).Select(int.Parse).ToList();
            var negativeItems = items.Where(item => item < 0).ToList();
            if (negativeItems.Any())
                throw new ArgumentOutOfRangeException(nameof(numbers));

            return items.Sum();
        }
    }
}