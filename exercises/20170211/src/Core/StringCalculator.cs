﻿namespace GusztavVargadDr.Tdd.Katas
{
    public class StringCalculator
    {
        private const int DefaultSum = 0;
        private const string NumberDelimiter = ",";

        public int Add(string numbers)
        {
            if (numbers == string.Empty)
                return DefaultSum;

            if (numbers.Contains(NumberDelimiter))
                return int.Parse(numbers[0].ToString()) + int.Parse(numbers[2].ToString());

            return int.Parse(numbers);
        }
    }
}