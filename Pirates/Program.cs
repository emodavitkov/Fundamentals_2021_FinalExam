using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Pirates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string,int>> targetedCities = new Dictionary<string, Dictionary<string,int>>();

            while (true)
            {
                string data = Console.ReadLine();
                if (data=="Sail")
                {
                    break;
                }
                string[] input = data
                    .Split("||", StringSplitOptions.RemoveEmptyEntries);

                string city = input[0];
                int population = int.Parse(input[1]);
                int gold = int.Parse(input[2]);

                if (!targetedCities.ContainsKey(input[0]))
                {
                    

                    //targetedCities.Add(city, new Dictionary<string, int>());
                    //targetedCities[city].Add("population", population);
                    //targetedCities[city].Add("gold", gold);

                    targetedCities.Add(city, new Dictionary<string, int>()
                    {
                        { "population", population },
                        { "gold", gold }
                    
                    });
                    
                }

                else
                {
                    targetedCities[city]["population"] += population;
                    targetedCities[city]["gold"] += gold;
                }

            }

            while (true)
            {

                string tokens = Console.ReadLine();

                if (tokens=="End")
                {
                    break;
                }
                
                string[] token = tokens
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string command = token[0];
                string city = token[1];
                

                switch (command)
                {
                    case "Plunder":
                        //"Plunder=>{town}=>{people}=>{gold}"

                        int population = int.Parse(token[2]);
                        int gold = int.Parse(token[3]);
                        targetedCities[city]["population"] -= population;
                        targetedCities[city]["gold"] -= gold;
                        Console.WriteLine($"{city} plundered! {gold} gold stolen, {population} citizens killed.");

                        if (targetedCities[city]["population"]==0||targetedCities[city]["gold"]==0)
                        {
                            Console.WriteLine($"{city} has been wiped off the map!");
                            targetedCities.Remove(city);
                        }
                        break;

                    case "Prosper":
                        //"Prosper=>{town}=>{gold}"
                        int goldIncrease = int.Parse(token[2]);
                        if (goldIncrease<0)
                        {
                            Console.WriteLine("Gold added cannot be a negative number!");
                            
                            continue;
                        }

                        targetedCities[city]["gold"] += goldIncrease;
                        Console.WriteLine($"{goldIncrease} gold added to the city treasury. {city} now has {targetedCities[city]["gold"]} gold.");
                        //"{gold added} gold added to the city treasury. {town} now has {total gold} gold." 
                        break;

                    default:
                        break; 
                }

            }

            if (targetedCities.Count>0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {targetedCities.Count} wealthy settlements to go to:");

                targetedCities = targetedCities
                    .OrderByDescending(t => t.Value["gold"])
                    .ThenBy(t => t.Key)
                    .ToDictionary(k => k.Key, v=>v.Value);


                foreach (var kvp in targetedCities)
                {
                    int population = kvp.Value["population"];
                    int gold = kvp.Value["gold"];
                        Console.WriteLine($"{kvp.Key} -> Population: {population} citizens, Gold: {gold} kg");
                      
                }
            }

            else
            {
                Console.WriteLine($"Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            



        }
    }
}
