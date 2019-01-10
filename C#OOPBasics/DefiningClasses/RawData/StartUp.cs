using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        List<Car> cars = new List<Car>();
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

        var command = Console.ReadLine();

        switch (command)
        {
            case "fragile":
                var sortedCargoFragile = cars.Where(a => a.Cargo.Type == command).ToList();

                foreach (var car in sortedCargoFragile.Where(a => a.Tiers.Any(b => b.Pressure < 1)))
                {
                    Console.WriteLine(car.Model);
                }
                break;
            case "flamable":
                var sortedCargoFlamable = cars.Where(a => a.Cargo.Type == command).ToList();

                foreach (var car in sortedCargoFlamable.Where(a => a.Engine.Power > 250))
                {
                    Console.WriteLine(car.Model);
                }

                break;

        }

    }
}
