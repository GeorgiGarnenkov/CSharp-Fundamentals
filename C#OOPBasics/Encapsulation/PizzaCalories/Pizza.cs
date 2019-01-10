using System;
using System.Collections.Generic;
using System.Linq;

public class Pizza
{
    private string name;
    private Dough dough;
    private List<Topping> toppings;
    private double totalCallories;

    public Pizza()
    {
        this.Toppings = new List<Topping>();
    }

    public Pizza(string name, Dough dough)
        : this()
    {
        this.Name = name;
        this.Dough = dough;
    }
    public string Name
    {
        get => name;
        private set
        {
            if (string.IsNullOrEmpty(value) || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }

            this.name = value;
        }
    }

    public Dough Dough
    {
        get => dough;
        private set => dough = value;
    }

    public List<Topping> Toppings
    {
        get => toppings;
        private set
        {
            if (value.Count < 0 || value.Count > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            this.toppings = value;
        }
    }

    public void AddTopping(Topping topping)
    {
        this.Toppings.Add(topping);
        if (this.Toppings.Count > 10)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }
    }

    public double TotalCallories(Dough dough, List<Topping> toppings)
    {
        var doughCallories = dough.Callories();

        var toppingsCallories = 0.0;
        if (toppings.Count != 0)
        {
            toppingsCallories = toppings.Sum(a => a.Callories());
        }

        return this.totalCallories = doughCallories + toppingsCallories;
    }
}