using System.Linq;

namespace GusztavVargadDr.Katas.Tdd
{
    public class StringCalculator
    {
        private const int DefaultSum = 0;
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

            if (numbers.StartsWith("//") && numbers[3] == '\n')
            {
                Delimiters = new[] {numbers[2]};
                numbers = numbers.Substring(4);
            }

            return numbers.Split(Delimiters).Sum(int.Parse);
        }
    }
}