namespace GusztavVargadDr.Katas.Tdd
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (numbers == string.Empty)
                return 0;

            return int.Parse(numbers);
        }
    }
}