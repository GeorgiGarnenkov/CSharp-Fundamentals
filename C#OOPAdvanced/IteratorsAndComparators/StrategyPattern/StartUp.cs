using System;
using System.Collections.Generic;

namespace StrategyPattern
{
    public class StartUp
    {
        public static void Main()
        {
            SortedSet<Person> personsNames = new SortedSet<Person>(new PersonNameComparer());
            SortedSet<Person> personsAges = new SortedSet<Person>(new PersonAgeComparer());

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine().Split();

                var name = args[0];
                var age = int.Parse(args[1]);

                Person person = new Person(name, age);

                personsNames.Add(person);
                personsAges.Add(person);
            }

            foreach (Person p in personsNames)
            {
                Console.WriteLine($"{p.Name} {p.Age}");
            }

            foreach (Person p in personsAges)
            {
                Console.WriteLine($"{p.Name} {p.Age}");
            }
        }
    }
}
