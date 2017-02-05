using System.Linq;

namespace TddKata
{
    public class StringCalculator
    {
        private static readonly char[] NumberDelimiters = {',', '\n'};

        public int Add(string numbers)
        {
            if (numbers == string.Empty)
                return 0;

            return numbers.Split(NumberDelimiters).Sum(int.Parse);
        }
    }
}