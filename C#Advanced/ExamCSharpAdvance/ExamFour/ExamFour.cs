using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamFour
{
    public class ExamFour
    {
        public static void Main()
        {
            var targetInfoIndex = int.Parse(Console.ReadLine());

            string input;

            List<Person> people = new List<Person>();

            while ((input = Console.ReadLine()) != "end transmissions")
            {
                var commandArgs = input.Split('=');

                var name = commandArgs[0];
                var kvp = commandArgs[1].Split(':', ';');
                
                if (people.All(p => p.Name != name))
                {
                    Person person = new Person();

                    person.Name = name;
                    person.Info = new Dictionary<string, string>();

                    for (int i = 0; i < kvp.Length; i+=2)
                    {
                        var key = kvp[i];
                        var value = kvp[i + 1];
                        if (!person.Info.ContainsKey(key))
                        {
                            person.Info.Add(key, value);
                        }
                        else
                        {
                            person.Info[key] = value;
                        }
                    }

                    people.Add(person);
                }
                else
                {
                    Person person = people.FirstOrDefault(p => p.Name == name);
                    for (int i = 0; i < kvp.Length; i += 2)
                    {
                        var key = kvp[i];
                        var value = kvp[i + 1];

                        if (!person.Info.ContainsKey(key))
                        {
                            person.Info.Add(key, value);
                        }
                        else
                        {
                            person.Info[key] = value;
                        }
                    }
                }
            }

            string[] killCommand = Console.ReadLine().Split();
            string killName = killCommand[1];
            int infoIndex = 0;

            Person killPerson = people.FirstOrDefault(p => p.Name == killName);
            foreach (var key in killPerson.Info.Keys)
            {
                infoIndex += key.Length;
            }

            foreach (var value in killPerson.Info.Values)
            {
                infoIndex += value.Length;
            }

            Console.WriteLine($"Info on {killName}:");
            foreach (var info in killPerson.Info.OrderBy(a => a.Key))
            {
                Console.WriteLine($"---{info.Key}: {info.Value}");
            }

            Console.WriteLine($"Info index: {infoIndex}");

            if (infoIndex >= targetInfoIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {targetInfoIndex - infoIndex} more info.");
            }
        }
    }

    public class Person
    {
        public string Name { get; set; }

        public Dictionary<string, string> Info { get; set; }
    }
}
