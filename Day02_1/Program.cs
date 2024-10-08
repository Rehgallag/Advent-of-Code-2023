using System.Runtime.CompilerServices;

namespace Day02_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // game ID, red, green, blue cube no
            const int MaxRed = 12;
            const int MaxGreen = 13;
            const int MaxBlue = 14;

            var total = 0;

            while (Console.ReadLine() is { } line)
            {
                var gameInfo = line.Split(':');
                var gameId = int.Parse(gameInfo[0].Split(' ')[1]);
                var rounds = gameInfo[1].Split(';', StringSplitOptions.TrimEntries);
                bool isGameValid = true;
                foreach (var round in rounds)
                {
                    var colourInfos = round.Split(',', StringSplitOptions.TrimEntries);
                    foreach(var colour in colourInfos)
                    {
                        var colourInfo = colour.Split(' ');
                        var colourCount = int.Parse(colourInfo[0]);
                        var colourName = colourInfo[1];
                        switch (colourName) 
                        {
                            case "red":
                                if(colourCount > MaxRed)
                                {
                                    isGameValid = false;
                                }
                                break;
                            case "green":
                                if (colourCount > MaxGreen)
                                {
                                    isGameValid = false;
                                }
                                break;
                            case "blue":
                                if (colourCount > MaxBlue)
                                {
                                    isGameValid = false;
                                }
                                break;

                        }
                    }

                    if (!isGameValid)
                    {
                        break;
                    }
                }
                if (isGameValid) 
                {
                    total += gameId;
                }
            }

            Console.WriteLine(total);
        }
    }
}
