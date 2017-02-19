using System.Linq;

namespace GusztavVargadDr.Katas.Tdd
{
    public class StringCalculator
    {
        private const int DefaultResult = 0;
        private const char Delimiter = ',';

        public int Add(string numbers)
        {
            if (numbers == string.Empty)
                return DefaultResult;

            if (numbers.Contains(Delimiter))
                return numbers.Split(Delimiter).Sum(int.Parse);

            return int.Parse(numbers);
        }
    }
}