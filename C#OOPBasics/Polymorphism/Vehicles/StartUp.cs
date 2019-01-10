using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Vehicles
{
    public class StartUp
    {
        public static void Main()
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            var carInput = Console.ReadLine().Split();
            var fuelQuantityC = double.Parse(carInput[1]);
            var fuelConsumptionC = double.Parse(carInput[2]);

            vehicles.Add(new Car(fuelQuantityC, fuelConsumptionC));


            var truckInput = Console.ReadLine().Split();
            var fuelQuantityT = double.Parse(truckInput[1]);
            var fuelConsumptionT = double.Parse(truckInput[2]);

            vehicles.Add(new Truck(fuelQuantityT, fuelConsumptionT));
            
            var numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                var commands = Console.ReadLine().Split();

                var command = commands[0];
                var vehicleType = commands[1];
                var distanceOrFuel = double.Parse(commands[2]);
                try
                {
                    switch (command)
                    {
                        case "Drive":
                            if (vehicleType == "Car")
                            {
                                vehicles[0].Drive(distanceOrFuel);
                            }
                            else if (vehicleType == "Truck")
                            {
                                vehicles[1].Drive(distanceOrFuel);
                            }
                            break;
                        case "Refuel":
                            if (vehicleType == "Car")
                            {
                                vehicles[0].Refuel(distanceOrFuel);
                            }
                            else if (vehicleType == "Truck")
                            {
                                vehicles[1].Refuel(distanceOrFuel);
                            }
                            break;
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle.ToString());
            }
        }
    }
}
