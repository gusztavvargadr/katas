using System.Linq;

namespace GusztavVargadDr.Katas.Tdd
{
    public class StringCalculator
    {
        private const int DefaultResult = 0;

        private static readonly char[] Delimiters = {',', '\n'};


        public int Add(string numbers)
        {
            if (numbers == string.Empty)
                return DefaultResult;

            return numbers.Split(Delimiters).Sum(int.Parse);
        }
    }
}