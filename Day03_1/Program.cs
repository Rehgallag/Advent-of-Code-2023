using Tools;

namespace Day03_1
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
            var hasNeigbouringSymbol = false;

            for (var y = 0; y < height; y++)
            {
                void EndCurrentNumber()
                {
                    if (currentNumber != 0 && hasNeigbouringSymbol) 
                    {
                        total += currentNumber;
                    }
                    currentNumber = 0;
                    hasNeigbouringSymbol = false;
                }
                
                for (var x = 0; x < height; x++)
                {
                    var character = map[x, y];
                    // check if reading number
                    if (char.IsDigit(character))
                    {
                        var value = character - '0';
                        currentNumber = currentNumber * 10 + value;
                        foreach(var direction in Directions.WithDiagonals)
                        {
                            var neighbourX = x + direction.X;
                            var neighbourY = y + direction.Y;
                            if(neighbourX < 0 || neighbourX >= width || neighbourY < 0 || neighbourY >= height)
                            {
                                continue;
                            }

                            var neighbourCharacter = map[neighbourX, neighbourY];
                            if(!char.IsDigit(neighbourCharacter) && neighbourCharacter != '.')
                            {
                                hasNeigbouringSymbol = true;
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

            Console.WriteLine(total);
        }
    }
}
