using System;
using System.IO;
using System.Linq;

namespace AdventOfCodeApp.Task03
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var lines = File.ReadAllLines(@"Task03\input.txt")
                .ToList();

            var measuresCount = lines.Count;

            var firstNumbers = GetLineNumbers(lines.First());
            var numbersCount = firstNumbers.Length;
            
            var currentCounts = new int[numbersCount];

            foreach (var line in lines)
            {
                var numbers = GetLineNumbers(line);

                for (var i = 0; i < numbersCount; i++)
                {
                    currentCounts[i] += numbers[i];
                }
            }

            var gammaRateItems = new int[numbersCount];
            var gammaRate = 0;
            var epsilonRate = 0;

            for (var i = 0; i < numbersCount; i++)
            {
                gammaRateItems[i] = currentCounts[i] > measuresCount / 2 ? 1 : 0;

                var k = (int) Math.Pow(2, i);
                
                if (gammaRateItems[i] == 1)
                {
                    gammaRate += k;
                }
                else
                {
                    epsilonRate += k;
                }
            }

            // var epsilonRate = ~ gammaRate;

            var result = gammaRate * epsilonRate;

            Console.WriteLine(result);
        }

        private static int[] GetLineNumbers(string line)
        {
            var numbers = line.ToCharArray()
                .Select(x => (int) char.GetNumericValue(x))
                .ToArray();

            return numbers;
        }
    }
}
