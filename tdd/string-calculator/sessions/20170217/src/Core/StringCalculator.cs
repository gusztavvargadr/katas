using System.Linq;

namespace GusztavVargadDr.Katas.Tdd
{
    public class StringCalculator
    {
        private const int DefaultSum = 0;
        private const char Delimiter = ',';

        public int Add(string numbers)
        {
            if (numbers == string.Empty)
                return DefaultSum;

            return numbers.Split(Delimiter).Sum(int.Parse);
        }
    }
}