using Tools;

namespace Day04_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = InputTools.ReadAllLines();
            int[] cardCount = new int[input.Length];
            for (int i = 0; i < input.Length; i++) 
            {
                cardCount[i] = 1;
            }

            for (int cardId = 0; cardId < input.Length; cardId++)
            {
                string? line = input[cardId];
                var cardInfo = line.Split(':');
                var numbers = cardInfo[1].Split('|');
                var gameNumbers = numbers[0]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                    .Select(int.Parse)
                    .ToArray();
                var playerNumbers = numbers[1]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                    .Select(int.Parse)
                    .ToArray();

                var matchCount = gameNumbers.Intersect(playerNumbers).Count();

                for (int i = 0; i < matchCount; i++) 
                {
                    cardCount[cardId + 1 + i] += cardCount[cardId];
                }
            }

            Console.WriteLine(cardCount.Sum());

        }
    }
}
