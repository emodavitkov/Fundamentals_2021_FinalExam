using System;
using System.Linq;
using System.Collections.Generic;

namespace ThePianist
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, string[]> pieces = new Dictionary<string, string[]>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine()
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);

                pieces.Add(data[0], new string[] {data[1], data[2]});
            }

            string command = string.Empty;

            while ((command=Console.ReadLine())!= "Stop")
            {
                string[] token = command.Split("|",StringSplitOptions.RemoveEmptyEntries);


                switch (token[0])
                {
                    case "Add":
                        if (pieces.ContainsKey(token[1]))
                        {
                            Console.WriteLine($"{token[1]} is already in the collection!");
                        }
                        else
                        {
                            pieces.Add(token[1], new string[] { token[2], token[3] });
                            Console.WriteLine($"{token[1]} by {token[2]} in {token[3]} added to the collection!");
                        }
                        break;

                    case "Remove":
                        if (pieces.ContainsKey(token[1]))
                        {
                            pieces.Remove(token[1]);
                            Console.WriteLine($"Successfully removed {token[1]}!");
                        }

                        else
                        {
                            Console.WriteLine($"Invalid operation! {token[1]} does not exist in the collection.");
                        }
                        break;

                    case "ChangeKey":
                        if (pieces.ContainsKey(token[1]))
                        {
                            pieces[token[1]][1] = token[2];
                            Console.WriteLine($"Changed the key of {token[1]} to {token[2]}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {token[1]} does not exist in the collection.");
                        }
                        break;


                    default:
                        break;
                }
            }

            pieces = pieces
                .OrderBy(p => p.Key)
                .ThenBy(p => p.Value[0])
                .ToDictionary(k=> k.Key, v=> v.Value);

            foreach (var piece in pieces)
            {
                Console.WriteLine($"{piece.Key} -> Composer: {piece.Value[0]}, Key: {piece.Value[1]}");
            }
        }
    }
}
