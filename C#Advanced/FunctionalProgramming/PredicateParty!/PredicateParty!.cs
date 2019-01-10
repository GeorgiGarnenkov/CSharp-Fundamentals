using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateParty_
{
    class PredicateParty_
    {

        static void Main()
        {
            List<string> list = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            ExecuteCommands(list);
            PrintCommingList(list);

        }

        private static void PrintCommingList(List<string> comming)
        {
            if (comming.Any())
            {
                var names = string.Join(", ", comming);
                Console.WriteLine($"{names} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static void ExecuteCommands(List<string> comming)
        {
            string input;
            while ((input = Console.ReadLine()) != "Party!")
            {
                var commandArgs = input
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var command = commandArgs[0];
                var parameter = commandArgs[2];

                if (commandArgs.Length < 3)
                {
                    commandArgs = Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }

                switch (commandArgs[1])
                {
                    case "StartsWith":
                        ForeachName(command, comming, n => n.StartsWith(parameter));
                        break;
                    case "EndsWith":
                        ForeachName(command, comming, n => n.EndsWith(parameter));
                        break;
                    case "Length":
                        ForeachName(command, comming, n => n.Length == int.Parse(parameter));
                        break;
                    default:
                        break;
                }
            }
        }

        private static void ForeachName(string command, List<string> comming, Func<string, bool> condition)
        {
            for (int i = comming.Count - 1; i >= 0; i--)
            {
                if (condition(comming[i]))
                {
                    switch (command)
                    {
                        case "Remove":
                            comming.RemoveAt(i);
                            break;
                        case "Double":
                            comming.Add(comming[i]);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
