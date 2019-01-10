using System;

public class StartUp
{
    public static void Main()
    {
        try
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Chicken chicken = new Chicken(name, age);
            Console.WriteLine($"Chicken {chicken.Name} (age {chicken.Age}) can produce {chicken.ProductPerDay} eggs per day.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}