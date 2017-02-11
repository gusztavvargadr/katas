using System.Linq;

namespace GusztavVargadDr.Tdd.Katas
{
    public class StringCalculator
    {
        private const int DefaultSum = 0;
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

            if (numbers.StartsWith("//") && numbers[3] == '\n')
            {
                NumberDelimiters = new[] {numbers[2]};
                numbers = numbers.Substring(4);
            }

            return numbers.Split(NumberDelimiters).Sum(int.Parse);
        }
    }
}