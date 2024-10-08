using Tools;

namespace Day04_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = InputTools.ReadAllLines();
            long total = 0;

            foreach (var line in input) 
            { 
                var cardInfo = line.Split(':');
                var numbers = cardInfo[1].Split('|');
                var gameNumbers = numbers[0]
                    .Split(' ' , StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                    .Select(int.Parse)
                    .ToArray();
                var playerNumbers = numbers[1]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                    .Select(int.Parse)
                    .ToArray();

                var matchCount = gameNumbers.Intersect(playerNumbers).Count();
                if (matchCount == 0)
                {
                    continue;
                }
                total += (1 << (matchCount - 1));
            }

            Console.WriteLine(total);

        }
    }
}
