namespace TddKata
{
    public class StringCalculator
    {
        private const char NumberDelimiter = ',';

        public int Add(string numbers)
        {
            if (numbers == string.Empty)
                return 0;

            if (numbers.Length > 1 && numbers[1] == NumberDelimiter)
                return int.Parse(numbers[0].ToString()) + int.Parse(numbers[2].ToString());

            return int.Parse(numbers);
        }
    }
}