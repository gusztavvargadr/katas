using System.Linq;

namespace TddKata
{
    public class StringCalculator
    {
        private const int DefaultSum = 0;
        private const char NumberSeparator = ',';

        public int Add(string numbers)
        {
            if (numbers == string.Empty)
                return DefaultSum;

            return numbers.Split(NumberSeparator).Select(int.Parse).Sum();
        }
    }
}