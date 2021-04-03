﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int[]> worriors = new Dictionary<string, int[]>(); // value[0] -> health; value[1] -> energy

            string command = Console.ReadLine();
            while (command != "Results")
            {
                string[] tokens = command.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string currCommand = tokens[0];
                string name = tokens[1];

                switch (currCommand)
                {
                    case "Add":
                        int health = int.Parse(tokens[2]);
                        int energy = int.Parse(tokens[3]);

                        if (!worriors.ContainsKey(name))
                        {
                            worriors.Add(name, new int[] { health, energy });
                        }
                        else
                        {
                            worriors[name][0] += health;
                        }
                        break;

                    case "Attack":
                        string attackerName = tokens[1];
                        string defenderName = tokens[2];
                        int damage = int.Parse(tokens[3]);
                        
                        if (worriors.ContainsKey(attackerName) && worriors.ContainsKey(defenderName))
                        {
                            worriors[defenderName][0] -= damage;
                            if (worriors[defenderName][0] <= 0)
                            {
                                worriors.Remove(defenderName);
                                Console.WriteLine($"{defenderName} was disqualified!");
                            }

                            worriors[attackerName][1] -= 1;
                            if (worriors[attackerName][1] == 0)
                            {
                                worriors.Remove(attackerName);
                                Console.WriteLine($"{attackerName} was disqualified!");
                            }
                        }
                        break;

                    case "Delete":
                        if (name == "All")
                        {
                            worriors.Clear();
                        }
                        else
                        {
                            worriors.Remove(name);
                        }
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine();
            }

            worriors = worriors.OrderByDescending(h => h.Value[0]).ThenBy(n => n.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            Console.WriteLine($"People count: {worriors.Count}");
            foreach (var worrior in worriors)
            {
                Console.WriteLine($"{worrior.Key} - {worrior.Value[0]} - {worrior.Value[1]}");
            }
        }

    }
}