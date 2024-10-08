using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        long total = 0;
        while(Console.ReadLine() is { } line)
        {
            int firstDigit = line.First(line => char.IsDigit(line)) - '0';
            int lastDigit = line.Last(line => char.IsDigit(line)) - '0';

            var fullNumber = firstDigit * 10 + lastDigit;
            total += fullNumber;
        }

        Console.WriteLine(total);
    } 
}
