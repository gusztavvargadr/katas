using System.Linq;

namespace GusztavVargadDr.Tdd.Katas
{
    public class StringCalculator
    {
        private const int DefaultSum = 0;
        private const char NumberDelimiter = ',';

        public int Add(string numbers)
        {
            if (numbers == string.Empty)
                return DefaultSum;

            return numbers.Split(NumberDelimiter).Sum(int.Parse);
        }
    }
}