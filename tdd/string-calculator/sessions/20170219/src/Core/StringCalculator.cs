namespace GusztavVargadDr.Katas.Tdd
{
    public class StringCalculator
    {
        private const int DefaultResult = 0;

        public int Add(string numbers)
        {
            if (numbers == string.Empty)
            {
                return DefaultResult;
            }

            return int.Parse(numbers);
        }
    }
}