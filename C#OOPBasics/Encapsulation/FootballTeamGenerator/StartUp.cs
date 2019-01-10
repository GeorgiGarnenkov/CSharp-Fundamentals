using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {

        string input;
        List<FootballTeam> teams = new List<FootballTeam>();
        while ((input = Console.ReadLine()) != "END")
        {
            try
            {
                var commandArgs = input.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                var command = commandArgs[0];
                var teamName = commandArgs[1];
                if (command != "Team" && teams.All(t => t.Name != teamName))
                {
                    throw new ArgumentException($"Team {teamName} does not exist.");
                }
                if (command == "Team")
                {
                    FootballTeam team = new FootballTeam(teamName);
                    teams.Add(team);

                }
                else if (command == "Add")
                {

                    AddPlayer(teams, commandArgs, teamName);

                }
                else if (command == "Remove")
                {

                    RemovePlayer(teams, commandArgs, teamName);

                }
                else if (command == "Rating")
                {
                    PrintRating(teams, teamName);
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }

    private static void PrintRating(List<FootballTeam> teams, string teamName)
    {
        if (teams.Any(a => a.Name == teamName))
        {
            var rating = teams.First(t => t.Name == teamName).Rating();
            Console.WriteLine($"{teamName} - {rating}");
        }
        else
        {
            Console.WriteLine($"Team {teamName} does not exist.");
        }
    }

    private static void RemovePlayer(List<FootballTeam> teams, string[] commandArgs, string teamName)
    {
        var playerName = commandArgs[2];
        teams.First(t => t.Name == teamName).RemovePlayer(playerName);
    }

    private static void AddPlayer(List<FootballTeam> teams, string[] commandArgs, string teamName)
    {

        var playerName = commandArgs[2];
        var endurance = int.Parse(commandArgs[3]);
        var sprint = int.Parse(commandArgs[4]);
        var dribble = int.Parse(commandArgs[5]);
        var passing = int.Parse(commandArgs[6]);
        var shooting = int.Parse(commandArgs[7]);
        Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
        if (teams.Any(a => a.Name == teamName))
        {
            teams.First(t => t.Name == teamName).AddPlayer(player);
        }
        else
        {
            Console.WriteLine($"Team {teamName} does not exist.");
        }
    }
}