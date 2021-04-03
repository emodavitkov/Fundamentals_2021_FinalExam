﻿using System;
using System.Text.RegularExpressions;

namespace SecondTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"!([A-Z][a-z]{2,})!:\[(\D{8,})\]";

            int msgCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < msgCount; i++)
            {
                string message = Console.ReadLine();
                Regex regex = new Regex(pattern);
                Match match = regex.Match(message);

                if (!regex.IsMatch(message))
                {
                    Console.WriteLine("The message is invalid");
                }
                else
                {
                    Console.Write($"{match.Groups[1]}: ");
                    foreach (char symbol in match.Groups[2].Value)
                    {
                        Console.Write($"{(int)symbol} ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}