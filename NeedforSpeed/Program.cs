using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace NeedforSpeed
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> cars = new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                int milage = int.Parse(input[1]);
                int fuel = int.Parse(input[2]);

                cars.Add(input[0], new Dictionary<string, int>());
                cars[model].Add("milage", milage);
                cars[model].Add("fuel", fuel);
            }

            while (true)
            {
                string token = Console.ReadLine();

                if (token=="Stop")
                {
                    break;
                }

                string[] commands = token
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                string command = commands[0];
                string car = commands[1];

                switch (command)
                {
                    case "Drive":

                        int distance = int.Parse(commands[2]);
                        int fuelNeeded = int.Parse(commands[3]);
                        if (cars[car]["fuel"]<fuelNeeded)
                        {
                            Console.WriteLine($"Not enough fuel to make that ride");
                        }

                        else
                        {
                            cars[car]["milage"] += distance;
                            cars[car]["fuel"] -= fuelNeeded;
                            Console.WriteLine($"{car} driven for {distance} kilometers. {fuelNeeded} liters of fuel consumed.");
                        }

                        if (cars[car]["milage"] >= 100000)
                        {
                            Console.WriteLine($"Time to sell the {car}!");
                            cars.Remove(car);
                        }
                        break;

                    case "Refuel":
                        int reFuel = int.Parse(commands[2]);
                        int fuelMax = 75;
                        int deltaFuel = 0;

                        if ((cars[car]["fuel"] + reFuel) > 75)
                        {
                            deltaFuel = fuelMax - cars[car]["fuel"];
                            Console.WriteLine($"{car} refueled with {deltaFuel} liters");
                            cars[car]["fuel"] = fuelMax;
                        }

                        else
                        {
                            cars[car]["fuel"] += reFuel;
                            Console.WriteLine($"{car} refueled with {reFuel} liters");
                        }
                        
                        break;

                    case "Revert":
                        int kilometersDecreased = int.Parse(commands[2]);
                        cars[car]["milage"] -= kilometersDecreased;

                        Console.WriteLine($"{car} mileage decreased by {kilometersDecreased} kilometers");

                        if (cars[car]["milage"]<10000)
                        {
                            cars[car]["milage"] = 10000;
                        }
                        break;

                    default:
                        break;
                }
            }

            cars = cars
                  .OrderByDescending(x => x.Value["milage"])
                  .ThenBy(y => y.Key)
                  .ToDictionary(k=> k.Key, v => v.Value);

            foreach (var item in cars)
            {
                //"{car} -> Mileage: {mileage} kms, Fuel in the tank: {fuel} lt." 
                int milage = item.Value["milage"];
                int fule = item.Value["fuel"];
               
                Console.WriteLine($"{item.Key} -> Mileage: {milage} kms, Fuel in the tank: {fule} lt.");

            }
        }
    }
}
