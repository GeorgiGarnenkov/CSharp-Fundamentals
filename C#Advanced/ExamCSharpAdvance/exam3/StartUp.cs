using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace exam3
{
    public class StartUp
    {
        public static void Main()
        {
            var location = Console.ReadLine();

            var block = Console.ReadLine();

            Regex rgx = new Regex(@"((?:(?<bracket>\{)|\[)(?<symbols>.*?)(?:(?<bracketInside>\{)|\[)(?<cityCode>[A-Z]{3} [A-Z]{2})(?(bracketInside)\}|\])(?(symbols).*?)(?(bracketInside)\{|\[)(?<seatNumber>[A-Z]{1}\d{1,2})(?(bracketInside)\}|\])(?(symbols).*?)(?(bracket)\}|\]))");

            List<string> tickets = new List<string>();

            foreach (Match match in rgx.Matches(block))
            {
                string bracket = match.Groups["bracket"].Value;
                string bracketInside = match.Groups["bracketInside"].Value;

                if (bracketInside == bracket)
                {
                    continue;
                }

                var cityCode = match.Groups["cityCode"].Value;

                if (cityCode != location)
                {
                    continue;
                }

                var seatNumber = match.Groups["seatNumber"].Value;
                
                tickets.Add(seatNumber);
            }

            string ticketOne = string.Empty;
            string ticketTwo = string.Empty;

            var ticketslist = tickets.OrderBy(a => a.Remove(0, 1)).ToList();

            if (ticketslist.Count > 2)
            {
                while (ticketOne == String.Empty && ticketTwo == String.Empty)
                {
                    for (int i = 0; i < ticketslist.Count - 1; i++)
                    {
                        var first = ticketslist[i].Substring(1, ticketslist[i].Length - 1);
                        var second = ticketslist[i + 1].Substring(1, ticketslist[i + 1].Length - 1);

                        if (first != second)
                        {
                            continue;
                        }

                        if (first == second)
                        {
                            ticketOne = ticketslist[i];
                            ticketTwo = ticketslist[i + 1];
                            break;
                        }
                    }
                }
            }
            else if(tickets.Count == 2)
            {
                ticketOne = tickets[0];
                ticketTwo = tickets[1];
            }

            Console.WriteLine($"You are traveling to {location} on seats {ticketOne} and {ticketTwo}.");
        }
    }
}
