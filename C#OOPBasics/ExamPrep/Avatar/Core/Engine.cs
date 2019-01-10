using System;
using System.Linq;

public class Engine
{
    private readonly NationsBuilder nationsBuilder;

    public Engine()
    {
        this.nationsBuilder = new NationsBuilder();
    }

    public void Run()
    {
        string input;

        while ((input = Console.ReadLine()) != "Quit")
        {
            var commandArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var command = commandArgs[0];

            switch (command)
            {
                case "Bender":
                    nationsBuilder.AssignBender(commandArgs.Skip(1).ToList());
                    break;
                case "Monument":
                    nationsBuilder.AssignMonument(commandArgs.Skip(1).ToList());
                    break;
                case "Status":
                    Console.WriteLine(nationsBuilder.GetStatus(commandArgs[1]));
                    break;
                case "War":
                    nationsBuilder.IssueWar(commandArgs[1]);
                    break;
            }
        }

        Console.WriteLine(nationsBuilder.GetWarsRecord());

    }
}
