using Tools;

namespace Day03_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = InputTools.ReadAllLines();

            var width = input[0].Length;
            var height = input.Length;

            var map = new char[width, height];

            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    map[x, y] = input[y][x];
                }
            }

            var total = 0;
            var currentNumber = 0;
            var asterisks = new Dictionary<Point, List<int>>();
            var neighbouringAsterisks = new HashSet<Point>();

            for (var y = 0; y < height; y++)
            {
                void EndCurrentNumber()
                {
                    if (currentNumber != 0 && neighbouringAsterisks.Count > 0)
                    {
                        foreach (var neighbouringAsterisk in neighbouringAsterisks) 
                        {
                            var x = neighbouringAsterisk.X;
                            var y = neighbouringAsterisk.Y;
                            if (!asterisks.ContainsKey((x, y)))
                            {
                                asterisks[(x, y)] = [];
                            }
                            asterisks[(x, y)].Add(currentNumber);
                        }
                        
                    }
                    currentNumber = 0;
                    neighbouringAsterisks.Clear();
                }

                for (var x = 0; x < height; x++)
                {
                    var character = map[x, y];
                    // check if reading number
                    if (char.IsDigit(character))
                    {
                        var value = character - '0';
                        currentNumber = currentNumber * 10 + value;
                        foreach (var direction in Directions.WithDiagonals)
                        {
                            var neighbourX = x + direction.X;
                            var neighbourY = y + direction.Y;
                            if (neighbourX < 0 || neighbourX >= width || neighbourY < 0 || neighbourY >= height)
                            {
                                continue;
                            }

                            var neighbourCharacter = map[neighbourX, neighbourY];
                            if (neighbourCharacter == '*')
                            {
                                neighbouringAsterisks.Add((neighbourX, neighbourY));
                            }
                        }
                    }
                    else
                    {
                        EndCurrentNumber();
                    }
                }

                EndCurrentNumber();
            }

            foreach(var (point, numbers) in asterisks)
            {
                if(numbers.Count == 2)
                {
                    total += numbers[0] * numbers[1];
                }
                
            }

            Console.WriteLine(total);
        }
    }
}
