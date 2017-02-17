using System.Linq;

namespace GusztavVargadDr.Katas.Tdd
{
    public class StringCalculator
    {
        private const int DefaultSum = 0;
        private static readonly char[] Delimiters = {',', '\n'};

        public int Add(string numbers)
        {
            if (numbers == string.Empty)
                return DefaultSum;

            return numbers.Split(Delimiters).Sum(int.Parse);
        }
    }
}