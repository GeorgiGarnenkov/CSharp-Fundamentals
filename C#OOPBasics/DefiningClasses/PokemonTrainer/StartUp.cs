using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        string input;
        List<Trainer> trainers = new List<Trainer>();

        while ((input = Console.ReadLine()) != "Tournament")
        {
            var playerInput = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            var name = playerInput[0];
            var pokemonName = playerInput[1];
            var pokemonElement = playerInput[2];
            var pokemonHP = int.Parse(playerInput[3]);

            if (trainers.All(a => a.Name != name))
            {
                Trainer trainer = new Trainer();
                Pokemon pokemon = new Pokemon();
                pokemon.Name = pokemonName;
                pokemon.Element = pokemonElement;
                pokemon.Health = pokemonHP;
                trainer.Name = name;
                trainers.Add(trainer);
                trainers.Find(a => a.Name == name).Collection.Add(pokemon);
            }
            else
            {
                Pokemon pokemon = new Pokemon();
                pokemon.Name = pokemonName;
                pokemon.Element = pokemonElement;
                pokemon.Health = pokemonHP;

                trainers.Find(a => a.Name == name).Collection.Add(pokemon);
            }
        }
        
        while ((input = Console.ReadLine()) != "End")
        {
            var elementInput = input;

            switch (elementInput)
            {
                case "Fire":
                    foreach (var trainer in trainers)
                    {
                        trainer.CheckForElement(trainer, elementInput);
                    }
                    break;
                case "Water":
                    foreach (var trainer in trainers)
                    {
                        trainer.CheckForElement(trainer, elementInput);
                    }
                    break;
                case "Electricity":
                    foreach (var trainer in trainers)
                    {
                        trainer.CheckForElement(trainer, elementInput);
                    }
                    break;
            }
        }

        foreach (var trainer in trainers.OrderByDescending(a => a.Badges))
        {
            Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Collection.Count}");
        }
    }
}