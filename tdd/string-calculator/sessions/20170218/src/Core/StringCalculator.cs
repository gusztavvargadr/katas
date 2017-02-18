using System.Linq;

namespace GusztavVargadDr.Katas.Tdd
{
    public class StringCalculator
    {
        private const int DefaultSum = 0;

        public int Add(string numbers)
        {
            if (numbers == string.Empty)
                return DefaultSum;

            if (numbers.Contains(','))
                return int.Parse(numbers[0].ToString()) + int.Parse(numbers[2].ToString());

            return int.Parse(numbers);
        }
    }
}