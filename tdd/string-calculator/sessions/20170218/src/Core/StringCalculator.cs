namespace GusztavVargadDr.Katas.Tdd
{
    public class StringCalculator
    {
        private const int DefaultSum = 0;

        public int Add(string numbers)
        {
            if (numbers == string.Empty)
                return DefaultSum;

            return int.Parse(numbers);
        }
    }
}