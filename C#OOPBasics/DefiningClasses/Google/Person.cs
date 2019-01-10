using System;
using System.Collections.Generic;

public class Person
{
    private Company company;
    private Car car;

    public Person(string name)
    {
        Name = name;
        Pokemons = new List<Pokemon>();
        Parentses = new List<Parent>();
        Childrens = new List<Child>();
    }

    public string Name { get; set; }

    public Company Company
    {
        get => company;
        set => company = value;
    }

    public List<Pokemon> Pokemons { get; set; } 

    public List<Parent> Parentses { get; set; }

    public List<Child> Childrens { get; set; }

    public Car Car
    {
        get => car;
        set => car = value;
    }
}