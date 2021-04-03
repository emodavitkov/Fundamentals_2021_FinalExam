﻿using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "Done")
            {
                string[] splitCommand = command.Split();
                string currCommand = splitCommand[0];

                switch (currCommand)
                {
                    case "Change":
                        char currentChar = splitCommand[1][0];
                        char replacement = splitCommand[2][0];
                        line = line.Replace(currentChar, replacement);
                        Console.WriteLine(line);
                        break;

                    case "Includes":
                        Console.WriteLine(line.Contains(splitCommand[1]));
                        break;

                    case "End":
                        string endString = splitCommand[1];
                        Console.WriteLine(line.EndsWith(endString));
                        break;

                    case "Uppercase":
                        line = line.ToUpper();
                        Console.WriteLine(line);
                        break;

                    case "FindIndex":
                        currentChar = splitCommand[1][0];
                        Console.WriteLine(line.IndexOf(currentChar));
                        break;

                    case "Cut":
                        int startIndex = int.Parse(splitCommand[1]);
                        int length = int.Parse(splitCommand[2]);
                        line = line.Substring(startIndex, length);
                        Console.WriteLine(line);
                        break;
                }

                command = Console.ReadLine();
            }
        }

    }
}
