using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class StartUp
{
    public static void Main()
    {
        List<Person> allPeople = new List<Person>();
        string searchedPersonParam = Console.ReadLine();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            if (input.Contains("-"))
            {
                var commandArgs = input
                    .Split('-')
                    .Select(x => x.Trim())
                    .ToArray();

                var parentParam = commandArgs[0];
                var childParam = commandArgs[1];

                var parent = new Person();
                if (parentParam.Contains("/"))
                {
                    parent.Birthday = parentParam;
                }
                else
                {
                    parent.Name = parentParam;
                }

                var child = new Person();
                if (childParam.Contains("/"))
                {
                    child.Birthday = childParam;
                }
                else
                {
                    child.Name = childParam;
                }

                AddParentIfMissing(allPeople, parent);

                if (parent.Name != null)
                {
                    allPeople.FirstOrDefault(p => p.Name == parent.Name).AddChild(child);
                }
                else
                {
                    allPeople.FirstOrDefault(p => p.Birthday == parent.Birthday).AddChild(child);
                }
            }
            else
            {
                var tokens = input.Split(' ');
                var name = $"{tokens[0]} {tokens[1]}";
                var date = $"{tokens[2]}";
                var added = false;
                for (int i = 0; i < allPeople.Count; i++)
                {
                    if (allPeople[i].Name == name)
                    {
                        allPeople[i].Birthday = date;
                        added = true;
                    }

                    if (allPeople[i].Birthday == date)
                    {
                        allPeople[i].Name = name;
                        added = true;
                    }

                    allPeople[i].AddChildrenInfo(name, date);
                }

                if (!added)
                {
                    allPeople.Add(new Person(name, date));
                }
            }
        }

        PrintParentsAndChildrens(allPeople, searchedPersonParam);
    }

    private static void PrintParentsAndChildrens(List<Person> allPeople, string searchedPersonParam)
    {
        Person personWithTree;
        if (searchedPersonParam.Contains("/"))
        {
            personWithTree = allPeople.FirstOrDefault(p => p.Birthday == searchedPersonParam);
        }
        else
        {
            personWithTree = allPeople.FirstOrDefault(p => p.Name == searchedPersonParam);
        }

        var result = new StringBuilder();
        result.AppendLine($"{personWithTree.Name} {personWithTree.Birthday}");
        result.AppendLine("Parents:");
        foreach (var parent in allPeople.Where(p => p.FindChildName(personWithTree.Name) != null))
        {
            result.AppendLine($"{parent.Name} {parent.Birthday}");
        }

        result.AppendLine("Children:");

        foreach (var child in allPeople.FirstOrDefault(p => p.Name == personWithTree.Name).Children)
        {
            result.AppendLine($"{child.Name} {child.Birthday}");
        }

        Console.WriteLine(result);
    }

    private static void AddParentIfMissing(List<Person> allPeople, Person parent)
    {
        if (parent.Name != null && allPeople.Any(p => p.Name == parent.Name))
        {
            return;
        }

        if (parent.Birthday != null && allPeople.Any(b => b.Birthday == parent.Birthday))
        {
            return;
        }

        allPeople.Add(parent);
    }
}