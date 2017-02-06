using System.Linq;

namespace TddKata
{
    public class StringCalculator
    {
        private const int DefaultSum = 0;
        private static readonly char[] DefaultNumberSeparators = {',', '\n'};

        public StringCalculator()
        {
            NumberSeparators = DefaultNumberSeparators;
        }

        private char[] NumberSeparators { get; set; }

        public int Add(string numbers)
        {
            if (numbers == string.Empty)
                return DefaultSum;

            if (numbers.StartsWith("//") && numbers[3] == '\n')
            {
                NumberSeparators = new[] {numbers[2]};
                numbers = numbers.Substring(4);
            }

            return numbers.Split(NumberSeparators).Select(int.Parse).Sum();
        }
    }
}