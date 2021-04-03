using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PlantDiscovery
{
    class Program
    {
        static void Main(string[] args)
        {
          

            Dictionary<string, List<double>> plantsInfo = new Dictionary<string, List<double>>();
            
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] plants = Console.ReadLine()
                    .Split("<->", StringSplitOptions.RemoveEmptyEntries);

                string plant = plants[0];
                double rarity = double.Parse(plants[1]);

                if (plantsInfo.ContainsKey(plant))
                {

                    plantsInfo[plant][0] += rarity;

                }
                else
                {
                    plantsInfo.Add(plant, new List<double>());
                    plantsInfo[plant].Add(rarity);
                   
                }
               
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Exhibition")
                {
                    break;
                }

                string[] commands = input
                    .Split(new char[] { '-', ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);

                string command = commands[0];
                string plantCommand = commands[1];

                if (!plantsInfo.ContainsKey(plantCommand))
                {
                    Console.WriteLine("error");
                    continue;
                }

                switch (command)
                {
                    case "Rate":
                        //•	Rate: { plant} - { rating} – add the given rating to the plant(store all ratings)
                        double rating = double.Parse(commands[2]);
                        plantsInfo[plantCommand].Add(rating);

                        break;

                    case "Update":
                        //• Update: { plant} - { new_rarity} – update the rarity of the plant with the new one
                        double rarityNew = double.Parse(commands[2]);
                        plantsInfo[plantCommand][0]=rarityNew;
                        break;

                    case "Reset":
                        //•	Reset: { plant} – remove all the ratings of the given plant
                        
                        plantsInfo[plantCommand].RemoveRange(1,plantsInfo[plantCommand].Count-1);

                        break;

                    default:
                        Console.WriteLine("error");
                        break;
                }

            }


            foreach (var item in plantsInfo)
            {
                double rarity = item.Value[0];
                item.Value.RemoveAt(0);
                int count = item.Value.Count;
                double sum = item.Value.Sum();

                if (sum!=0)
                {
                    sum /= count;
                }

                item.Value.Clear();
                item.Value.Add(rarity);
                item.Value.Add(sum);
            }

            Console.WriteLine("Plants for the exhibition:");
            
            foreach (var item in plantsInfo.OrderByDescending(x => x.Value[0]).ThenByDescending(x => x.Value[1]).ToDictionary(x => x.Key, x => x.Value))
            {
                Console.WriteLine($"- {item.Key}; Rarity: {(int)item.Value[0]}; Rating: {item.Value[1]:f2}");
            }
        }
    }
}

