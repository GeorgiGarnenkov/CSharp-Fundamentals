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

            if (commandArgs.Length == 5 && commandArgs[0] == "Citizen")
            {
                var name = commandArgs[1];
                var age = commandArgs[2];
                var id = commandArgs[3];
                var birthdate = commandArgs[4];

                society.Add(new Citizen(name, age, id, birthdate));
            }
            else if (commandArgs.Length == 3 && commandArgs[0] == "Pet")
            {
                var name = commandArgs[1];
                var birthdate = commandArgs[2];

                society.Add(new Pet(name, birthdate));
            }

        }

        var birthdateChecker = Console.ReadLine();

        foreach (var s in society)
        {
            if (s.Birthdate.EndsWith(birthdateChecker))
            {
                Console.WriteLine(s.Birthdate);
            }
        }
    }
}