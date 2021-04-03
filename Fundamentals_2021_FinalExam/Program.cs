using System;
using System.Linq;
using System.Collections.Generic;

namespace TheImitationGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            
            
            while (true)
            {

                string command = Console.ReadLine();

                if (command=="Decode")
                {
                    break; 
                }

                string[] tokens = command
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);

                switch (tokens[0])
                {
                    case "Move":
                        int characterCount = int.Parse(tokens[1]);
                        string characters = message.Substring(0, characterCount);
                        message = message.Substring(characterCount) + characters;

                        break;

                    case "Insert":
                        
                            int index = int.Parse(tokens[1]);
                            //index = index - 1 >= 0 ? index - 1 : index;

                            message = message.Insert(index, tokens[2]);
                        
                        break;
                    case "ChangeAll":
                        while (message.Contains(tokens[1]))
                        {
                            message = message.Replace(tokens[1], tokens[2]);
                        }

                        break;

                    default:
                        break;
                }



            }
            Console.WriteLine($"The decrypted message is: {message}");

        }
    }
}
