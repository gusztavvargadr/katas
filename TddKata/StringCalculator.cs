using System;
using System.Linq;

namespace TddKata
{
    public class StringCalculator
    {
        private const string CustomDelimiterMark = "//";
        private const char CustomDelimiterSeparator = '\n';
        private static readonly char[] DefaultNumberSeparators = {',', '\n'};

        public StringCalculator()
        {
            NumberSeparators = DefaultNumberSeparators;
        }

        public char[] NumberSeparators { get; private set; }

        public int Add(string numbers)
        {
            // ReSharper disable once InvertIf
            if (numbers.StartsWith(CustomDelimiterMark) && numbers[3] == CustomDelimiterSeparator)
            {
                NumberSeparators = new[] {numbers[2]};
                numbers = numbers.Substring(4);
            }

            var allNumbers =
                numbers.Split(NumberSeparators, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var negativeNumbers = allNumbers.Where(item => item < 0).ToList();
            if (negativeNumbers.Any())
            {
                throw new ArgumentException(
                    $"negatives not allowed: {string.Join(", ", negativeNumbers)}");
            }
            return allNumbers.Sum();
        }
    }
}