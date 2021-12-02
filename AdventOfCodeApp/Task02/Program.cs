using System;
using System.IO;
using System.Linq;

namespace AdventOfCodeApp.Task02
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var lines = File.ReadAllLines(@"Task02\input.txt")
                .ToList();

            var horizontalResult = 0;
            var verticalResult = 0;

            foreach (var line in lines)
            {
                var tokens = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var command = tokens[0];
                var value = int.Parse(tokens[1]);

                switch (command)
                {
                    case "forward":
                        horizontalResult += value;
                        break;

                    case "down":
                        verticalResult += value;
                        break;

                    case "up":
                        verticalResult -= value;
                        break;
                }
            }

            var result = horizontalResult * verticalResult;

            Console.WriteLine(result);
        }
    }
}
