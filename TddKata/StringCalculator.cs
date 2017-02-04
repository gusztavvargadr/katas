using System;
using System.Linq;

namespace TddKata
{
    public class StringCalculator
    {
        // ReSharper disable once InconsistentNaming
        private readonly char[] NumberSeparators = {',', '\n'};

        public int Add(string numbers)
        {
            return numbers.Split(NumberSeparators, StringSplitOptions.RemoveEmptyEntries).Sum(int.Parse);
        }
    }
}