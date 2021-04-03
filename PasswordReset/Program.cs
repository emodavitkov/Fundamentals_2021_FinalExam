using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string password = string.Empty;

            while (true)
            {
                string commands = Console.ReadLine();

                if (commands=="Done")
                {
                    break;
                }

                String[] command = commands
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (command[0])
                {
                    case "TakeOdd":
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < input.Length; i++)
                        {
                            
                            if (i%2!=0)
                            {
                                sb.Append(input[i]);
                                //password += input[i];
                            }
                        }
                        password = sb.ToString();
                        Console.WriteLine(password);
                        break;

                    case "Cut":
                        int idx = int.Parse(command[1]);
                        int lenght = int.Parse(command[2]);

                        password = password.Remove(idx, lenght);
                        Console.WriteLine(password);
                        break;

                    case "Substitute":
                        string match = command[1];
                        string replace = command[2];

                        if (password.Contains(match))
                        {
                            
                            password = password.Replace(match, replace);
                            Console.WriteLine(password);
                        }
                        else
                        {
                            Console.WriteLine("Nothing to replace!");
                        }
                        
                        break;

                    
                }





            }

            Console.WriteLine($"Your password is: {password}");

        }
    }
}
