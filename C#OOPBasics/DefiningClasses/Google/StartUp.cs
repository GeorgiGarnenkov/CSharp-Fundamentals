using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        string input;
        List<Person> people = new List<Person>();
        while ((input = Console.ReadLine()) != "End")
        {
            var commandArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


            var personName = commandArgs[0];

            if (people.FirstOrDefault(a => a.Name == personName) == null)
            {
                Person person = new Person(personName);

                var command = commandArgs[1];

                CreatePerson(commandArgs, person, command);

                people.Add(person);
            }
            else
            {
                var command = commandArgs[1];

                AddToPerson(commandArgs, command, people, personName);
            }
        }

        var inputName = Console.ReadLine();

        var printPerson = people.Find(a => a.Name == inputName);

        PrintPerson(printPerson);
    }

    public static void PrintPerson(Person printPerson)
    {
        Console.WriteLine($"{printPerson.Name}");

        Console.WriteLine("Company:");
        if (printPerson.Company != null)
        {

            Console.WriteLine($"{printPerson.Company.Name} {printPerson.Company.Department} {printPerson.Company.Salary:f2}");
        }

        Console.WriteLine("Car:");
        if (printPerson.Car != null)
        {
            Console.WriteLine($"{printPerson.Car.Model} {printPerson.Car.Speed}");
        }

        Console.WriteLine("Pokemon:");
        if (printPerson.Pokemons.Count > 0)
        {
            foreach (var poke in printPerson.Pokemons)
            {
                Console.WriteLine($"{poke.Name} {poke.Type}");
            }

        }

        Console.WriteLine("Parents:");
        if (printPerson.Parentses.Count > 0)
        {
            foreach (var par in printPerson.Parentses)
            {
                Console.WriteLine($"{par.Name} {par.Birthday}");
            }
        }

        Console.WriteLine("Children:");
        if (printPerson.Childrens.Count > 0)
        {
            foreach (var child in printPerson.Childrens)
            {
                Console.WriteLine($"{child.Name} {child.Birthday}");
            }
        }
    }

    public static void AddToPerson(string[] commandArgs, string command, List<Person> people, string personName)
    {
        switch (command)
        {
            case "company":
                var companyName = commandArgs[2];
                var companyDepartment = commandArgs[3];
                var companySalary = decimal.Parse(commandArgs[4]);
                people.FirstOrDefault(a => a.Name == personName).Company = new Company(companyName, companyDepartment, companySalary);
                break;
            case "pokemon":
                var pokemonName = commandArgs[2];
                var pokemonType = commandArgs[3];
                people.FirstOrDefault(a => a.Name == personName).Pokemons.Add(new Pokemon(pokemonName, pokemonType));
                break;
            case "parents":
                var parentName = commandArgs[2];
                var parentBirthday = commandArgs[3];
                people.FirstOrDefault(a => a.Name == personName).Parentses.Add(new Parent(parentName, parentBirthday));
                break;
            case "children":
                var childName = commandArgs[2];
                var childBirthday = commandArgs[3];
                people.FirstOrDefault(a => a.Name == personName).Childrens.Add(new Child(childName, childBirthday));
                break;
            case "car":
                var carModel = commandArgs[2];
                var carSpeed = int.Parse(commandArgs[3]);
                people.FirstOrDefault(a => a.Name == personName).Car = new Car(carModel, carSpeed);
                break;
        }
    }

    public static void CreatePerson(string[] commandArgs, Person person, string command)
    {
        switch (command)
        {
            case "company":
                var companyName = commandArgs[2];
                var companyDepartment = commandArgs[3];
                var companySalary = decimal.Parse(commandArgs[4]);
                person.Company = new Company(companyName, companyDepartment, companySalary);
                break;
            case "pokemon":
                var pokemonName = commandArgs[2];
                var pokemonType = commandArgs[3];
                person.Pokemons.Add(new Pokemon(pokemonName, pokemonType));
                break;
            case "parents":
                var parentName = commandArgs[2];
                var parentBirthday = commandArgs[3];
                person.Parentses.Add(new Parent(parentName, parentBirthday));
                break;
            case "children":
                var childName = commandArgs[2];
                var childBirthday = commandArgs[3];
                person.Childrens.Add(new Child(childName, childBirthday));
                break;
            case "car":
                var carModel = commandArgs[2];
                var carSpeed = int.Parse(commandArgs[3]);
                person.Car = new Car(carModel, carSpeed);
                break;
        }
    }
}