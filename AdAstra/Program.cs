using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdAstra
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\||#)(?<food>[A-Za-z\s]+)\1(?<data>\d{2}\/\d{2}\/\d{2})\1(?<calories>\d{1,4}|10000)\1";

            Regex regex = new Regex(pattern);

            string data = Console.ReadLine();

            var matches = regex.Matches(data);

            int calories = matches
                .Select(m => int.Parse(m.Groups[4].ToString()))
                .Sum();

            Console.WriteLine($"You have food to last you for: {calories/2000} days!");

            foreach (Match match in matches)
            {
                Console.WriteLine($"Item: {match.Groups["food"].Value}, Best before: {match.Groups["data"].Value}, Nutrition: {match.Groups["calories"].Value}");
            }
        }
    }
}
