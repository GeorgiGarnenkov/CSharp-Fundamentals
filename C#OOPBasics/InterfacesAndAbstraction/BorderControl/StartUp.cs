using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        string input;
        List<Society> society = new List<Society>();
        while ((input = Console.ReadLine()) != "End")
        {
            var commandArgs = input.Split();

            if (commandArgs.Length == 3)
            {
                var name = commandArgs[0];
                var age = commandArgs[1];
                var id = commandArgs[2];

                society.Add(new Citizen(name, age, id));
            }
            else if (commandArgs.Length == 2)
            {
                var model = commandArgs[0];
                var id = commandArgs[1];

                society.Add(new Robot(model, id));
            }
        }

        var idChecker = Console.ReadLine();

        foreach (var s in society)
        {
            if (s.Id.EndsWith(idChecker))
            {
                Console.WriteLine(s.Id);
            }
        }
    }
}