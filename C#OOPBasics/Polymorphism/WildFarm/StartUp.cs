using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;

namespace WildFarm
{
    public class StartUp
    {
        public static void Main()
        {
            string input;
            List<Animal> animals = new List<Animal>();
            while ((input = Console.ReadLine()) != "End")
            {
                var commandArgs = input.Split(new []{' '},StringSplitOptions.RemoveEmptyEntries);
                var animalType = commandArgs[0];
                if (commandArgs.Length == 5)
                {
                    animalType = commandArgs[0];
                    var name = commandArgs[1];
                    var weight = double.Parse(commandArgs[2]);
                    var livingRegion = commandArgs[3];
                    var breed = commandArgs[4];

                    switch (animalType)
                    {
                        case "Cat":
                            animals.Add(new Cat(name , weight, livingRegion, breed));
                            break;
                        case "Tiger":
                            animals.Add(new Tiger(name, weight, livingRegion, breed));
                            break;
                    }
                }
                else if (commandArgs.Length == 4 && commandArgs[0] == "Mouse" || commandArgs[0] == "Dog")
                {
                    animalType = commandArgs[0];
                    var name = commandArgs[1];
                    var weight = double.Parse(commandArgs[2]);
                    var livingRegion = commandArgs[3];
                    switch (animalType)
                    {
                        case "Mouse":
                            animals.Add(new Mouse(name, weight, livingRegion));
                            break;
                        case "Dog":
                            animals.Add(new Dog(name, weight, livingRegion));
                            break;
                    }
                }
                else if (commandArgs.Length == 4)
                {
                    animalType = commandArgs[0];
                    var name = commandArgs[1];
                    var weight = double.Parse(commandArgs[2]);
                    var wingSize = double.Parse(commandArgs[3]);

                    switch (animalType)
                    {
                        case "Hen":
                            animals.Add(new Hen(name, weight, wingSize));
                            break;
                        case "Owl":
                            animals.Add(new Owl(name, weight, wingSize));
                            break;
                    }
                }


                var foodInput = Console.ReadLine().Split();

                var foodType = foodInput[0];
                var foodQuantity = int.Parse(foodInput[1]);

                try
                {
                    Console.WriteLine(animals.FindLast(a => a.GetType().Name == animalType).MakeSound());

                    animals.FindLast(a => a.GetType().Name == animalType).FeedTheAnimal(foodType, foodQuantity);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
