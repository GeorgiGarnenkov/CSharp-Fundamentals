using System;
using System.Collections.Generic;
using System.Linq;

namespace ThePartyReservationFilterModule
{
    class ThePartyReservationFilterModule
    {
        static void Main()
        {
            List<string> list = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<string> result = new List<string>();

            result.AddRange(list);

            result = ExecuteCommands(list, result);

            result.RemoveAll(n => n == ".");

            Console.WriteLine(string.Join(" ", result));
        }

        private static List<string> ExecuteCommands(List<string> comming, List<string> result)
        {
            string input;
            while ((input = Console.ReadLine()) != "Print")
            {
                var commandArgs = input
                    .Split(';');

                var command = commandArgs[0];
                var filter = commandArgs[1];
                var parameter = commandArgs[2];

                if (commandArgs.Length < 3)
                {
                    commandArgs = Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }

                switch (filter)
                {
                    case "Starts with":
                        ForeachName(command, comming, n => n.StartsWith(parameter), result);
                        break;
                    case "Ends with":
                        ForeachName(command, comming, n => n.EndsWith(parameter), result);
                        break;
                    case "Length":
                        ForeachName(command, comming, n => n.Length == int.Parse(parameter), result);
                        break;
                    case "Contains":
                        ForeachName(command, comming, n => n.Contains(parameter), result);
                        break;
                    default:
                        break;
                }
            }

            return result;
        }

        private static void ForeachName(string command, List<string> comming, Func<string, bool> condition, List<string> result)
        {
            for (int i = comming.Count - 1; i >= 0; i--)
            {
                if (condition(comming[i]))
                {
                    switch (command)
                    {
                        case "Add filter":
                            result.RemoveAt(i);
                            result.Insert(i, ".");
                            break;
                        case "Remove filter":
                            result.Add(comming[i]);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
