using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        List<Car> cars = new List<Car>();

        AddCars(n, cars);

        var command = Console.ReadLine();

        PrintResult(cars, command);
    }

    private static void AddCars(int n, List<Car> cars)
    {
        for (int i = 0; i < n; i++)
        {
            var commandArgs = Console.ReadLine().Split();

            var model = commandArgs[0];

            var speed = int.Parse(commandArgs[1]);
            var power = int.Parse(commandArgs[2]);
            Engine engine = new Engine(speed, power);

            var weight = int.Parse(commandArgs[3]);
            var type = commandArgs[4];
            Cargo cargo = new Cargo(weight, type);

            List<Tire> tires = new List<Tire>();
            for (int j = 5; j < commandArgs.Length; j += 2)
            {
                var pressure = double.Parse(commandArgs[j]);
                var age = int.Parse(commandArgs[j + 1]);
                Tire tire = new Tire(pressure, age);
                tires.Add(tire);
            }

            Car car = new Car(model, engine, cargo, tires);

            cars.Add(car);
        }
    }

    private static void PrintResult(List<Car> cars, string command)
    {
        switch (command)
        {
            case "fragile":
                var sortedCargoFragile = SortCarsByCargo(cars, command);
                foreach (var car in sortedCargoFragile.Where(a => a.Tiers.Any(b => b.Pressure < 1)))
                {
                    Console.WriteLine(car.Model);
                }
                break;
            case "flamable":
                List<Car> sortedCargoFlamable = SortCarsByCargo(cars, command);
                foreach (var car in sortedCargoFlamable.Where(a => a.Engine.Power > 250))
                {
                    Console.WriteLine(car.Model);
                }
                break;
        }
    }

    private static List<Car> SortCarsByCargo(List<Car> cars, string command)
    {
        return cars.Where(a => a.Cargo.Type == command).ToList();
    }
}