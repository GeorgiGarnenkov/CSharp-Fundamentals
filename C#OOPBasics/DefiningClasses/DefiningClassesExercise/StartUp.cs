using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        
        var family = new Family();
        for (int i = 0; i < n; i++)
        {
            var commandArgs = Console.ReadLine().Split();

            var name = commandArgs[0];
            var age = int.Parse(commandArgs[1]);
            
            var person = new Person();
            person.Name = name;
            person.Age = age;
            
            family.AddMember(person);
        }
        var olderThenThirty = family.GetOlderThenThirty();

        foreach (var person in olderThenThirty)
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}
