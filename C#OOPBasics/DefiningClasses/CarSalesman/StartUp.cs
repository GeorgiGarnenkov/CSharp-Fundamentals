using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        List<Engine> engines = new List<Engine>();

        var engCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < engCount; i++)
        {
            var engineInput = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);

            var model = engineInput[0];

            Engine engine = ParseEngine(engineInput, model);

            engines.Add(engine);
        }

        List<Car> cars = new List<Car>();

        var carCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < carCount; i++)
        {
            var carInput = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var model = carInput[0];

            Car car = ParseCar(carInput, engines, model);

            cars.Add(car);
        }

        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }
    }

    public static Car ParseCar(string[] carInput, List<Engine> engines, string model)
    {
        Car car = new Car(model);

        var engineModel = carInput[1];
        Engine carEngine = null;
        foreach (var en in engines.Where(a => a.Model == engineModel))
        {
            carEngine = en;
        }
        car.Engine = carEngine;


        string weight = "n/a";
        string color = "n/a";
        if (carInput.Length == 2)
        {
            car.Weight = weight;
            car.Color = color;
        }
        else if (carInput.Length == 3)
        {
            if (int.TryParse(carInput[2], out int a))
            {
                car.Weight = carInput[2];
                car.Color = color;
            }
            else
            {
                car.Weight = "n/a";
                car.Color = carInput[2];
            }
        }
        else if (carInput.Length == 4)
        {
            if (int.TryParse(carInput[2], out int a))
            {
                car.Weight = carInput[2];
                car.Color = carInput[3];
            }
            else
            {
                car.Color = carInput[2];
                car.Weight = carInput[3];
            }
        }

        return car;
    }

    public static Engine ParseEngine(string[] engineInput, string model)
    {
        Engine engine = new Engine(model);

        engine.Power = int.Parse(engineInput[1]);

        string displacement = "n/a";
        var efficiency = "n/a";
        if (engineInput.Length == 2)
        {
            engine.Displacement = displacement;
            engine.Efficiency = efficiency;
        }
        else if (engineInput.Length == 3)
        {
            if (int.TryParse(engineInput[2], out int a))
            {
                engine.Displacement = engineInput[2];
                engine.Efficiency = efficiency;
            }
            else
            {
                engine.Displacement = "n/a";
                engine.Efficiency = engineInput[2];
            }


        }
        else if (engineInput.Length == 4)
        {
            if (int.TryParse(engineInput[2], out int a))
            {
                engine.Displacement = engineInput[2];
                engine.Efficiency = engineInput[3];
            }
            else
            {
                engine.Efficiency = engineInput[2];
                engine.Displacement = engineInput[3];
            }
        }

        return engine;
    }
}