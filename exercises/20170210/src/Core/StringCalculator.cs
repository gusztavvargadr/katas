using System.Linq;

namespace GusztavVargadDr.Tdd.Katas
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (numbers == string.Empty)
            {
                return 0;
            }

            var items = numbers.Split(',').Select(int.Parse).ToList();
            return items.Sum();
        }
    }
}