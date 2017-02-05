using System.Linq;

namespace TddKata
{
    public class StringCalculator
    {
        private const char NumberDelimiter = ',';

        public int Add(string numbers)
        {
            if (numbers == string.Empty)
                return 0;

            return numbers.Split(NumberDelimiter).Sum(int.Parse);
        }
    }
}