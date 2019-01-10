using System;
using System.Collections.Generic;
using System.Dynamic;

public class StartUp
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        List<Car> cars = new List<Car>();
        for (int i = 0; i < n; i++)
        {
            Car car = new Car();

            var inputCar = Console.ReadLine().Split();

            car.Model = inputCar[0];
            car.FuelAmount = double.Parse(inputCar[1]);
            car.FuelConsumptionForOneKm = double.Parse(inputCar[2]);

            cars.Add(car);
        }

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            var commandArgs = input.Split();

            var model = commandArgs[1];
            var amountOfKm = int.Parse(commandArgs[2]);
            
            foreach (var car in cars)
            {
                if (model == car.Model)
                {
                    car.AmountOfKm = amountOfKm;
                    car.UsedFuel = car.AmountOfKm * car.FuelConsumptionForOneKm;
                    
                    car.CanOrCannotMove();
                }
            }
        }

        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.DistanceTraveled}");
        }
    }
}
