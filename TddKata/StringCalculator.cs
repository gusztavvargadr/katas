using System;
using System.Linq;

namespace TddKata
{
    public class StringCalculator
    {
        private const char NumberSeparator = ',';

        public int Add(string numbers)
        {
            return numbers.Split(new[] {NumberSeparator}, StringSplitOptions.RemoveEmptyEntries).Sum(int.Parse);
        }
    }
}