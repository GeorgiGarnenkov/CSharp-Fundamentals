using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        try
        {
            var pizzaInput = Console.ReadLine().Split();
            var pizzaName = pizzaInput[1];

            var doughInput = Console.ReadLine().Split();
            var doughType = doughInput[1];
            var doughBaking = doughInput[2];
            var doughWeight = double.Parse(doughInput[3]);

            Dough dough = new Dough(doughType, doughBaking, doughWeight);

            Pizza pizza = new Pizza(pizzaName, dough);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var toppingArgs = input.Split();

                var toppingType = toppingArgs[1];
                var toppingWeight = double.Parse(toppingArgs[2]);

                Topping topping = new Topping(toppingType, toppingWeight);
                
                pizza.AddTopping(topping);
            }

            Console.WriteLine($"{pizza.Name} - {pizza.TotalCallories(pizza.Dough, pizza.Toppings):f2} Calories.");

        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}