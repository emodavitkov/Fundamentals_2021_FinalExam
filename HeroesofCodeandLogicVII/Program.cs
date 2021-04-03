using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace HeroesofCodeandLogicVII
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> heroes = new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                string[] hero = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string heroCharacter = hero[0];
                int hitPoints = int.Parse(hero[1]);
                int manaPoints = int.Parse(hero[2]);

                heroes.Add(heroCharacter, new Dictionary<string, int>());
                heroes[heroCharacter].Add("HP", hitPoints);
                heroes[heroCharacter].Add("MP", manaPoints);
            }


            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] tokens = input
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                string character = tokens[1];

                switch (command)
                {
                    case "CastSpell":

                        int mpNeeded = int.Parse(tokens[2]);
                        int mpLeft = 0;
                        string spellName = tokens[3];

                        if (heroes[character]["MP"] >= mpNeeded)
                        {
                            mpLeft = heroes[character]["MP"] - mpNeeded;
                            heroes[character]["MP"] -= mpNeeded;
                            Console.WriteLine($"{character} has successfully cast {spellName} and now has {mpLeft} MP!");
                        }
                        else
                        {
                            Console.WriteLine($"{character} does not have enough MP to cast {spellName}!");
                        }
                        break;

                    case "TakeDamage":
                        int damage = int.Parse(tokens[2]);
                        int hpLeft = 0;
                        string attacker = tokens[3];

                        if (heroes[character]["HP"] > damage)
                        {
                            hpLeft = heroes[character]["HP"] - damage;
                            heroes[character]["HP"] -= damage;
                            Console.WriteLine($"{character} was hit for {damage} HP by {attacker} and now has {hpLeft} HP left!");
                        }
                        else
                        {
                            Console.WriteLine($"{character} has been killed by {attacker}!");
                            heroes.Remove(character);
                        }
                        break;

                    case "Recharge":
                        int amountRecharge = int.Parse(tokens[2]);
                        int mpAmount = heroes[character]["MP"] + amountRecharge;
                        int mpAmountMax = 200;
                        if (mpAmount < 200)
                        {
                            heroes[character]["MP"] += amountRecharge;

                        }
                        else
                        {
                            amountRecharge = mpAmountMax - heroes[character]["MP"];
                            heroes[character]["MP"] = mpAmountMax;

                            //Console.WriteLine($"{character} recharged for {mpAmountMax} MP!");
                        }

                        Console.WriteLine($"{character} recharged for {amountRecharge} MP!");
                        break;

                    case "Heal":
                        int amountHeal = int.Parse(tokens[2]);
                        int hpAmount = heroes[character]["HP"] + amountHeal;
                        int hpAmountMax = 100;
                        if (hpAmount < 100)
                        {
                            heroes[character]["HP"] += amountHeal;
                            //Console.WriteLine($"{character} healed for {heroes[character]["MP"]} HP!");
                        }
                        else
                        {
                            amountHeal = hpAmountMax - heroes[character]["HP"];
                            heroes[character]["HP"] = hpAmountMax;

                            //Console.WriteLine($"{character} healed for {hpAmountMax} HP!");
                        }

                        Console.WriteLine($"{character} healed for {amountHeal} HP!");
                        break;


                    default:
                        break;
                }

            }

            heroes = heroes
                .OrderByDescending(x => x.Value["HP"])
                .ThenBy(y => y.Key)
                .ToDictionary(k => k.Key, v => v.Value);


            foreach (var kvp in heroes)
            {

                int hpFinal = kvp.Value["HP"];
                int mpFinal = kvp.Value["MP"];
                //Console.WriteLine($"{kvp.Key} -> HP: {hpFinal}, MP: {mpFinal}");

                Console.WriteLine($"{kvp.Key}");
                Console.WriteLine($"  HP: {hpFinal}");
                Console.WriteLine($"  MP: {mpFinal}");



                //Console.WriteLine($"{piece.Key} -> Composer: {piece.Value[0]}, Key: {piece.Value[1]}");
            }

        }
    }
}

