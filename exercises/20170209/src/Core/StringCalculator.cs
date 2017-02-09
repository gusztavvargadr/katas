using System.Linq;

namespace TddKata
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (numbers == string.Empty)
                return 0;

            return numbers.Split(',').Select(int.Parse).Sum();
        }
    }
}