namespace TddKata
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (numbers == string.Empty)
                return 0;

            if (numbers.Contains(","))
            {
                return int.Parse(numbers[0].ToString()) + int.Parse(numbers[2].ToString());
            }

            return int.Parse(numbers);
        }
    }
}