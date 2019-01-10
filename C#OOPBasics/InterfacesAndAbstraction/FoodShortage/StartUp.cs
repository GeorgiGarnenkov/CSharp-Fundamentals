using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        List<Citizen> citizens = new List<Citizen>();
        var count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            var commandArgs = Console.ReadLine().Split();
            switch (commandArgs.Length)
            {
                case 4:
                    {
                        var name = commandArgs[0];
                        var age = commandArgs[1];
                        var id = commandArgs[2];
                        var birthdate = commandArgs[3];

                        if (citizens.All(a => a.Name != name))
                        {
                            citizens.Add(new Human(name, age, id, birthdate));
                        }


                        break;
                    }
                case 3:
                    {
                        var name = commandArgs[0];
                        var age = commandArgs[1];
                        var group = commandArgs[2];

                        if (citizens.All(a => a.Name != name))
                        {
                            citizens.Add(new Rebel(name, age, @group));
                        }

                        break;
                    }
            }
        }

        string input;

        while ((input = Console.ReadLine()) != "End")
        {
            var name = input;
            if (citizens.Any(a => a.Name == name))
            {
                var citizen = citizens.Find(a => a.Name == name);
                citizen.BuyFood();
            }
            
        }

        int allFood = 0;
        foreach (var citizen in citizens)
        {
            allFood += citizen.Food;
        }
        Console.WriteLine(allFood);
    }
}