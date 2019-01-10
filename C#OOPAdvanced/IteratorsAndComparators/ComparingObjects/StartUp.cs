using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class StartUp
    {
        public static void Main()
        {
            List<Person> people = new List<Person>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] args = input.Split();

                string name = args[0];
                int age = int.Parse(args[1]);
                string town = args[2];

                Person person = new Person(name, age, town);
                people.Add(person);
            }

            int index = int.Parse(Console.ReadLine()) - 1;

            int matches = 0;

            Person personForCompare = people[index];

            foreach (Person p in people)
            {
                if (p.CompareTo(personForCompare) == 0)
                {
                    matches++;
                }
            }

            if (matches > 1)
            {
                Console.WriteLine($"{matches} {people.Count - matches} {people.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
