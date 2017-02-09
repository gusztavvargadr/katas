using System.Linq;

namespace TddKata
{
    public class StringCalculator
    {
        private static readonly char[] Delimiters = {',', '\n'};

        public int Add(string numbers)
        {
            if (numbers == string.Empty)
                return 0;

            return numbers.Split(Delimiters).Select(int.Parse).Sum();
        }
    }
}