using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class StartUp
{
    public static void Main()
    {
        List<Car> cars = new List<Car>();

        List<Engine> engines = new List<Engine>();

        int engineCount = int.Parse(Console.ReadLine());

        AddEngine(engines, engineCount);

        int carCount = int.Parse(Console.ReadLine());

        AddCar(cars, engines, carCount);

        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }
    }

    private static void AddCar(List<Car> cars, List<Engine> engines, int carCount)
    {
        for (int i = 0; i < carCount; i++)
        {
            string[] parameters = Console.ReadLine()
                .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

            string carModel = parameters[0];

            string engine = parameters[1];

            Engine carEngine = engines.FirstOrDefault(e => e.Model == engine);


            if (parameters.Length == 3)
            {
                string weightOrColor = parameters[2];
                if (IntTryParse(weightOrColor))
                {
                    cars.Add(new Car(carModel, carEngine, weightOrColor));
                }
                else
                {
                    cars.Add(new Car(carModel, carEngine, weightOrColor));
                }
            }
            else if (parameters.Length == 4)
            {
                string weight = parameters[2];
                string color = parameters[3];

                cars.Add(new Car(carModel, carEngine, weight, color));
            }
            else
            {
                cars.Add(new Car(carModel, carEngine));
            }
        }
    }

    private static void AddEngine(List<Engine> engines, int engineCount)
    {
        for (int i = 0; i < engineCount; i++)
        {
            string[] parameters = Console.ReadLine()
                .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

            string engineModel = parameters[0];

            int enginePower = int.Parse(parameters[1]);
            
            if (parameters.Length == 3)
            {
                string displacementOrEfficiency = parameters[2];
                if (IntTryParse(displacementOrEfficiency))
                {
                    engines.Add(new Engine(engineModel, enginePower, displacementOrEfficiency));
                }
                else
                {
                    engines.Add(new Engine(engineModel, enginePower, displacementOrEfficiency));
                }
            }
            else if (parameters.Length == 4)
            {
                var displacement = parameters[2];
                var efficiency = parameters[3];

                engines.Add(new Engine(engineModel, enginePower, displacement, efficiency));
            }
            else
            {
                engines.Add(new Engine(engineModel, enginePower));
            }
        }
    }

    private static bool IntTryParse(string checkString)
    {
        return int.TryParse(checkString, out int dis);
    }
}