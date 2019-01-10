using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

public class StartUp
{
    public static void Main()
    {
        List<Animal> animals = new List<Animal>();
        string input;
        while ((input = Console.ReadLine()) != "Beast!")
        {
            try
            {
                var animalType = input;
                var animalProp = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                var animalName = animalProp[0];
                var animalAge = int.Parse(animalProp[1]);
                var animalGender = animalProp[2];

                switch (animalType.ToLower())
                {
                    case "dog":
                        animals.Add(new Dog(animalName, animalAge, animalGender));
                        break;
                    case "frog":
                        animals.Add(new Frog(animalName, animalAge, animalGender));
                        break;
                    case "cat":
                        animals.Add(new Cat(animalName, animalAge, animalGender));
                        break;
                    case "tomcat":
                        animals.Add(new Tomcat(animalName, animalAge, animalGender));
                        break;
                    case "kitten":
                        animals.Add(new Kitten(animalName, animalAge, animalGender));
                        break;
                    default:
                        throw new ArgumentException("Invalid input!");
                        break;
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        foreach (var animal in animals)
        {
            Console.WriteLine(animal.ToString());
        }
    }
}