using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string rawActivationKey = Console.ReadLine();
            string activationKey = rawActivationKey;

            while (true)
            {
                string commands = Console.ReadLine();

                if (commands=="Generate")
                {
                    break;
                }

                string[] command = commands
                    .Split(">>>", StringSplitOptions.RemoveEmptyEntries);

                string instruction = command[0];

                switch (instruction)
                {
                    case "Contains":
                        if (activationKey.Contains(command[1]))
                        {
                            Console.WriteLine($"{activationKey} contains {command[1]}");
                        }

                        else
                        {
                            Console.WriteLine("Substring not found!");
                        }
                        break;

                    case "Flip":

                        int idxLenght = int.Parse(command[3]) - int.Parse(command[2]);
                        string flipPart = activationKey.Substring((int.Parse(command[2])),idxLenght);
                        activationKey = activationKey.Replace(flipPart, "");
                        if (command[1]=="Upper")
                        {
                            activationKey = activationKey.Insert(int.Parse(command[2]), flipPart.ToUpper());
                        }
                        else
                        {
                            activationKey = activationKey.Insert(int.Parse(command[2]), flipPart.ToLower());
                        }

                        Console.WriteLine(activationKey);
                        break;

                    case "Slice":
                        int indCount= int.Parse(command[2])- int.Parse(command[1]);
                        activationKey = activationKey.Remove(int.Parse(command[1]), indCount);
                        Console.WriteLine(activationKey);
                        break;


                    default:
                        break;
                }

            }

            Console.WriteLine($"Your activation key is: {activationKey}");
        }
    }
}
