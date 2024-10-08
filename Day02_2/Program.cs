namespace Day02_2
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
                var maxRed = 0;
                var maxGreen = 0;
                var maxBlue = 0;
                foreach (var round in rounds)
                {
                    var colourInfos = round.Split(',', StringSplitOptions.TrimEntries);
                    foreach (var colour in colourInfos)
                    {
                        var colourInfo = colour.Split(' ');
                        var colourCount = int.Parse(colourInfo[0]);
                        var colourName = colourInfo[1];
                        switch (colourName)
                        {
                            case "red":
                                maxRed = Math.Max(colourCount, maxRed);
                                break;
                            case "green":
                                maxGreen = Math.Max(colourCount, maxGreen);
                                break;
                            case "blue":
                                maxBlue = Math.Max(colourCount, maxBlue);
                                break;

                        }
                    }
                }
                var product = maxRed * maxGreen * maxBlue;
                total += product;

            }

            Console.WriteLine(total);
        }
    }
}
