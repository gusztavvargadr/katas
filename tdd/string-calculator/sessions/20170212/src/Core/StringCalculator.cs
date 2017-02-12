using System.Linq;

namespace GusztavVargadDr.Katas.Tdd
{
    public class StringCalculator
    {
        private const int DefaultResult = 0;
        private const char NumberDelimiter = ',';

        public int Add(string numbers)
        {
            if (numbers == string.Empty)
                return DefaultResult;

            if (numbers.Contains(NumberDelimiter))
                return int.Parse(numbers[0].ToString()) + int.Parse(numbers[2].ToString());

            return int.Parse(numbers);
        }
    }
}