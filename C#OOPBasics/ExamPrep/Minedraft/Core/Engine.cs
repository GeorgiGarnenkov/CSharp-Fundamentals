using System;
using System.Linq;

public class Engine
{
    private readonly DraftManager manager;

    public Engine()
    {
        this.manager = new DraftManager();
    }

    public void Run()
    {
        string input;

        while ((input = Console.ReadLine()) != "Shutdown")
        {
            var commandArgs = input.Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
            ExecuteCommand(commandArgs);
        }

        Console.WriteLine(manager.ShutDown());

    }

    private void ExecuteCommand(string[] commandArgs)
    {
        var command = commandArgs[0];

        switch (command)
        {
            case "RegisterHarvester":
                Console.WriteLine(manager.RegisterHarvester(commandArgs.Skip(1).ToList()));
                break;
            case "RegisterProvider":
                Console.WriteLine(manager.RegisterProvider(commandArgs.Skip(1).ToList()));
                break;
            case "Day":
                Console.WriteLine(manager.Day());
                break;
            case "Mode":
                Console.WriteLine(manager.Mode(commandArgs.Skip(1).ToList()));
                break;
            case "Check":
                Console.WriteLine(manager.Check(commandArgs.Skip(1).ToList()));
                break;
            default:
                break;
        }
    }
}